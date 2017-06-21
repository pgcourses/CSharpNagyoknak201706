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
namespace _03GenericRepository.Test
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GenericRepository")]
    public partial class GenericRepositoryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GenericRepository.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("hu-HU"), "GenericRepository", "     Mint fejlesztő, szükségem van egy általános repo osztályra,\r\n\t ami típuspara" +
                    "méterekkel hívható az egyes adattáblákra", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GenericRepo Hozzáadás")]
        public virtual void GenericRepoHozzaadas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GenericRepo Hozzáadás", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("egy GenericRepo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 7
 testRunner.When("egy új elemet rögzítek", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 8
 testRunner.Then("annak látszódnia kell a repoban.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GenericRepo Keresés")]
        public virtual void GenericRepoKereses()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GenericRepo Keresés", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("egy GenericRepo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 12
 testRunner.When("rákeresek egy létező elemre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 13
 testRunner.Then("meg kell találnom", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GenericRepo Törlés")]
        public virtual void GenericRepoTorles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GenericRepo Törlés", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("egy GenericRepo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 17
 testRunner.When("törlök egy létező elemet,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 18
 testRunner.Then("annak el kell tűnnie", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("GenericRepo Módosítás")]
        public virtual void GenericRepoModositas()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GenericRepo Módosítás", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("egy GenericRepo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 22
 testRunner.When("módosítok egy meglévő elemet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 23
 testRunner.Then("a módosításnak látszódnia kell", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
