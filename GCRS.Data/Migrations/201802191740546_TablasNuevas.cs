namespace GCRS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasNuevas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ofertas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.Int(nullable: false),
                        FechaI = c.DateTime(),
                        FechaF = c.DateTime(),
                        PrecioxUTR = c.Int(),
                        CantUTR = c.Int(),
                        Precio = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Agente_Id = c.Int(),
                        Cliente_Id = c.Int(),
                        Inmueble_Id = c.Int(),
                        UTR_Id = c.Int(),
                        Cliente_Id1 = c.Int(),
                        Cliente_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agentes", t => t.Agente_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Inmuebles", t => t.Inmueble_Id)
                .ForeignKey("dbo.UnidadTiempoRentas", t => t.UTR_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id1)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id2)
                .Index(t => t.Agente_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Inmueble_Id)
                .Index(t => t.UTR_Id)
                .Index(t => t.Cliente_Id1)
                .Index(t => t.Cliente_Id2);
            
            CreateTable(
                "dbo.Inmuebles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantHabitaciones = c.Int(nullable: false),
                        Direccion = c.String(),
                        InfoAdicional = c.String(),
                        Categoria_Id = c.Int(),
                        Municipio_Id = c.Int(),
                        Provincia_Id = c.Int(),
                        Reparto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .ForeignKey("dbo.Municipios", t => t.Municipio_Id)
                .ForeignKey("dbo.Provincias", t => t.Provincia_Id)
                .ForeignKey("dbo.Repartoes", t => t.Reparto_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Municipio_Id)
                .Index(t => t.Provincia_Id)
                .Index(t => t.Reparto_Id);
     
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ofertas", "Cliente_Id2", "dbo.Clientes");
            DropForeignKey("dbo.Ofertas", "Cliente_Id1", "dbo.Clientes");
            DropForeignKey("dbo.Ofertas", "UTR_Id", "dbo.UnidadTiempoRentas");
            DropForeignKey("dbo.Ofertas", "Inmueble_Id", "dbo.Inmuebles");
            DropForeignKey("dbo.Inmuebles", "Reparto_Id", "dbo.Repartoes");
            DropForeignKey("dbo.Inmuebles", "Provincia_Id", "dbo.Provincias");
            DropForeignKey("dbo.Inmuebles", "Municipio_Id", "dbo.Municipios");
            DropForeignKey("dbo.Inmuebles", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Ofertas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Ofertas", "Agente_Id", "dbo.Agentes");
            DropIndex("dbo.Inmuebles", new[] { "Reparto_Id" });
            DropIndex("dbo.Inmuebles", new[] { "Provincia_Id" });
            DropIndex("dbo.Inmuebles", new[] { "Municipio_Id" });
            DropIndex("dbo.Inmuebles", new[] { "Categoria_Id" });
            DropIndex("dbo.Ofertas", new[] { "Cliente_Id2" });
            DropIndex("dbo.Ofertas", new[] { "Cliente_Id1" });
            DropIndex("dbo.Ofertas", new[] { "UTR_Id" });
            DropIndex("dbo.Ofertas", new[] { "Inmueble_Id" });
            DropIndex("dbo.Ofertas", new[] { "Cliente_Id" });
            DropIndex("dbo.Ofertas", new[] { "Agente_Id" });
            DropTable("dbo.UnidadTiempoRentas");
            DropTable("dbo.Repartoes");
            DropTable("dbo.Provincias");
            DropTable("dbo.Municipios");
            DropTable("dbo.Inmuebles");
            DropTable("dbo.Ofertas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Agentes");
            DropTable("dbo.Admins");
        }
    }
}
