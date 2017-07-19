﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.ToolsSpecs.Toolbox.Scripting.Ruby
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RubyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Ruby.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Ruby", "\tIn order to execute Ruby\r\n\tAs a Warewolf user\r\n\tI want a tool that allows me to " +
                    "execute Ruby", ProgrammingLanguage.CSharp, new string[] {
                        "RubyFeature"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Ruby")))
            {
                Warewolf.ToolsSpecs.Toolbox.Scripting.Ruby.RubyFeature.FeatureSetup(null);
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
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby Variable is 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyVariableIs1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby Variable is 1", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have a script variable \"[[val]]\" with this value \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I have this script to execute \"ruby_one_variable.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("the script result should be \"one\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1625 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1625.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 14
 testRunner.And("the debug inputs as", ((string)(null)), table1625, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1626 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1626.AddRow(new string[] {
                        "[[result]] = one"});
#line 17
 testRunner.And("the debug output as", ((string)(null)), table1626, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby blank script")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyBlankScript()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby blank script", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have this script to execute \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("the script result should be \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1627 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1627.AddRow(new string[] {
                        "Ruby",
                        "\"\""});
#line 27
 testRunner.And("the debug inputs as", ((string)(null)), table1627, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1628 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1628.AddRow(new string[] {
                        "[[result]] ="});
#line 30
 testRunner.And("the debug output as", ((string)(null)), table1628, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby Variable is 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyVariableIs2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby Variable is 2", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("I have a script variable \"[[val]]\" with this value \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.And("I have this script to execute \"ruby_one_variable.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("the script result should be \"two\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1629 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1629.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 41
 testRunner.And("the debug inputs as", ((string)(null)), table1629, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1630 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1630.AddRow(new string[] {
                        "[[result]] = two"});
#line 44
 testRunner.And("the debug output as", ((string)(null)), table1630, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby Variable is 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyVariableIs3()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby Variable is 3", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I have a script variable \"[[val]]\" with this value \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I have this script to execute \"ruby_one_variable.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("the script result should be \"not one or two\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1631 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1631.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 55
 testRunner.And("the debug inputs as", ((string)(null)), table1631, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1632 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1632.AddRow(new string[] {
                        "[[result]] = not one or two"});
#line 58
 testRunner.And("the debug output as", ((string)(null)), table1632, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby Variable is 100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyVariableIs100()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby Variable is 100", ((string[])(null)));
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
 testRunner.Given("I have a script variable \"[[val]]\" with this value \"100\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
 testRunner.And("I have this script to execute \"ruby_one_variable.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then("the script result should be \"not one or two\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1633 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1633.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 69
 testRunner.And("the debug inputs as", ((string)(null)), table1633, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1634 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1634.AddRow(new string[] {
                        "[[result]] = not one or two"});
#line 72
 testRunner.And("the debug output as", ((string)(null)), table1634, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute badly formed Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteBadlyFormedRuby()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute badly formed Ruby", ((string[])(null)));
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given("I have a script variable \"[[val]]\" with this value \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And("I have this script to execute \"ruby_badly_formatted.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1635 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1635.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 82
 testRunner.And("the debug inputs as", ((string)(null)), table1635, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1636 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1636.AddRow(new string[] {
                        "[[result]] ="});
#line 85
 testRunner.And("the debug output as", ((string)(null)), table1636, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby with 2 variables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyWith2Variables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby with 2 variables", ((string[])(null)));
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given("I have a script variable \"[[val1]]\" with this value \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.Given("I have a script variable \"[[val2]]\" with this value \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.And("I have this script to execute \"ruby_two_variables.txt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("the script result should be \"two\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1637 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1637.AddRow(new string[] {
                        "Ruby",
                        "String = String"});
#line 97
 testRunner.And("the debug inputs as", ((string)(null)), table1637, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1638 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1638.AddRow(new string[] {
                        "[[result]] = two"});
#line 100
 testRunner.And("the debug output as", ((string)(null)), table1638, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Ruby with a negative recordset index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Ruby")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RubyFeature")]
        public virtual void ExecuteRubyWithANegativeRecordsetIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Ruby with a negative recordset index", ((string[])(null)));
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
 testRunner.Given("I have this script to execute \"[[my(-1).val]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
 testRunner.And("I have selected the language as \"Ruby\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("I execute the script tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1639 = new TechTalk.SpecFlow.Table(new string[] {
                        "Language",
                        "Script"});
            table1639.AddRow(new string[] {
                        "Ruby",
                        "[[my(-1).val]] ="});
#line 109
 testRunner.And("the debug inputs as", ((string)(null)), table1639, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1640 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1640.AddRow(new string[] {
                        "[[result]] ="});
#line 112
 testRunner.And("the debug output as", ((string)(null)), table1640, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
