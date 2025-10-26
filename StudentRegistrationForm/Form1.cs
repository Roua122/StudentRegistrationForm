using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationForm
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();

            cmbCountry.Items.Add("Yemen");
            cmbCountry.Items.Add("Egypt");
            cmbCountry.Items.Add("Oman");
            cmbCountry.Items.Add("Qatar");
            cmbCountry.Items.Add("Palestine");
            cmbCountry.Items.Add("Syria");

            // تعيين القيمة الافتراضية (اختياري)
            cmbCountry.SelectedIndex = -1; // لا شيء محدد في البداية
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e) {
        //{
        //    cmbCountry.Items.Add("Yemen");
        //    cmbCountry.Items.Add("Egypt");
        //    cmbCountry.Items.Add("Oman");
        //    cmbCountry.Items.Add("Qatar");
        //    cmbCountry.Items.Add("Palestine");
        //    cmbCountry.Items.Add("Syria");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            // Validate Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // Validate Email (Basic Email Format Check)
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Enter a valid email address!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validate Password (Min 6 characters)
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Validate Gender Selection
            if (!rdoMale.Checked && !rdoFemale.Checked && !rdoOther.Checked)
            {
                MessageBox.Show("Please select a gender!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Country Selection
            if (cmbCountry.SelectedItem == null)
            {
                MessageBox.Show("Please select a country!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCountry.Focus();
                return;
            }

            // Validate Favorite Color Selection
            if (lblSelectedColor.Text == "No Color Selected")
            {
                MessageBox.Show("Please select your favorite color!", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // All validations passed - Proceed with displaying data
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string gender = rdoMale.Checked ? "Male" : rdoFemale.Checked ? "Female" : "Other";
            string birthdate = dtpBirthdate.Value.ToShortDateString();
            string country = cmbCountry.SelectedItem.ToString();
            string color = lblSelectedColor.Text.Replace("Selected Color: ", ""); // Extracting selected color

            // Displaying result
            lblResult.Text = $"Name: {name}\nEmail: {email}\nGender: {gender}\n" +
                             $"Birthdate: {birthdate}\nCountry: {country}\nFavorite Color: {color}";
        }

        

        private void btnPickColor_Click(object sender, EventArgs e)
        {
          
            // إنشاء مربع اختيار اللون
            ColorDialog colorDialog = new ColorDialog();

            // عرض مربع الحوار وفحص إذا ضغط المستخدم OK
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // عرض اللون المختار في الـ Label
                lblSelectedColor.Text = $"Selected Color: {colorDialog.Color.Name}";
            }
        }

    }
}

