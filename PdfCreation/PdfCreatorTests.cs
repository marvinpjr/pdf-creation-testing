using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfCreation.App;
using System.IO;
using System.Collections.Generic;

namespace PdfCreation.Tests
{
    [TestClass]
    public class PdfCreatorTests
    {
        string fName, fPath;
        PdfCreator creator;

        [TestInitialize]
        public void init()
        {
            fName = Guid.NewGuid() + ".pdf";
            fPath = new PdfFilePaths().Pdfs; 
            creator = new PdfCreator(new PdfStarter(fName, fPath));
        }

        [TestMethod]
        public void ShouldBeAbleToCreatePdf()
        {
            creator.CreateSimpleDocument("Hey, what's up?!?!");
            Assert.IsTrue(File.Exists(fPath+fName));
        }

        [TestMethod]
        public void ShouldBeAbleToCreatePdfFromTemplate()
        { 
            List<string> items = new List<string> { 
                "Toothpaste", "Soap", "Hairspray"
            };
            creator.CreateFromHtmlTemplate("123456", 12.24M, DateTime.Today, items);
            Assert.IsTrue(File.Exists(fPath + fName));
        }

        [TestMethod]
        public void ShouldBeAbleToCreatePdfWithImage()
        {
            creator.CreateWithImage(450, 700);
            Assert.IsTrue(File.Exists(fPath + fName));
        }

        [TestMethod]
        public void CanCreateTableInPdf()
        {
            creator.CreateTable();
            Assert.IsTrue(File.Exists(fPath + fName));
        }
    }
}
