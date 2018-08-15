﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.UIBindingTests.RabbitMqSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RabbitMqSourceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "RabbitMq Source.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RabbitMq Source", "\tIn order to share settings\r\n\tI want to save my RabbitMq source Settings\r\n\tSo tha" +
                    "t I can reuse them", ProgrammingLanguage.CSharp, new string[] {
                        "RabbitMqSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll",
                        "MSTest:DeploymentItem:InfragisticsWPF4.DataPresenter.v15.1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll",
                        "MSTest:DeploymentItem:Warewolf.Studio.Themes.Luna.dll"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "RabbitMq Source")))
            {
                global::Warewolf.UIBindingTests.RabbitMqSource.RabbitMqSourceFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create New RabbitMq source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RabbitMq Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RabbitMqSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.DataPresenter.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf_Studio.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Newtonsoft.Json.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Microsoft.Practices.Prism.SharedInterfaces.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("System.Windows.Interactivity.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf.Studio.Themes.Luna.dll")]
        public virtual void CreateNewRabbitMqSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create New RabbitMq source", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("the title is \"New RabbitMQ Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("\"Host\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("\"User Name\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("\"Password\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("\"Virtual Host\" input is \"/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("\"Test Connection\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Enable Send and Enable Save")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RabbitMq Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RabbitMqSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.DataPresenter.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf_Studio.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Newtonsoft.Json.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Microsoft.Practices.Prism.SharedInterfaces.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("System.Windows.Interactivity.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf.Studio.Themes.Luna.dll")]
        public virtual void EnableSendAndEnableSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enable Send and Enable Save", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("I type Host as \"test-rabbitmq\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I type Password as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I click \"Test Connection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.And("Send is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("I save as \"TestRabbitMq\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.And("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Fail Send Shows correct error message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RabbitMq Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RabbitMqSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.Controls.Grids.XamGrid.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("InfragisticsWPF4.DataPresenter.v15.1.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf_Studio.exe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Newtonsoft.Json.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Microsoft.Practices.Prism.SharedInterfaces.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("System.Windows.Interactivity.dll")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItemAttribute("Warewolf.Studio.Themes.Luna.dll")]
        public virtual void FailSendShowsCorrectErrorMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail Send Shows correct error message", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I open New RabbitMq Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
 testRunner.Then("\"New RabbitMQ Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("I type Host as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("\"Port\" input is \"5672\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I type Password as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("Send is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("Send is \"Failed: None of the specified endpoints were reachable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("the error message is \"Failed: None of the specified endpoints were reachable\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
