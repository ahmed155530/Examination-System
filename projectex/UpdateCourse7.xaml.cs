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
    /// Interaction logic for UpdateCourse7.xaml
    /// </summary>
    public partial class UpdateCourse7 : Window
    {
        Context c = new Context();
        public UpdateCourse7()
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
            if (DataGrid1.SelectedItem != null)
            {
                var branch = c.Branches.ToList();
                object Item = DataGrid1.SelectedItem;
                //Instructor_ID.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Course_Name.Text= (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;

                Course_EDiscription.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                Max_Degree.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                // Branch_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                Min_Degree.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                var instruct = c.Instructors.ToList();
                Instructor_Id.ItemsSource = instruct;
                Instructor_Id.DisplayMemberPath = "Instructor_Name";
                Instructor_Id.SelectedValue = "Instructor_Id";
                Instructor_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text) - 1;
                
                // login_id.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;
                var track = c.Tracks.ToList();
                Track_Id.ItemsSource = track;
                Track_Id.DisplayMemberPath = "Track_Name";
                Track_Id.SelectedValue = "Track_Id";
                Track_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text)-1;
                
                // Manager_Id.Text = (DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text;


            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Course z = c.Courses.ToList().FirstOrDefault(c => c.Course_Id == (Convert.ToInt32(Text)));

                z.Course_Name = Course_Name.Text;
                z.Course_eDiscription = Course_EDiscription.Text;
                z.Max_Degree = int.Parse(Max_Degree.Text);
                z.Min_Degree = int.Parse(Min_Degree.Text);
                z.Instructor = (Instructor)Instructor_Id.SelectedValue;
                z.Track = (Track)Track_Id.SelectedValue;
                c.SaveChanges();
                loadedCourse();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Course z = c.Courses.ToList().FirstOrDefault(c => c.Course_Id == (Convert.ToInt32(Text)));
                c.Courses.Remove(z);
                c.SaveChanges();
                loadedCourse();

            }

        }
    }
}
