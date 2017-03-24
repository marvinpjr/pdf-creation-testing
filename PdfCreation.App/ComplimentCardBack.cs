using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public class ComplimentCardBack: Document
    {
        public ComplimentCardBack(string fileName, string filePath) :base()
        {
            _fileName = fileName;
            _filePath = filePath;
        }
        public ComplimentCardBack(
            Rectangle pageSize, float marginLeft, float marginRight, float marginTop, float marginBottom, 
            string fileName, string filePath) 
            :base(pageSize, marginLeft, marginRight, marginTop, marginBottom)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public string _fileName { get; private set; }
        public string _filePath { get; private set; }
    }
}
