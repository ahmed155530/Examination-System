using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace projectex
{
    /// <summary>
    /// Interaction logic for DisplayExam.xaml
    /// </summary>
    public partial class displayexam : Window
    {

        Context Context = new Context();
        Question[] Questions;
        MC_Question[] Chooses;
        Dictionary<int, string> Answer = new Dictionary<int, string>();
        int currentQuestion;
      

        int user_id;
        int ExamId;
        public displayexam(int userid, int examid)
        {
            user_id = userid;
            currentQuestion = 0;
            Questions = getExamByIdCourse(examid);
           
            InitializeComponent();
            setAnswerKey();
            createBody();
            time();

        }

        public void createBody()
        {
            Viewbox viewbox = new Viewbox();

            EXName.Content = Questions[0].Course.Course_Name + " Exam";

            if (currentQuestion < Questions.Length && currentQuestion > -1)
            {
                Label.Content = Questions[currentQuestion].Question_Body;
                if (Questions[currentQuestion].type == 1) //mcq
                {
                    Chooses = getChooses(Questions[currentQuestion].Question_Id);

                    for (int j = 0; j < Chooses.Length; j++)
                    {
                        RadioButton rb = new RadioButton()
                        {
                            Content = Chooses[j].MCQ_Option,
                            Tag = j,
                            FontSize = 20
                        };

                        stackPanel.Children.Add(rb);
                        if (Answer[currentQuestion] == rb.Content.ToString())
                        {
                            if (rb.IsChecked.HasValue)
                            {
                                rb.IsChecked = true;
                            }
                        }

                        rb.Checked += radioButton1_CheckedChanged;
                    }


                }
                else if (Questions[currentQuestion].type == 2) //true and false
                {
                    RadioButton t = new RadioButton() { Content = "True", FontSize = 20 };
                    RadioButton f = new RadioButton() { Content = "False", FontSize = 20 };

                    stackPanel.Children.Add(t);
                    stackPanel.Children.Add(f);
                    t.Checked += radioButton1_CheckedChanged;
                    f.Checked += radioButton1_CheckedChanged;
                    if (Answer[currentQuestion] != "")
                    {
                        if (Answer[currentQuestion] == "True")
                        {
                            t.IsChecked = true;
                        }
                        else if (Answer[currentQuestion] == "False")
                        {
                            f.IsChecked = true;
                        }
                    }
                }
                else if (Questions[currentQuestion].type == 3) //text
                {
                    TextBox text = new TextBox();
                    text.FontSize = 15;
                    text.Width = 1000;
                    text.MinHeight = 50;
                    stackPanel.Children.Add(text);
                    text.LostFocus += textBox1_LostFocus;
                    if (Answer[currentQuestion] != "")
                    {
                        text.Text = Answer[currentQuestion];
                    }
                }

            }
            else
            {
                MessageBox.Show("Finish");
            }



        }
        public void click_Next(object sender, RoutedEventArgs e)
        {
            if (currentQuestion < Questions.Length - 1)
            {
                currentQuestion++;
                stackPanel.Children.Clear();
                createBody();
            }
        }
        public void click_prev(object sender, RoutedEventArgs e)
        {
            if (currentQuestion != 0)
            {
                currentQuestion--;
                stackPanel.Children.Clear();
                createBody();
            }

        }

        public void radioButton1_CheckedChanged(Object sender, EventArgs e)
        {
            Answer[currentQuestion] = ((RadioButton)sender).Content.ToString();
        }
        private void textBox1_LostFocus(object sender, System.EventArgs e)
        {
            Answer[currentQuestion] = ((TextBox)sender).Text;
        }


        public void createButtonFinish()
        {
            Finish.Click += new RoutedEventHandler(save);
        }
        public Question[] getExamByIdCourse(int examid)
        {
          

            var questions =
                (from e in Context.Exam_Question
                 where e.Exam_Id == examid
                 select e.Question).ToArray();

            ExamId = examid;

            return questions;
        }
        public Question[] getExam(int IdExam)
        {
            var questions =
                (from e in Context.Exam_Question
                 where e.Exam_Id == IdExam
                 select e.Question).ToArray();

            if (questions.Length > 0)
                ExamId = IdExam;

            return questions;
        }
        public MC_Question[] getChooses(int IdQuestion)
        {
            var query =
                (from c in Context.MC_Question
                 where c.Question_Id == IdQuestion
                 select c).ToArray();
            return query;
        }
        public void setAnswerKey()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Answer.Add(i, "");
            }
        }


        DispatcherTimer _timer;
        TimeSpan _time;
        public void time()
        {
            _time = TimeSpan.FromHours(1.5);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {

                lblTime.Content = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    save(null, null);

                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

        }

        private void save(object sender, RoutedEventArgs e)
        {
            Context context = new Context();

            int tf = -1;
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i].type == 2)
                {
                    if (Answer[i] == "False")
                        tf = 0;
                    if (Answer[i] == "True")
                        tf = 1;
                }
                if (Answer[i] != "")
                    context.Database.ExecuteSqlCommand($"Answer_Question_proc {user_id},{ExamId},{Questions[i].Question_Id} ,[{Answer[i]}],{tf} ;", parameters: new object[] { });
            }
            ResultStudent result = new ResultStudent(user_id); //Id student
            result.Show();
            this.Close();


        }
    }
}
