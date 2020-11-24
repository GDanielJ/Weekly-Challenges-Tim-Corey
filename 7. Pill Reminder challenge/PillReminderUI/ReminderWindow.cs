using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        BindingList<PillModel> medications = new BindingList<PillModel>();
        BindingList<PillModel> pillsToTake = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";

            pillsToTakeListBox.DataSource = pillsToTake;
            pillsToTakeListBox.DisplayMember = "PillInfo";

            PopulateDummyData();
        }

        public void PopulatePillsToTakeList()
        {
            var pillsToTakeList = medications.Where(p => p.TimeToTake.TimeOfDay <= DateTime.Now.TimeOfDay)
                .Where(p => p.LastTaken.Date < DateTime.Now.Date)
                .OrderBy(p => p.TimeToTake.TimeOfDay);

            pillsToTake.Clear();

            foreach (var pill in pillsToTakeList)
            {
                pillsToTake.Add(pill);
            }
        }

        private void PopulateDummyData()
        {
            CultureInfo enUS = new CultureInfo("en-US", false);

            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.ParseExact("0:15 am", "h:mm tt", enUS, DateTimeStyles.AssumeLocal) });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("11:45 pm") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("6:15 pm") });
        }

        private void refreshPillsToTake_Click(object sender, EventArgs e)
        {
            PopulatePillsToTakeList();
        }

        private void takePill_Click(object sender, EventArgs e)
        {
            var selectedPill = (PillModel)pillsToTakeListBox.SelectedItem;

            selectedPill.LastTaken = DateTime.Now;
            pillsToTake.Remove(selectedPill);
        }
    }
}
