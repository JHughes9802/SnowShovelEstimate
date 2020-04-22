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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dteAppointmentDate.MinDate = DateTime.Today;
            dteAppointmentDate.MaxDate = DateTime.Today.AddDays(7);
        }

        private void btnSpecialRequest_Click(object sender, EventArgs e)
        {
            FormSpecialRequests frmSpecialRequests = new FormSpecialRequests();
            frmSpecialRequests.Tag = lblSpecialRequests.Text;
            DialogResult specialRequestResults = frmSpecialRequests.ShowDialog();

            if (specialRequestResults == DialogResult.OK)
            {
                if (frmSpecialRequests.Tag is string specialRequests)
                {
                    lblSpecialRequests.Text = specialRequests;
                }
            }
        }

        private void btnGetEstimate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            DateTime date = dteAppointmentDate.Value;

            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(address) || date == null)
            {
                MessageBox.Show("Please fill all fields", "Error");
                return;
            }

            double price;

            if (rdoSingle.Checked)
            {
                price = 20;
            }
            else
            {
                price = 30;
            }

            if (date.Date == DateTime.Today)
            {
                price += 5;
            }

            txtPrice.Text = $"{price:c}";
        }

        /* Added this event in case the user changes the date or sidewalk type and forgets to click
         * the Get Estimate button again. That way, there's no chance of the user getting an
         * incorrect idea of the price. I could instead set txtPrice to automatically update,
         * but then the Get Estimate button wouldn't have a purpose */
        private void clearEstimate(object sender, EventArgs e)
        {
            txtPrice.Clear();
        }
    }
}
