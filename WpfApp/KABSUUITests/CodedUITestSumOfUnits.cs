using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace KABSUUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITestSumOfUnits
    {
        public CodedUITestSumOfUnits()
        {
        }
        /// <summary>
        /// This is to test the "Sum OF Units" function.
        /// We will look for "Mouse" with the "Owner" filter, and click on "Sum Of Units" the expected result is 54 (number may vary depedning on new entries)
        /// </summary>
        [TestMethod]
        public void CodedUITestFilteredSumOfUnits()
        {

            this.UIMap.TestForSumOfUnits();

        }
        /// <summary>
        /// This is to test to the total Sum Of Units without any filters or test in the search box.
        /// The expected result is 213972 (number may vary depedning on new entries)
        /// </summary>
        [TestMethod]
        public void CodedUITestTotalSumOfUnits()
        {

            this.UIMap.TestForTotalSumOfUnits();

        }
        /// <summary>
        ///  This is to test to the total Sum Of Units with a filter ther than "Owner" in this case we will try "Breed" with the search entry "Mouse"
        ///  The expcted result is 0
        /// </summary>
        public void CodedUITestMethod3()
        {

            this.UIMap.IsThisGonnaWork();

        }
 

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
