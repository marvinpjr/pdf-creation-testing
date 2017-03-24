using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class PdfFilePaths
    {
        public PdfFilePaths()
        {
            Pdfs = @"C:\Users\marvinpjr\Dropbox\Marvin\Code\PdfCreation\PdfCreation.App\Pdfs\";
            Templates = @"C:\Users\marvinpjr\Dropbox\Marvin\Code\PdfCreation\PdfCreation.App\Templates\";
        }

        public string Pdfs { get; private set; }
        public string Templates { get; private set; }
    }
    public class PdfFiles
    {
        public PdfFiles()
        {
            CardFrontFullPathAndFileName = new PdfFilePaths().Templates + "Business Cards.pdf";
            CardBothFullPathAndFileName = new PdfFilePaths().Pdfs + "WholeCards_" + Guid.NewGuid().ToString() + ".pdf";
        }

        public string CardFrontFullPathAndFileName { get; private set; }
        public string CardBothFullPathAndFileName { get; private set; }
    }
}
