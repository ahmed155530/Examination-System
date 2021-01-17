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
    /// Interaction logic for DesignExam.xaml
    /// </summary>
    public partial class DesignExam : Window
    {
        Context context = new Context();
        int user_id;
        public DesignExam(int userid)
        {
            user_id = userid;
            InitializeComponent();
            ShowCoursesInDesign();
           
        }
        private void ShowCoursesInDesign()
        {
            
            cmbBoxCourses.ItemsSource=context.Courses.Where(c => c.Instructor_Id == user_id).ToList();
            cmbBoxCourses.DisplayMemberPath = "Course_Name";
            cmbBoxCourses.SelectedValue = "Course_Id";
            cmbBoxCourses.SelectedIndex = 0;
        }

        private void collectExamInfo()
        {
            try
            { 
            if(ExamName_txtBox.Text!=""&& MCQDegree_txtBox.Text!=""&& TandFDegree_txtBox.Text!=""&& TextDegree_txtBox.Text!="" && cmbBoxCourses.SelectedIndex!=-1)
            {
                context.Exams.Add(new Exam
                {
                    Exam_Name = ExamName_txtBox.Text,
                    MCQ_Degree = int.Parse(MCQDegree_txtBox.Text),
                    T_F_Degree = int.Parse(TandFDegree_txtBox.Text),
                    Text_Degree = int.Parse(TextDegree_txtBox.Text),
                    Course_Id = ((Course)cmbBoxCourses.SelectedValue).Course_Id
                });
                context.SaveChanges();
                    MessageBox.Show("Exam added successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    ExamName_txtBox.Text = "";
                MCQDegree_txtBox.Text = "";
                TandFDegree_txtBox.Text = "";
                TextDegree_txtBox.Text = "";
            }
            else
            {
                MessageBox.Show("Please , Enter all the fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddExam_Click(object sender, RoutedEventArgs e)
        {

                collectExamInfo();
        }

        private void PickExam_Click(object sender, RoutedEventArgs e)
        {
            PickExam pick = new PickExam(user_id);
            pick.Show();
            this.Close();
        }

     
    }
}
