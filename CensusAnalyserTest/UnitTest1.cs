using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IndianStateCensusAnalyser;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusPath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusData.csv";
        string wrongPath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCensus.csv";
        string wrongFileType = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\TextFile1.txt";
        string invalidDelimeter = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\WorngDelimeter.csv";
        string stateCodePath = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\IndianStateCode.csv";
        string stateCodeInvalidDelimeter = @"C:\Users\HP1\source\repos\Lambda\CensusAnalyser\IndianStateCensusAnalyser\StateCodeWrongDelimeter.csv";
        IndianStateCensusAnalyser.CensusAdapterFactory csv = null;
        CensusAdapter adapter;
        Dictionary<string, CensusData> totalRecord;
        Dictionary<string, CensusData> stateRecord;

        [TestInitialize]
        public void testSetup()
        {
            csv = new CensusAdapterFactory();
            adapter = new CensusAdapter();
            totalRecord = new Dictionary<string, CensusData>();
            stateRecord = new Dictionary<string, CensusData>();
        }

        //TC.1
        //Giving correct path it should return total count of the census list
        [TestCategory("StateCensusAnalyser")]
        [TestMethod]
        public void GivenStateCensusReturnTotalRecord()
        {
            stateRecord = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            int actual = stateRecord.Count;
            int expected = 36;
            //assertion
            Assert.AreEqual(actual, expected);
        }
    }
}
