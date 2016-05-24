// Course: CIT 255
// Assignment: Laboratory 07
// Author: Instructor

using System;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

public partial class frmAddUpdate : Form
{
    public clsZipCode ZipCode;
    public string Mode;
    private const string mDatabaseFileName = "zipCodes.accdb";


    public frmAddUpdate()
    {
        InitializeComponent();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private bool validateInput()
    {
        const string cZipCodeBad = "Zip Code is required, is numeric, and must be exactly 5 digits in length.";
        const string cStateBad = "State is required.";
        const string cCityBad = "City is required.";
        const string cLongitudeBad = "Longitude is required, and must be numeric.";
        const string cLatitudeBad = "Latitude is required, and must be numeric";

        // Validate Zip Code.

        if (txtZipCode.Text.Length != 5)
        {
            messageBoxOK(cZipCodeBad);
            txtZipCode.Focus();
            return false;
        }

        if (isNumbersOnly(txtZipCode.Text) == false)
        {
            messageBoxOK(cZipCodeBad);
            txtZipCode.Focus();
            return false;
        }

        // Validate City.

        if (txtCity.Text == "")
        {
            messageBoxOK(cCityBad);
            txtCity.Focus();
            return false;
        }

        // Validate State.

        if (txtState.Text == "")
        {
            messageBoxOK(cStateBad);
            txtState.Focus();
            return false;
        }

        // Validate Longitude.

        double doubleDigit;

        if (double.TryParse(txtLongitude.Text, out doubleDigit) == false)
        {
            messageBoxOK(cLongitudeBad);
            txtLongitude.Focus();
            return false;
        }


        // Validate Latitude.

        if (double.TryParse(txtLatitude.Text, out doubleDigit) == false)
        {
            messageBoxOK(cLatitudeBad);
            txtLatitude.Focus();
            return false;
        }

        // If we get here, then everything must be OK.

        return true;
    }

    private bool isNumbersOnly(string numberString)
    {
        string character;
        int intDigit;

        for (int index = 0; index < numberString.Length; index++)
        {
            character = numberString.Substring(index, 1);

            if (int.TryParse(character, out intDigit) == false)
            {
                return false;
            }
        }

        return true;
    }

    private void messageBoxOK(string msg)
    {
        MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void frmAddUpdate_Load(object sender, EventArgs e)
    {
        Text = Mode + " Zip Code";

        if (Mode == "Update")
        {
            txtZipCode.Text = ZipCode.ZipCode;
            txtZipCode.ReadOnly = true;

            txtCity.Text = ZipCode.City;
            txtState.Text = ZipCode.State;
            txtLongitude.Text = ZipCode.Longitude.ToString();
            txtLatitude.Text = ZipCode.Latitude.ToString();
            txtLastUpdated.Text = ZipCode.LastUpdated.ToShortDateString() 
                + " " + ZipCode.LastUpdated.ToShortTimeString();

            chkActive.Checked = ZipCode.Active;
        }
        else if (Mode == "Add")
        {
            chkActive.Checked = true;
            txtLastUpdated.Text = DateTime.Now.ToShortDateString() 
                + " " + DateTime.Now.ToShortTimeString();
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (validateInput() == false)
        {
            return;
        }

        ZipCode.ZipCode = txtZipCode.Text;
        ZipCode.City = txtCity.Text;
        ZipCode.State = txtState.Text;
        ZipCode.Longitude = double.Parse(txtLongitude.Text);
        ZipCode.Latitude = double.Parse(txtLatitude.Text);
        ZipCode.Active = chkActive.Checked;
        ZipCode.LastUpdated = DateTime.Now;

        if (Mode == "Add")
        {
            //frmMain.mZipCodeResultsAL.Add(ZipCode);
            addMode();
        }
        else
        {
            updateMode();
        }

        DialogResult = DialogResult.OK;
    }

    private void updateMode()
    {
        string sql = "UPDATE ZipCodes SET "
            + "City = " + toSql(ZipCode.City) + ", "
            + "State = " + toSql(ZipCode.State) + ", "
            + "Longitude = " + toSql(ZipCode.Longitude) + ", "
            + "Latitude = " + toSql(ZipCode.Latitude) + ", "
            + "Active = " + toSql(ZipCode.Active) + ", "
            + "LastUpdated = " + toSql(ZipCode.LastUpdated)

            + " WHERE ZipCode = " + toSql(ZipCode.ZipCode);
        using (OleDbConnection db = new OleDbConnection())
        {
            string fullFileName;
            string connectionString;

            fullFileName = Path.Combine(Application.StartupPath, mDatabaseFileName);
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFileName;

            db.ConnectionString = connectionString;
            db.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, db))
            {
                cmd.ExecuteNonQuery();
            }
            db.Close();
        }
    }

    private void addMode()
    {
        string sql = "INSERT INTO ZipCodes ("
            + "ZipCode, " + "City, " + "State, " + "Longitude, "
            + "Latitude, " + "Active, " + "LastUpdated" + ") VALUES ("

            + toSql(ZipCode.ZipCode) + ", " 
            + toSql(ZipCode.City) + ", " 
            + toSql(ZipCode.State) + ", "
            + toSql(ZipCode.Longitude) + ", "
            + toSql(ZipCode.Latitude) + ", "
            + toSql(ZipCode.Active) + ", "
            + toSql(ZipCode.LastUpdated)
            + ")";

        using (OleDbConnection db = new OleDbConnection())
        {
            string fullFileName;
            string connectionString;

            fullFileName = Path.Combine(Application.StartupPath, mDatabaseFileName);
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFileName;

            db.ConnectionString = connectionString;
            db.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, db))
            {
                cmd.ExecuteNonQuery();
            }
            db.Close();
        }
    }

    private string toSql(string value)
    {
        return "'" + value.Replace("'", "''") + "'";
    }
    private string toSql(double value)
    {
        return value.ToString();
    }
    private string toSql(DateTime value)
    {
        return "'" + value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
    }
    private string toSql(bool value)
    {
        return value.ToString();
    }
}