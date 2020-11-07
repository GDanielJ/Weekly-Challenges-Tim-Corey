using Dapper;
using DapperDemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Dashboard : Form
    {
        BindingList<SystemUserModel> users = new BindingList<SystemUserModel>();

        BusinessLayer bl = new BusinessLayer();

        public Dashboard()
        {
            InitializeComponent();

            userDisplayList.DataSource = users;
            userDisplayList.DisplayMember = "FullName";

            var records = bl.GetUsers();

            LoadUsers(records);
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            bl.CreateUser(firstNameText.Text, lastNameText.Text);

            firstNameText.Text = "";
            lastNameText.Text = "";
            firstNameText.Focus();

            var records = bl.GetUsers();

            LoadUsers(records);
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            var records = bl.GetFilteredUsers(filterUsersText.Text);

            LoadUsers(records);
        }

        private void LoadUsers(List<SystemUserModel> list)
        {
            users.Clear();
            list.ForEach(x => users.Add(x));
        }
    }
}
