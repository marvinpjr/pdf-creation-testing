using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class PdfMerger
    {
        public Document CreateMergedDocWith(string fullFileName1, string fullFileName2)
        {
            // try http://stackoverflow.com/questions/6029142/merging-multiple-pdfs-using-itextsharp-in-c-net
            PdfReader BusinessCardsReader = new PdfReader(fullFileName1);
            int bPages = BusinessCardsReader.NumberOfPages;
            PdfReader CardBackReader = new PdfReader(fullFileName2);
            int cPages = CardBackReader.NumberOfPages;

            Document documentToReturn = new Document();

            PdfCopy copy = new PdfCopy(documentToReturn, new FileStream(new PdfFiles().CardBothFullPathAndFileName, FileMode.Create));
            documentToReturn.Open();

            if (cPages == 1)
            {
                PdfImportedPage cCardPageToAdd = copy.GetImportedPage(CardBackReader, 1);
                copy.AddPage(cCardPageToAdd);
            }
            if (bPages == 1)
            {
                PdfImportedPage bCardPageToAdd = copy.GetImportedPage(BusinessCardsReader, 1);
                copy.AddPage(bCardPageToAdd);
            }

            documentToReturn.Close();

            return documentToReturn;
        }
    }
}
