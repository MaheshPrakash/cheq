﻿using Dev2.Studio.Core;
using Dev2.Studio.Interfaces.DataList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;
using Dev2.Common.Interfaces.DB;
using ActivityUnitTests;
using Dev2.Activities.Specs.BaseTypes;
using System;
using System.Xml.Linq;
using Dev2.Studio.ViewModels.DataList;
using Dev2.Studio.Core.Models;
using Dev2.Data.Util;
using Dev2.Studio.Core.Models.DataList;
using Dev2.Studio.Interfaces;
using Dev2.Services;
using Dev2.Messages;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using System.Threading;
using WarewolfParserInterop;
using Dev2.Common;
using Dev2.Session;
using Dev2.Studio.Core.Network;
using Dev2.Threading;
using System.Activities.Statements;
using Dev2.Utilities;

namespace Warewolf.Tools.Specs.Toolbox.Database
{
    [Binding]
    public class DatabaseToolsSteps : BaseActivityUnitTest
    {
        readonly ScenarioContext _scenarioContext;
        SubscriptionService<DebugWriterWriteMessage> _debugWriterSubscriptionService;
        readonly AutoResetEvent _resetEvt = new AutoResetEvent(false);
        const int EnvironmentConnectionTimeout = 15;

        public DatabaseToolsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
            _commonSteps = new CommonSteps(_scenarioContext);
        }
        readonly CommonSteps _commonSteps;

        [BeforeScenario("@OpeningSavedWorkflowWithPostgresServerTool", "@ChangeTheSourceOnExistingPostgresql", "@ChangeTheActionOnExistingPostgresql", "@ChangeTheRecordsetOnExistingPostgresqlTool", "@ChangingSqlServerFunctions", "@CreatingOracleToolInstance", "@ChangingOracleActions")]
        public void InitChangingFunction()
        {
            var mock = new Mock<IDataListViewModel>();
            mock.Setup(model => model.ScalarCollection).Returns(new ObservableCollection<IScalarItemModel>());
            if (DataListSingleton.ActiveDataList == null)
            {
                DataListSingleton.SetDataList(mock.Object);
            }
        }

        public static void AssertAgainstServiceInputs(Table table, ICollection<IServiceInput> inputs)
        {
            var rowNum = 0;
            foreach (var row in table.Rows)
            {
                var inputValue = row["Input"];
                var value = row["Value"];
                var serviceInputs = inputs.ToList();
                var serviceInput = serviceInputs[rowNum];
                Assert.AreEqual(inputValue, serviceInput.Name);
                Assert.AreEqual(value, serviceInput.Value);
                rowNum++;
            }
        }
        public IContextualResourceModel SaveAWorkflow(string workflowName)
        {
            Get<List<IDebugState>>("debugStates").Clear();
            BuildShapeAndTestData();

            var activityList = _commonSteps.GetActivityList();

            var flowSteps = new List<FlowStep>();

            TestStartNode = new FlowStep();
            flowSteps.Add(TestStartNode);
            if (activityList != null)
            {
                foreach (var activity in activityList)
                {
                    if (TestStartNode.Action == null)
                    {
                        TestStartNode.Action = activity.Value;
                    }
                    else
                    {
                        var flowStep = new FlowStep { Action = activity.Value };
                        flowSteps.Last().Next = flowStep;
                        flowSteps.Add(flowStep);
                    }
                }
            }
            TryGetValue("resourceModel", out IContextualResourceModel resourceModel);
            TryGetValue("server", out IServer server);
            TryGetValue("resourceRepo", out IResourceRepository repository);

            var currentDl = CurrentDl;
            resourceModel.DataList = currentDl.Replace("root", "DataList");
            var helper = new WorkflowHelper();
            var xamlDefinition = helper.GetXamlDefinition(FlowchartActivityBuilder);
            resourceModel.WorkflowXaml = xamlDefinition;
            repository.Save(resourceModel);
            repository.SaveToServer(resourceModel);

            return resourceModel;
        }
        public void ExecuteWorkflow(IContextualResourceModel resourceModel)
        {
            if (resourceModel?.Environment == null)
            {
                return;
            }

            var debugTo = new DebugTO { XmlData = "<DataList></DataList>", SessionID = Guid.NewGuid(), IsDebugMode = true };
            EnsureEnvironmentConnected(resourceModel.Environment, EnvironmentConnectionTimeout);
            var clientContext = resourceModel.Environment.Connection;
            if (clientContext != null)
            {
                var dataList = XElement.Parse(debugTo.XmlData);
                dataList.Add(new XElement("BDSDebugMode", debugTo.IsDebugMode));
                dataList.Add(new XElement("DebugSessionID", debugTo.SessionID));
                dataList.Add(new XElement("EnvironmentID", resourceModel.Environment.EnvironmentID));
                WebServer.Send(resourceModel, dataList.ToString(), new SynchronousAsyncWorker());
                _resetEvt.WaitOne(3000);
            }
        }

