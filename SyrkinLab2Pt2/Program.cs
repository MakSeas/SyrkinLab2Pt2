using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyrkinLab2Pt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к директории для анализа: ");
            string path = Console.ReadLine();

            string[] fileNames=Directory.GetFiles(path);

            List<string> exts = new List<string>();
            List<int> extCount = new List<int>();

            foreach (string file in fileNames)
            {
                bool ext=false;

                string extWord = "";

                for(int i = 0; i<file.Length; i++)
                {
                    if (ext) extWord += file[i];

                    if (file[i]=='.')
                    {
                        ext = true;
                    }
                }

                if (!CheckForMatch(exts, extWord))
                {
                    exts.Add(extWord);
                    extCount.Add(1);
                }
                else
                {
                    int index = FindMatchIndex(exts, extWord);
                    extCount[index]++;
                }
            }

            for(int j = 0; j < exts.Count()-1; j++)
            {
                for(int i = 0; i < exts.Count() - j-1; i++)
                {
                    if (extCount[i] < extCount[i+1])
                    {
                        int swap = extCount[i];
                        extCount[i] = extCount[i+1];
                        extCount[i+1] = swap;

                        string swap1 = exts[i];
                        exts[i] = exts[i + 1];
                        exts[i + 1] = swap1;
                    }
                }
            }

            Console.WriteLine("ТОП-5 расширений:");

            for(int i = 0; i < 5; i++)
            {
                if(i < exts.Count() - 1)
                Console.WriteLine($".{exts[i]} встречается {extCount[i]} раз");
            }
        }

        static int FindMatchIndex(List<string> exts, string extWord)
        {
            int result = 0;

            for (int i=0;i < exts.Count();i++)
            {
                if (exts[i] == extWord)
                {
                    result = i;
                }
            }

            return result;
        }
        static bool CheckForMatch(List<string> exts, string extWord)
        {
            bool result=false;

            foreach(string ext in exts)
            {
                if(ext==extWord)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
