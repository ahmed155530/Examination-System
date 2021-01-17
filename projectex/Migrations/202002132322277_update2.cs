namespace projectex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "login_id");
            RenameColumn(table: "dbo.Students", name: "Login_User_ID", newName: "login_id");
            RenameIndex(table: "dbo.Students", name: "IX_Login_User_ID", newName: "IX_login_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_login_id", newName: "IX_Login_User_ID");
            RenameColumn(table: "dbo.Students", name: "login_id", newName: "Login_User_ID");
            AddColumn("dbo.Students", "login_id", c => c.Int());
        }
    }
}
