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
    /// Interaction logic for instructor.xaml
    /// </summary>
    public partial class instructor : Window
    {
        int user_id;
        public instructor(int userid)
        {
            InitializeComponent();
            user_id = userid;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            assignstudenttoexam assignstudenttoexam = new assignstudenttoexam(user_id);
            assignstudenttoexam.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            updatequestion updatequestion = new updatequestion(user_id);
            updatequestion.Show();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            addquestion addquestion = new addquestion(user_id);
            addquestion.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            updateexam updateexam = new updateexam(user_id);
            updateexam.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            makeexam makeexam = new makeexam(user_id);
            makeexam.Show();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            DesignExam designExam = new DesignExam(user_id);
            designExam.Show();
        }
    }
}
