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
    /// Interaction logic for addstudent.xaml
    /// </summary>
    public partial class addstudent : Window
    {
        Context context = new Context();
        public addstudent()
        {
            InitializeComponent();
            loadStudents();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb1.ItemsSource = context.Branches.ToList();
            cmb1.DisplayMemberPath = "Branch_Name";
            cmb1.SelectedValue= "Branch_id";
            cmb1.SelectedIndex = 0;

            cmb2.ItemsSource = context.Tracks.ToList();
            cmb2.DisplayMemberPath = "Track_Name";
            cmb2.SelectedValue = "Track_Id";
            cmb2.SelectedIndex = 0;


            cmb3.ItemsSource = context.Intakes.ToList();
            cmb3.DisplayMemberPath = "Intake_Number";
            cmb3.SelectedValue = "Intake_Id";
            cmb3.SelectedIndex = 0;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if(birth.SelectedDate != null && name.Text!="" && code.Text!="" && username.Text!="" && passwordtxt.Text!="" && cmb1.SelectedIndex!=-1 && cmb2.SelectedIndex!=-1 && cmb3.SelectedIndex!=-1)
                {
                    var branchid = ((Branch)cmb1.SelectedValue);
                    int branch_id1 = branchid.Branch_Id;

                    var trackid = ((Track)cmb2.SelectedValue);
                    int track_id1 = trackid.Track_Id;


                    var intakeid = ((Intake)cmb3.SelectedValue);
                    int intake_id1 = intakeid.Intake_Id;


                    string Name = name.Text;
                    DateTime date;
               
                
                        date = birth.SelectedDate.Value.Date;
                
             
                    string code1 = code.Text;

                    string user = username.Text;
                    string pass = passwordtxt.Text;
                    var query = context.Login_User.Where(c => c.UserName == user).FirstOrDefault();
                    if (query == null)
                    {
                            var query2 = context.Students.Where(c => c.student_code == code1).FirstOrDefault();

                            if (query2 == null)
                            {
                                var login = new Login_User
                                {
                                    UserName = user,
                                    Password = pass,
                                    Position = "student",
                                    position_id = 3
                                };


                                context.Login_User.Add(login);
                                context.SaveChanges();
                                var student = new Student
                                {
                                    Student_Name = Name,
                                    Student_BirthDate = date,
                                    isdeleted = false,
                                    student_code = code1,
                                    login_id = login.ID,
                                    Branch_Id = branch_id1,
                                    Track_Id = track_id1,
                                    Intake_Id = intake_id1
                                };
                                context.Students.Add(student);
                                context.SaveChanges();
                                MessageBox.Show("student added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                                name.Text = "";
                                code.Text = "";
                                username.Text = "";
                                passwordtxt.Text = "";
                                cmb1.SelectedIndex = 0;
                                cmb2.SelectedIndex = 0;
                                cmb3.SelectedIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("this student  code added before!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                            }
                        }
                    else
                    {
                        MessageBox.Show("this username added before!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please , Fill all the fields first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        public void loadStudents()
        {
            var StudentQuery = from s in context.Students
                               select new
                               {
                                   s.Student_Name,
                                   s.Branch.Branch_Name,
                                   s.Track.Track_Name,
                                   s.Intake.Intake_Number,
                                   s.isdeleted
                               };
            dataGrid_StudentNames.ItemsSource = StudentQuery.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var StudentQuery = from s in context.Students
                               where s.Student_Name.Contains(txtBox_Student_search.Text)
                               select new
                               {
                                   s.Student_Name,
                                   s.Branch.Branch_Name,
                                   s.Track.Track_Name,
                                   s.Intake.Intake_Number,
                                   s.isdeleted
                               };
            dataGrid_StudentNames.ItemsSource = StudentQuery.ToList();
        }
    }
}
