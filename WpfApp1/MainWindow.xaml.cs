using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Windows.Shapes;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnect db = new DBConnect();

        public MainWindow()
        {
            InitializeComponent();

            RoleComboBox.ItemsSource = db.Roles;
            RoleComboBox.SelectedIndex = 0;



        }

        private void AddButton_Click(object sender, RoutedEventArgs e)//current name is difrent!!!
        {
            db.OpenConnection();
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            var item = RoleComboBox.SelectedItem as string;
            db.insert(UsernameTextBox.Text, PasswordTextBox.Text, item);
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            var sda = db.readMySqlDataAdapter();

            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DbDataGrid.ItemsSource = ds.Tables[0].DefaultView;
            }


        }


    }
}
