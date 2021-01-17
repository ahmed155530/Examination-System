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
/// Interaction logic for addinstructor.xaml
/// </summary>
    public partial class addinstructor : Window
    {
        Context context = new Context();
        int user_id;
        public addinstructor(int userid)
        {
            user_id = userid;
            InitializeComponent();
            LoadInstructors();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if(datebick.SelectedDate != null && name.Text!="" && salary.Text!="" && datebick.SelectedDate!=null && user.Text!="" && pass.Text!="" && cmb1.SelectedIndex!=-1)
            {
                var branchid = ((Branch)cmb1.SelectedValue);
                int branch_id1 = branchid.Branch_Id;

                string Name = name.Text;
                DateTime date = datebick.SelectedDate.Value.Date;
                float instructorsalary = float.Parse(salary.Text);

                string username = user.Text;
                string password = pass.Text;
                var query = context.Login_User.Where(c => c.UserName == username).FirstOrDefault();
                if (query == null)
                {
                    var login = new Login_User
                    {
                        UserName = username,
                        Password = password,
                        Position = "instructor",
                        position_id = 2
                    };


                    context.Login_User.Add(login);
                    context.SaveChanges();
                    var instructor = new Instructor
                    {
                        Instructor_Name = Name,
                        Instructor_HireDate = date,
                        Instructor_Salary = instructorsalary,
                        isdeleted = false,
                        login_id = login.ID,
                        Branch_Id = branch_id1,
                        Manager_Id = user_id
                    };
                    context.Instructors.Add(instructor);
                    context.SaveChanges();
                    MessageBox.Show("instructor added successfully","successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    name.Text = "";
                    salary.Text = "";
                    user.Text = "";
                    pass.Text = "";
                    cmb1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("this username added before!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please , Fill all fields First.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
                        catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb1.ItemsSource = context.Branches.ToList();
            cmb1.DisplayMemberPath = "Branch_Name";
            cmb1.SelectedValue = "Branch_id";
            cmb1.SelectedIndex = 0;
        }

        public void LoadInstructors()
        {
            var InsQuery = from i in context.Instructors
                           select new
                           {
                               i.Instructor_Id,
                               i.Instructor_Name,
                               i.Instructor_Salary,
                               i.Instructor_HireDate,
                               i.Branch.Branch_Name,
                           };
            dataGrid_Instructors.ItemsSource = InsQuery.ToList();
        }

        private void txtBox_InstructorName_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var InsQuery = from i in context.Instructors
                           where i.Instructor_Name.Contains(txtBox_InstructorName_Search.Text)
                           select new
                           {
                               i.Instructor_Id,
                               i.Instructor_Name,
                               i.Instructor_Salary,
                               i.Instructor_HireDate,
                               i.Branch.Branch_Name,
                           };
            dataGrid_Instructors.ItemsSource = InsQuery.ToList();
        }
    }
}
