using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WCL_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void api_test_button_Click(object sender, EventArgs e)
        {
            API_Engine a = new API_Engine();

            //Temporarily get the credentials.
            string id = "";
            string secret = "";

            string[] cred_lines = File.ReadAllLines("main.creds");
            foreach (string line in cred_lines)
            {
                if (line.IndexOf(':') != -1)
                {

                    var name = line.Substring(0, line.IndexOf(':'));
                    var value = line.Substring(line.IndexOf(':')+1);

                    switch (name)
                    {
                        case "client_id":
                            id = value;
                            break;
                        case "secret":
                            secret = value;
                            break;
                    }

                }
            }
            Console.WriteLine(id);
            Console.WriteLine(secret);



            a.Get_Token(id, secret);
        }
    }
}
