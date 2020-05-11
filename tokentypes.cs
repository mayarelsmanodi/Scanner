using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public enum Token_Class { SpecialSymbols, ReservedWords, Identifier,String,  Error, comment, number, program, dataType, other, two_operator };


namespace Project1Scanner
{
    public class tokentypes
    {
        Dictionary<String, Token_Class> Classes;
        public void filldic()
        {
            Classes.Add("if", Token_Class.ReservedWords);
            Classes.Add(";", Token_Class.SpecialSymbols);
            Classes.Add("program", Token_Class.program);
            Classes.Add("+", Token_Class.SpecialSymbols);
            Classes.Add("-", Token_Class.SpecialSymbols);
            Classes.Add("*", Token_Class.SpecialSymbols);
            Classes.Add("/", Token_Class.SpecialSymbols);
            Classes.Add("int", Token_Class.dataType);
            Classes.Add("float", Token_Class.dataType);
            Classes.Add("string", Token_Class.dataType);
            Classes.Add("read", Token_Class.ReservedWords);
            Classes.Add("write", Token_Class.ReservedWords);
            Classes.Add("<", Token_Class.SpecialSymbols);
            Classes.Add(">", Token_Class.SpecialSymbols);
            Classes.Add("=", Token_Class.SpecialSymbols);
            Classes.Add("<>", Token_Class.SpecialSymbols);
            Classes.Add("||", Token_Class.SpecialSymbols);
            Classes.Add("&&", Token_Class.SpecialSymbols);
            Classes.Add("repeat", Token_Class.ReservedWords);
            Classes.Add("while", Token_Class.ReservedWords);
            Classes.Add("until", Token_Class.ReservedWords);
            Classes.Add("elseif", Token_Class.ReservedWords);
            Classes.Add("else", Token_Class.ReservedWords);
            Classes.Add("then", Token_Class.ReservedWords);
            Classes.Add("return", Token_Class.ReservedWords);
            Classes.Add("end", Token_Class.ReservedWords);
            Classes.Add("(", Token_Class.SpecialSymbols);
            Classes.Add(")", Token_Class.SpecialSymbols);
            Classes.Add(",", Token_Class.SpecialSymbols);
            Classes.Add("{", Token_Class.SpecialSymbols);
            Classes.Add("}", Token_Class.SpecialSymbols);
            Classes.Add("main", Token_Class.ReservedWords);
            Classes.Add(":=", Token_Class.SpecialSymbols);
        }
        public tokentypes()
        {
            Classes = new Dictionary<string, Token_Class>();
            filldic();
        }
        public string check(string T)
        {

            T = T.ToLower();
            string type = "Error";
            if (Classes.ContainsKey(T)) { type = Classes[T].ToString(); }
            else
            {

                int i = 0;
                if (ScannerClassification.is_letter(T[i]))
                {
                    while (i < T.Length && (ScannerClassification.is_letter(T[i]) || ScannerClassification.is_digit(T[i])))
                    {

                        i++;
                    }
                    if (i == T.Length)
                        type = Token_Class.Identifier.ToString();
                    else i = 0;

                }
                else if (ScannerClassification.is_digit(T[i]))
                {
                    int dots = 0;
                    while (i < T.Length && (ScannerClassification.is_digit(T[i]) || (T[i] == '.' && dots == 0)))
                    {
                        if (T[i] == '.')
                            dots++;
                        ++i;

                    }
                    if (dots < 2 && i == T.Length) type = Token_Class.number.ToString();

                }
                else if (i <= T.Length - 2 && ScannerClassification.is_two_operator(T[i], T[i + 1]))
                {

                    if (T[i] == '/' && T[i + 1] == '/')
                    {
                        type = Token_Class.comment.ToString();
                    }
                    else if (T[i] == '/' && T[i + 1] == '*')
                    {
                        if (T[T.Length - 2] == '*' && T[T.Length - 1] == '/')
                            type = Token_Class.comment.ToString();
                        else type = Token_Class.Error.ToString();

                    }
                    else
                        type = Token_Class.two_operator.ToString();
                }
                else if (ScannerClassification.is_one_operator(T[i]))
                {
                    //type = Type.Operator.ToString();
                    if (T[i] == '"')
                    {
                        if (T[T.Length - 1] == '"') type = Token_Class.String.ToString();

                    }
                    else type = Token_Class.Error.ToString();
                }
            }
            return type;
        }
    }
}
