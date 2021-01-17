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
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        Context context = new Context();
        int user_id;
        public manager(int userid)
        {
            InitializeComponent();
            user_id = userid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            iti it = new iti();
            it.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addstudent addstud = new addstudent();
            addstud.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = context.Instructors.Where(c => c.Instructor_Id == user_id).Select(c => c.Instructor_Name).FirstOrDefault();
            welcome.Text = $"wellcome {query}";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addinstructor addins = new addinstructor(user_id);
            addins.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addcourse addcourse = new addcourse();
            addcourse.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            makeexam makeexam = new makeexam(user_id);
            makeexam.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            assignstudenttoexam assignstudenttoexam = new assignstudenttoexam(user_id);
            assignstudenttoexam.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            updateinstructor ins = new updateinstructor();
            ins.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            updatestudent updatestudent = new updatestudent();
            updatestudent.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            updatecourse updatecourse = new updatecourse();
            updatecourse.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            updatequestion updatequestion = new updatequestion(user_id);
            updatequestion.Show();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            updatelogin updatelogin = new updatelogin();
            updatelogin.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            updateexam updateexam = new updateexam(user_id);
            updateexam.Show();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            addquestion addquestion = new addquestion(user_id);
            addquestion.Show();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            DesignExam designExam = new DesignExam(user_id);
            designExam.Show();
        }
    }
}
