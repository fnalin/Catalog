using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Category (Name, CreatedAt) VALUES ('Category 1', GetDate());
                INSERT INTO Category (Name, CreatedAt) VALUES ('Category 2', GetDate());
                INSERT INTO Category (Name, CreatedAt) VALUES ('Category 3', GetDate());
                INSERT INTO Category (Name, CreatedAt) VALUES ('Category 4', GetDate());
                INSERT INTO Category (Name, CreatedAt) VALUES ('Category 5', GetDate());
                
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 1', 10, 1, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 2', 20, 1, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 3', 30, 2, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 4', 40, 2, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 5', 50, 3, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 6', 60, 3, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 7', 70, 4, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 8', 80, 4, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ('Product 9', 90, 5, GetDate());
                INSERT INTO Product (Name, Price, CategoryId, CreatedAt) VALUES ( 'Product 10', 100, 5, GetDate());
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
