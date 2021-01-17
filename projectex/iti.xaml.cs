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
    /// Interaction logic for iti.xaml
    /// </summary>
    public partial class iti : Window
    {
        Context context = new Context();
        public iti()
        {
            InitializeComponent();
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(trackname.Text!="")
            {
                string ititrackname = trackname.Text;
                var tracknamequery = context.Tracks.Where(c => c.Track_Name == ititrackname).
                 FirstOrDefault();

                var track = new Track();
                if (tracknamequery == null)
                {
                    track.Track_Name = ititrackname;
                    context.Tracks.Add(track);
                    context.SaveChanges();
                    MessageBox.Show("track added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    trackname.Text = "";
                }
                else
                {
                    MessageBox.Show("this track added before", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please , Enter Track name First", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


/*
            var itiq = context.ITIs.Where(c => c.Track_Id == tid && c.Intake_Id == inid && c.Branch_Id == bid).FirstOrDefault();
            if (itiq == null)
            {
                var iti = new ITI
                {
                    Branch_Id = bid,
                    Intake_Id = inid,
                    Track_Id = tid
                };
                context.ITIs.Add(iti);
                context.SaveChanges();
            }
            */
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(branchname.Text!="")
            {
                string bname = branchname.Text;
                var branchnamequery = context.Branches.Where(c => c.Branch_Name == bname).
                    FirstOrDefault();
                var branch = new Branch();
                if (branchnamequery == null)
                {
                    branch.Branch_Name = bname;
                    context.Branches.Add(branch);
                    context.SaveChanges();
                    MessageBox.Show("Branch added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    branchname.Text = "";
                }
                else
                {
                    MessageBox.Show("this Branch was added before", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please , enter a branch name", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            { 
            if(intakenumber.Text!="")
            {
                int intakenum = Convert.ToInt32(intakenumber.Text);
                var intakenumquery = context.Intakes.Where(c => c.Intake_Number == intakenum).
                   FirstOrDefault();
                var intake = new Intake();
                if (intakenumquery == null)
                {

                    intake.Intake_Number = intakenum;
                    context.Intakes.Add(intake);
                    context.SaveChanges();
                    MessageBox.Show("Intake added successfully", "Successfully Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    intakenumber.Text = "";
                }
                else
                {
                    MessageBox.Show("this Intake track added before", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please , Enter an Intake Number", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            }
            catch (Exception E)
            {
                MessageBox.Show("Some invalid input!! please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

   
    }
}
