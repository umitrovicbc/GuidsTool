using MiscUtil.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChangeGuidsTextTool
{
    public class Services
    {
        private string book;
        private string newBook;
        private List<string> guidList;
        private static string guidPattern = "[a-z0-9]{32}";
        private static string sportBookPattern = "(SportsbookEnum\\.[a-zA-z]+)";

        public Services()
        {
            book = File.ReadAllText("book.txt");
            guidList = new List<string>();
            foreach (string line in new LineReader(() => new StringReader(File.ReadAllText("guids.txt"))))
            {
                guidList.Add(line);
            }
        }

        public void makeNewBookAndScript()
        {
            Console.WriteLine("Enter new sportsbook name: \n");
            var sportsBookName = Console.ReadLine();
            int i = 0;
            string newGuidsForScript = "";

            foreach (string line in new LineReader(() => new StringReader(book)))
            {
                string input = line;

                string sportBookReplacement = "SportsbookEnum." + sportsBookName;

                string guidReplacement = guidList[i];
                string guidResultLine = Regex.Replace(input, guidPattern, guidReplacement);

                if (guidResultLine != input)
                {
                    newGuidsForScript += "\'" + guidList[i] + "\'," + "\n";
                    i++;
                }
                newBook += Regex.Replace(guidResultLine, sportBookPattern, sportBookReplacement) + "\n";
            }
            File.WriteAllText("newBook.txt", newBook);
            File.WriteAllText("newGuidsForScript.txt", newGuidsForScript);
        }

        //In case you have finished book but need guids for script
        public void extractGuids()
        {
            var guids = "";
            foreach (string line in new LineReader(() => new StringReader(book)))
            {
                string input = line;
                Match m = Regex.Match(input, guidPattern, RegexOptions.None);
                if (m.Success)
                    guids += "\'" + m.Value + "\'," + "\n";
                File.WriteAllText("guidsForScript.txt", guids);
            }


        }
    }
 
}
