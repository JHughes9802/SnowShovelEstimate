using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowShovelEstimate
{
    public partial class FormSpecialRequests : Form
    {
        private bool Saved = false;

        public FormSpecialRequests()
        {
            InitializeComponent();
        }

        private void FormSpecialRequests_Load(object sender, EventArgs e)
        {
            txtRequests.Text = Tag.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tag = txtRequests.Text;
            Saved = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSpecialRequests_Close(object sender, FormClosingEventArgs e)
        {
            bool userMadeChanges = Tag.ToString() != txtRequests.Text;

            if (!Saved && userMadeChanges)
            {
                DialogResult closeResult = MessageBox.Show("Your changes are not saved, close anyway?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (closeResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
