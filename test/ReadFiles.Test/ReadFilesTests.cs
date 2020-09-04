using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ReadFiles.Test
{
    [TestClass]
    public class ReadFilesTests
    {
        [TestMethod]
        public void BothFilesExistFormatCorrect_Valid()
        {
            //Arrange
            string inputfolder = ConfigurationManager.AppSettings["inputDataFolder"];
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            //Act
            List<OutputLine> output = Program.ReadFiles(files);

            //Assert
            Assert.AreEqual(6, output.Count);
            Assert.AreEqual("Driver Four", output[0].DriverName);
        }
        [TestMethod]
        public void OneFileDoesntExist_Valid()
        {
            //Arrange
            string inputfolder = ConfigurationManager.AppSettings["inputDataFolder"];
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            //Act
            var listFiles = new List<string>(files);
            listFiles.RemoveAt(0);
            List<OutputLine> output = Program.ReadFiles(listFiles.ToArray());

            //Assert
            Assert.AreEqual(3, output.Count);
            Assert.AreEqual("Driver Four", output[0].DriverName);
        }
        [TestMethod]
        public void OneFileWithBlankLines_Valid()
        {
            //Arrange
            string inputfolder = ".\\inputDataBlankLines\\";
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            //Act
            List<OutputLine> output = Program.ReadFiles(files);

            //Assert
            Assert.AreEqual(6, output.Count);
            Assert.AreEqual("Driver Four", output[0].DriverName);
        }
        [TestMethod]
        public void DuplicatedDriversInFiles_Valid()
        {
            //Arrange
            string inputfolder = ".\\duplicatedDriverinputData\\";
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            //Act
            List<OutputLine> output = Program.ReadFiles(files);

            //Assert
            Assert.AreEqual(7, output.Count);
            Assert.AreEqual("Driver Two", output[0].DriverName);
        }
        [TestMethod]
        public void OneFileWithWrongData_NotValid()
        {
            //Arrange
            string inputfolder = ".\\wrongOneFileData\\";
            string filesPattern = ConfigurationManager.AppSettings["Files"];
            string[] files = Directory.GetFiles(inputfolder, filesPattern);

            //Act
            var ex = Assert.ThrowsException<Exception>(() => Program.ReadFiles(files));
            //Assert
            Assert.IsNotNull(ex);

        }

    }
}
