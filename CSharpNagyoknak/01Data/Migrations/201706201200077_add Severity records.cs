namespace _01Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSeverityrecords : DbMigration
    {
        public override void Up()
        {
            //COMMENT: Nem adtam meg az adatb�zis kulcs�t
            //Sql("insert Severities (Title) values ('Fontos')");
            //Sql("insert Severities (Title) values ('Nem fontos')");

            //Megadom az azonos�t�t
            Sql("set identity_insert dbo.Severities on");
            Sql("insert Severities (Id, Title) values (1, 'Fontos')");
            Sql("insert Severities (Id, Title) values (2, 'Nem fontos')");
            Sql("set identity_insert dbo.Severities off");
        }

        public override void Down()
        {
            //COMMENT: a megnevez�sre keresek, nem a kulcs�ra a rekordnak
            //Sql("delete Severities where Title='Fontos'");
            //Sql("delete Severities where Title='Nem fontos'");
            Sql("delete Severities where Id=1");
            Sql("delete Severities where Id=2");
        }
    }
}
