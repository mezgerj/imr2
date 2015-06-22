namespace Inspinia_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGeolocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geolocations",
                c => new
                    {
                        GeolocationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Altitude = c.Single(nullable: false),
                        Description = c.String(),
                        Application_Id = c.Int(nullable: false),
                        Parent_Geo_Id = c.Int(nullable: false),
                        Range = c.Single(nullable: false),
                        DownloadTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeolocationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Geolocations");
        }
    }
}
