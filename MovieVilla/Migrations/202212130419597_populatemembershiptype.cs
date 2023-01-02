namespace MovieVilla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershiptype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Description", c => c.String(nullable: false));
            Sql("INSERT INTO dbo.MembershipTypes(MembershipTypeId,Description,duration,discount) VALUES(1,'Pay as you go',0,0)");
            Sql("INSERT INTO dbo.MembershipTypes(MembershipTypeId,Description,duration,discount) VALUES(2,'Monthly',1,5)");
            Sql("INSERT INTO dbo.MembershipTypes(MembershipTypeId,Description,duration,discount) VALUES(3,'Quaterly',3,10)");
            Sql("INSERT INTO dbo.MembershipTypes(MembershipTypeId,Description,duration,discount) VALUES(4,'Yearly',12,20)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Description", c => c.String());
        }
    }
}
