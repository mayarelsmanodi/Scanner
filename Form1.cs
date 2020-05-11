

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        List<string> inStrings(string inputcode)
        {

            List<string> Lines = new List<string>();

            string tmp = "";

            for (int i = 0; i < inputcode.Length; i++)
            {
                if (inputcode[i] == '\n' || inputcode[i] == '\r')
                    continue;
                tmp += inputcode[i];

                if (inputcode[i] == ';')
                {
                    Lines.Add(tmp);
                    tmp = "";
                }
            }

            return Lines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Scanner.NewLine.Clear();
           
            string code = inputCode.Text;
            Mainscanner compile = new Mainscanner(code);


            int numberOfElement = compile.tokens.Count();

            DataTable dtable = new DataTable();
            dtable.Columns.Add("tokenvalue");
            dtable.Columns.Add("tokentype");

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("tokenvalue");

           

           for (int i = 0; i < numberOfElement; ++i)
            {
                
                if (compile.types[i].ToString() == "Error")
                {
                    dt2.Rows.Add(compile.tokens[i].ToString());
                }
                else
                    dtable.Rows.Add(compile.tokens[i].ToString(), compile.types[i].ToString());
            }
            dataGridView.DataSource = dtable;
            
            

            ////////////////////////////////////////////////try///////////////////////////////////////////////////////////////
            DataTable symTable = new DataTable();
            symTable.Columns.Add("Identifier");
            symTable.Columns.Add("Value");
            symTable.Columns.Add("Datatype");
            symTable.Columns.Add("Scope");
          
        }
    }
}
