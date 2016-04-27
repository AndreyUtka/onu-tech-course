using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DormitoryProject.Presenters;

namespace DormitoryProject
{
    public partial class LoginForm : Form
    {
        LoginPresenter LP;
        public LoginForm()
        {
            InitializeComponent();
            LP = new LoginPresenter(this);
            tbPwd.PasswordChar = '*';
        }

        public string getPassword()
        {
            return tbPwd.Text.ToString();
        }
        public string getLogin()
        {
            return tbLogin.Text.ToString();
        }

        public void resetFields()
        {
            tbLogin.Text = string.Empty;
            tbPwd.Text = string.Empty;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LP.checkLogin();
        }
    }
}
