// Course: CIT 255
// Assignment: Laboratory 07
// Author: Instructor

using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.OleDb;

public partial class frmMain : Form
{
    private const string mDatabaseFileName = "zipCodes.accdb";
    private string mFullTextFileName;
    
    // private OleDbConnection mDB = new OleDbConnection();

    public ArrayList mZipCodeResultsAL = new ArrayList();
    
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }

    public frmMain()
    {
        InitializeComponent();
    }

    //private void opendatabaseconnection()
    //{
    //    string fullfilename;
    //    string connectionstring;

    //    fullfilename = path.combine(application.startuppath, mdatabasefilename);
    //    connectionstring = "provider=microsoft.ace.oledb.12.0;data source=" + fullfilename;

    //    mdb.connectionstring = connectionstring;
    //    mdb.open();
    //}

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        /*
        clsZipCode soughtZipCode = null;
        clsZipCode currentZipCode = null;

        // Confirm that an item in the list box has been selected.

        if (lstZipCodes.SelectedItems.Count == 0)
        {
            return;
        }

        // Ask for confirmation and then delete the Zip Code.

        if (messageBoxYesNo("Are you sure you want to delete this Zip Code?") != DialogResult.Yes)
        {
            return;
        }

        int index = lstZipCodes.SelectedIndex;
        soughtZipCode = (clsZipCode)mZipCodeResultsAL[index];

        // Remove the zip code from the results array list currently displayed in the list box.

        mZipCodeResultsAL.RemoveAt(index);

        // Locate the zip code within the master array list, then remove it.

        for (int i = 0; i < mZipCodeMasterAL.Count; i++)
        {
            currentZipCode = (clsZipCode)mZipCodeMasterAL[i];

            if (currentZipCode.ZipCode == soughtZipCode.ZipCode)
            {
                mZipCodeMasterAL.RemoveAt(i);
                break;
            }
        }

        loadListBox();*/
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        loadListBox();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        frmAddUpdate addUpdate = new frmAddUpdate();
        addUpdate.Mode = "Add";
        addUpdate.ZipCode = new clsZipCode();

        if (addUpdate.ShowDialog(this) == DialogResult.OK)
        {
            loadListBox();
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Confirm that an item in the list box has been selected.

        if (lstZipCodes.SelectedItems.Count == 0)
        {
            return;
        }

        // Show the update dialog.

        frmAddUpdate addUpdate = new frmAddUpdate();
        addUpdate.Mode = "Update";

        int index = lstZipCodes.SelectedIndex;
        addUpdate.ZipCode = (clsZipCode)mZipCodeResultsAL[index];

        if (addUpdate.ShowDialog(this) == DialogResult.OK)
        {
            loadListBox();
        }
    }

 
    private void loadListBox()
    {
        string formattedOutput;
        clsZipCode currentZipCode;
        string searchFor;
        
        // First create a new ArrayList containing all matching zip code objects.

        mZipCodeResultsAL.Clear();

        searchFor = txtSearchFor.Text.ToUpper();

        // Finally load the listbox with the list of matching zip codes.

        lstZipCodes.Items.Clear();
        string sql = "SELECT * FROM ZipCodes ORDER BY City, State, ZipCode";

        if (searchFor.Length != 0) 
        {
            sql = "SELECT * FROM ZipCodes " 
                + "WHERE ZipCode = " + toSql(searchFor) + " OR City LIKE " + toSql(searchFor)
                + "ORDER BY City, State, ZipCode";
        }

        using (OleDbConnection db = new OleDbConnection())
        {
            string fullFileName;
            string connectionString;

            fullFileName = Path.Combine(Application.StartupPath, mDatabaseFileName);
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFileName;

            db.ConnectionString = connectionString;
            db.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, db))
            using (OleDbDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read() == true)
                {
                    clsZipCode zipCode = new clsZipCode();
                    zipCode.ZipCode = (string)rdr["ZipCode"];
                    zipCode.State = (string)rdr["State"];
                    zipCode.City = (string)rdr["City"];
                    zipCode.Longitude = (double)rdr["Longitude"];
                    zipCode.Latitude = (double)rdr["Latitude"];
                    zipCode.LastUpdated = (DateTime)rdr["LastUpdated"];
                    zipCode.Active = (bool)rdr["Active"];

                    mZipCodeResultsAL.Add(zipCode);
                }
            }
            db.Close();
        }

        for (int i = 0; i < mZipCodeResultsAL.Count; i++)
        {
            if (i == 100)
            {
                messageBoxOK("Displaying the first 100 results.");
                break;
            }
            currentZipCode = (clsZipCode)mZipCodeResultsAL[i];
            formattedOutput = currentZipCode.ZipCode.PadRight(10);
            formattedOutput += currentZipCode.City.PadRight(25);
            formattedOutput += currentZipCode.State.PadRight(5);
            formattedOutput += currentZipCode.Longitude.ToString("##0.000").PadLeft(7);
            formattedOutput += currentZipCode.Latitude.ToString("##0.000").PadLeft(9);

            lstZipCodes.Items.Add(formattedOutput);
        }
    }

    private void messageBoxOK(string msg)
    {
        MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private DialogResult messageBoxYesNo(string msg)
    {
        DialogResult button;
        button = MessageBox.Show(msg, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        return button;
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