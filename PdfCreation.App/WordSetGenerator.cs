using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdfCreation.App
{
    public static class WordSetGenerator
    {
        public static List<WordSet> GetWordSets()
        {
            List<WordSet> wordSetToReturn = new List<WordSet>() {
                new WordSet("vini", "vidi", "vici"),
                new WordSet("rain", "spain", "pain"),
                new WordSet("purple", "yellow", "green"),
                new WordSet("fat", "skinny", "tall"),
                new WordSet("sexual", "spiritual", "emotional"),
                new WordSet("fruity", "salty", "sour"),
                new WordSet("tired", "excited", "angry"),
                new WordSet("action", "drama", "tragedy"),
                new WordSet("thirsty", "hungry", "stuffed"),
                new WordSet("bright", "shiny", "dull")
                };
            return wordSetToReturn;
        }
    }
}
