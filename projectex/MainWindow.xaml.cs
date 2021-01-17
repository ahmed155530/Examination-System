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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projectex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           
          try
            { 
            string username = user.Text;
            string password = pass.Password;
            var query = context.Login_User.Where(c => c.UserName == username && c.Password == password)
                .Select(c => c.position_id).FirstOrDefault();
            var query2 = context.Login_User.Where(c => c.UserName == username && c.Password == password)
.Select(c => c.ID).FirstOrDefault();
            if (query==1)
            {
      var query3 = context.Instructors.Where(c => c.login_id==query2)
     .Select(c => c.Instructor_Id).FirstOrDefault();
                manager m = new manager(query3);
                m.Show();
            }
            else if(query==2)
            {
                var query3 = context.Instructors.Where(c => c.login_id == query2)
.Select(c => c.Instructor_Id).FirstOrDefault();
                instructor ins = new instructor(query3);
                ins.Show();
            }
           else if(query==3)
            {
                var query3 = context.Students.Where(c => c.login_id == query2)
.Select(c => c.Student_Id).FirstOrDefault();
                student s = new student(query3);
                s.Show();
            }
            else
            {
                MessageBox.Show("invalid username or password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
