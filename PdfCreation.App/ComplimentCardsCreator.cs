using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class ComplimentCardsCreator
    {
        private ComplimentCardBackPdfCreator _backCreator;
        private PdfMerger _merger;
        public ComplimentCardsCreator(ComplimentCardBackPdfCreator backCreator, PdfMerger merger)
        {
            _merger = merger;
            _backCreator = backCreator;
        }

        public void Create()
        {
            ComplimentCardBack cardBack = _backCreator.CreateCardBack();
            Document wholeDoc = _merger.CreateMergedDocWith(cardBack._filePath + cardBack._fileName, new PdfFiles().CardFrontFullPathAndFileName);
        }
    }
}
