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
    /// Interaction logic for studentUp.xaml
    /// </summary>
    public partial class studentUp : Window
    {
        Context c = new Context();

        public studentUp()
        {
            InitializeComponent();
            loadtrainee();
        }

        public void loadtrainee()
        {
            var stud = (from student in c.Students.ToList()
                        select new
                        {
                            student.Student_Id,
                            student.Student_Name,
                            student.student_code,
                            student.Branch_Id,
                            student.Intake_Id,
                            student.Track_Id
                        });
            DataGrid1.ItemsSource = stud;
        }
        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            loadtrainee();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var branch = c.Branches.ToList();
            var intake = c.Intakes.ToList();
            var track = c.Tracks.ToList();
            if (DataGrid1.SelectedItem != null)
            {
                object Item = DataGrid1.SelectedItem;

                // Student_Id.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Student_Name.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;
                //Isdeleted.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;

                //login_Id.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                student_Code.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                Branch_Id.ItemsSource = branch;
                Branch_Id.DisplayMemberPath = "Branch_Name";
                Branch_Id.SelectedValue = "Branch_id";
                Branch_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text)-1;
                //(DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                Intake_Id.ItemsSource = intake;
                Intake_Id.DisplayMemberPath = "Intake_Number";

                Intake_Id.SelectedValue= "Intake_Id";
                Intake_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text)-1;
                
                //Intake_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                Track_Id.ItemsSource = track;
                Track_Id.DisplayMemberPath = "Track_Name";
                Track_Id.SelectedValue = "Track_Id";
                //Track_Id.SelectedItem= (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;
                Track_Id.SelectedIndex = int.Parse((DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text)-1;

                //Track_Id.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
            Student z = c.Students.ToList().FirstOrDefault(c=>c.Student_Id==(int.Parse(Text)));
            if (z != null) { 
           // z.Student_Id = int.Parse(Student_Id.Text);
            z.Student_Name = Student_Name.Text;
            //z.isdeleted = bool.Parse(Isdeleted.Text);
            //z.login_id = int.Parse(login_Id.Text);
            z.student_code = student_Code.Text;

                var branch = (Branch)Branch_Id.SelectedValue;
                int branchid = branch.Branch_Id;
                z.Branch_Id = branchid;
                var intake = (Intake)Intake_Id.SelectedValue;
                int intakeid = intake.Intake_Id;
                z.Intake_Id = intakeid;
                var track = (Track)Track_Id.SelectedValue;
                int trackid = track.Track_Id;
                z.Track_Id = trackid;
            
                c.SaveChanges();
                loadtrainee();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
            Student z = c.Students.ToList().FirstOrDefault(c => c.Student_Id == (int.Parse(Text)));
            if (z != null) { 
            z.isdeleted = true;
            ConfirmDelete confirm = new ConfirmDelete(Convert.ToInt32(Text),c,this);
            confirm.Show();
            c.SaveChanges();
           
            loadtrainee();
            }

            //DataGrid1.ItemsSource = stud;

        }

    }
}
