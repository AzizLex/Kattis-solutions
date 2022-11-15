using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AddingWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, int> variables = new Dictionary<string, int>();

            //you can SetIn console input to File
            string line; //line of file

            while ((line = ReadLine()) != null)
            {
                var tokens = line.Split();
                int tokenValue;
                string tokenKey;
                int calc = 0;
                int sign = 1;
                string result = "";


                if (tokens[0] == "def")
                {
                    if (!variables.TryAdd(tokens[1], int.Parse(tokens[2])))
                    {
                        variables[tokens[1]] = int.Parse(tokens[2]);
                    }
                }
                else if (tokens[0] == "clear")
                {
                    variables.Clear();
                }
                else if (tokens[0] == "calc")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (tokens[i] == "-")
                        {
                            Write(" - ");
                            sign = -1;
                        }
                        else if (tokens[i] == "+")
                        {
                            Write(" + ");
                            sign = 1;
                        }
                        else if (tokens[i] == "=")
                        {
                            Write(" = ");
                        }
                        else
                        {
                            Write(tokens[i]);
                            if (variables.TryGetValue(tokens[i], out tokenValue))
                            {
                                calc = calc + (sign * tokenValue);
                            }
                            else
                            {
                                result = "unknown";
                            }
                        }
                    }
                    if (result == "unknown")
                    {
                        WriteLine("unknown");
                    }
                    else
                    {
                        tokenKey = variables.FirstOrDefault(x => x.Value == calc).Key;
                        if (tokenKey != null)
                        {
                            WriteLine(tokenKey);
                        }
                        else
                        {
                            WriteLine("unknown");
                        }
                    }

                }


            }

        }
    }
}