using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control = LoginSaver.Model.Control;

namespace LoginSaver.Presentation
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Control con = new Control();
            String message = con.Register(txbLogin.Text, txbPassword.Text, txbConfirmPassword.Text);
            if (con.valid)
            {
                MessageBox.Show(message, "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(con.message);
            }
        }
    }
}
