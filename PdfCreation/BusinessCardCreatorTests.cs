using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfCreation.App;
using System.IO;

namespace PdfCreation
{
    [TestClass]
    public class BusinessCardCreatorTests
    {
        string fName, fPath;
        ComplimentCardBackPdfCreator bCreator;

        [TestInitialize]
        public void init()
        {
            fName = Guid.NewGuid() + ".pdf";
            fPath = new PdfFilePaths().Pdfs;
            bCreator = new ComplimentCardBackPdfCreator(new PdfStarter(fName, fPath));
        }

        [TestMethod]
        public void CanCreateComplimentCardsBacks()
        {
            bCreator.CreateCardBack();
            Assert.IsTrue(File.Exists(fPath + fName));
        }

        [TestMethod]
        public void CanCreateComplimentCardsFrontAndBack()
        {
            ComplimentCardsCreator cCreator = new ComplimentCardsCreator(bCreator, new PdfMerger());
            cCreator.Create();
            Assert.IsTrue(File.Exists(fPath + fName));
        }
    }
}
