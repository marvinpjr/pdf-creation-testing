using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class ImageAdder
    {
        public void AddImageToDoc(Document doc, float x, float y)
        {
            var qrcode = Image.GetInstance(new PdfFilePaths().Templates + "qrcode.jpg");
            qrcode.SetAbsolutePosition(x, y); // from bottom left of page
            doc.Add(qrcode);
        }

        public void PlaceImagesOnCards(Document document)
        { 
            // x is horizontal from left, y is vertical from bottom
            float xdiff = 278f;
            float ydiff = 157f;

            float xleft = 44f;
            float xright = xleft + xdiff;
            float y1 = 60f;
            float y2 = y1 + ydiff;
            float y3 = y2 + ydiff;
            float y4 = y3 + ydiff;
            float y5 = y4 + ydiff;

            AddImageToDoc(document, xleft, y1);
            AddImageToDoc(document, xleft, y2);
            AddImageToDoc(document, xleft, y3);
            AddImageToDoc(document, xleft, y4);
            AddImageToDoc(document, xleft, y5);
            AddImageToDoc(document, xright, y1);
            AddImageToDoc(document, xright, y2);
            AddImageToDoc(document, xright, y3);
            AddImageToDoc(document, xright, y4);
            AddImageToDoc(document, xright, y5);
        }
    }
}