        void EnsureEnvironmentConnected(IServer server, int timeout)
        {
            if (timeout <= 0)
            {
                _scenarioContext.Add("ConnectTimeoutCountdown", timeout);
                throw new TimeoutException("Connection to Warewolf server \"" + server.Name + "\" timed out.");
            }

            if (!server.IsConnected && !server.Connection.IsConnected)
            {
                server.Connect();
            }

            if (!server.IsConnected && !server.Connection.IsConnected)
            {
                Thread.Sleep(GlobalConstants.NetworkTimeOut);
                timeout--;
                EnsureEnvironmentConnected(server, timeout);
            }
        }
        public void DebugWriterSubscribe(IServer environmentModel)
        {
            _debugWriterSubscriptionService = new SubscriptionService<DebugWriterWriteMessage>(environmentModel.Connection.ServerEvents);
            _debugWriterSubscriptionService.Subscribe(msg => Append(msg.DebugState));
        }
        void Append(IDebugState debugState)
        {
            TryGetValue("debugStates", out List<IDebugState> debugStates);
            TryGetValue("debugStatesDuration", out List<IDebugState> debugStatesDuration);
            TryGetValue("parentName", out string workflowName);
            TryGetValue("server", out IServer server);
            if (debugStatesDuration == null)
            {
                debugStatesDuration = new List<IDebugState>();
                Add("debugStatesDuration", debugStatesDuration);
            }
            if (debugState.WorkspaceID == server.Connection.WorkspaceID)
            {
                if (debugState.StateType != StateType.Duration)
                {
                    debugStates.Add(debugState);
                }
                else
                {
                    debugStatesDuration.Add(debugState);
                }
            }
            if (debugState.IsFinalStep() && debugState.DisplayName.Equals(workflowName))
            {
                _resetEvt.Set();
            }
        }
        void Add(string key, object value) => _scenarioContext.Add(key, value);

        public T Get<T>(string keyName)
        {
            return _scenarioContext.Get<T>(keyName);
        }
        public void TryGetValue<T>(string keyName, out T value)
        {
            _scenarioContext.TryGetValue(keyName, out value);
        }

        protected void BuildShapeAndTestData()
        {
            var shape = new XElement("root");
            var data = new XElement("root");
            var dataListViewModel = new DataListViewModel();
            dataListViewModel.InitializeDataListViewModel(new ResourceModel(null));
            DataListSingleton.SetDataList(dataListViewModel);

            var row = 0;
            _scenarioContext.TryGetValue("variableList", out dynamic variableList);
            if (variableList != null)
            {
                try
                {
                    foreach (dynamic variable in variableList)
                    {
                        var variableName = DataListUtil.AddBracketsToValueIfNotExist(variable.Item1);
                        if (!string.IsNullOrEmpty(variable.Item1) && !string.IsNullOrEmpty(variable.Item2))
                        {
                            string value = variable.Item2 == "blank" ? "" : variable.Item2;
                            if (value.ToUpper() == "NULL")
                            {
                                DataObject.Environment.AssignDataShape(variable.Item1);
                            }
                            else
                            {
                                DataObject.Environment.Assign(variableName, value, 0);
                            }
                        }
                        if (DataListUtil.IsValueScalar(variableName))
                        {
                            var scalarName = DataListUtil.RemoveLanguageBrackets(variableName);
                            var scalarItemModel = new ScalarItemModel(scalarName);
                            if (!scalarItemModel.HasError)
                            {
                                DataListSingleton.ActiveDataList.Add(scalarItemModel);
                            }
                        }
                        if (DataListUtil.IsValueRecordsetWithFields(variableName))
                        {
                            var rsName = DataListUtil.ExtractRecordsetNameFromValue(variableName);
                            var fieldName = DataListUtil.ExtractFieldNameOnlyFromValue(variableName);
                            var rs = DataListSingleton.ActiveDataList.RecsetCollection.FirstOrDefault(model => model.Name == rsName);
                            if (rs == null)
                            {
                                var recordSetItemModel = new RecordSetItemModel(rsName);
                                DataListSingleton.ActiveDataList.Add(recordSetItemModel);
                                recordSetItemModel.Children.Add(new RecordSetFieldItemModel(fieldName,
                                    recordSetItemModel));
                            }
                            else
                            {
                                var recordSetFieldItemModel = rs.Children.FirstOrDefault(model => model.Name == fieldName);
                                if (recordSetFieldItemModel == null)
                                {
                                    rs.Children.Add(new RecordSetFieldItemModel(fieldName, rs));
                                }
                            }
                        }
                        //Build(variable, shape, data, row);
                        row++;
                    }
                    DataListSingleton.ActiveDataList.WriteToResourceModel();
                }

                catch

                {

                }
            }

            var isAdded = _scenarioContext.TryGetValue("rs", out List<Tuple<string, string>> emptyRecordset);
            if (isAdded)
            {
                foreach (Tuple<string, string> emptyRecord in emptyRecordset)
                {
                    DataObject.Environment.Assign(DataListUtil.AddBracketsToValueIfNotExist(emptyRecord.Item1), emptyRecord.Item2, 0);
                }
            }

            _scenarioContext.TryGetValue("objList", out dynamic objList);
            if (objList != null)
            {
                try
                {
                    foreach (dynamic variable in objList)
                    {
                        if (!string.IsNullOrEmpty(variable.Item1) && !string.IsNullOrEmpty(variable.Item2))
                        {
                            string value = variable.Item2 == "blank" ? "" : variable.Item2;
                            if (value.ToUpper() == "NULL")
                            {
                                DataObject.Environment.AssignDataShape(variable.Item1);
                            }
                            else
                            {
                                DataObject.Environment.AssignJson(new AssignValue(DataListUtil.AddBracketsToValueIfNotExist(variable.Item1), value), 0);
                            }
                        }
                    }
                }

                catch

                {

                }
            }

            CurrentDl = shape.ToString();
            TestData = data.ToString();
        }
    }
}
