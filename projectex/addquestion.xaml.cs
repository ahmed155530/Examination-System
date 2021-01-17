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
    /// Interaction logic for addquestion.xaml
    /// </summary>
    public partial class addquestion : Window
    {
        List<Course> courses;
        Context context = new Context();
        int user_id;
        public addquestion(int userid)
        {
        
            user_id = userid;
            InitializeComponent();
            ShowCourses();
            showMCQ();
            showTandFQues();
            showTextQues();
        
        }

      
        private void ShowCourses()
        {
            try
            { 
            Courses_CmbBox.ItemsSource = context.Courses.Where(c => c.Instructor_Id == user_id).ToList();
            Courses_CmbBox.DisplayMemberPath = "Course_Name";
            Courses_CmbBox.SelectedValue = "Course_Id";
            Courses_CmbBox.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showMCQ()
        {
            try
            { 
            var query =
              (from s in context.Questions
               where (s.type == 1 && s.Course_Id == ((Course)Courses_CmbBox.SelectedValue).Course_Id)
               select s).ToArray();
            MCQ_CmbBox.ItemsSource = query;
            MCQ_CmbBox.DisplayMemberPath = "Question_Body";
            MCQ_CmbBox.SelectedValue = "Question_Id";
            MCQ_CmbBox.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showTandFQues()
        {
            try
            {
                var query =
                  (from s in context.Questions
                   where (s.type == 2 && s.Course_Id == ((Course)Courses_CmbBox.SelectedValue).Course_Id)
                   select s).ToList();
                TandFQues_CmbBox.ItemsSource = query;
                TandFQues_CmbBox.DisplayMemberPath = "Question_Body";
                TandFQues_CmbBox.SelectedValue = "Question_Id";
                TandFQues_CmbBox.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showTextQues()
        {
            try
            { 
            var query =
              (from s in context.Questions
               where (s.type == 3 && s.Course_Id == ((Course)Courses_CmbBox.SelectedValue).Course_Id)
               select s).ToList();
            TextQues_CmbBox.ItemsSource = query;
            TextQues_CmbBox.DisplayMemberPath = "Question_Body";
            TextQues_CmbBox.SelectedValue = "Question_Id";
            TextQues_CmbBox.SelectedIndex = 0;
        }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
}

        private void AddMCQQuestion()
        {
            try
            { 

            if(MCQBody_txtBox.Text!="")
            {
                Question question = new Question();
                question.Course_Id = ((Course)Courses_CmbBox.SelectedValue).Course_Id;
                question.Question_Body = MCQBody_txtBox.Text;
                question.Question_Type = "MCQ";
                question.type = 1;
                context.Questions.Add(question);
                context.SaveChanges();
                MessageBox.Show("The Question is added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                MCQBody_txtBox.Text = "";
            }
            else
            {
                MessageBox.Show("Please , Enter a question!!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

}

        private void AddMCQOption()
        {
            try
            {
                if (MCQOption_txtBox.Text != "")
                {
                    MC_Question mc_Question = new MC_Question();
                    mc_Question.Question_Id = ((Question)MCQ_CmbBox.SelectedValue).Question_Id;
                    mc_Question.MCQ_Option = MCQOption_txtBox.Text;
                    if (IsTrue_CmbBox.SelectedIndex != -1)
                    {


                        if (IsTrue_CmbBox.SelectedIndex == 0)
                        {
                            mc_Question.MCQ_Istrue = true;
                        }
                        else if (IsTrue_CmbBox.SelectedIndex == 1)
                        {
                            mc_Question.MCQ_Istrue = false;
                        }


                        context.MC_Question.Add(mc_Question);
                        context.SaveChanges();
                        MessageBox.Show("The Option is added Successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                        MCQOption_txtBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Please , Choose if the option is True or Not!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    }
                else
                {
                    MessageBox.Show("Please , Enter an option!!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            
                    }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
}

        private void AddTandFQuestion()
        {
            try
            { 
            if (TandFBody_txtBox.Text != "")
            {
                Question question = new Question();
                question.Course_Id = ((Course)Courses_CmbBox.SelectedValue).Course_Id;
                question.Question_Body = TandFBody_txtBox.Text;
                question.Question_Type = "True and False";
                question.type = 2;
                context.Questions.Add(question);
                context.SaveChanges();
                MessageBox.Show("The Question is added Successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                TandFBody_txtBox.Text = "";
            }
            else
            {
                MessageBox.Show("please , Enter A Question!!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
}

        private void addCorrectAnswer()
        {
            try
            { 
     
                TrueAndFalse_Question trueAndFalse_Question = new TrueAndFalse_Question();
                trueAndFalse_Question.Question_Id = ((Question)TandFQues_CmbBox.SelectedValue).Question_Id;
                if (IsTrue2_CmbBox.SelectedIndex == 0)
                {
                    trueAndFalse_Question.TAndF_Correct_Answer = true;
                }
                else if (IsTrue2_CmbBox.SelectedIndex == 1)
                {
                    trueAndFalse_Question.TAndF_Correct_Answer = false;
                }              
                context.TrueAndFalse_Question.Add(trueAndFalse_Question);
                context.SaveChanges();
                MessageBox.Show("The answer is added successfully.", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                TextQues_txtBox.Text = "";
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addTextQuestion()
        {
            try
            { 
            if (TextQues_txtBox.Text != "")
            {
                Question question = new Question();
                question.Course_Id = ((Course)Courses_CmbBox.SelectedValue).Course_Id;
                question.Question_Body = TextQues_txtBox.Text;
                question.Question_Type = "Text";
                question.type = 3;
                context.Questions.Add(question);               
                context.SaveChanges();
                MessageBox.Show("The Question is added succesfully", "Succefully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                TextQues_txtBox.Text = "";
            }
            else
            {
                MessageBox.Show("please , Enter A Question!!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AddTextCorrectAnswer()
        {
            try
            {
                if (TextQuesCorrectAnswer_txtBox.Text != "" && TextQues_CmbBox.SelectedValue != null)
                {
                    Text_Question text_Question = new Text_Question();
                    text_Question.Question_Id = ((Question)TextQues_CmbBox.SelectedValue).Question_Id;
                    text_Question.Text_Correct_Answer = TextQuesCorrectAnswer_txtBox.Text;
                    context.Text_Question.Add(text_Question);
                    context.SaveChanges();
                    MessageBox.Show("The answer is added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    TextQuesCorrectAnswer_txtBox.Text = "";
                }
                else
                {
                    MessageBox.Show("please , select a question and Enter A correct Answer!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            
                    }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
}
        private void Button_Click_addAnswer(object sender, RoutedEventArgs e)
        {
            AddTextCorrectAnswer();
        }

        private void btn_addOption(object sender, RoutedEventArgs e)
        {
            AddMCQOption();
            context.SaveChanges();
        }

        private void btn_addMCQ(object sender, RoutedEventArgs e)
        {
            AddMCQQuestion();
            showMCQ();
        }

        private void btn_addTandFQ(object sender, RoutedEventArgs e)
        {
            AddTandFQuestion();
            showTandFQues();
        }

        private void btn_addCorrectAnswer(object sender, RoutedEventArgs e)
        {
            addCorrectAnswer();
            showTandFQues();
        }

        private void btn_addTextQues(object sender, RoutedEventArgs e)
        {
            addTextQuestion();
            showTextQues();
        }


        private void Courses_CmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showMCQ();
            showTandFQues();
            showTextQues();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsTrue_CmbBox.SelectedIndex = 0;
            IsTrue2_CmbBox.SelectedIndex = 0;
           
        }

    }
}

