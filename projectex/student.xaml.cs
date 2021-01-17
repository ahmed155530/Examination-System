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
    /// Interaction logic for student.xaml
    /// </summary>
    public partial class student : Window
    {
        Context context = new Context();
        int user_id;
        public student(int userid)
        {
            InitializeComponent();
            user_id = userid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            displayexam();

        }

        public void displayexam()
        {
            var query = (from c in context.Student_Degree
                         join s in context.Exams
                         on c.Exam_Id equals s.Exam_Id
                         where c.Student_Id == user_id
                         where c.isenterd == 0
                         select s).ToList();

            cmb1.ItemsSource = query;
            cmb1.DisplayMemberPath = "Exam_Name";
            cmb1.SelectedValue = "Exam_Id";
            cmb1.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmb1.SelectedItem != null)
            {
                var ex = ((Exam)cmb1.SelectedValue);
                int examid = ex.Exam_Id;
                var std = context.Student_Degree.Where(c => c.Student_Id == user_id && c.Exam_Id == examid).FirstOrDefault();
                std.isenterd = 1;
                context.SaveChanges();

                displayexam displayexams = new displayexam(user_id, examid);
                displayexams.Show();

                displayexam();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResultStudent res = new ResultStudent(user_id);
            res.Show();
        }
    }
}
