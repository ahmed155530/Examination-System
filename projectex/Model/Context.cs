using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectex
{
    public partial class Context: DbContext
    {
        public Context()
           : base("data source=LENOVO;initial catalog=Examination_test;integrated security=True")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());

        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Exam_Question> Exam_Question { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Intake> Intakes { get; set; }
     
        public virtual DbSet<Login_User> Login_User { get; set; }
        public virtual DbSet<MC_Question> MC_Question { get; set; }
        public virtual DbSet<MCQ_Answer> MCQ_Answer { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Answer> Student_Answer { get; set; }
        public virtual DbSet<Student_Degree> Student_Degree { get; set; }
        public virtual DbSet<Students_Course> Students_Course { get; set; }
        public virtual DbSet<Text_Answer> Text_Answer { get; set; }
        public virtual DbSet<Text_Question> Text_Question { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<TrueAndFalse_Answer> TrueAndFalse_Answer { get; set; }
        public virtual DbSet<TrueAndFalse_Question> TrueAndFalse_Question { get; set; }
    }
}
