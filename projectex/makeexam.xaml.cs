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
    /// Interaction logic for makeexam.xaml
    /// </summary>
    public partial class makeexam : Window
    {
        Context context = new Context();
        int user_id;
        public makeexam(int userid)
        {
            InitializeComponent();
            user_id = userid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb1.ItemsSource = context.Courses.Where(c => c.Instructor_Id == user_id).ToList();
            cmb1.DisplayMemberPath = "Course_Name";
            cmb1.SelectedValue = "Course_Id";
            cmb1.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            var course = ((Course)cmb1.SelectedValue);
            int courseid = course.Course_Id;


            string examName = exam.Text;
            int mcq_deg = int.Parse(mcqdeg.Text);
            int tf_deg = int.Parse(tfdeg.Text);
            int txt_deg = int.Parse(txtdeg.Text);

            int mcq_no = int.Parse(mcqno.Text);
            int tf_no = int.Parse(tfno.Text);
            int txt_no = int.Parse(txtno.Text);

        var q=context.Database.ExecuteSqlCommand(" make_question_exam @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8", parameters: new object[] {user_id,courseid,
            examName,mcq_no,tf_no,txt_no,mcq_deg,tf_deg,txt_deg});
                //exec make_question_exam 2,1,'c++_exam',5,10,5,5,5,5

                if(q==-1)
                {
                    MessageBox.Show("exam  exceed the max degree of coures ", "Warning", MessageBoxButton.OK, MessageBoxImage.Hand);

                }
                else
                MessageBox.Show("exam  and exam_question added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
