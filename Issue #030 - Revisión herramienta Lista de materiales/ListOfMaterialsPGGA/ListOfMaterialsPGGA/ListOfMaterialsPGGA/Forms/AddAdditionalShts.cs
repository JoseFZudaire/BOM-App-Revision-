using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListOfMaterialsPGGA.Forms
{
    public partial class AddAdditionalShts : Form
    {
        public AddAdditionalShts()
        {
            InitializeComponent();
        }

        string docValues = "";

        public string DocValues
        {
            get { return docValues; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            docValues = "";
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            docValues = textBox2.Text;
            this.Close();
        }
    }
}
