using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void signin_click(object sender, EventArgs e)
        {
            //Table.Dispose();

            this.Dispose(false);
            SignIn c = new SignIn();
            c.Show();

        }
    }
}
