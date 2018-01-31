namespace OnlineShopModel.Migrations
{
    using Model.EF;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.EF.OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.EF.OnlineShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Accounts.AddOrUpdate(new Account() { UserName = "daty", PassWord = "c4ca4238a0b923820dcc509a6f75849b", Name ="Dang Huynh Dat Y" });

            context.SaveChanges();
        }
    }
}