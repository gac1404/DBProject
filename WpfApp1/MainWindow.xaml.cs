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

            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Columns.Add("Role", typeof(string));

            DbDataGrid.DataContext = table;

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
            var list = db.read();
        }


    }
}
