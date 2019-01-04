namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Pay As You Go' WHERE Id=1");
            Sql("Update MembershipTypes SET Name='Weekly' WHERE Id=2");
            Sql("Update MembershipTypes SET Name='Monthly' WHERE Id=3");
            Sql("Update MembershipTypes SET Name='Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
