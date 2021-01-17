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
    /// Interaction logic for Question_Update9.xaml
    /// </summary>
    public partial class Question_Update9 : Window
    {
        Context c = new Context();

        // Question_Id
        // Question_Body
        // Question_Type
        // Course_Id
        public Question_Update9()
        {
            InitializeComponent();
            loadedQuestion();
        }
        public void loadedQuestion()
        {
            var question1 = (from Question in c.Questions.ToList()
                         select new
                         {
                             Question.Question_Id,
                             Question.Question_Body,
                             Question.Question_Type,
                             Question.Course_Id,
                            
                         });
            DataGrid1.ItemsSource = question1;
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var exam = c.Exams.ToList();
                object Item = DataGrid1.SelectedItem;
                Question_Body.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;
                
               
                
      

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Question z = c.Questions.ToList().FirstOrDefault(c => c.Question_Id== (Convert.ToInt32(Text)));
                c.Questions.Remove(z);
                c.SaveChanges();
                loadedQuestion();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Question z = c.Questions.ToList().FirstOrDefault(c => c.Question_Id == (Convert.ToInt32(Text)));

                z.Question_Body = Question_Body.Text;


                c.SaveChanges();
                loadedQuestion();
            }
            
        }
    }
}
