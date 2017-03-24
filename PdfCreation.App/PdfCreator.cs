using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace PdfCreation.App
{
    public class PdfCreator
    {
        Document document;

        public PdfCreator(PdfStarter starter)
        {
            document = starter.GetNewComplimentCardBack();
        }

        public void CreateSimpleDocument(string text)
        {
            document.Open();

            var welcomeParagraph = new Paragraph(text);
            document.Add(welcomeParagraph);

            document.Close();
        }

        public void CreateFromHtmlTemplate(string orderId, decimal price, DateTime orderDate, List<string> items)
        {
            document.Open();
            string contents = File.ReadAllText(new PdfFilePaths().Templates + "Template.htm");
            contents = contents.Replace("[ORDERID]", orderId);
            contents = contents.Replace("[TOTALPRICE]", price.ToString());
            contents = contents.Replace("[ORDERDATE]", orderDate.ToShortDateString());
            contents = contents.Replace("[ITEMS]", getItems(items));

            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
            foreach (var element in parsedHtmlElements)
                document.Add(element as IElement);

            document.Close();
        }

        public void CreateTable()
        {
            // work through this http://www.mikesdotnetting.com/Article/86/iTextSharp-Introducing-Tables
            document.Open();

            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("Header spanning 4 columns"));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 4 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");
            table.AddCell("Col 4 Row 2"); 
            document.Add(table);

            document.Close();
        }

        //see http://auctionrepair.com/pixels.html
        public void CreateWithImage(float x, float y)
        {
            document.Open();
            new ImageAdder().AddImageToDoc(document, x, y);
            document.Close();
        }

        private string getItems(List<string> items)
        {
            StringBuilder sb = new StringBuilder("<ul>");
            foreach (string item in items)
                sb.Append("<li>").Append(item).Append("</li>");
            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}
