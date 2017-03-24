using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class PdfStarter
    {
        private string _fileName;
        private string _path;
        private FileStream _output;

        public PdfStarter(string fileName, string path)
        {
            _fileName = fileName;
            _path = path;
            _output = new FileStream(_path + _fileName, FileMode.Create);
        }

        public ComplimentCardBack GetNewComplimentCardBack()
        {
            var document = new ComplimentCardBack(PageSize.A4, 50, 50, 25, 25, _fileName, _path);
            var writer = PdfWriter.GetInstance(document, _output);
            return document;
        }
    }
}
