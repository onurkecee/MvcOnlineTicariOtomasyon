namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
          //  DropTable("dbo.Mesajlars");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Mesajlars",
            //    c => new
            //        {
            //            MESAJID = c.Int(nullable: false, identity: true),
            //            GONDERICI = c.String(maxLength: 50, unicode: false),
            //            ALICI = c.String(maxLength: 50, unicode: false),
            //            KONU = c.String(maxLength: 50, unicode: false),
            //            ICERIK = c.String(maxLength: 2000, unicode: false),
            //            TARIH = c.DateTime(nullable: false, storeType: "smalldatetime"),
            //        })
            //    .PrimaryKey(t => t.MESAJID);
            
        }
    }
}
