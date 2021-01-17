namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Branch_Id = c.Int(nullable: false, identity: true),
                        Branch_Name = c.String(),
                        Branch_Location = c.String(),
                    })
                .PrimaryKey(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false, identity: true),
                        Instructor_Name = c.String(),
                        Instructor_Salary = c.Int(nullable: false),
                        Instructor_HireDate = c.DateTime(nullable: false),
                        Branch_Id = c.Int(),
                        Manager_Id = c.Int(),
                        isdeleted = c.Boolean(),
                        login_id = c.Int(),
                        Login_User_ID = c.Int(),
                        Instructor2_Instructor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Instructor_Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .ForeignKey("dbo.Login_User", t => t.Login_User_ID)
                .ForeignKey("dbo.Instructors", t => t.Instructor2_Instructor_Id)
                .Index(t => t.Branch_Id)
                .Index(t => t.Login_User_ID)
                .Index(t => t.Instructor2_Instructor_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Course_Id = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(),
                        Course_eDiscription = c.String(),
                        Max_Degree = c.Int(nullable: false),
                        Min_Degree = c.Int(nullable: false),
                        Instructor_Id = c.Int(),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Course_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Exam_Id = c.Int(nullable: false, identity: true),
                        Exam_Name = c.String(),
                        Course_Id = c.Int(),
                        MCQ_Degree = c.Int(nullable: false),
                        T_F_Degree = c.Int(nullable: false),
                        Text_Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Exam_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Exam_Question",
                c => new
                    {
                        Exam_Question_Id = c.Int(nullable: false, identity: true),
                        Exam_Id = c.Int(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Exam_Question_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Exam_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Question_Id = c.Int(nullable: false, identity: true),
                        Question_Body = c.String(),
                        Question_Type = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Question_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.MC_Question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Question_Id = c.Int(nullable: false),
                        MCQ_Option = c.String(),
                        MCQ_Istrue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Student_Answer",
                c => new
                    {
                        Student_Answer_Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(),
                        Exam_Id = c.Int(),
                        Question_id = c.Int(),
                    })
                .PrimaryKey(t => t.Student_Answer_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .ForeignKey("dbo.Questions", t => t.Question_id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Exam_Id)
                .Index(t => t.Question_id);
            
            CreateTable(
                "dbo.MCQ_Answer",
                c => new
                    {
                        MCQ_Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        Student_Answer_Id = c.Int(),
                        answer_degree = c.Int(),
                    })
                .PrimaryKey(t => t.MCQ_Id)
                .ForeignKey("dbo.Student_Answer", t => t.Student_Answer_Id)
                .Index(t => t.Student_Answer_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Student_Id = c.Int(nullable: false, identity: true),
                        Student_Name = c.String(),
                        Student_BirthDate = c.DateTime(nullable: false),
                        ITI_Id = c.Int(),
                        isdeleted = c.Boolean(),
                        login_id = c.Int(),
                        Login_User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Student_Id)
                .ForeignKey("dbo.ITIs", t => t.ITI_Id)
                .ForeignKey("dbo.Login_User", t => t.Login_User_ID)
                .Index(t => t.ITI_Id)
                .Index(t => t.Login_User_ID);
            
            CreateTable(
                "dbo.ITIs",
                c => new
                    {
                        ITI_Id = c.Int(nullable: false, identity: true),
                        Branch_Id = c.Int(),
                        Intake_Id = c.Int(),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ITI_Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .ForeignKey("dbo.Intakes", t => t.Intake_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .Index(t => t.Branch_Id)
                .Index(t => t.Intake_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.Intakes",
                c => new
                    {
                        Intake_Id = c.Int(nullable: false, identity: true),
                        Intake_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Intake_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Track_Id = c.Int(nullable: false, identity: true),
                        Track_Name = c.String(),
                    })
                .PrimaryKey(t => t.Track_Id);
            
            CreateTable(
                "dbo.Login_User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Position = c.String(),
                        position_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student_Degree",
                c => new
                    {
                        Student_Degree_Id = c.Int(nullable: false, identity: true),
                        Student_Id = c.Int(),
                        Exam_Id = c.Int(),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Student_Degree_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.Students_Course",
                c => new
                    {
                        Studend_Course_Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Studend_Course_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Text_Answer",
                c => new
                    {
                        Text_Id = c.Int(nullable: false, identity: true),
                        Text_Answer1 = c.String(),
                        Student_Answer_Id = c.Int(),
                        answer_degree = c.Int(),
                    })
                .PrimaryKey(t => t.Text_Id)
                .ForeignKey("dbo.Student_Answer", t => t.Student_Answer_Id)
                .Index(t => t.Student_Answer_Id);
            
            CreateTable(
                "dbo.TrueAndFalse_Answer",
                c => new
                    {
                        TAndF_Id = c.Int(nullable: false, identity: true),
                        TAndF_Answer = c.Boolean(),
                        Student_Answer_Id = c.Int(),
                        answer_degree = c.Int(),
                    })
                .PrimaryKey(t => t.TAndF_Id)
                .ForeignKey("dbo.Student_Answer", t => t.Student_Answer_Id)
                .Index(t => t.Student_Answer_Id);
            
            CreateTable(
                "dbo.Text_Question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Question_Id = c.Int(nullable: false),
                        Text_Correct_Answer = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.TrueAndFalse_Question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Question_Id = c.Int(nullable: false),
                        TAndF_Correct_Answer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "Instructor2_Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.TrueAndFalse_Question", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Text_Question", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TrueAndFalse_Answer", "Student_Answer_Id", "dbo.Student_Answer");
            DropForeignKey("dbo.Text_Answer", "Student_Answer_Id", "dbo.Student_Answer");
            DropForeignKey("dbo.Students_Course", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students_Course", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Student_Degree", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Student_Degree", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Student_Answer", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Login_User_ID", "dbo.Login_User");
            DropForeignKey("dbo.Instructors", "Login_User_ID", "dbo.Login_User");
            DropForeignKey("dbo.ITIs", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Courses", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Students", "ITI_Id", "dbo.ITIs");
            DropForeignKey("dbo.ITIs", "Intake_Id", "dbo.Intakes");
            DropForeignKey("dbo.ITIs", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Student_Answer", "Question_id", "dbo.Questions");
            DropForeignKey("dbo.MCQ_Answer", "Student_Answer_Id", "dbo.Student_Answer");
            DropForeignKey("dbo.Student_Answer", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.MC_Question", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Exam_Question", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Exam_Question", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Instructors", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.TrueAndFalse_Question", new[] { "Question_Id" });
            DropIndex("dbo.Text_Question", new[] { "Question_Id" });
            DropIndex("dbo.TrueAndFalse_Answer", new[] { "Student_Answer_Id" });
            DropIndex("dbo.Text_Answer", new[] { "Student_Answer_Id" });
            DropIndex("dbo.Students_Course", new[] { "Student_Id" });
            DropIndex("dbo.Students_Course", new[] { "Course_Id" });
            DropIndex("dbo.Student_Degree", new[] { "Exam_Id" });
            DropIndex("dbo.Student_Degree", new[] { "Student_Id" });
            DropIndex("dbo.ITIs", new[] { "Track_Id" });
            DropIndex("dbo.ITIs", new[] { "Intake_Id" });
            DropIndex("dbo.ITIs", new[] { "Branch_Id" });
            DropIndex("dbo.Students", new[] { "Login_User_ID" });
            DropIndex("dbo.Students", new[] { "ITI_Id" });
            DropIndex("dbo.MCQ_Answer", new[] { "Student_Answer_Id" });
            DropIndex("dbo.Student_Answer", new[] { "Question_id" });
            DropIndex("dbo.Student_Answer", new[] { "Exam_Id" });
            DropIndex("dbo.Student_Answer", new[] { "Student_Id" });
            DropIndex("dbo.MC_Question", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "Course_Id" });
            DropIndex("dbo.Exam_Question", new[] { "Question_Id" });
            DropIndex("dbo.Exam_Question", new[] { "Exam_Id" });
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Track_Id" });
            DropIndex("dbo.Courses", new[] { "Instructor_Id" });
            DropIndex("dbo.Instructors", new[] { "Instructor2_Instructor_Id" });
            DropIndex("dbo.Instructors", new[] { "Login_User_ID" });
            DropIndex("dbo.Instructors", new[] { "Branch_Id" });
            DropTable("dbo.TrueAndFalse_Question");
            DropTable("dbo.Text_Question");
            DropTable("dbo.TrueAndFalse_Answer");
            DropTable("dbo.Text_Answer");
            DropTable("dbo.Students_Course");
            DropTable("dbo.Student_Degree");
            DropTable("dbo.Login_User");
            DropTable("dbo.Tracks");
            DropTable("dbo.Intakes");
            DropTable("dbo.ITIs");
            DropTable("dbo.Students");
            DropTable("dbo.MCQ_Answer");
            DropTable("dbo.Student_Answer");
            DropTable("dbo.MC_Question");
            DropTable("dbo.Questions");
            DropTable("dbo.Exam_Question");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
            DropTable("dbo.Instructors");
            DropTable("dbo.Branches");
        }
    }
}
