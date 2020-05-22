namespace Netbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INSERTmoviesDB : DbMigration
    {
        public override void Up()

        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES" +
                " ('Troy',1, '2019-06-18', '2019-06-18',10)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES" +
                " ('Spider Man 3',2, '2017-05-20', '2019-06-18',3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES" +
                " ('X-Man 2',3, '2015-04-09', '2019-06-18',4)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES" +
                " ('The Terminator 4',4, '2018-10-07', '2019-06-18',9)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES" +
                " ('Fast 9',5, '2020-03-5', '2020-05-1',100)");
            Sql("SET IDENTITY_INSERT Movies OFF");

        }
        
        public override void Down()
        {
        }
    }
}
