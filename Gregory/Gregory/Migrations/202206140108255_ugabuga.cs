namespace Gregory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ugabuga : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RoupaModels", name: "Fornecedor_Id", newName: "FornecedorId");
            RenameIndex(table: "dbo.RoupaModels", name: "IX_Fornecedor_Id", newName: "IX_FornecedorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RoupaModels", name: "IX_FornecedorId", newName: "IX_Fornecedor_Id");
            RenameColumn(table: "dbo.RoupaModels", name: "FornecedorId", newName: "Fornecedor_Id");
        }
    }
}
