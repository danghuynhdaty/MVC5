namespace OnlineShopModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLongToInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.About");
            DropPrimaryKey("dbo.CategoryNews");
            DropPrimaryKey("dbo.Content");
            DropPrimaryKey("dbo.ContentTag");
            DropPrimaryKey("dbo.ProductCategory");
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.About", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Account", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.CategoryNews", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CategoryNews", "ParentID", c => c.Int());
            AlterColumn("dbo.Content", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Content", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.ContentTag", "ContentID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductCategory", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ProductCategory", "ParentID", c => c.Int());
            AlterColumn("dbo.Product", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Product", "CategoryID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.About", "ID");
            AddPrimaryKey("dbo.CategoryNews", "ID");
            AddPrimaryKey("dbo.Content", "ID");
            AddPrimaryKey("dbo.ContentTag", new[] { "ContentID", "TagID" });
            AddPrimaryKey("dbo.ProductCategory", "ID");
            AddPrimaryKey("dbo.Product", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Product");
            DropPrimaryKey("dbo.ProductCategory");
            DropPrimaryKey("dbo.ContentTag");
            DropPrimaryKey("dbo.Content");
            DropPrimaryKey("dbo.CategoryNews");
            DropPrimaryKey("dbo.About");
            AlterColumn("dbo.Product", "CategoryID", c => c.Long(nullable: false));
            AlterColumn("dbo.Product", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ProductCategory", "ParentID", c => c.Long());
            AlterColumn("dbo.ProductCategory", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ContentTag", "ContentID", c => c.Long(nullable: false));
            AlterColumn("dbo.Content", "CategoryID", c => c.Long(nullable: false));
            AlterColumn("dbo.Content", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.CategoryNews", "ParentID", c => c.Long());
            AlterColumn("dbo.CategoryNews", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Account", "ModifiedBy", c => c.Long());
            AlterColumn("dbo.About", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Product", "ID");
            AddPrimaryKey("dbo.ProductCategory", "ID");
            AddPrimaryKey("dbo.ContentTag", new[] { "ContentID", "TagID" });
            AddPrimaryKey("dbo.Content", "ID");
            AddPrimaryKey("dbo.CategoryNews", "ID");
            AddPrimaryKey("dbo.About", "ID");
        }
    }
}
