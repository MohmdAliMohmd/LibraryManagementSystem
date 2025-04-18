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

namespace LibraryManagementSystem.Person.Controls
{
    public partial class ctrlPersonInfo : UserControl
    {
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }


        private int _PersonID;

        clsPerson _Person;


        #region
        [Category("Person Info")]
       
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value;
                _Person = clsPerson.FindByPersonID(_PersonID);
                if (_Person != null)
                    _LoadPersonData();
                else
                    _LoadDefaultValues();
            }
        }

        #endregion

        string _getGender()
        {
            return (_Person.Gender == 0) ? ("Male") : ("Female");
        }
        void _LoadPersonImage()
        {
            if (_Person != null)
            {
                if (_Person.ImagePath != null)
                {
                    if (File.Exists(_Person.ImagePath))
                        pbProfileImage.ImageLocation = _Person.ImagePath;
                    else
                    {
                        pbProfileImage.Image = (_Person.Gender == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);
                    }
                }
                else
                    pbProfileImage.Image = Resources.UnKnown_Male;
            }
        }
        void _LoadPersonData()
        {
            lblPersonID.Text=_Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblGender.Text = _getGender();
            lblBirthdate.Text = _Person.DateOfBirth.ToShortTimeString();
            lblAddress.Text = _Person.Address;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            _LoadPersonImage();
        }

        void _LoadDefaultValues()
        {
            lblPersonID.Text = "[????]";
            lblName.Text ="[?????????????????????]";
            lblGender.Text = "[Male/Female]";
            lblBirthdate.Text ="[??/??/????]";
            lblAddress.Text = "[?????????????????????]";
            lblEmail.Text = "[????????????@?????.???]";
            lblPhone.Text = "[?????????????????????]";
            _LoadPersonImage();
        }

      

    } 
}
