using System.Data;
using FunkyCode.AdventureWorks.EntityFramework.Context;
using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace FunkyCode.AdventureWorks.Test.Integration
{
    public class Tests
    {
        [SetUp]
        public void Init()
        {
            using var conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master; Integrated Security = True");
            using var cmd = new SqlCommand("sp_dropRestoreDb", conn) {CommandType = CommandType.StoredProcedure};

            conn.Open();

            cmd.Parameters.Add(new SqlParameter("@databaseName", "AdventureWorks2016"));
            cmd.Parameters.Add(new SqlParameter("@backupPath", @"c:\Projects\Pets\blogengine\_devops\Db-backups\"));
            
            cmd.ExecuteNonQuery();
        }

        [Test]
        public void ProductReview_1_Should_Be_Removed()
        {
            using var ctx = new AdventureWorks2016DbContext();
            var productReview = ctx.ProductReview.Find(1);
            ctx.ProductReview.Remove(productReview);
            ctx.SaveChanges();
        }

        [Test]
        public void ProductReview_1_Should_Be_Updated()
        {
            using var ctx = new AdventureWorks2016DbContext();
            var productReview = ctx.ProductReview.Find(1);
            productReview.Comments = "Updated";
            ctx.SaveChanges();
        }
    }
}