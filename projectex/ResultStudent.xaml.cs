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
    /// Interaction logic for ResultStudent.xaml
    /// </summary>
    public partial class ResultStudent : Window
    {
        List<Student_Degree> Degrees;
        List<StudentDegreeViewData> items = new List<StudentDegreeViewData>();
        int Id;
        public ResultStudent(int Id)
        {
            this.Id = Id;
            GetResult();
            setToList();
            InitializeComponent();
            lvStudent.ItemsSource = items;
        }

        public void GetResult()
        {
            Context context = new Context();

            var query =
                     (from s in context.Student_Degree
                      where s.Student_Id.Value == Id //Idstudent
                      where s.isenterd==1
                      select s).ToList();
            Degrees = query;
        }

        public void setToList()
        {
            try
            { 
            foreach (var item in Degrees)
            {
                if (item.Degree >= item.Exam.Course.Min_Degree)
                {
                    items.Add(new StudentDegreeViewData
                    {
                        Title = item.Exam.Exam_Name,
                        Completion = item.Degree,
                        Degree = item.Degree,
                        color = "green",
                        max = item.Exam.Course.Max_Degree,
                        min = item.Exam.Course.Min_Degree
                    });
                }
                else if (item.Degree < item.Exam.Course.Min_Degree)
                {
                    items.Add(new StudentDegreeViewData
                    {
                        Title = item.Exam.Exam_Name,
                        Completion = item.Degree,
                        Degree = item.Degree,
                        color = "red",
                        max = item.Exam.Course.Max_Degree,
                        min = item.Exam.Course.Min_Degree
                    });
                }

            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    class StudentDegreeViewData
    {
        public string Title { get; set; }
        public int Completion { get; set; }
        public int Degree { get; set; }
        public string color { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }
}

