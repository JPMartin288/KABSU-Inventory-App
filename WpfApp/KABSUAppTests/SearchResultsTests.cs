using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.SqlClient;

namespace WpfApp.Tests
{
    [TestClass()]
    public class SearchResultsTests
    {
        [TestMethod()]
        public void retrieveDataReturnEmptyListIfInvalidSearchTerm()
        {
            SearchTerm term = new SearchTerm(null, null, null, null, null, null, null);
            SearchResults results = new SearchResults();

            Assert.IsNotNull(results.retrieveData(term));
        }
    }
}