using static System.Console;
using System.Linq;

namespace ImageDecoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter(@"C:\Users\UserA\source\repos\Kattis-solutions\src\ImageDecoding\answer.ans"))
            {
                using (var reader = new StreamReader(@"C:\Users\UserA\source\repos\Kattis-solutions\src\ImageDecoding\sample.in"))
                {
                    SetOut(writer);
                    SetIn(reader);
                    bool first = true;

                    while (true)
                    {                       
                        Image Image = new Image();
                        if (!Image.Read()) break;
                        Image.ConvertToNew();
                        
                        if (!first)
                        {
                            WriteLine();
                        }
                        else
                        {
                            first = false;
                        }
                        Image.Write();
                    }
                }
            }
        }
    }
    internal class Image
    {

        public string[] OldLines { get; set; }
        public string[] NewLines { get; set; }
        public int LineCount { get; private set; }

        public Image()
        {

        }

        public bool Read()
        {
            string line = ReadLine();
            if (line == "0") return false;

            LineCount = int.Parse(line);

            OldLines = new string[LineCount];

            for (int i = 0; i < LineCount; i++)
            {
                OldLines[i] = ReadLine();
            }

            return true;
        }

        public void Write()
        {
            for (int i = 0; i < LineCount; i++)
            {
                WriteLine(NewLines[i]);
            }
            if (NewLines.Sum(l => l.Length) / (double)LineCount != NewLines[0].Length)
            {
                WriteLine("Error decoding image");
            }
        }

        public bool ConvertToNew()
        {
            NewLines = new string[LineCount];

            for (int i = 0; i < LineCount; i++)
            {
                char startCh = OldLines[i][0];
                char nextCh = (startCh == '.') ? '#' : '.';

                int[] pixelLens = OldLines[i].Split().Skip(1).Select(s => int.Parse(s)).ToArray();
                for (int j = 0; j < pixelLens.Length; j++)
                {
                    nextCh = (nextCh == '#') ? '.' : '#';
                    NewLines[i] += new string(nextCh, pixelLens[j]);
                }
            }
            return true;
        }
    }
}