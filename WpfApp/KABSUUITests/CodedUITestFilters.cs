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
    public class CodedUITestFilters
    {
        public CodedUITestFilters()
        {

        }


        /// <summary>
        /// This is a test to open the "Modify Record" window
        /// </summary>
        [TestMethod]
        public void CodedUITestOpenSearchWindow()
        {
            
            this.UIMap.OpeningModifyRecordWindow();
        }
        /// <summary>
        /// This is a test to use the "Owner" filter in search
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByOwnerFilter()
        {

            this.UIMap.SearchByOwnerFilter();

        }
        /// <summary>
        /// This is a test to use the "Breed" filter in search
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByBreedFilter()
        {

            this.UIMap.SearchByBreedFilter();

        }
        /// <summary>
        /// This is a test to use the "Animal Name" filter in search
        /// We will search for "Holy Smoker" as we know it exists
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByAnimalNameFilter()
        {

            this.UIMap.SearchByAnimalNameFilter();

        }
        /// <summary>
        /// This is a test to use the "Code #" filter in search
        /// we will search for "countyo" as we know it exists 
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByCodeFilter()
        {

            this.UIMap.SearchByCodeFilter();

        }
        /// <summary>
        /// This is a test to use the "Can #" filter in search
        /// we will search for "658" as we know it exists 
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByCanFilter()
        {

            this.UIMap.SearchByCanFilter();

        }
        /// <summary>
        /// This is a test to use the "Town" filter in search
        /// we will search for "Lemasa" as we know it exists 
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByTownFilter()
        {

            this.UIMap.SearchByTownFilter();

        }
        /// <summary>
        /// This is a test to use the "State" filter in search
        /// we will search for "KS" as we know it exists 
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByStateFilter()
        {

            this.UIMap.SearchByStateFilter();

        }
        /// <summary>
        /// This is a test to use the "Owner" filter  AND "Breed" filter (2 filters)
        /// we will search for "Mouse" in the owner filter and "Cross" in Breed filter as we know both exist.
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByOwnerAndCross()
        {

            this.UIMap.SearchByOwnerAndCross();

        }
        /// <summary>
        /// This is a test to use the "Owner" filter  AND "Breed" AND "Animal Name" filter (3 filters)
        /// we will search for "Mouse" in the owner filter and "Cross" in Breed filter and "Holy Smoker" in Animal Name as we know they exist.
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByOwnerAndByBreedAndByAnimalName()
        {

            this.UIMap.SearchByOwnerAndByBreedAndByAnimalName();

        }
        /// <summary>
        /// This is a test to use the "Owner" filter  AND "Breed" AND "Animal Name" AND "Code" filter (4 filters)
        /// we will search for "Mouse" in the owner filter and "Cross" in Breed filter and "Holy Smoker" in Animal Name and "54XB399" as we know they exist.
        /// </summary>
        [TestMethod]
        public void CodedUITestSearchByOwnerAndByBreedAndByAnimalNameAndByCode()
        {

            this.UIMap.SearchByOwnerAndByBreedAndByAnimalNameAndByCode();

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
