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
    /// Interaction logic for assignstudenttoexam.xaml
    /// </summary>
    public partial class assignstudenttoexam : Window
    {
        Context context = new Context();
        int user_id;
        public assignstudenttoexam(int userid)
        {
            user_id = userid;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                gridstudent.ItemsSource = (from students in context.Students
                                           select new
                                           {
                                               students.Student_Id,
                                               students.Student_Name,
                                               students.student_code,
                                               students.Branch.Branch_Name,
                                               students.Track.Track_Name,
                                               students.Intake.Intake_Number

                                           }).ToList();
                cmb2.ItemsSource = context.Exams.Where(c => c.Course.Instructor_Id == user_id).ToList();
                cmb2.DisplayMemberPath = "Exam_Name";
                cmb2.SelectedValue = "Exam_Id";
                cmb2.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object Item = gridstudent.SelectedItem;
                int stdid = int.Parse((gridstudent.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text);

                var exam = ((Exam)cmb2.SelectedValue);
                int examid = exam.Exam_Id;

                var query = context.Student_Degree.Where(c => c.Exam_Id == examid && c.Student_Id == stdid).FirstOrDefault();
                if (query == null)
                {
                    Student_Degree stdeg = new Student_Degree
                    {
                        Exam_Id = examid,
                        Student_Id = stdid,
                        Degree = 0,
                        isenterd = 0
                    };
                    context.Student_Degree.Add(stdeg);
                    context.SaveChanges();
                    MessageBox.Show("assigned", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("assigned before", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void gridstudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
