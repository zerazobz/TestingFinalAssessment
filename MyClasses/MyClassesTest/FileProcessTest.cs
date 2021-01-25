using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private string _badfileNamePath = @"C:\Windows\BadFilename.bad";
        private string _gooFileNamePath = String.Empty;

        [TestInitialize]
        public void Initialiaze()
        {
            _gooFileNamePath = ConfigurationManager.AppSettings["GoodFileName"];

            if (_gooFileNamePath.Contains("[AppPath]"))
                _gooFileNamePath = _gooFileNamePath.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.Windows));
        }

        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall;

            Console.WriteLine(_gooFileNamePath);
            fromCall = fileProcess.FileExists(_gooFileNamePath);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(_badfileNamePath);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowArgumentException()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowArgumentException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            try
            {
                fromCall = fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //The test was a success
                return;
            }

            Assert.Fail("Call to FileExists did not throw ArgumentException.");
        }
    }
}
