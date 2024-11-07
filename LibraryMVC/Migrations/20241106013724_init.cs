using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: true),
                    Runtime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_LibraryCardId", x => x.LibraryCardId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryItemId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowingHistories_LibraryItems_LibraryItemId",
                        column: x => x.LibraryItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingHistories_Users_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "Users",
                        principalColumn: "LibraryCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 1, "Derick Roob", "Book", 99, new DateTime(2022, 8, 15, 2, 55, 55, 749, DateTimeKind.Local).AddTicks(6748), 5, "Non nemo et quasi." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 2, "Barton Denesik", "DVD", new DateTime(2021, 7, 22, 2, 44, 46, 593, DateTimeKind.Local).AddTicks(395), 8, "86", "Accusantium voluptas similique maxime." },
                    { 3, "Kim Nolan", "DVD", new DateTime(2021, 3, 4, 12, 2, 11, 815, DateTimeKind.Local).AddTicks(8101), 5, "98", "Aut officia culpa qui." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 4, "Adella Ratke", "Book", 84, new DateTime(2020, 12, 15, 3, 18, 40, 609, DateTimeKind.Local).AddTicks(8442), 5, "Iure magnam adipisci fugit." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 5, "Nikki Aufderhar", "Magazine", new DateTime(2021, 9, 21, 2, 58, 7, 942, DateTimeKind.Local).AddTicks(9671), 8, "Exercitationem quam repellat nulla." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 6, "Mack Zieme", "Book", 108, new DateTime(2022, 5, 23, 23, 42, 52, 984, DateTimeKind.Local).AddTicks(4690), 8, "Possimus rerum doloribus est." },
                    { 7, "Houston Glover", "Book", 57, new DateTime(2021, 11, 16, 0, 50, 5, 403, DateTimeKind.Local).AddTicks(9421), 10, "Cum placeat non dignissimos." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 8, "Trinity Wintheiser", "DVD", new DateTime(2021, 2, 7, 6, 55, 40, 210, DateTimeKind.Local).AddTicks(8322), 9, "134", "Eum voluptas maiores molestiae." },
                    { 9, "Tod Durgan", "DVD", new DateTime(2021, 2, 26, 20, 9, 46, 374, DateTimeKind.Local).AddTicks(1883), 8, "108", "Voluptatibus possimus culpa possimus." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 10, "Ardella Kunde", "Magazine", new DateTime(2021, 2, 1, 11, 18, 20, 900, DateTimeKind.Local).AddTicks(9897), 9, "Incidunt ea blanditiis voluptate." },
                    { 11, "Geo Mayert", "Magazine", new DateTime(2022, 9, 29, 0, 4, 15, 672, DateTimeKind.Local).AddTicks(3828), 7, "Molestiae quia ut maxime." },
                    { 12, "Sanford Little", "Magazine", new DateTime(2022, 3, 11, 10, 8, 55, 919, DateTimeKind.Local).AddTicks(7571), 9, "Possimus nisi deleniti eos." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 13, "May Quitzon", "DVD", new DateTime(2022, 2, 20, 20, 59, 31, 904, DateTimeKind.Local).AddTicks(2298), 8, "129", "Reprehenderit necessitatibus ipsam vero." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 14, "Eula Heaney", "Book", 98, new DateTime(2021, 9, 26, 1, 34, 22, 217, DateTimeKind.Local).AddTicks(9948), 8, "Porro quae fuga aut." },
                    { 15, "Travon Streich", "Book", 96, new DateTime(2022, 6, 15, 16, 8, 49, 550, DateTimeKind.Local).AddTicks(1454), 5, "Nihil est aut et." },
                    { 16, "Jailyn Swift", "Book", 79, new DateTime(2021, 11, 13, 21, 49, 26, 731, DateTimeKind.Local).AddTicks(9230), 7, "Repudiandae quam asperiores qui." },
                    { 17, "Frederik Schoen", "Book", 63, new DateTime(2022, 8, 6, 7, 11, 57, 875, DateTimeKind.Local).AddTicks(7948), 10, "Ea enim rerum officia." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 18, "Leda Ankunding", "Magazine", new DateTime(2022, 3, 19, 20, 0, 0, 11, DateTimeKind.Local).AddTicks(8555), 10, "Qui quod nemo soluta." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 19, "Madge Morar", "DVD", new DateTime(2021, 9, 4, 5, 28, 1, 749, DateTimeKind.Local).AddTicks(5653), 5, "125", "Modi accusamus aut et." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 20, "Adonis Crooks", "Magazine", new DateTime(2021, 12, 18, 9, 50, 32, 92, DateTimeKind.Local).AddTicks(9563), 5, "Consequuntur est fugit ut." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 21, "Devin Stokes", "DVD", new DateTime(2022, 2, 24, 20, 31, 8, 486, DateTimeKind.Local).AddTicks(3151), 9, "141", "Temporibus consequatur est necessitatibus." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 22, "Sherwood McKenzie", "Book", 134, new DateTime(2022, 5, 6, 17, 18, 2, 249, DateTimeKind.Local).AddTicks(3616), 7, "Molestiae quia quia quia." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 23, "Jodie Hahn", "Magazine", new DateTime(2020, 11, 11, 0, 29, 2, 284, DateTimeKind.Local).AddTicks(7173), 5, "Et in architecto perferendis." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 24, "Sidney Renner", "DVD", new DateTime(2022, 1, 3, 11, 22, 58, 549, DateTimeKind.Local).AddTicks(3496), 10, "90", "Aliquam reiciendis ipsa molestiae." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 25, "Nicola Gorczany", "Magazine", new DateTime(2021, 7, 28, 7, 25, 50, 952, DateTimeKind.Local).AddTicks(8219), 10, "Vitae qui itaque debitis." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 26, "Amaya MacGyver", "Book", 86, new DateTime(2021, 11, 1, 16, 58, 34, 332, DateTimeKind.Local).AddTicks(9387), 7, "Similique ullam minima nisi." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 27, "Annalise Skiles", "Magazine", new DateTime(2021, 8, 18, 15, 57, 19, 914, DateTimeKind.Local).AddTicks(3183), 10, "Quo distinctio sint dolorem." },
                    { 28, "Amos Volkman", "Magazine", new DateTime(2021, 4, 24, 12, 45, 53, 372, DateTimeKind.Local).AddTicks(8777), 8, "Totam unde incidunt delectus." },
                    { 29, "Lavern Grant", "Magazine", new DateTime(2020, 12, 1, 4, 53, 50, 891, DateTimeKind.Local).AddTicks(7116), 10, "Molestiae hic voluptatem reprehenderit." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 30, "Joanne Schoen", "Book", 123, new DateTime(2022, 7, 8, 2, 15, 10, 428, DateTimeKind.Local).AddTicks(6050), 9, "Impedit ad dolorem vel." },
                    { 31, "Ova Spinka", "Book", 124, new DateTime(2022, 8, 16, 1, 9, 53, 780, DateTimeKind.Local).AddTicks(5843), 8, "Illum et alias perferendis." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 32, "Bonita Green", "Magazine", new DateTime(2020, 12, 6, 15, 55, 45, 16, DateTimeKind.Local).AddTicks(7446), 7, "Quia et est tenetur." },
                    { 33, "Helena Durgan", "Magazine", new DateTime(2022, 4, 29, 0, 20, 56, 283, DateTimeKind.Local).AddTicks(8119), 5, "Mollitia expedita aperiam minus." },
                    { 34, "Derek Klein", "Magazine", new DateTime(2021, 12, 23, 8, 9, 21, 487, DateTimeKind.Local).AddTicks(1588), 6, "Iure voluptatibus iste quo." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 35, "Jaleel Sauer", "DVD", new DateTime(2021, 10, 6, 13, 57, 53, 67, DateTimeKind.Local).AddTicks(4528), 5, "75", "Ipsum et autem ea." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 36, "Sydney West", "Magazine", new DateTime(2021, 7, 14, 12, 28, 48, 1, DateTimeKind.Local).AddTicks(8346), 9, "Cum non aliquid rerum." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 37, "Dulce Kessler", "Book", 124, new DateTime(2020, 12, 2, 7, 45, 48, 119, DateTimeKind.Local).AddTicks(289), 6, "Minus sequi illum qui." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 38, "Gerda Abshire", "DVD", new DateTime(2021, 11, 12, 20, 23, 21, 433, DateTimeKind.Local).AddTicks(9691), 9, "136", "Molestiae cum accusantium voluptatibus." },
                    { 39, "Kitty Gerhold", "DVD", new DateTime(2022, 6, 12, 14, 51, 46, 39, DateTimeKind.Local).AddTicks(3920), 9, "125", "Tempora rerum in quia." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 40, "Payton Jakubowski", "Book", 121, new DateTime(2020, 12, 16, 11, 28, 17, 81, DateTimeKind.Local).AddTicks(1797), 9, "Rerum quia laboriosam aut." });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LibraryCardId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Admin Address", "2e5f2460-78bb-4479-9adb-8891207a2e83", "admin@gmail.com", true, new Guid("727ae296-7a61-4871-b530-28f15ea62050"), false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEC6xobf2F0sDkwPyhHSGAOP9NubrURARJdeuWDypxvPk8Xe6VmgTU12ejhGIlOjXQA==", "123456789", false, "7572eb36-6fc8-4c56-a80e-daf34ccb5dcc", false, "admin" },
                    { 2, 0, "20020 Rosenbaum Drive", "df59d357-efbb-497a-8567-30b2cb930f75", "Tre.Torphy3@gmail.com", true, new Guid("08fb96d4-e236-40ea-aac3-6ba468e9ef0f"), false, null, "Marlee Cruickshank", "TRE.TORPHY3@GMAIL.COM", "TRE.TORPHY3@GMAIL.COM", "AQAAAAIAAYagAAAAEJvkjDUsIhsQG+qo9q0Hq+41zCBAslhDfJcccSX3480/pe1+dNt9DGsR4K8FqxYk2w==", "1-348-398-2822 x42124", false, "cc64e50f-f302-4194-a7e7-8d2ba96be9f0", false, "Tre.Torphy3@gmail.com" },
                    { 3, 0, "47466 Altenwerth Club", "152b349b-3a20-4824-81ed-c8a3fcdaa56a", "Rolando.Zulauf@hotmail.com", true, new Guid("a7979d46-e381-4e03-8d8c-de9e5d6b5493"), false, null, "Precious Heller", "ROLANDO.ZULAUF@HOTMAIL.COM", "ROLANDO.ZULAUF@HOTMAIL.COM", "AQAAAAIAAYagAAAAEHtuHnpcJO1bcTUStjtenR9/F44CJ8g36/2aAopUXAumKkXmbVCfCgVKx1yhLCqTvA==", "341.369.1396 x26801", false, "a191dda3-32e0-464b-ae4a-cfbb1de9a763", false, "Rolando.Zulauf@hotmail.com" },
                    { 4, 0, "06617 Beverly Cliff", "c7f4bd72-8f7c-4dfb-b16a-a9c74e3eefb1", "Shana.Kautzer22@hotmail.com", true, new Guid("51a9193e-bab3-4470-b4e0-cb58e064be55"), false, null, "Elva Labadie", "SHANA.KAUTZER22@HOTMAIL.COM", "SHANA.KAUTZER22@HOTMAIL.COM", "AQAAAAIAAYagAAAAEO27y7GgsBjF0h3JJTuIejyd7AlHAggoOcSyL5fQULy9YVW54qhjRlRPNpM0FU+BSw==", "592-507-2060 x9253", false, "332cafe7-c220-4351-866f-f279ab7b88bd", false, "Shana.Kautzer22@hotmail.com" },
                    { 5, 0, "173 Donald Tunnel", "1e50e93d-e1e7-4675-9eb0-5b07f11bdd69", "Gilberto68@hotmail.com", true, new Guid("9a16aeaf-c0db-48c7-a4c9-af7148904620"), false, null, "Forrest Ebert", "GILBERTO68@HOTMAIL.COM", "GILBERTO68@HOTMAIL.COM", "AQAAAAIAAYagAAAAECyPKNY0BQ8agvnMn6RoYEP4GfUobP2K6kt1IvbWadtREzvWvEyag9bzCgmCxXzo9A==", "1-312-794-5246 x207", false, "bc348a76-91a8-4d16-88dc-e2fa782642d8", false, "Gilberto68@hotmail.com" },
                    { 6, 0, "932 Bennie Center", "c24c07de-7b00-4631-9d66-e41ec1d63889", "Helena32@hotmail.com", true, new Guid("ab002241-e0d0-4a42-8542-f8c30747982b"), false, null, "Adolf Sanford", "HELENA32@HOTMAIL.COM", "HELENA32@HOTMAIL.COM", "AQAAAAIAAYagAAAAEPdQg7nCmWOpRYXfKniltw3q5Sbp0tuCaKEi0Y93TT/rUISH36vZ0E3smODZrOPGxA==", "267.973.3355 x742", false, "01f9b56e-4f34-4653-8b20-5ddfa9fdb9e2", false, "Helena32@hotmail.com" },
                    { 7, 0, "5864 Rod Light", "145f7233-f9d0-46b6-b01d-29d455e1db33", "Marcel_Zieme95@hotmail.com", true, new Guid("56e19e8b-b83b-4d52-95f5-2731ce2d0638"), false, null, "Connie Quitzon", "MARCEL_ZIEME95@HOTMAIL.COM", "MARCEL_ZIEME95@HOTMAIL.COM", "AQAAAAIAAYagAAAAECePmywMXOzF5+LRsEaAmhYof8KJyLbV0RFoibRSc3RqkKh7YcMx5eoPEaZNYFGazw==", "681-538-1439 x7115", false, "3c282685-5eba-4ae9-9cfc-a0d222bbae1c", false, "Marcel_Zieme95@hotmail.com" },
                    { 8, 0, "10370 Huels Coves", "7b9fde09-e765-4b7e-85b8-1ac50eb7e249", "Travis.Gorczany@hotmail.com", true, new Guid("606698ff-4b14-4fca-be38-b14372aff76a"), false, null, "Ivory Upton", "TRAVIS.GORCZANY@HOTMAIL.COM", "TRAVIS.GORCZANY@HOTMAIL.COM", "AQAAAAIAAYagAAAAEOPnXbsq3pLg+IMQuBW32O0BJcMtYy62vjpN77Dih/z01ZgfQdWJ/qifEkMfc+g1tw==", "1-409-911-1722 x0081", false, "da032778-1849-494b-bf87-e7136eaa1f04", false, "Travis.Gorczany@hotmail.com" },
                    { 9, 0, "93780 Aniyah Manors", "89cd6931-fc05-4661-acea-efd81a604d58", "Treva_Quitzon@hotmail.com", true, new Guid("7c0feafe-f7fa-4a20-8ae7-3c1d0e737703"), false, null, "Linnie Ruecker", "TREVA_QUITZON@HOTMAIL.COM", "TREVA_QUITZON@HOTMAIL.COM", "AQAAAAIAAYagAAAAEK12w02rw9zZJNQfafiWkEMZCVi5xJOcWugCwHMOeJ3bwfH52NJ7hr0SpRvy1WP2rA==", "(347) 572-4863", false, "b047cbba-790b-429d-b842-fafcfecb905f", false, "Treva_Quitzon@hotmail.com" },
                    { 10, 0, "828 Shanahan Forges", "83e67e6c-59a6-41bc-b8c9-e13cf111644c", "Maribel81@gmail.com", true, new Guid("75e786fe-dcc7-4899-ab89-463570c06e48"), false, null, "Buck Kunde", "MARIBEL81@GMAIL.COM", "MARIBEL81@GMAIL.COM", "AQAAAAIAAYagAAAAEPHze2UNWGJRcwV2QeBHdAatnrYOhKD9gP11EuHTMMcvxD6LGCjHrFsYw0LJhAH9kg==", "866-676-4646", false, "c2c879b7-dd34-4eed-8e05-8d29e2c16ced", false, "Maribel81@gmail.com" },
                    { 11, 0, "362 Olson Mountain", "300bba0f-08ce-48b3-93e2-0898fc3d68e6", "Tiffany_Beier33@hotmail.com", true, new Guid("c5e7752a-3e88-4330-84f9-25c9b2e8bcf0"), false, null, "Myra Emard", "TIFFANY_BEIER33@HOTMAIL.COM", "TIFFANY_BEIER33@HOTMAIL.COM", "AQAAAAIAAYagAAAAEIDmmHi519vkuWJLpixhI3cxhgYJtfv/5xcERXyWttNchNsbD5gICApupaD9yefcTA==", "743-762-1409", false, "07eb6b6d-7377-4d4c-a870-fb700863d022", false, "Tiffany_Beier33@hotmail.com" },
                    { 12, 0, "281 Muller Turnpike", "23b58b29-f1af-4f9e-b317-acfdbab1dff6", "Madeline95@gmail.com", true, new Guid("a02e8fc9-d75d-4e64-8c9b-94720fe25f69"), false, null, "Gregoria Mertz", "MADELINE95@GMAIL.COM", "MADELINE95@GMAIL.COM", "AQAAAAIAAYagAAAAEO2GQtE767vM8NsD2PaJrWjh2OKgBN6Pgl2s+6zoknee6ruHnm8+eTObxmEYnipjrQ==", "762.931.4569 x699", false, "d8f45742-ebd6-42e2-89b7-f0b598af42cd", false, "Madeline95@gmail.com" },
                    { 13, 0, "7897 Antonina Knoll", "04a1f758-d54d-450f-a9ee-aa5fbf962193", "David.Kautzer@hotmail.com", true, new Guid("dbbd9b3f-9c8f-491c-88fc-59a8f7bb782f"), false, null, "Hunter Grimes", "DAVID.KAUTZER@HOTMAIL.COM", "DAVID.KAUTZER@HOTMAIL.COM", "AQAAAAIAAYagAAAAEPFwsEwm0CSukKs4djoMn/vIDKYDf4bJpGPdgY688zYc5oM/ktlxG+GGUQNUFXROAg==", "270.842.7484 x4958", false, "bd7762e6-acaf-44f3-a6d8-bbacbffacf68", false, "David.Kautzer@hotmail.com" },
                    { 14, 0, "38293 Juliana Islands", "0f7e0936-47b9-492c-8693-c6936645ee9a", "Alexa51@yahoo.com", true, new Guid("16e4ad6b-e6f7-417a-a9f1-c102e17a1767"), false, null, "Norwood Towne", "ALEXA51@YAHOO.COM", "ALEXA51@YAHOO.COM", "AQAAAAIAAYagAAAAECvf2Le1mD0yXzuQzLk04vOykGU+GrarASUVjWluSRDSZlY5ne3ClP5mme/VwYZifQ==", "1-965-272-7658 x9053", false, "42fe669f-2ca8-440a-acb4-3e4dea6f6159", false, "Alexa51@yahoo.com" },
                    { 15, 0, "172 Ledner Fords", "504e5ab4-57f6-4716-8754-b2d0782f2ff0", "Alison79@gmail.com", true, new Guid("8a8c4e60-3a0b-4ffa-b5df-992852757cfe"), false, null, "Gardner Sporer", "ALISON79@GMAIL.COM", "ALISON79@GMAIL.COM", "AQAAAAIAAYagAAAAEEyQ/wQJZwxeifKKQLR9L3eZ4E6SAVfRBmEWAmYEzXPvKFZUncJ/Np9U4G09oYphZA==", "919.223.6317", false, "80e5c970-a5c1-4f1d-a27f-0b0d562e55cd", false, "Alison79@gmail.com" },
                    { 16, 0, "685 Jast Cliffs", "f62e2175-3a18-41dc-8b1c-162f0799fe1a", "Jazlyn_Considine67@hotmail.com", true, new Guid("c83e6913-2d58-4c8f-971f-2fda26b6b8e9"), false, null, "Betty Lueilwitz", "JAZLYN_CONSIDINE67@HOTMAIL.COM", "JAZLYN_CONSIDINE67@HOTMAIL.COM", "AQAAAAIAAYagAAAAEMwi9o93JVDR/qqqPY1wuNQp9hi6wtywt/MSmgYMP3terbU4F96Qhq+Z4HBQDXHGLg==", "1-697-884-8725 x313", false, "d3858672-b5bd-4e40-b79a-3f2fa2e81600", false, "Jazlyn_Considine67@hotmail.com" },
                    { 17, 0, "063 Quitzon Junction", "814d47d4-9e86-4d91-87fd-c8d1562da2e0", "Elenora71@yahoo.com", true, new Guid("35a6209f-3f8f-446b-8ce4-09e2b718666d"), false, null, "Emerald Hoppe", "ELENORA71@YAHOO.COM", "ELENORA71@YAHOO.COM", "AQAAAAIAAYagAAAAEP+e+OM3fCWP/C8i/giJBAJwiEO7oXp20n4nBiebm3dYXyRhV/CkdHeMVcU0JhhLRw==", "565.535.9196 x003", false, "f4e08588-3bd2-4f77-891f-7b07963e6836", false, "Elenora71@yahoo.com" },
                    { 18, 0, "309 Nona Common", "ac0d1f18-86d2-414d-a1b7-99cf7f4a1940", "Taurean_Crona80@gmail.com", true, new Guid("abc31af5-ba57-4bf8-a43f-23b46017dd3a"), false, null, "Susan Bahringer", "TAUREAN_CRONA80@GMAIL.COM", "TAUREAN_CRONA80@GMAIL.COM", "AQAAAAIAAYagAAAAEI+K73Fwra1gpQ6a+WT6X1X88ioBJAquKdb9jrWQKLzqm0JsQpqflR0vFteMVb7yNg==", "882.235.9884 x693", false, "52bf44a0-1cdd-4792-a5a6-146bc536e6d5", false, "Taurean_Crona80@gmail.com" },
                    { 19, 0, "4938 Erdman Camp", "4453198e-2184-490b-8d69-191f742205b2", "Milan93@yahoo.com", true, new Guid("52db1c36-52f0-440e-98f4-db9974e723cc"), false, null, "Gerhard Witting", "MILAN93@YAHOO.COM", "MILAN93@YAHOO.COM", "AQAAAAIAAYagAAAAEJ8bNk7gG/NBQ4cMO2jXHYVEiQH5CY8OXRa4/ChWgzZIZq6BqKaMcbEKqVH0myAlaw==", "(329) 519-1288", false, "8437982c-80eb-4f5c-b5bb-d899b127e1fe", false, "Milan93@yahoo.com" },
                    { 20, 0, "71082 Paucek Rapids", "ba1b8a48-7d88-4da6-bb7a-0171fc6834d7", "Colleen14@yahoo.com", true, new Guid("75b74ed7-5a25-48c1-8e81-609eafd5b09a"), false, null, "Mac Jacobs", "COLLEEN14@YAHOO.COM", "COLLEEN14@YAHOO.COM", "AQAAAAIAAYagAAAAEOiEhkYsbPxMEUH1VIApDlJGmEjXkLZDYpG6qNgAcGJ8DM97qc2L3RIYOIDpinCcog==", "571-478-2017", false, "1ecd4621-50f1-4893-a425-6b6adcbddb5b", false, "Colleen14@yahoo.com" },
                    { 21, 0, "48479 Moore Flats", "451e1e2e-a907-423d-b6eb-5cce271ba90e", "Brycen26@yahoo.com", true, new Guid("7e5c6a48-d89b-4d42-a99b-2c3eea90bc05"), false, null, "Claire Brekke", "BRYCEN26@YAHOO.COM", "BRYCEN26@YAHOO.COM", "AQAAAAIAAYagAAAAELF4FoNC/F+Zoy87DWBMh/sfm8adnHSEMeg+bmLjmPfv4MNvpi/HoaGGyAYz0t1GlA==", "1-509-405-6563", false, "e4c2a85d-dc7a-4c11-8493-6f4e231a4a49", false, "Brycen26@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "BorrowingHistories",
                columns: new[] { "Id", "BorrowDate", "DueDate", "LibraryCardId", "LibraryItemId", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 15, 8, 9, 21, 487, DateTimeKind.Local).AddTicks(1588), new DateTime(2022, 3, 25, 8, 9, 21, 487, DateTimeKind.Local).AddTicks(1588), new Guid("75e786fe-dcc7-4899-ab89-463570c06e48"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2022, 2, 16, 20, 23, 21, 433, DateTimeKind.Local).AddTicks(9691), new DateTime(2022, 3, 16, 20, 23, 21, 433, DateTimeKind.Local).AddTicks(9691), new Guid("52db1c36-52f0-440e-98f4-db9974e723cc"), 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2021, 2, 23, 15, 55, 45, 16, DateTimeKind.Local).AddTicks(7446), new DateTime(2021, 3, 9, 15, 55, 45, 16, DateTimeKind.Local).AddTicks(7446), new Guid("08fb96d4-e236-40ea-aac3-6ba468e9ef0f"), 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2022, 3, 14, 11, 22, 58, 549, DateTimeKind.Local).AddTicks(3496), new DateTime(2022, 3, 30, 11, 22, 58, 549, DateTimeKind.Local).AddTicks(3496), new Guid("a7979d46-e381-4e03-8d8c-de9e5d6b5493"), 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5, new DateTime(2022, 10, 7, 2, 55, 55, 749, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 10, 24, 2, 55, 55, 749, DateTimeKind.Local).AddTicks(6748), new Guid("51a9193e-bab3-4470-b4e0-cb58e064be55"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2022, 11, 3, 2, 55, 55, 749, DateTimeKind.Local).AddTicks(6748), new DateTime(2022, 11, 16, 2, 55, 55, 749, DateTimeKind.Local).AddTicks(6748), new Guid("9a16aeaf-c0db-48c7-a4c9-af7148904620"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2022, 3, 25, 8, 9, 21, 487, DateTimeKind.Local).AddTicks(1588), new DateTime(2022, 4, 15, 8, 9, 21, 487, DateTimeKind.Local).AddTicks(1588), new Guid("35a6209f-3f8f-446b-8ce4-09e2b718666d"), 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2021, 5, 6, 11, 18, 20, 900, DateTimeKind.Local).AddTicks(9897), new DateTime(2021, 5, 17, 11, 18, 20, 900, DateTimeKind.Local).AddTicks(9897), new Guid("dbbd9b3f-9c8f-491c-88fc-59a8f7bb782f"), 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2021, 1, 14, 0, 29, 2, 284, DateTimeKind.Local).AddTicks(7173), new DateTime(2021, 2, 5, 0, 29, 2, 284, DateTimeKind.Local).AddTicks(7173), new Guid("35a6209f-3f8f-446b-8ce4-09e2b718666d"), 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2022, 1, 23, 16, 58, 34, 332, DateTimeKind.Local).AddTicks(9387), new DateTime(2022, 2, 11, 16, 58, 34, 332, DateTimeKind.Local).AddTicks(9387), new Guid("606698ff-4b14-4fca-be38-b14372aff76a"), 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2022, 8, 4, 17, 18, 2, 249, DateTimeKind.Local).AddTicks(3616), new DateTime(2022, 8, 22, 17, 18, 2, 249, DateTimeKind.Local).AddTicks(3616), new Guid("a7979d46-e381-4e03-8d8c-de9e5d6b5493"), 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2022, 12, 24, 0, 4, 15, 672, DateTimeKind.Local).AddTicks(3828), new DateTime(2023, 1, 6, 0, 4, 15, 672, DateTimeKind.Local).AddTicks(3828), new Guid("7e5c6a48-d89b-4d42-a99b-2c3eea90bc05"), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 13, new DateTime(2021, 7, 14, 12, 45, 53, 372, DateTimeKind.Local).AddTicks(8777), new DateTime(2021, 8, 4, 12, 45, 53, 372, DateTimeKind.Local).AddTicks(8777), new Guid("52db1c36-52f0-440e-98f4-db9974e723cc"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 14, new DateTime(2021, 1, 25, 7, 45, 48, 119, DateTimeKind.Local).AddTicks(289), new DateTime(2021, 2, 21, 7, 45, 48, 119, DateTimeKind.Local).AddTicks(289), new Guid("51a9193e-bab3-4470-b4e0-cb58e064be55"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2022, 2, 8, 16, 58, 34, 332, DateTimeKind.Local).AddTicks(9387), new DateTime(2022, 2, 26, 16, 58, 34, 332, DateTimeKind.Local).AddTicks(9387), new Guid("52db1c36-52f0-440e-98f4-db9974e723cc"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2022, 8, 2, 0, 20, 56, 283, DateTimeKind.Local).AddTicks(8119), new DateTime(2022, 8, 19, 0, 20, 56, 283, DateTimeKind.Local).AddTicks(8119), new Guid("75e786fe-dcc7-4899-ab89-463570c06e48"), 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2022, 3, 30, 11, 22, 58, 549, DateTimeKind.Local).AddTicks(3496), new DateTime(2022, 4, 10, 11, 22, 58, 549, DateTimeKind.Local).AddTicks(3496), new Guid("c83e6913-2d58-4c8f-971f-2fda26b6b8e9"), 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2021, 7, 27, 12, 45, 53, 372, DateTimeKind.Local).AddTicks(8777), new DateTime(2021, 8, 16, 12, 45, 53, 372, DateTimeKind.Local).AddTicks(8777), new Guid("a02e8fc9-d75d-4e64-8c9b-94720fe25f69"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 19, new DateTime(2022, 7, 15, 17, 18, 2, 249, DateTimeKind.Local).AddTicks(3616), new DateTime(2022, 8, 12, 17, 18, 2, 249, DateTimeKind.Local).AddTicks(3616), new Guid("a02e8fc9-d75d-4e64-8c9b-94720fe25f69"), 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 20, new DateTime(2021, 12, 6, 13, 57, 53, 67, DateTimeKind.Local).AddTicks(4528), new DateTime(2021, 12, 23, 13, 57, 53, 67, DateTimeKind.Local).AddTicks(4528), new Guid("35a6209f-3f8f-446b-8ce4-09e2b718666d"), 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2022, 5, 22, 20, 31, 8, 486, DateTimeKind.Local).AddTicks(3151), new DateTime(2022, 6, 7, 20, 31, 8, 486, DateTimeKind.Local).AddTicks(3151), new Guid("a02e8fc9-d75d-4e64-8c9b-94720fe25f69"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2021, 1, 19, 0, 29, 2, 284, DateTimeKind.Local).AddTicks(7173), new DateTime(2021, 2, 11, 0, 29, 2, 284, DateTimeKind.Local).AddTicks(7173), new Guid("a02e8fc9-d75d-4e64-8c9b-94720fe25f69"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 23, new DateTime(2021, 10, 19, 15, 57, 19, 914, DateTimeKind.Local).AddTicks(3183), new DateTime(2021, 11, 5, 15, 57, 19, 914, DateTimeKind.Local).AddTicks(3183), new Guid("16e4ad6b-e6f7-417a-a9f1-c102e17a1767"), 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 24, new DateTime(2021, 9, 18, 12, 28, 48, 1, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 10, 12, 12, 28, 48, 1, DateTimeKind.Local).AddTicks(8346), new Guid("606698ff-4b14-4fca-be38-b14372aff76a"), 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, new DateTime(2022, 5, 27, 20, 59, 31, 904, DateTimeKind.Local).AddTicks(2298), new DateTime(2022, 6, 21, 20, 59, 31, 904, DateTimeKind.Local).AddTicks(2298), new Guid("35a6209f-3f8f-446b-8ce4-09e2b718666d"), 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingHistories_LibraryCardId",
                table: "BorrowingHistories",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingHistories_LibraryItemId",
                table: "BorrowingHistories",
                column: "LibraryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowingHistories");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "LibraryItems");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
