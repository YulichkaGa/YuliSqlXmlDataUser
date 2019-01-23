using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    public string id { get; set; }
    public string Mail { get; set; }
    public string Birthday { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public List<Users> UserList;
    public List<Users> UserListXml;
    public const string ConSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\97252\Documents\Visual Studio 2015\WebSites\Yulik\App_Data\UsersYulik.mdf;Integrated Security=True";
    private bool firstEntry;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            id = "id";
            Mail = "Mail";
            Birthday = "Birthday";
            Fname = "First name";
            Lname = "Last name";
            Phone = "Phone";
            Gender = "Gender-(Male/Female)";
            UserList = new List<Users>();
            lblM.Visible = false;
            lblM.Text = "Fill all colums!!!";
            firstEntry = false;

            if (IsPostBack)
            {
            }
            else
            {
                GetDataList();
            }
        }
        catch
        {

        }

    }

    private void GetDataList()
    {
        if (ChSql.Checked)
        {
            dlsUsers.DataSource =GetUserListFromSql();

        }
        else
        {
            //dlsUsers.DataSource = InsertDataToXml();
            dlsUsers.DataSource = getFromXMl();

        }
        dlsUsers.DataBind();
    }

    public List<Users> getFromXMl()
    {
        List<Users> userList = new List<Users>();
        var XMLLoadfullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("App_Data", "XMLFile.xml"));



        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(XMLLoadfullPath);

        XmlNodeList usernodes = xmldoc.SelectNodes("Users/User");
        foreach (XmlNode usr in usernodes)
        {

            var user = new Users();
            user.id = usr["id"].InnerText;
            user.Mail = usr["Mail"].InnerText;
            user.Birthday = usr["Birthday"].InnerText;
            user.FName = usr["FirstName"].InnerText;
            user.LName = usr["LastName"].InnerText;
            user.Phone = usr["Phone"].InnerText;
            user.Gender = usr["Gender"].InnerText;
            userList.Add(user);
        }

        return userList;
    }




    public List<Users> GetUserListFromSql()
    {

        using (var connection = new SqlConnection(ConSTR))
        {
            connection.Open();
            string sql = "SELECT * FROM Users";
            using (var command = new SqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        var user = new Users();
                        user.Mail = reader["Mail"].ToString();
                        user.Birthday = reader["Birthday"].ToString();
                        user.FName = reader["Firstname"].ToString();
                        user.LName = reader["Firstname"].ToString();
                        user.Phone = reader["Phone"].ToString();
                        user.Gender = reader["Gender"].ToString();

                        UserList.Add(user);
                    }

                    return UserList;
                }
            }
        }
    }


    private List<Users> InsertDataToXml()
    {

        var XMLLoadfullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.Combine("App_Data", "XMLFile.xml"));
        XDocument doc = XDocument.Load(XMLLoadfullPath);
        XElement users = doc.Element("Users");
        users.Add(new XElement("User",

                   new XElement("id", new Guid()),
                   new XElement("Mail", txtMail.Text),
                   new XElement("Birthday", txtBirthday.Text),
                   new XElement("FirstName", txtFName.Text),
                   new XElement("LastName", txtLName.Text),
                   new XElement("Phone", txtPhone.Text),
                   new XElement("Gender", drpGender.Text)
                   ));

        var user = new Users();
        user.Mail = txtMail.Text;
        user.Birthday = txtBirthday.Text;
        user.FName = txtFName.Text;
        user.LName = txtLName.Text;
        user.Phone = txtPhone.Text;
        user.Gender = drpGender.Text;
        UserList.Add(user);

        doc.Save(XMLLoadfullPath);
        return UserList;

    }

    public void InsertDataToDb()
    {
        try
        {
           
            System.Data.SqlClient.SqlConnection sqlConnection1 =
        new System.Data.SqlClient.SqlConnection(ConSTR);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Users (Mail,Birthday,Firstname,Lastname,Phone,Gender)" +
               " VALUES (" + "'" + txtMail.Text + "','" + txtBirthday.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + txtPhone.Text + "','" + drpGender.Text + "')";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            //var user = new Users();
            //user.Mail = txtMail.Text;
            //user.Birthday = txtBirthday.Text;
            //user.FName = txtFName.Text;
            //user.LName = txtLName.Text;
            //user.Phone = txtPhone.Text;
            //user.Gender = drpGender.Text;
            //UserList.Add(user);
        }
        catch(Exception etr1)
        {

        }

        

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtBirthday.Text != "" && txtFName.Text != "" && txtLName.Text != "" && txtMail.Text != "" && drpGender.Text != "")
            {
                if (ChSql.Checked)
                {
                    InsertDataToDb();

                }
                else
                {
                    dlsUsers.DataSource = InsertDataToXml();

                }
                txtBirthday.Text = txtFName.Text = txtLName.Text = txtMail.Text = drpGender.Text = txtPhone.Text = drpGender.Text = "";

                GetDataList();


                dlsUsers.DataBind();
            }
            else
            {
                lblM.Visible = true;
            }
        }
        catch { }
    }
    object clickBox = null;

    protected void ChSql_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChSql.Checked)
            {

                ChSql.Checked = true;
                ChXML.Checked = false;
            }
            else
            {
                ChSql.Checked = false;
                ChXML.Checked = true;


            }
            GetDataList();
        }
        catch { }
    }

    protected void ChXML_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChXML.Checked)
            {


                ChSql.Checked = false;
                ChXML.Checked = true;
            }
            else
            {
                ChSql.Checked = true;
                ChXML.Checked = false;
            }


            GetDataList();
        }
        catch { }

    }
}
