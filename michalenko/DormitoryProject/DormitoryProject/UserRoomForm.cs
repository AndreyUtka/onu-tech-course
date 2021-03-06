﻿using System;
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
    public partial class UserRoomForm : Form
    {
        UserRoomPresenter presenter;
        LoginForm LF;
        public UserRoomForm(LoginForm lf,string login,string connection)
        {
            InitializeComponent();
            presenter = new UserRoomPresenter(this,login, connection);
            LF = lf;
        }

        public void setInfo(string userInfo)
        {
            lbInfo.Text += "\n"+userInfo;
        }

        private void UserRoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LF.resetFields();
            LF.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm(presenter.getCurrentRole());
            uf.Show();
        }
    }
}
