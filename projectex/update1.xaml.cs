using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Interaction logic for update1.xaml
    /// </summary>
    public partial class update1 : Window
    {
        Context c = new Context();
        public update1()
        {
            InitializeComponent();
        }

        public object False { get; private set; }

        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            var instr = (from instruct in c.Instructors.ToList()
                           select new
                           {
                               instruct.Instructor_Id,
                               instruct.Instructor_Name,
                               instruct.Instructor_Salary,
                               instruct.Instructor_HireDate.Year,
                               instruct.Branch_Id,
                               instruct.login_id,
                               instruct.Manager_Id,
                               instruct.isdeleted
                           });
            DataGrid1.ItemsSource = instr;
            DataGrid1.Columns[3].Header= "HireDate";
         // DataGrid1.DisplayMemberPath = "Name";
            //DataGrid1.Columns["Manager/Login_user/Branch/Course/Instructor"].Visible = false;
            //.ToShortDateString()




        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var branch = c.Branches.ToList();
                object Item = DataGrid1.SelectedItem ;
                //Instructor_ID.Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Instructor_Name.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(Item) as TextBlock).Text;

                Instructor_Salary.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(Item) as TextBlock).Text;
                Instructor_HireDate.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(Item) as TextBlock).Text;
                // Branch_Id.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text;
                Branch_Id.ItemsSource = branch;
                Branch_Id.DisplayMemberPath = "Branch_Name";
                Branch_Id.SelectedIndex= int.Parse((DataGrid1.SelectedCells[4].Column.GetCellContent(Item) as TextBlock).Text)-1;
                // login_id.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(Item) as TextBlock).Text;

                // Manager_Id.Text = (DataGrid1.SelectedCells[6].Column.GetCellContent(Item) as TextBlock).Text;


            }

            #region comm
            //====================================
            //DataGrid data1 =  (DataGrid)sender;
            //DataRowView rowselected = data1.SelectedItem as DataRowView;
            //if (DataGrid1.CurrentItem is Instructor )
            //{
            //    Instructor s = (Instructor)DataGrid1.SelectedItem;
            //    if (s != null && (s.Instructor_Id != 0))
            //    {
            //        Instructor_Name.Text = s.Instructor_Name.ToString();
            //        Instructor_Salary.Text = s.Instructor_Salary.ToString();
            //        Instructor_HireDate.Text = s.Instructor_HireDate.ToShortDateString();
            //        //DateTime.Parse(Instructor_HireDate.Text).Date
            //        Branch_Id.Text = s.Branch_Id.ToString();
            //        if (s.Manager_Id == null)
            //        {
            //            Manager_Id.Text = "NULL";
            //        }
            //        else
            //        {
            //            Manager_Id.Text = s.Manager_Id.ToString();
            //        }
            //        login_id.Text = s.login_id.ToString();
            //        Instructor_ID.Text = s.Instructor_Id.ToString();

            //    }
            //    else
            //    {
            //        Instructor_ID.Text = "NULL";
            //        Instructor_Name.Text = "NULL";
            //        Instructor_Salary.Text = "NULL";
            //        Instructor_HireDate.Text = "NULL";
            //        Branch_Id.Text = "NULL";
            //        Manager_Id.Text = "NULL";
            //        login_id.Text = "NULL";
            //    }
            //}
            //else
            //{

            //}




            //if (rowselected != null) { 
            //        Instructor_Name.Text = rowselected["Instructor_Name"].ToString();
            //        Instructor_Salary.Text = rowselected["Instructor_Salary"].ToString();
            //        Instructor_HireDate.Text = rowselected["Instructor_HireDate"].ToString();
            //        Branch_Id.Text = rowselected["Branch_Id"].ToString();
            //        Manager_Id.Text = rowselected["Manager_Id"].ToString();
            //        login_id.Text = rowselected["login_id"].ToString();
            //        Manager.Text = rowselected["Manager"].ToString();
            //    } 
            #endregion
        }


            private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click_1(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            if(Item != null) { 
            var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
            Instructor z = c.Instructors.ToList(). FirstOrDefault(c => c.Instructor_Id == (Convert.ToInt32(Text)));

            z.Instructor_Name = Instructor_Name.Text;
            z.Instructor_Salary = int.Parse(Instructor_Salary.Text);
            z.Instructor_HireDate = DateTime.Parse(Instructor_HireDate.Text+ "-1"+ "-1");
                z.Branch_Id = int.Parse(Branch_Id.Text);
                c.SaveChanges();
                var instr = (from instruct in c.Instructors
                             select new
                             {
                                 instruct.Instructor_Id,
                                 instruct.Instructor_Name,
                                 instruct.Instructor_Salary,
                                 instruct.Instructor_HireDate.Year,
                                 instruct.Branch_Id,
                                 instruct.login_id,
                                 instruct.Manager_Id,
                                 instruct.isdeleted
                             });
                DataGrid1.ItemsSource = instr.ToList();
                DataGrid1.Columns[3].Header = "HireDate";
            }
            //z.Instructor_HireDate = z.Instructor_HireDate.ToString("dd/M/yyyy"));
            //if (Manager_Id.Text == "")
            //{
            // Manager_Id.Text = "NULL";
            //}
            //else
            //{
            //    z.Manager_Id = int.Parse(Manager_Id.Text);
            //}

            //z.login_id = int.Parse(login_id.Text);
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object Item = DataGrid1.SelectedItem;
            if (Item != null)
            {
                var Text = (DataGrid1.SelectedCells[0].Column.GetCellContent(Item) as TextBlock).Text;
                Instructor z = c.Instructors.ToList().FirstOrDefault(c => c.Instructor_Id == (Convert.ToInt32(Text)));
                z.isdeleted = true;
                c.SaveChanges();
                var instr = (from instruct in c.Instructors
                             select new
                             {
                                 instruct.Instructor_Id,
                                 instruct.Instructor_Name,
                                 instruct.Instructor_Salary,
                                 instruct.Instructor_HireDate.Year,
                                 instruct.Branch_Id,
                                 instruct.login_id,
                                 instruct.Manager_Id,
                                 instruct.isdeleted
                             });
                DataGrid1.ItemsSource = instr.ToList();
                DataGrid1.Columns[3].Header = "HireDate";
            }
        }
    }
}
