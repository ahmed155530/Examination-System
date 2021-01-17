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
    /// Interaction logic for updatequestion.xaml
    /// </summary>
    public partial class updatequestion : Window
    {
        Context context = new Context();
        int userid;
        public updatequestion(int user_id)
        {
            userid = user_id;
            InitializeComponent();
            loadCourses();
            loadQuestions();
        }


        public void loadCourses()
        {
            cmbBox_Courses.ItemsSource = context.Courses.Where(c => c.Instructor_Id == userid).ToList();
            cmbBox_Courses.DisplayMemberPath = "Course_Name";
            cmbBox_Courses.SelectedValue = "Course_Id";
            cmbBox_Courses.SelectedIndex = 0;
        }

        public void loadQuestions()
        {
            //CheckBox check = new CheckBox();
            var QuestionQuery = from q in context.Questions
                                where q.Course_Id == ((Course)cmbBox_Courses.SelectedValue).Course_Id
                                select new { q.Question_Id ,q.Question_Body , q.Question_Type  };
            //dataGrid_Questions.Columns[0].Visibility = Visibility.Collapsed;
            dataGrid_Questions.ItemsSource = QuestionQuery.ToList();
            
            dataGrid_Questions.SelectedIndex = 0;

        }

        private void cmbBox_Courses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadQuestions();
        }

        private void dataGrid_Questions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object Item = dataGrid_Questions.SelectedItem;
            txtBox_QuestionBody.Text = (dataGrid_Questions.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            object Item = dataGrid_Questions.SelectedItem;
            if (Item != null)
            {
                var Text = (dataGrid_Questions.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Question z = context.Questions.ToList().FirstOrDefault(c => c.Question_Id == (Convert.ToInt32(Text)));
                z.Question_Body = txtBox_QuestionBody.Text;
                context.SaveChanges();
                txtBox_QuestionBody.Text = "";
                loadQuestions();
            }
        }

        private void txtBox_QuestionSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var QuestionSearchQuery = from q in context.Questions
                                where q.Course_Id == ((Course)cmbBox_Courses.SelectedValue).Course_Id && q.Question_Body.Contains(txtBox_QuestionSearch.Text)
                                select new { q.Question_Id, q.Question_Body, q.Question_Type };
            dataGrid_Questions.ItemsSource = QuestionSearchQuery.ToList();
            dataGrid_Questions.SelectedIndex = 0;
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    cmb1.ItemsSource = c.Courses.Where(c => c.Instructor_Id == userid).ToList();
        //    cmb1.DisplayMemberPath = "Course_Name";
        //    cmb1.SelectedValue = "Course_Id";
        //    cmb1.SelectedIndex = 0;
        //    loadedQuestion();
        //}

        //public void loadedQuestion()
        //{
        //    var course = ((Course)cmb1.SelectedValue);
        //    int courseid = course.Course_Id;
        //    var question1 = (from Question in c.Questions
        //                     where Question.Course_Id==courseid
        //                     select new
        //                     {
        //                         Question.Question_Id,
        //                         Question.Question_Body,
        //                         Question.Question_Type,
        //                         Question.Course_Id,

        //                     }).ToList();
        //    DataGrid1.ItemsSource = question1;
        //}

        //private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (DataGrid1.SelectedItem != null)
        //    {
        //        var exam = c.Exams.ToList();
        //        object Item = DataGrid1.SelectedItem;
        //        Question_Body.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;
        //    }
        //}

        //private void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    { 
        //    object Item = DataGrid1.SelectedItem;
        //    if (Item != null)
        //    {
        //        var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
        //        Question z = c.Questions.ToList().FirstOrDefault(c => c.Question_Id == (Convert.ToInt32(Text)));
        //        c.Questions.Remove(z);
        //        c.SaveChanges();
        //            MessageBox.Show("Question Deleted successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);
        //            Question_Body.Text = "";
        //            loadedQuestion();
        //    }
        //    }
        //    catch (Exception E)
        //    {
        //        MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    { 
        //    object Item = DataGrid1.SelectedItem;
        //    if (Item != null)
        //    {
        //        var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
        //        Question z = c.Questions.ToList().FirstOrDefault(c => c.Question_Id == (Convert.ToInt32(Text)));

        //        z.Question_Body = Question_Body.Text;


        //        c.SaveChanges();
        //            MessageBox.Show("Question updated successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);

        //            loadedQuestion();
        //    }
        //    }
        //    catch (Exception E)
        //    {
        //        MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}


        //private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    loadedQuestion();
        //}

    }
}
