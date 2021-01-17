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
    /// Interaction logic for PickExam.xaml
    /// </summary>
    public partial class PickExam : Window
    {
        Context context = new Context();
        List<Question> questions = new List<Question>();
        int count;
        int user_id;
        public PickExam(int userid)
        {
            
            user_id = userid;
            count = 0;
            InitializeComponent();
          
            ShowCourses();
            ShowExams();
            showQuestions();

           
        }

        public void ShowExams()
        {
            try
            { 
            var query =
              (from e in context.Exams
               where e.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id
               select e).ToList();
            Exams_cmbBox.ItemsSource = query;
            Exams_cmbBox.DisplayMemberPath = "Exam_Name";
            Exams_cmbBox.SelectedValue = "Exam_Id";
            Exams_cmbBox.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void ShowCourses()
        {
            Courses_cmbBox.ItemsSource = context.Courses.Where(c => c.Instructor_Id == user_id).ToList();
            Courses_cmbBox.DisplayMemberPath = "Course_Name";
            Courses_cmbBox.SelectedValue = "Course_Id";
            Courses_cmbBox.SelectedIndex = 0;
        }


        public void showQuestions()
        {
            try
            { 
            if (Courses_cmbBox.SelectedItem != null && Exams_cmbBox.SelectedItem != null)
            {
                var query =
                  (from q in context.Questions
                   where q.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id
                   select q).ToList();
                questions_cmbBox.ItemsSource = query;
                questions_cmbBox.DisplayMemberPath = "Question_Body";
                questions_cmbBox.SelectedValue = "Question_Id";
                questions_cmbBox.SelectedIndex = 0;



                var MCQquery =
                       from q in context.Exam_Question
                       where q.Exam.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id &&
                       q.Exam.Exam_Id == ((Exam)Exams_cmbBox.SelectedValue).Exam_Id &&
                       q.Question.type == 1
                       select new { q.Question_Id, q.Question.Question_Body, q.Question.Question_Type, q.Exam.MCQ_Degree };

                datagrid_showquestionsMCQ.ItemsSource = MCQquery.ToList();
                datagrid_showquestionsMCQ.SelectedIndex = 0;




                var TFquery =
                       from q in context.Exam_Question
                       where q.Exam.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id &&
                       q.Exam.Exam_Id == ((Exam)Exams_cmbBox.SelectedValue).Exam_Id &&
                       q.Question.type == 2
                       select new { q.Question_Id, q.Question.Question_Body, q.Question.Question_Type, q.Exam.T_F_Degree };

                datagrid_showquestionsTF.ItemsSource = TFquery.ToList();
                //datagrid_showquestionsTF.DisplayMemberPath = "Question_Body";
                //datagrid_showquestionsTF.SelectedValue = "Question_Id";
                datagrid_showquestionsTF.SelectedIndex = 0;


                var Textquery =
                       from q in context.Exam_Question
                       where q.Exam.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id &&
                       q.Exam.Exam_Id == ((Exam)Exams_cmbBox.SelectedValue).Exam_Id &&
                       q.Question.type == 3
                       select new { q.Question_Id, q.Question.Question_Body, q.Question.Question_Type, q.Exam.Text_Degree };


                datagrid_showquestionsText.ItemsSource = Textquery.ToList();
                //datagrid_showquestionsText.DisplayMemberPath = "Question_Body";
                //datagrid_showquestionsText.SelectedValue = "Question_Id";
                datagrid_showquestionsText.SelectedIndex = 0;
            }
   
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        // public void AddQuestionToExam()
        // {
        //     int type = ((Question)questions_cmbBox.SelectedValue).type;
        //      int x = 0;
        //     if (questions_cmbBox.SelectedValue != null && Exams_cmbBox.SelectedValue != null)
        //     {
        //         if (type == 1)
        //         {
        //                 x = ((Exam)Exams_cmbBox.SelectedValue).MCQ_Degree;
        //         }
        //         else if (type == 2)
        //         {
        //             x = ((Exam)Exams_cmbBox.SelectedValue).T_F_Degree;
        //         }
        //         else if (type == 3)
        //         {
        //             x = ((Exam)Exams_cmbBox.SelectedValue).Text_Degree;
        //         }
        //         if ((count + x) <= ((Course)Courses_cmbBox.SelectedValue).Max_Degree) 
        //         {
        //             questions.Add(((Question)questions_cmbBox.SelectedValue));
        //         }

        //    }
        //}




        public void AddQuestionToExam()
        {
            try
            { 
            int MCQCouter = datagrid_showquestionsMCQ.Items.Count;
            int TFCouter = datagrid_showquestionsTF.Items.Count;
            int TextCouter = datagrid_showquestionsText.Items.Count;

            int MCQDegree = ((Exam)(Exams_cmbBox.SelectedValue)).MCQ_Degree;
            int TFDegree = ((Exam)(Exams_cmbBox.SelectedValue)).T_F_Degree;
            int TextDegree = ((Exam)(Exams_cmbBox.SelectedValue)).Text_Degree;

            int type = ((Question)questions_cmbBox.SelectedValue).type;
            int x = 0;


            if (questions_cmbBox.SelectedValue != null && Exams_cmbBox.SelectedValue != null)
            {
                if (type == 1)
                {
                    x = ((Exam)Exams_cmbBox.SelectedValue).MCQ_Degree;
                }
                else if (type == 2)
                {
                    x = ((Exam)Exams_cmbBox.SelectedValue).T_F_Degree;
                }
                else if (type == 3)
                {
                    x = ((Exam)Exams_cmbBox.SelectedValue).Text_Degree;
                }

                if (((MCQCouter * MCQDegree) + (TFCouter * TFDegree) + (TextCouter * TextDegree) + x) <= ((Course)Courses_cmbBox.SelectedValue).Max_Degree)
                {
                    int Question_Id = ((Question)questions_cmbBox.SelectedValue).Question_Id;
                    var query = context.Exam_Question.Where(c => c.Question_Id == Question_Id&&c.Exam_Id==((Exam)Exams_cmbBox.SelectedValue).Exam_Id).FirstOrDefault();
                    if(query==null)
                    {
                        context.Exam_Question.Add(new Exam_Question
                        {
                            Exam_Id = ((Exam)Exams_cmbBox.SelectedValue).Exam_Id,
                            Question_Id = ((Question)questions_cmbBox.SelectedValue).Question_Id,
                        });
                        context.SaveChanges();
                        MessageBox.Show("The Question is added Successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                        x = 0;
                    }
                    else
                    {
                        MessageBox.Show("This Question is already added.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The total degrees of exam exceeds the max degree of the course", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Choose an exam and a question to add", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }





                //    //if (questions_cmbBox.SelectedValue != null && Exams_cmbBox.SelectedValue != null)
                //    //{
                //    //    context.Exam_Question.Add(new Exam_Question
                //    //    {
                //    //        Exam_Id = ((Exam)Exams_cmbBox.SelectedValue).Exam_Id,
                //    //        Question_Id = ((Question)questions_cmbBox.SelectedValue).Question_Id,
                //    //    });
                //    //    if (((MCQCouter* MCQDegree)+(TFCouter* TFDegree)+(TextCouter* TextDegree)) <= ((Course)Courses_cmbBox.SelectedValue).Max_Degree)
                //    //    {
                //    //        context.SaveChanges();
                //    //        MessageBox.Show("The Question is added Successfully");
                //    //    }
                //    //    else
                //    //    {
                //    //        MessageBox.Show("The total degrees of exam exceeds the max degree of the course");
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("Please Choose an exam and a question to add");
                //    //}














                //    //if (questions_cmbBox.SelectedValue != null && Exams_cmbBox.SelectedValue != null)
                //    //{
                //    //    context.Exam_Question.Add(new Exam_Question
                //    //    {
                //    //        Exam_Id = ((Exam)Exams_cmbBox.SelectedValue).Exam_Id,
                //    //        Question_Id = ((Question)questions_cmbBox.SelectedValue).Question_Id,
                //    //    });
                //    //    if (((datagrid_showquestionsMCQ.Items.Count-1) *((Exam)(Exams_cmbBox.SelectedValue)).MCQ_Degree
                //    //        + ((datagrid_showquestionsTF.Items.Count-1)*((Exam)(Exams_cmbBox.SelectedValue)).T_F_Degree)
                //    //        + ((datagrid_showquestionsText.Items.Count-1)*((Exam)(Exams_cmbBox.SelectedValue)).T_F_Degree)) <= (((Course)Courses_cmbBox.SelectedValue).Max_Degree))
                //    //    {
                //    //        context.SaveChanges();
                //    //        MessageBox.Show("The Question is added Successfully");
                //    //    }
                //    //    else
                //    //    {
                //    //        MessageBox.Show("The total degrees of exam exceeds the max degree of the course");
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("Please Choose an exam and a question to add");
                //    //}

                //    //if(((datagrid_showquestionsMCQ.Items.Count-1)*((Exam)(Exams_cmbBox.SelectedValue)).MCQ_Degree)
                //    //    + ((datagrid_showquestionsTF.Items.Count-1)* ((Exam)(Exams_cmbBox.SelectedValue)).T_F_Degree)
                //    //    + ((datagrid_showquestionsText.Items.Count-1) * ((Exam)(Exams_cmbBox.SelectedValue)).T_F_Degree) <= ((Course)Courses_cmbBox.SelectedValue).Max_Degree)
                //    //{           
                //    //    if (questions_cmbBox.SelectedValue != null && Exams_cmbBox.SelectedValue!=null)
                //    //    {
                //    //        context.Exam_Question.Add(new Exam_Question
                //    //    {
                //    //        Exam_Id = ((Exam)Exams_cmbBox.SelectedValue).Exam_Id,
                //    //        Question_Id = ((Question)questions_cmbBox.SelectedValue).Question_Id,
                //    //    });
                //    //    context.SaveChanges();
                //    //    MessageBox.Show("The Question is added Successfully");
                //    //    }
                //    //    else
                //    //    {
                //    //        MessageBox.Show("Please Choose an exam and a question to add");
                //    //    }

                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("The total degrees of exam exceeds the max degree of the course");
                //    //}
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void QuestionSelect_btn_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionToExam();
            showQuestions();
        }

        private void Courses_cmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowExams();
            showQuestions();
        }

        private void Exams_cmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showQuestions();
        }

        private void txtBox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
        var query =
            (from q in context.Questions
            where q.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id &&
            q.Question_Body.Contains(txtBox_search.Text)
            select q).ToList();
        questions_cmbBox.ItemsSource = query;
        questions_cmbBox.DisplayMemberPath = "Question_Body";
        questions_cmbBox.SelectedValue = "Question_Id";
        questions_cmbBox.SelectedIndex = 0;

        }

        private void cmbBox_search_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBox_search_Type.SelectedIndex == 0)
            {
                var query =
                  (from q in context.Questions
                   where q.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id && q.type == 1
                   select q).ToList();
                questions_cmbBox.ItemsSource = query;
                questions_cmbBox.DisplayMemberPath = "Question_Body";
                questions_cmbBox.SelectedValue = "Question_Id";
                questions_cmbBox.SelectedIndex = 0;
            }
            else if(cmbBox_search_Type.SelectedIndex == 1)
            {
                var query =
                  (from q in context.Questions
                   where q.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id && q.type == 2
                   select q).ToList();
                questions_cmbBox.ItemsSource = query;
                questions_cmbBox.DisplayMemberPath = "Question_Body";
                questions_cmbBox.SelectedValue = "Question_Id";
                questions_cmbBox.SelectedIndex = 0;
            }
            else if(cmbBox_search_Type.SelectedIndex == 2)
            {
                var query =
                    (from q in context.Questions
                     where q.Course_Id == ((Course)Courses_cmbBox.SelectedValue).Course_Id && q.type == 3
                     select q).ToList();
                questions_cmbBox.ItemsSource = query;
                questions_cmbBox.DisplayMemberPath = "Question_Body";
                questions_cmbBox.SelectedValue = "Question_Id";
                questions_cmbBox.SelectedIndex = 0;
            }
        }
    }
}

