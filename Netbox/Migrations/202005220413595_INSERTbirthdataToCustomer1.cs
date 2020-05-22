namespace Netbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INSERTbirthdataToCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1992-09-01' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
