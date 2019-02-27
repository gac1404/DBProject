using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;


class DBConnect
{
    private List<string> roles = new List<string>
    {
        "ADMIN",
        "USER",
        "REPORTER",
    };


    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public List<string> Roles { get => roles;}



    //Constructor
    public DBConnect()
    {
        Initialize();
    }
    
    //Initialize values
    private void Initialize()
    {
        server = "sql7.freemysqlhosting.net";
        database = "sql7280716";
        uid = "sql7280716";
        password = "MJ3gxIA6Xi";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

      //  connectionString = "DataSource=mysql8.db4free.net:3307; UserID=gac1404; password=dupa1234; database=person";

        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            MessageBox.Show("It Works!!");
            return true;
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
                default:
                    MessageBox.Show("error num: " + ex.Number.ToString());
                    break;

            }
            return false;
        }
    }

    //Close connection
    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    public void insert(string username , string password , string role)
    {
        MySqlCommand comm = connection.CreateCommand();
        comm.CommandText = "INSERT INTO Users(username , password , role) VALUES(@username, @password , @role)";
        comm.Parameters.AddWithValue("@username", username);
        comm.Parameters.AddWithValue("@password", password);
        comm.Parameters.AddWithValue("@role", role);
        comm.ExecuteNonQuery();
    }

    public List<Message> read()
    {
  
        List<Message> messageList = new List<Message>();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM `Users`";

        MySqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            Message msg = new Message();

            msg.id       = reader.GetInt32(0);
            msg.username = reader.GetString(1);
            msg.password = reader.GetString(2);
            msg.role     = reader.GetString(3);

            messageList.Add(msg);
        }

        return messageList;
    }

}