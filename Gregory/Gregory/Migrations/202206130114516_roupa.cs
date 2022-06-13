namespace Gregory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roupa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FornecedorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Pais = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoupaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cor = c.String(nullable: false),
                        Estampa = c.String(nullable: false),
                        Preco = c.Single(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FornecedorModels", t => t.Fornecedor_Id)
                .Index(t => t.Fornecedor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoupaModels", "Fornecedor_Id", "dbo.FornecedorModels");
            DropIndex("dbo.RoupaModels", new[] { "Fornecedor_Id" });
            DropTable("dbo.RoupaModels");
            DropTable("dbo.FornecedorModels");
        }
    }
}
