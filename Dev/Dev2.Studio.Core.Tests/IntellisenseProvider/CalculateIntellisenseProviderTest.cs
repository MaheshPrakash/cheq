/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using Dev2.Calculate;
using Dev2.Studio.InterfaceImplementors;
using Dev2.Studio.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Core.Tests.IntellisenseProvider
{
    [TestClass]
    [TestCategory("Intellisense Provider Core")]
    public class CalculateIntellisenseProviderTest
    {
        
        #region CalculateIntellisenseProvider Tests

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_Construct")]
        public void CalculateIntellisenseProvider_Construct_DefaultPropertiesAreSet()
        {
            var calculateIntellisenseProvider = GetCalculateProvider(false);

            Assert.IsFalse(calculateIntellisenseProvider.HandlesResultInsertion);
            Assert.AreEqual(IntellisenseProviderType.NonDefault, calculateIntellisenseProvider.IntellisenseProviderType);
            Assert.IsNotNull(calculateIntellisenseProvider.IntellisenseResult);
            Assert.AreEqual(175, calculateIntellisenseProvider.IntellisenseResult.Count);
            Assert.IsFalse(calculateIntellisenseProvider.Optional);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_InputBeginsCaretPositonedAfterTwoCharacters_ResultsFilteredBasedOnCharacters()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "se",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);

            Assert.AreEqual(4, results.Count);
            Assert.AreEqual("search", results[0].Name);
            Assert.AreEqual("searchb", results[1].Name);
            Assert.AreEqual("second", results[2].Name);
            Assert.AreEqual("seriessum", results[3].Name);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_DesiredIsEntireSet_ResultAllResult()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "se",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.EntireSet
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);

            Assert.AreEqual(4, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_CalculateModeIsFalse_ResultCountIsZero()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "se",
                    IsInCalculateMode = false,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_ProviderContextIsNull_ResultsCountIsZero()
        {
            var calculateIntellisenseProvider = new CalculateIntellisenseProvider();
            var results = calculateIntellisenseProvider.GetIntellisenseResults(null);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_InputStringIsEmpty_ResultsCountIsZero()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(175, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_InputStringIsNull_ResultsCountIsZero()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = null,
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(175, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_CaretPositionIsZero_ResultsCountIsZero()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 0,
                    InputText = "se",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(false);
            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(4, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_DesiredResultSetIsEntiresetAndInputIsInvalidText_EntiresetPlusAndError()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "XXXXX",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.EntireSet
                };

            var calculateIntellisenseProvider = GetCalculateProvider(true);

            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(0, results.Count);
           
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_DesiredResultsetIsClosestMatchAndInputTextIsNotFound_AnError()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 2,
                    InputText = "cantbefound",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(true);

            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_DesiredResultsetIsClosestMatchAndInputTextIsFound_ResultPlusAnError()
        {
            var context = new IntellisenseProviderContext
                {
                    CaretPosition = 3,
                    InputText = "sum",
                    IsInCalculateMode = true,
                    DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
                };

            var calculateIntellisenseProvider = GetCalculateProvider(true);

            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("sum", results[0].Name);
            Assert.AreEqual("Sums all the numbers given as arguments and returns the sum.", results[0].Description);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_GetIntellisenseResults")]
        public void CalculateIntellisenseProvider_GetIntellisenseResults_DesiredResultsetIsDefaultExpressionIsIncomplete_AnError()
        {
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 3,
                InputText = "sum",
                IsInCalculateMode = true,
                DesiredResultSet = IntellisenseDesiredResultSet.Default
            };

            var calculateIntellisenseProvider = GetCalculateProvider(true);

            var results = calculateIntellisenseProvider.GetIntellisenseResults(context);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("sum", results[0].Name);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_PerformResultInsertion")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CalculateIntellisenseProvider_PerformResultInsertion_ValidContext_ThrowsException()
        {
            var context = new IntellisenseProviderContext
            {
                CaretPosition = 0,
                InputText = "se",
                IsInCalculateMode = true,
                DesiredResultSet = IntellisenseDesiredResultSet.ClosestMatch
            };

            var calculateIntellisenseProvider = new CalculateIntellisenseProvider();
            calculateIntellisenseProvider.PerformResultInsertion("some string", context);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_Dispose")]
        public void CalculateIntellisenseProvider_Dispose_IntellisenseResultIsNullified()
        {
            var calculateIntellisenseProvider = new CalculateIntellisenseProvider();
            var countBeforeDispose = calculateIntellisenseProvider.IntellisenseResult.Count;
            calculateIntellisenseProvider.Dispose();
            Assert.AreEqual(175, countBeforeDispose);
            Assert.AreEqual(null, calculateIntellisenseProvider.IntellisenseResult);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_Optional")]
        public void CalculateIntellisenseProvider_IsOptional_False()
        {
            var calculateIntellisenseProvider = new CalculateIntellisenseProvider();
            Assert.AreEqual(false, calculateIntellisenseProvider.Optional);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("CalculateIntellisenseProvider_HandlesResultInsertion")]
        public void CalculateIntellisenseProvider_HandlesResultInsertion_False()
        {
            var calculateIntellisenseProvider = new CalculateIntellisenseProvider();
            Assert.AreEqual(false, calculateIntellisenseProvider.HandlesResultInsertion);
        }


        CalculateIntellisenseProvider GetCalculateProvider(bool hasEventLogs)
        {
            var syntaxBuilderMock = new Mock<ISyntaxTreeBuilderHelper>();
            syntaxBuilderMock.SetupGet(p => p.HasEventLogs).Returns(hasEventLogs);
            syntaxBuilderMock.SetupGet(p => p.EventLog).Returns(new EventLogParser());

            var calculateIntellisenseProvider = new CalculateIntellisenseProvider(syntaxBuilderMock.Object);
            return calculateIntellisenseProvider;
        }

        #endregion CalculateIntellisenseProvider Tests
    }
}
