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
using System.Windows.Shapes;

namespace projectex
{
    /// <summary>
    /// Interaction logic for updatelogin.xaml
    /// </summary>
    public partial class updatelogin : Window
    {
        Context c = new Context();
        public updatelogin()
        {
            InitializeComponent();
            loadedLoginUser();
        }
        public void loadedLoginUser()
        {
            var loginuser1 = (from loginuser in c.Login_User.ToList()
                              select new
                              {
                                  loginuser.ID,
                                  loginuser.UserName,
                                  loginuser.Password,
                                  loginuser.Position,
                                  loginuser.position_id,
                              });
            DataGrid1.ItemsSource = loginuser1;
        }
        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            if (DataGrid1.SelectedItem != null)
            {
                //var loginuser = c.Login_User.ToList();
                object Item = DataGrid1.SelectedItem;
                //Instructor_ID.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                UserName.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;

                Password.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                int cell = int.Parse((DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text);
                if (cell == 1)
                {
                    Position.SelectedIndex = 0;
                }
                else if (cell == 2)
                {
                    Position.SelectedIndex = 1;
                }
                else if (cell == 3)
                {
                    Position.SelectedIndex = 2;
                }
                //Position.ItemsSource = c.Login_User.Select(c => c.Position).Distinct().ToList();
                //Position.SelectedIndex = int.Parse((DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text)-1;
                //Position.DisplayMemberPath = "Position";
                //Position.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                // Branch_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                //Position_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                //var instruct = c.Instructors.ToList();
                //Instructor_Id.ItemsSource = instruct;
                //Instructor_Id.DisplayMemberPath = "Instructor_Name";
                //Instructor_Id.SelectedValue = "Instructor_Id";
                //Instructor_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text) - 1;

                //// login_id.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;
                //var track = c.Tracks.ToList();
                //Track_Id.ItemsSource = track;
                //Track_Id.DisplayMemberPath = "Track_Name";
                //Track_Id.SelectedValue = "Track_Id";
                //Track_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text) - 1;

                // Manager_Id.Text = (DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text;


            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Login_User z = c.Login_User.ToList().FirstOrDefault(c => c.ID == (Convert.ToInt32(Text)));

                z.UserName = UserName.Text;
                z.Password = Password.Text;
                if (Position.SelectedIndex == 0)
                {
                    z.position_id = 1;
                }
                else if (Position.SelectedIndex == 1)
                {
                    z.position_id = 2;
                }
                else if (Position.SelectedIndex == 2)
                {
                    z.position_id = 3;
                }
                //===========================================
                if (z.position_id == 1)
                {
                    Position.SelectedIndex = 0;
                    z.Position = "Manager";

                }
                if (z.position_id == 2)
                {
                    Position.SelectedIndex = 1;
                    z.Position = "Instructor";

                }
                if (z.position_id == 3)
                {
                    Position.SelectedIndex = 2;
                    z.Position = "Student";

                }
                //z.position_id = int.Parse(Position_Id.Text);

                c.SaveChanges();
                    MessageBox.Show("Login user updated successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);

                    loadedLoginUser();
            }

            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Login_User z = c.Login_User.ToList().FirstOrDefault(c => c.ID == (Convert.ToInt32(Text)));
                c.Login_User.Remove(z);
                c.SaveChanges();
                    MessageBox.Show("Login user Deleted successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserName.Text = "";
                    Password.Text = "";
                    Position.SelectedIndex = -1;
                        loadedLoginUser();
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var loginuser1 = (from loginuser in c.Login_User.ToList()
                              where loginuser.UserName.Contains(txtBox_search.Text)
                              select new
                              {
                                  loginuser.ID,
                                  loginuser.UserName,
                                  loginuser.Password,
                                  loginuser.Position,
                                  loginuser.position_id,
                              }).ToList();
            DataGrid1.ItemsSource = loginuser1;
        }

        private void cmbBox_Role_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBox_Role_Search.SelectedIndex == 0)
            { 
            var loginuser1 = (from loginuser in c.Login_User.ToList()
                              where loginuser.position_id == 1
                              select new
                              {
                                  loginuser.ID,
                                  loginuser.UserName,
                                  loginuser.Password,
                                  loginuser.Position,
                                  loginuser.position_id,
                              }).ToList();
            DataGrid1.ItemsSource = loginuser1;
            }

            else if (cmbBox_Role_Search.SelectedIndex == 1)
            {
                var loginuser1 = (from loginuser in c.Login_User.ToList()
                                  where loginuser.position_id == 2
                                  select new
                                  {
                                      loginuser.ID,
                                      loginuser.UserName,
                                      loginuser.Password,
                                      loginuser.Position,
                                      loginuser.position_id,
                                  }).ToList();
                DataGrid1.ItemsSource = loginuser1;
            }

            else if (cmbBox_Role_Search.SelectedIndex == 2)
            {
                var loginuser1 = (from loginuser in c.Login_User.ToList()
                                  where loginuser.position_id == 3
                                  select new
                                  {
                                      loginuser.ID,
                                      loginuser.UserName,
                                      loginuser.Password,
                                      loginuser.Position,
                                      loginuser.position_id,
                                  }).ToList();
                DataGrid1.ItemsSource = loginuser1;
            }

        }
    }
}