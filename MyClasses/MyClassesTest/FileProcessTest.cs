using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(@"C:\Windows\Regedit.exe");

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fileProcess = new FileProcess();
            bool fromCall;

            fromCall = fileProcess.FileExists(@"C:\Windows\BadFilename.bad");

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
