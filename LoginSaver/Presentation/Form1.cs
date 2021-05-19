using LoginSaver.Presentation;
using System;
using System.Windows.Forms;
using Control = LoginSaver.Model.Control;

namespace LoginSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Control control = new Control();
            control.Access(txbLogin.Text, txbPass.Text);
            if (control.message.Equals(""))
            {
                if (control.valid)
                {
                    MessageBox.Show("Successful Login", "Loging in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Welcome wc = new Welcome();
                    wc.Show();
                }
                else
                {
                    MessageBox.Show("Invalid login or password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(control.message);
            }
        }
    }
}
