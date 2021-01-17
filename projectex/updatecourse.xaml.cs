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
    /// Interaction logic for updatecourse.xaml
    /// </summary>
    public partial class updatecourse : Window
    {
        Context c = new Context();
        public updatecourse()
        {
            InitializeComponent();
        }
        public void loadedCourse()
        {
            var course1 = (from courses in c.Courses.ToList()
                           select new
                           {
                               courses.Course_Id,
                               courses.Course_Name,
                               courses.Course_eDiscription,
                               courses.Max_Degree,
                               courses.Min_Degree,
                               courses.Instructor_Id,
                               courses.Track_Id
                           });
            DataGrid1.ItemsSource = course1;
        }
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            loadedCourse();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            if (DataGrid1.SelectedItem != null)
            {
                var branch = c.Branches.ToList();
                object Item = DataGrid1.SelectedItem;
                //Instructor_ID.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                txtCourseName.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;

                txtCourse_EDiscription.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                txtMax_Degree.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                // Branch_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                txtMin_Degree.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                var instruct = c.Instructors.ToList();
                Instructor_Id.ItemsSource = instruct;
                Instructor_Id.DisplayMemberPath = "Instructor_Name";
                Instructor_Id.SelectedValue = "Instructor_Id";
                //Instructor_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text) - 1;
                int y = int.Parse((DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text);

                Instructor_Id.SelectedItem = c.Instructors.Where(c => c.Instructor_Id == y).FirstOrDefault();
                // login_id.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;
                var track = c.Tracks.ToList();
                Track_Id.ItemsSource = track;
                Track_Id.DisplayMemberPath = "Track_Name";
                Track_Id.SelectedValue = "Track_Id";
                //Track_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text) - 1;
                int z = int.Parse((DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text);

                Track_Id.SelectedItem = c.Tracks.Where(c => c.Track_Id == z).FirstOrDefault();
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
            if(txtCourseName.Text!="" && txtCourse_EDiscription.Text!="" && txtMax_Degree.Text!="" && txtMax_Degree.Text!="")
            {
                if (Item != null)
                {
                    var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                    Course z = c.Courses.ToList().FirstOrDefault(c => c.Course_Id == (Convert.ToInt32(Text)));

                    z.Course_Name = txtCourseName.Text;
                    z.Course_eDiscription = txtCourse_EDiscription.Text;
                    z.Max_Degree = int.Parse(txtMax_Degree.Text);
                    z.Min_Degree = int.Parse(txtMax_Degree.Text);
                    z.Instructor = (Instructor)Instructor_Id.SelectedValue;
                    z.Track = (Track)Track_Id.SelectedValue;
                    c.SaveChanges();
                        MessageBox.Show("Course updated successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);

     
                    loadedCourse();
                }
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
                Course z = c.Courses.ToList().FirstOrDefault(c => c.Course_Id == (Convert.ToInt32(Text)));
                c.Courses.Remove(z);
                c.SaveChanges();
                MessageBox.Show("The Course is deleted", "Deleted Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCourseName.Text = "";
                txtCourse_EDiscription.Text = "";
                txtMax_Degree.Text = "";
                txtMin_Degree.Text = "";
                    Instructor_Id.SelectedIndex = -1;
                    Track_Id.SelectedIndex = -1;
                    loadedCourse();

            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

