namespace MovieAndCustomerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdateForCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1992-08-17' WHERE Name = 'Jay' ");
        }
        
        public override void Down()
        {
        }
    }
}
