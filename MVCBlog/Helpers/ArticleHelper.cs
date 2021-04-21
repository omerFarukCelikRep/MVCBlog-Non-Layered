using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Helpers
{
    public static class ArticleHelper
    {
        private static List<char> specialCharacters = new List<char>() { ' ', ',', '.', '@', '(', ')', '"' };
        public static int CalculateReadTime(string text)
        {
            List<char> letters = new List<char>();

            foreach (char item in text)
            {
                if (specialCharacters.Contains(item))
                {
                    continue;
                }
                letters.Add(item);
            }

            int readTime = letters.Count / 150;

            return readTime;
        }
    }
}
