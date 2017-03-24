namespace PdfCreation.App
{
    public class WordSet
    {
        public WordSet(string first, string second, string third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public string First { get; private set; }
        public string Second { get; private set; }
        public string Third { get; private set; }
    }
}
