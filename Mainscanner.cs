using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1Scanner
{
    public class Mainscanner
    {

        string sourceCode;
        
        public List<string> tokens, types;
        Scanner scaner;
        tokentypes tokensTypes;
        List<Token> ListofT;
        public void compile()
        {
            types = new List<string>();
            int numberOfElement = tokens.Count();
            for (int i = 0; i < numberOfElement; ++i)
            {
                types.Add(tokensTypes.check(tokens[i]));
            }
        }
        public Mainscanner(string sourceCode)
        {
            this.sourceCode = sourceCode;
            scaner = new Scanner();
            tokens = new List<string>();
            tokens = scaner.scan(sourceCode);
            tokensTypes = new tokentypes();
            compile();
            
          
        }
    }
}
