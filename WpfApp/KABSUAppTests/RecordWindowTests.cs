using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Windows.Controls;

namespace WpfApp.Tests
{
    [TestClass()]
    public class RecordWindowTests
    {
        private RecordWindow recordWindow;

        [TestMethod()]
        public void RetrieveMorphThrowsIOExceptionIfInvalidConnectionStringAndIDTest()
        {
            recordWindow = new RecordWindow();
            Assert.ThrowsException<InvalidOperationException>(() => recordWindow.RetrieveMorph("",""));
        }

        [TestMethod()]
        public void RetrieveRecordsThrowsIOExceptionIfInvalidConnectionStringAndIDTest()
        {
            recordWindow = new RecordWindow();
            Assert.ThrowsException<InvalidOperationException>(() => recordWindow.RetrieveRecords("",""));
        }

        [TestMethod()]
        public void StoreParentThrowsIOExceptionIfInvalidConnectionStringTest()
        {
            recordWindow = new RecordWindow();
            Assert.ThrowsException<InvalidOperationException>(() => recordWindow.StoreParent(""));
        }
    }
}