using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Scanner
{
    class Scanner
    {



        public static List<int> NewLine = new List<int>();
        public List<String> scan(String source_code)
        {
            NewLine.Add(-1);
            List<String> tokens = new List<String>();

            for (int i = 0; i < source_code.Length; i++)
            {
                int count = i;
                String defaultstring = "";

                if (ScannerClassification.is_letter(source_code[count]))
                {
                    while (count < source_code.Length && (ScannerClassification.is_letter(source_code[count]) || ScannerClassification.is_digit(source_code[count])))
                    {
                        defaultstring += source_code[count];
                        count++;
                    }
                    tokens.Add(defaultstring);
                    i = count - 1;
                }
                else if (ScannerClassification.is_digit(source_code[count]))
                {
                    int dots = 0;
                    while (count < source_code.Length && (ScannerClassification.is_digit(source_code[count]) || source_code[count] == '.' || ScannerClassification.is_letter(source_code[count])))
                    {
                        if (source_code[count] == '.')
                            dots++;
                        defaultstring += source_code[count];
                        count++;
                    }
                    tokens.Add(defaultstring);
                    i = count - 1;
                }
                else if (count != source_code.Length - 1 && ScannerClassification.is_two_operator(source_code[count], source_code[count + 1]))
                {
                    defaultstring += source_code[count];
                    defaultstring += source_code[count + 1];

                    if (source_code[count] == '/' && source_code[count + 1] == '/')
                    {
                        count = count + 2;
                        while (count < source_code.Length && source_code[count] != '\n')
                        {
                            defaultstring += source_code[count];
                            ++count;
                            //  MessageBox.Show(lex.ToString());
                        }
                    }
                    else if (source_code[count] == '/' && source_code[count + 1] == '*')
                    {

                        count = count + 2;
                        while (count < source_code.Length - 1 && source_code[count] != '*' && source_code[count + 1] != '/')
                        {
                            defaultstring += source_code[count];
                            count += 1;
                            //  MessageBox.Show(lex.ToString());
                        }

                        if (count < source_code.Length - 1 && source_code[count] == '*' && source_code[count + 1] == '/')
                        {
                            defaultstring += source_code[count];
                            defaultstring += source_code[count + 1];
                            count++;
                        }

                    }
                    else
                        count++;
                    // MessageBox.Show(lex.ToString());
                    i = count;
                    tokens.Add(defaultstring);
                }
                else if (ScannerClassification.is_one_operator(source_code[count]))
                {
                    defaultstring += source_code[count];


                    if (source_code[count] == '"')
                    {

                        //string tmp ="";
                        //  tmp += source_code[cur];
                        ++count;
                        while (count < source_code.Length && source_code[count] != '"' && source_code[count] != '\n' && source_code[count] != ';')
                        {

                            defaultstring += source_code[count];
                            ++count;

                        }
                        if (source_code[count] == '"') defaultstring += source_code[count];
                    }
                    i = count;
                    tokens.Add(defaultstring);

                }
                else
                {
                    count = i;
                    if (source_code[count] == ' ' || source_code[count] == '\r' || source_code[count] == '\n')
                    {
                        if (source_code[count] == '\n')
                            NewLine.Add(tokens.Count - 1);
                        continue;
                    }
                    

                    while (count < source_code.Length && source_code[count] != ' ' && source_code[count] != '\r' && source_code[count] != '\n') { defaultstring += source_code[count]; ++count; }
                    tokens.Add(defaultstring);
                    i = count - 1;
                }

            }
            NewLine.Add(tokens.Count - 1);
            return tokens;
        }

    }
}
