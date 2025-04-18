using LibraryManagementSystem.Global;
using LibraryManagementSystem.Properties;
using LibraryManagementSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSystem.Person
{
    public partial class frmAddEditPerson : Form
    {
        private int? _PersonID;
        clsPerson _Person;
        public enum enMode { AddNew = 1, Update = 2 };
        enMode _Mode = enMode.AddNew;

        public enum enGender { Male = 1, Female = 2 };
        byte _GetGender()
        {
            return ((rbMale.Checked)? (byte)enGender.Male:(byte)enGender.Female);
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
            _Person = clsPerson.FindByPersonID(PersonID);

        }
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

            _PersonID = null;
            _Person = new clsPerson();
        }
        void _HandelPersonPicture()
        {
            
            if (_Person.ImagePath == string.Empty && pbProfileImage.ImageLocation==null)
                pbProfileImage.Image = (rbMale.Checked) ? (Resources.UnKnown_Male) : (Resources.UnKnown_Female);
            else
            {
                if(File.Exists(_Person.ImagePath))
                    pbProfileImage.ImageLocation = _Person.ImagePath;
                else
                    pbProfileImage.Image = (rbMale.Checked) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);
            }

        }
        void _LoadPersomImage()
        {
            if (_Person == null)
            {
                pbProfileImage.Image = (rbMale.Checked) ? (Resources.UnKnown_Male) : (Resources.UnKnown_Female);
            }
            else 
            {
                _HandelPersonPicture();
            }
        }
        void _LoadDefaultValue()
        {
            lblPersonID.Text = "[???]";
            txtAddress.Text = "????";
            txtLastName.Text = "????";
            txtMiddleName.Text = "????";
            txtPhone.Text = string.Empty;
            txtEmail.Text =String.Empty;
            txtAddress.Text = string.Empty;
            //pbProfileImage.Image = Resources.UnKnown_Male;
            rbMale.Checked = true;
            btnDelete.Enabled = false;
            
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {

            if (clsTextBoxFilter.TextBoxIsNullOrEmpty(sender, e))
                errorProvider1.SetError((TextBox)sender, "This field is required!");
            else
                errorProvider1.SetError((TextBox)sender, null);
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyLetters_KeyPress(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyLetters_KeyPress(sender, e);
        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyLetters_KeyPress(sender, e);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyDigits_KeyPress(sender, e);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == string.Empty)
                return;

            if (!clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This isn't a valid Email");
                return;
            }
            else
                errorProvider1.SetError((TextBox)sender, null);

            if (txtEmail.Text.Trim() != _Person.Email && clsPerson.IsPersonExistByEmail(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "Email Address is used for another person!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);

        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {

            if (clsTextBoxFilter.TextBoxIsNullOrEmpty(sender, e))
                errorProvider1.SetError((TextBox)sender, "This field is required!");
            else
                errorProvider1.SetError((TextBox)sender, null);
        }

        

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            if (_PersonID == null)
                _LoadDefaultValue();
            else
                _LoadPersonDetails();
                
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbProfileImage.ImageLocation == null)
                pbProfileImage.Image = Resources.UnKnown_Male;

        }

       

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.png)|*.png|JPG|*.jpg|JPEG|*.jpeg;|BMP|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbProfileImage.Load(selectedFilePath);
                

            }
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbProfileImage.ImageLocation == null)
                pbProfileImage.Image = Resources.UnKnown_Female;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbProfileImage.ImageLocation= null;
           // _Person.ImagePath = string.Empty;
            _HandelPersonPicture();
        }

        void _GetPersonDetails()
        {
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.MiddleName = txtMiddleName.Text.Trim();
            _Person.Gender = _GetGender();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone= txtPhone.Text.Trim();
            _Person.DateOfBirth=dtpBirthDate.Value;
            _Person.ImagePath = (pbProfileImage.ImageLocation== null)?string.Empty:pbProfileImage.ImageLocation;


        }
        void _LoadGender()
        {
            if(_Person.Gender == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }
        void _LoadPersonDetails()
        {
            lblPersonID.Text=_Person.PersonID.ToString();
            txtFirstName.Text=_Person.FirstName.ToString();
            txtLastName.Text=_Person.LastName.ToString();
            txtMiddleName.Text=_Person.MiddleName.ToString();
            txtPhone.Text=_Person.Phone.ToString();
            txtEmail.Text=_Person.Email.ToString();
            txtAddress.Text=_Person.Address.ToString();
            dtpBirthDate.Value = _Person.DateOfBirth;
            _LoadGender();
            _LoadPersomImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _GetPersonDetails();
            if (_Mode == enMode.AddNew)
                _Person.CreationDate = DateTime.Now;
            else
                _Person.ModificationDate = DateTime.Now;
            if (_Person.Save())
            {
                MessageBox.Show("Person Saved Successfully", "OK",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Save Person Successfully", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _LoadPersonDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _LoadPersonDetails();
        }
    }
}
