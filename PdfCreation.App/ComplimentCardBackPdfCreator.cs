using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class ComplimentCardBackPdfCreator
    {
        ComplimentCardBack document;

        public ComplimentCardBackPdfCreator(PdfStarter starter)
        {
            document = starter.GetNewComplimentCardBack();
        }

        public ComplimentCardBack CreateCardBack()
        {
            document.Open();

            PdfPTable table = new PdfPTable(4);
            table.SpacingBefore = 39f;
            table.TotalWidth = 636f;
            table.LockedWidth = true;
            float[] widths = new float[] { 40f, 278f, 278f, 40f }; 
            table.SetWidths(widths);

            List<WordSet> wordSets = WordSetGenerator.GetWordSets();
            AddCellsToTableFromWordSets(wordSets, table);
            document.Add(table);

            new ImageAdder().PlaceImagesOnCards(document);

            document.Close();
            return document;
        }

        private void AddCellsToTableFromWordSets(List<WordSet> wordSets, PdfPTable table)
        {
            for (int i = 1; i <= wordSets.Count; i += 2)
            {
                WordSet left = wordSets[i - 1];
                WordSet right = wordSets[i];

                table.AddCell(string.Empty);
                table.AddCell(MakeCell(left.First, left.Second, left.Third));
                table.AddCell(MakeCell(right.First, right.Second, right.Third));
                table.AddCell(string.Empty);
            }
        }

        private PdfPCell MakeCell(string word1, string word2, string word3)
        {
            PdfPCell cellToReturn = new PdfPCell();
            Font arial = FontFactory.GetFont("Arial", 14, Color.BLACK);
            Phrase p1 = new Phrase(word1 + "\n", arial);
            Phrase p2 = new Phrase(word2 + "\n", arial);
            Phrase p3 = new Phrase(word3, arial);
            cellToReturn.AddElement(p1);
            cellToReturn.AddElement(p2);
            cellToReturn.AddElement(p3);
            cellToReturn.PaddingLeft = 158f;
            cellToReturn.PaddingTop = 40f;
            cellToReturn.PaddingBottom = 54f;
            return cellToReturn;
        }
    }
}
