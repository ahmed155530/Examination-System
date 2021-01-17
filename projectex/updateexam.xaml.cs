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
    /// Interaction logic for updateexam.xaml
    /// </summary>
    public partial class updateexam : Window
    {
        Context c = new Context();
        int user_id;
        public updateexam(int userid)
        {
            user_id = userid;
            InitializeComponent();
            loadedExam();
      
        }
        public void loadedExam()
        {
            try
            { 
            var exam1 = (from exam in c.Exams 
                         where exam.Course.Instructor_Id==user_id
                         select new
                         {
                             exam.Exam_Id,
                             exam.Exam_Name,
                           
                             exam.MCQ_Degree,
                             exam.T_F_Degree,
                             exam.Text_Degree,
                         }).ToList();
            DataGrid1.ItemsSource = exam1;
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            if (DataGrid1.SelectedItem != null)
            {
                var exam = c.Exams.ToList();
                object Item = DataGrid1.SelectedItem;
                //Exam_Id.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Exam_Name.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;
            //    Course_Id.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                MCQ_Degree.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                T_F_Degree.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                Text_Degree.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;

            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Exam z = c.Exams.ToList().FirstOrDefault(c => c.Exam_Id == (Convert.ToInt32(Text)));

                z.Exam_Name = Exam_Name.Text;
             
                z.MCQ_Degree = int.Parse(MCQ_Degree.Text);
                z.T_F_Degree = int.Parse(T_F_Degree.Text);
                z.Text_Degree = int.Parse(Text_Degree.Text);

                c.SaveChanges();
                    MessageBox.Show("Exam updated successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);

                    loadedExam();
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Exam z = c.Exams.ToList().FirstOrDefault(c => c.Exam_Id == (Convert.ToInt32(Text)));
                c.Exams.Remove(z);
                c.SaveChanges();
                    MessageBox.Show("Exam Deleted successfully", "successfully completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    MCQ_Degree.Text = "";
                    T_F_Degree.Text = "";
                    Text_Degree.Text = "";
                    Exam_Name.Text = "";
                    loadedExam();
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

