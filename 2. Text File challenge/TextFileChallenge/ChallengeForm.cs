using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        // Use StandardDataSet.csv
        //string path = @"C:\Users\johan\source\repos\GDanielJ\Weekly Challanges Tim Corey\2. Text File challenge\TextFileChallenge\StandardDataSet.csv";

        // Use AdvancedDataSet.csv
        string path = @"C:\Users\johan\source\repos\GDanielJ\Weekly Challanges Tim Corey\2. Text File challenge\TextFileChallenge\AdvancedDataSet.csv";

        BindingList<UserModel> users = new BindingList<UserModel>();
        FileService fileService = new FileService();

        public ChallengeForm()
        {
            InitializeComponent();

            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            users = fileService.ReadUsers(path);
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            users.Add(new UserModel 
            { 
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text,
                Age = (int)agePicker.Value,
                IsAlive = isAliveCheckbox.Checked
            });
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            fileService.SaveUsers(users, path);
        }
    }
}
