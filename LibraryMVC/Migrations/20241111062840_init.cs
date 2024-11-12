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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    LibraryItemId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        name: "FK_BorrowingHistories_Users_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
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
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 1, "Elmo Gorczany", "DVD", new DateTime(2022, 9, 16, 7, 29, 38, 941, DateTimeKind.Local).AddTicks(9365), 5, "55", "Suscipit saepe iusto distinctio." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 2, "William Grimes", "Magazine", new DateTime(2020, 12, 9, 4, 29, 7, 734, DateTimeKind.Local).AddTicks(3795), 5, "Alias doloribus nulla non." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 3, "Margret O'Keefe", "Book", 136, new DateTime(2021, 10, 4, 14, 20, 28, 833, DateTimeKind.Local).AddTicks(9266), 9, "Saepe et nam error." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 4, "Tyson Stokes", "Magazine", new DateTime(2022, 10, 10, 0, 36, 27, 492, DateTimeKind.Local).AddTicks(7758), 6, "Non voluptas quas ut." },
                    { 5, "Wilton Green", "Magazine", new DateTime(2021, 4, 28, 9, 1, 57, 882, DateTimeKind.Local).AddTicks(8912), 8, "Ab libero aut temporibus." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 6, "Earl Wuckert", "DVD", new DateTime(2022, 2, 18, 1, 23, 54, 964, DateTimeKind.Local).AddTicks(5552), 5, "120", "Et odit et corporis." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 7, "Raul Runte", "Book", 74, new DateTime(2021, 9, 12, 4, 51, 10, 355, DateTimeKind.Local).AddTicks(8755), 7, "Mollitia sed similique sed." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 8, "Jerrod Deckow", "Magazine", new DateTime(2022, 10, 11, 7, 32, 37, 607, DateTimeKind.Local).AddTicks(4792), 9, "Cumque commodi sit alias." },
                    { 9, "Serenity Mills", "Magazine", new DateTime(2022, 7, 19, 22, 57, 30, 794, DateTimeKind.Local).AddTicks(5962), 7, "Aspernatur quis fugiat tempore." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 10, "Bonita Bradtke", "DVD", new DateTime(2022, 11, 9, 3, 18, 26, 163, DateTimeKind.Local).AddTicks(862), 10, "71", "Ullam quas dolorem neque." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 11, "Alanis Hahn", "Book", 60, new DateTime(2022, 5, 24, 13, 24, 49, 698, DateTimeKind.Local).AddTicks(3409), 7, "Excepturi quos quia dolores." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 12, "Xander Ondricka", "DVD", new DateTime(2021, 8, 15, 8, 39, 1, 210, DateTimeKind.Local).AddTicks(1092), 8, "89", "Qui ut vitae enim." },
                    { 13, "German Dickens", "DVD", new DateTime(2021, 7, 15, 13, 6, 56, 175, DateTimeKind.Local).AddTicks(6185), 5, "63", "Et non ducimus totam." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 14, "Ned Hauck", "Book", 122, new DateTime(2021, 11, 14, 22, 36, 10, 621, DateTimeKind.Local).AddTicks(4504), 9, "Suscipit dolor quia at." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 15, "Evan Daniel", "Magazine", new DateTime(2022, 3, 29, 1, 21, 52, 532, DateTimeKind.Local).AddTicks(763), 7, "Est consectetur corporis modi." },
                    { 16, "Litzy Maggio", "Magazine", new DateTime(2022, 1, 5, 22, 59, 30, 999, DateTimeKind.Local).AddTicks(6342), 8, "Necessitatibus ut deleniti veritatis." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 17, "Elda O'Connell", "DVD", new DateTime(2021, 7, 6, 10, 59, 58, 781, DateTimeKind.Local).AddTicks(4340), 9, "51", "Mollitia et ducimus possimus." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 18, "Ulices Upton", "Magazine", new DateTime(2022, 8, 28, 1, 23, 12, 79, DateTimeKind.Local).AddTicks(8322), 7, "Inventore similique non vero." },
                    { 19, "Alphonso Kunde", "Magazine", new DateTime(2021, 7, 21, 11, 11, 40, 899, DateTimeKind.Local).AddTicks(6674), 7, "Tenetur eaque fugit natus." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 20, "Jay Pacocha", "Book", 117, new DateTime(2022, 1, 13, 17, 53, 28, 961, DateTimeKind.Local).AddTicks(1814), 7, "Assumenda maxime repellat voluptatem." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 21, "Broderick Tromp", "DVD", new DateTime(2022, 11, 4, 2, 55, 44, 189, DateTimeKind.Local).AddTicks(5602), 10, "56", "Odio ut quos in." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 22, "Rachael Romaguera", "Magazine", new DateTime(2021, 9, 20, 7, 12, 14, 884, DateTimeKind.Local).AddTicks(1530), 10, "Quos labore culpa in." },
                    { 23, "Christy Runolfsdottir", "Magazine", new DateTime(2022, 6, 9, 20, 0, 36, 957, DateTimeKind.Local).AddTicks(7292), 10, "Eum suscipit id iste." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 24, "Addison Shields", "Book", 98, new DateTime(2021, 8, 30, 15, 7, 30, 156, DateTimeKind.Local).AddTicks(1972), 10, "Impedit iure et sed." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 25, "London Lockman", "Magazine", new DateTime(2022, 8, 27, 17, 6, 17, 33, DateTimeKind.Local).AddTicks(1108), 10, "Unde impedit non ducimus." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 26, "Sandra Bernier", "Book", 71, new DateTime(2020, 12, 6, 10, 31, 5, 835, DateTimeKind.Local).AddTicks(2446), 10, "Deleniti excepturi et tenetur." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 27, "Jamal Hessel", "Magazine", new DateTime(2021, 2, 17, 13, 25, 29, 234, DateTimeKind.Local).AddTicks(3815), 7, "Illum dolorem deserunt numquam." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 28, "Diego Price", "DVD", new DateTime(2021, 5, 21, 4, 4, 47, 491, DateTimeKind.Local).AddTicks(2686), 5, "125", "Non molestias natus ad." },
                    { 29, "Ora O'Hara", "DVD", new DateTime(2021, 6, 8, 12, 59, 3, 864, DateTimeKind.Local).AddTicks(6392), 9, "103", "Ut nemo qui eveniet." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 30, "Christine Gusikowski", "Magazine", new DateTime(2021, 1, 12, 11, 57, 13, 146, DateTimeKind.Local).AddTicks(1974), 9, "Perspiciatis officiis occaecati iusto." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 31, "Erica Anderson", "DVD", new DateTime(2022, 8, 15, 22, 19, 4, 436, DateTimeKind.Local).AddTicks(2596), 5, "121", "Ea tempore sapiente libero." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 32, "Nya Wyman", "Book", 73, new DateTime(2022, 5, 21, 13, 32, 54, 893, DateTimeKind.Local).AddTicks(9084), 9, "Qui molestiae similique dolore." },
                    { 33, "Rosa Predovic", "Book", 130, new DateTime(2022, 3, 25, 19, 11, 27, 699, DateTimeKind.Local).AddTicks(5999), 6, "Assumenda soluta id consequatur." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[,]
                {
                    { 34, "Judah Boehm", "DVD", new DateTime(2022, 6, 30, 7, 54, 15, 398, DateTimeKind.Local).AddTicks(8490), 10, "65", "Nobis officia voluptas consequatur." },
                    { 35, "Ryann Swaniawski", "DVD", new DateTime(2021, 5, 30, 14, 57, 24, 467, DateTimeKind.Local).AddTicks(6374), 6, "55", "Perspiciatis odio mollitia molestias." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Title" },
                values: new object[] { 36, "Della Gusikowski", "Magazine", new DateTime(2022, 5, 13, 12, 50, 4, 511, DateTimeKind.Local).AddTicks(3971), 5, "Laborum voluptates nulla recusandae." });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "NumberOfPages", "PublicationDate", "Quantity", "Title" },
                values: new object[,]
                {
                    { 37, "Bridget Anderson", "Book", 67, new DateTime(2021, 11, 30, 15, 22, 59, 643, DateTimeKind.Local).AddTicks(4247), 10, "Rerum possimus aliquid enim." },
                    { 38, "Glenda Auer", "Book", 127, new DateTime(2020, 11, 25, 3, 15, 21, 726, DateTimeKind.Local).AddTicks(7699), 5, "Laboriosam qui animi omnis." },
                    { 39, "Hubert Skiles", "Book", 57, new DateTime(2021, 1, 4, 0, 0, 19, 658, DateTimeKind.Local).AddTicks(2572), 10, "Qui dolorum voluptatem provident." }
                });

            migrationBuilder.InsertData(
                table: "LibraryItems",
                columns: new[] { "Id", "Author", "ItemType", "PublicationDate", "Quantity", "Runtime", "Title" },
                values: new object[] { 40, "Abdul Orn", "DVD", new DateTime(2020, 12, 27, 1, 3, 10, 226, DateTimeKind.Local).AddTicks(7734), 10, "123", "Earum itaque sint dignissimos." });

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
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "Admin Address", "ca21b70a-ad86-4817-9353-03077082ba81", "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEGLjGE4k34aMXmpbxAzZTESPfIThfZodOmoHCGU95zYDOwoiNE1VNTUTa9I1l/4vyQ==", "123456789", false, "20659c7a-57d6-4f96-86b0-ba1094199c05", false, "admin" },
                    { 2, 0, "03284 Colby Expressway", "3eaa370f-2339-4d04-8753-d8037281fdc1", "Allan.Hamill9@hotmail.com", true, false, null, "Rickey Moore", "ALLAN.HAMILL9@HOTMAIL.COM", "ALLAN.HAMILL9@HOTMAIL.COM", "AQAAAAIAAYagAAAAEDukAucBN2tVWXwm/jYmXp3Da2g/1nU4bSXezRYPZxDzmiYsfO/ozzA3gXkMdYocVQ==", "713.622.8794 x7162", false, "9da1f1ee-4286-4792-bad8-8e2dbc63767d", false, "Allan.Hamill9@hotmail.com" },
                    { 3, 0, "981 Torp Alley", "52ec81a6-228e-4175-9017-ce3d0fa033d8", "Keagan42@gmail.com", true, false, null, "Tristin Hartmann", "KEAGAN42@GMAIL.COM", "KEAGAN42@GMAIL.COM", "AQAAAAIAAYagAAAAEJ9dVR9l/oCPv9WloyZquDCwbmFjSwQRb/OjuVFkjfIcrKcJonj9aIA1ffzc4D5zXQ==", "(753) 753-3076 x82543", false, "bb7c3f6f-872d-40b2-b820-6d7783439d9c", false, "Keagan42@gmail.com" },
                    { 4, 0, "656 Gunner Light", "f0b0d275-fc4d-40e0-be9e-29d07f0a3bda", "Horace_Donnelly@yahoo.com", true, false, null, "Talia Walker", "HORACE_DONNELLY@YAHOO.COM", "HORACE_DONNELLY@YAHOO.COM", "AQAAAAIAAYagAAAAEN2hlXAxySyyEsa/hZw9/H0muy0/iHYRKipom8bKUd7mv4eaqnRoRinZoGUD7sW0pg==", "456.388.3190", false, "0fa4b1a7-0403-49c9-8754-a103fcfbb2c8", false, "Horace_Donnelly@yahoo.com" },
                    { 5, 0, "37629 Brielle Expressway", "c529f933-0dc3-4f98-bb4c-607e2bbad48f", "Krista4@gmail.com", true, false, null, "Berta Collier", "KRISTA4@GMAIL.COM", "KRISTA4@GMAIL.COM", "AQAAAAIAAYagAAAAEBkrpiBbYXvjlxUrR0y2jEa6+BSoThq+x1TeJYEHKmdz4o/8hw2m+rnNAvgthH1wSg==", "1-590-731-8839", false, "fbf6b418-3450-4e7d-9e6e-c7a3e113692c", false, "Krista4@gmail.com" },
                    { 6, 0, "6103 Aurelie Isle", "4e82b16d-331b-4276-b03f-4e9b217b7273", "Kaycee.Buckridge56@gmail.com", true, false, null, "Jamar Wiegand", "KAYCEE.BUCKRIDGE56@GMAIL.COM", "KAYCEE.BUCKRIDGE56@GMAIL.COM", "AQAAAAIAAYagAAAAEBSG44RWW0WjTQzJL4CrhSzGUF1ZS7SseveNnlMmx+JmD7lSOgSQlTIipqfl5bSf0A==", "(500) 592-1983 x3240", false, "ad3474a3-832b-4a9c-9d45-b9ad5a628368", false, "Kaycee.Buckridge56@gmail.com" },
                    { 7, 0, "49588 Jeffery Causeway", "bc87ab49-bd62-428b-9a22-bfe9fb8ef921", "Johan4@gmail.com", true, false, null, "Immanuel Mitchell", "JOHAN4@GMAIL.COM", "JOHAN4@GMAIL.COM", "AQAAAAIAAYagAAAAEMsoTD4sBwFVZuA3nfNdJXVGR28RHDmLx66+smIK+PjPRo+WfQx+NfrfgpajZyNYbg==", "1-961-276-4539 x208", false, "db5b1a34-df8f-4611-940d-ba0a93a6a968", false, "Johan4@gmail.com" },
                    { 8, 0, "7527 Dorthy Garden", "41cb175f-7fb1-47ab-afe1-b0ac555a252a", "Ashtyn.Tremblay39@hotmail.com", true, false, null, "Jodie Waters", "ASHTYN.TREMBLAY39@HOTMAIL.COM", "ASHTYN.TREMBLAY39@HOTMAIL.COM", "AQAAAAIAAYagAAAAEMcO+/U+9CKcrH+J0tQRsEnZrQ0qMEhykexFpXidhAwOnAzlV2Rhp9irJsy9gjBdnw==", "1-765-374-7435 x4265", false, "1611f085-2ede-473f-9ff8-062f003f3158", false, "Ashtyn.Tremblay39@hotmail.com" },
                    { 9, 0, "62350 Allie Inlet", "3563a1a4-0d19-445f-8b49-e9b58922b2cd", "Beth28@hotmail.com", true, false, null, "Cindy Mitchell", "BETH28@HOTMAIL.COM", "BETH28@HOTMAIL.COM", "AQAAAAIAAYagAAAAEDp+3dNLxEgtxCcGSVfOYo1dOd/ve3GdegGJb0X30JkUxFMJWyjx3tpRETEjN5m9Og==", "(758) 939-4746 x32963", false, "fb9d3d7f-e411-4622-8045-02000c698865", false, "Beth28@hotmail.com" },
                    { 10, 0, "92193 Mertz Underpass", "edc77c1f-ec75-4e99-96c3-35d55ba8f4d0", "Nadia.Schmidt58@gmail.com", true, false, null, "Oceane Schuppe", "NADIA.SCHMIDT58@GMAIL.COM", "NADIA.SCHMIDT58@GMAIL.COM", "AQAAAAIAAYagAAAAEPHEQrZJfS3Iug191q6KAatiFHImS5gKpIyGmrC7rYprZh7Y6PI8VpErF+y5MLh7XA==", "1-401-880-8149 x2534", false, "977e593c-b68e-4033-b413-f903fdaf4d09", false, "Nadia.Schmidt58@gmail.com" },
                    { 11, 0, "440 Kling Junctions", "7556f125-e33f-433e-89e9-63c793bb5548", "Oran.Abbott@yahoo.com", true, false, null, "Rudy Thiel", "ORAN.ABBOTT@YAHOO.COM", "ORAN.ABBOTT@YAHOO.COM", "AQAAAAIAAYagAAAAEKEVgWYCsFtaE3vnGlwnJGNFMX4GSBzN2NE5SSvNlgYamAqlbKlKS6VMmSVkOlWcHA==", "599-632-5308 x0853", false, "da923f6f-beca-4b5d-b2f7-24f9d9c4840d", false, "Oran.Abbott@yahoo.com" },
                    { 12, 0, "662 Medhurst Inlet", "d2d5d455-b614-4103-922f-351e685fa53e", "Jordane82@yahoo.com", true, false, null, "Johnnie Dare", "JORDANE82@YAHOO.COM", "JORDANE82@YAHOO.COM", "AQAAAAIAAYagAAAAEDdSqIGdePkfeo3VAk2RWi9/NWZAwviYmJA+/1aBMPmyONSkeUJt3ImQyC/rEgxnFw==", "914.377.0483 x60823", false, "7e12b3eb-f0c4-4a68-a022-cd9940b09d15", false, "Jordane82@yahoo.com" },
                    { 13, 0, "9435 Meredith Extension", "07ce447f-5210-4fbb-a81f-fe0e3b2f7481", "Simone10@hotmail.com", true, false, null, "Vladimir Bruen", "SIMONE10@HOTMAIL.COM", "SIMONE10@HOTMAIL.COM", "AQAAAAIAAYagAAAAEMEbaCFatHcF8nwYpNofGgaYTZWb4jiUtuzXAy12Pbg3sRYMKn556RTzKCQCFPwgAw==", "804.263.6115 x13404", false, "f1b2b22c-834f-4c06-a6f3-982811c0f48a", false, "Simone10@hotmail.com" },
                    { 14, 0, "180 Ondricka Corner", "78f80ccf-bf6f-4a4b-9b20-8affef81ba8b", "Adah_Will@gmail.com", true, false, null, "Shana Block", "ADAH_WILL@GMAIL.COM", "ADAH_WILL@GMAIL.COM", "AQAAAAIAAYagAAAAEE1roRzU8jOQA8zbWVVBv1CHKcH/WDiLYF0fFR51lRQZXxo01O+OTSuStyZkc4NlHQ==", "(232) 233-5168", false, "f20fc6a5-07b9-47e3-84a9-377aa7c1e3db", false, "Adah_Will@gmail.com" },
                    { 15, 0, "5905 O'Hara Mountain", "ff3d04c0-fab6-4ac4-8b09-4e6422a9ab8f", "Darian.Bednar68@gmail.com", true, false, null, "Eveline Bradtke", "DARIAN.BEDNAR68@GMAIL.COM", "DARIAN.BEDNAR68@GMAIL.COM", "AQAAAAIAAYagAAAAEE4fz/RK2IvahgEFpqPFOLVZdceMPpsbPNvDwKnBItuVBJHm+YwtAMXAFPzNXpOPUQ==", "1-615-466-7684 x92491", false, "54921fbc-6014-49e8-a800-670bc5886f94", false, "Darian.Bednar68@gmail.com" },
                    { 16, 0, "39530 Adan Mills", "4685eaa9-57cf-4e77-bb12-9c8f9db30871", "Marcelino.Koch84@yahoo.com", true, false, null, "Leon Swift", "MARCELINO.KOCH84@YAHOO.COM", "MARCELINO.KOCH84@YAHOO.COM", "AQAAAAIAAYagAAAAEG8ZBUpij/MehuZIl0y6er3SYkBfkqQBjyNXsk2zocG6IohmaWCJW9hEd/auFVwcdQ==", "988.706.8383 x875", false, "a4edbc4a-c500-460c-89cc-b85b6fa4c3c2", false, "Marcelino.Koch84@yahoo.com" },
                    { 17, 0, "59515 Rigoberto Island", "c13ecf55-cdd0-4a56-a8cb-4fad7d421813", "Helene_Kohler@gmail.com", true, false, null, "Bernard Weimann", "HELENE_KOHLER@GMAIL.COM", "HELENE_KOHLER@GMAIL.COM", "AQAAAAIAAYagAAAAEHqnKqBwAwuEYUELOSLCyzS9J6qyeigLq/wgYvnQ2iugW+TuWizkekX7X3+ZsOIdng==", "951.356.8368 x1175", false, "5a8d0f15-aecd-4092-8e23-12a46fbdd1ba", false, "Helene_Kohler@gmail.com" },
                    { 18, 0, "822 Roob Stream", "3dd6c573-fdfd-4508-957c-6ed997a57186", "Hubert51@gmail.com", true, false, null, "Jaden McLaughlin", "HUBERT51@GMAIL.COM", "HUBERT51@GMAIL.COM", "AQAAAAIAAYagAAAAEADl+mGimBp0Ld/ut/WEncGt5smJ4VD9/jVev2REF4L+uEx8e784s8lX3kwHp58urQ==", "563.732.3271", false, "fce0cb92-fa1c-4de2-97b2-eaa0ede13301", false, "Hubert51@gmail.com" },
                    { 19, 0, "6850 Vita Prairie", "a032cf93-5a7f-40ed-ae58-3336455f1817", "Ali.Parisian35@hotmail.com", true, false, null, "Marisol O'Conner", "ALI.PARISIAN35@HOTMAIL.COM", "ALI.PARISIAN35@HOTMAIL.COM", "AQAAAAIAAYagAAAAEOdo62K2xA4JlJA245lKQYHRzqzhbj4SWRymv5pfpMkb9LlGvE5Z3+KFAbUvwPaHeA==", "620-461-0211", false, "d1733e39-5e85-47f6-8455-0319a4105619", false, "Ali.Parisian35@hotmail.com" },
                    { 20, 0, "25327 Steuber Tunnel", "52ac2269-85b4-4065-8f7c-fde406d0d1cb", "Alene.Reinger6@yahoo.com", true, false, null, "Brendon Howell", "ALENE.REINGER6@YAHOO.COM", "ALENE.REINGER6@YAHOO.COM", "AQAAAAIAAYagAAAAELzSIiiIvbSKZW/j6eWpWN0GIFUCrxLl37efQ7pWbJtwyVgTBX40MGOLjGvPhVqI6Q==", "(336) 327-7278 x5382", false, "18dfa3ef-1772-4605-b26a-a350e5a6a4d4", false, "Alene.Reinger6@yahoo.com" },
                    { 21, 0, "1935 Macejkovic Parkway", "e2d19ac2-4833-4b3a-9eac-caea5d26edff", "Darby.Tremblay@gmail.com", true, false, null, "Raegan Johns", "DARBY.TREMBLAY@GMAIL.COM", "DARBY.TREMBLAY@GMAIL.COM", "AQAAAAIAAYagAAAAEFLGa1JLzxjfdwNoZQ2oWr3F9AW4duP9q3V+hZzm1rMCclshTcXf7krLcRawjZ3NpQ==", "(270) 939-6412 x205", false, "ca7051c2-1412-4e69-82a3-57f5833b99d3", false, "Darby.Tremblay@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "BorrowingHistories",
                columns: new[] { "Id", "BorrowDate", "BorrowerId", "DueDate", "LibraryItemId", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 13, 25, 29, 234, DateTimeKind.Local).AddTicks(3815), 15, new DateTime(2021, 6, 6, 13, 25, 29, 234, DateTimeKind.Local).AddTicks(3815), 39, null, 0 },
                    { 2, new DateTime(2021, 11, 28, 14, 20, 28, 833, DateTimeKind.Local).AddTicks(9266), 20, new DateTime(2021, 12, 13, 14, 20, 28, 833, DateTimeKind.Local).AddTicks(9266), 33, null, 0 },
                    { 3, new DateTime(2021, 7, 2, 9, 1, 57, 882, DateTimeKind.Local).AddTicks(8912), 14, new DateTime(2021, 7, 17, 9, 1, 57, 882, DateTimeKind.Local).AddTicks(8912), 26, null, 1 },
                    { 4, new DateTime(2022, 2, 15, 22, 36, 10, 621, DateTimeKind.Local).AddTicks(4504), 3, new DateTime(2022, 2, 28, 22, 36, 10, 621, DateTimeKind.Local).AddTicks(4504), 18, null, 3 },
                    { 5, new DateTime(2022, 8, 1, 13, 32, 54, 893, DateTimeKind.Local).AddTicks(9084), 9, new DateTime(2022, 8, 13, 13, 32, 54, 893, DateTimeKind.Local).AddTicks(9084), 38, null, 1 },
                    { 6, new DateTime(2021, 12, 7, 4, 51, 10, 355, DateTimeKind.Local).AddTicks(8755), 20, new DateTime(2021, 12, 25, 4, 51, 10, 355, DateTimeKind.Local).AddTicks(8755), 31, null, 1 },
                    { 7, new DateTime(2022, 4, 12, 17, 53, 28, 961, DateTimeKind.Local).AddTicks(1814), 5, new DateTime(2022, 5, 4, 17, 53, 28, 961, DateTimeKind.Local).AddTicks(1814), 30, null, 3 },
                    { 8, new DateTime(2021, 9, 5, 10, 59, 58, 781, DateTimeKind.Local).AddTicks(4340), 17, new DateTime(2021, 10, 3, 10, 59, 58, 781, DateTimeKind.Local).AddTicks(4340), 36, null, 0 },
                    { 9, new DateTime(2021, 4, 7, 11, 57, 13, 146, DateTimeKind.Local).AddTicks(1974), 10, new DateTime(2021, 5, 5, 11, 57, 13, 146, DateTimeKind.Local).AddTicks(1974), 32, null, 1 },
                    { 10, new DateTime(2022, 9, 8, 22, 57, 30, 794, DateTimeKind.Local).AddTicks(5962), 9, new DateTime(2022, 9, 24, 22, 57, 30, 794, DateTimeKind.Local).AddTicks(5962), 33, null, 0 },
                    { 11, new DateTime(2021, 12, 24, 7, 12, 14, 884, DateTimeKind.Local).AddTicks(1530), 2, new DateTime(2022, 1, 20, 7, 12, 14, 884, DateTimeKind.Local).AddTicks(1530), 32, null, 2 },
                    { 12, new DateTime(2022, 4, 13, 1, 23, 54, 964, DateTimeKind.Local).AddTicks(5552), 19, new DateTime(2022, 4, 24, 1, 23, 54, 964, DateTimeKind.Local).AddTicks(5552), 17, null, 0 },
                    { 13, new DateTime(2022, 6, 24, 1, 21, 52, 532, DateTimeKind.Local).AddTicks(763), 15, new DateTime(2022, 7, 7, 1, 21, 52, 532, DateTimeKind.Local).AddTicks(763), 27, null, 2 },
                    { 14, new DateTime(2022, 4, 3, 22, 59, 30, 999, DateTimeKind.Local).AddTicks(6342), 19, new DateTime(2022, 4, 29, 22, 59, 30, 999, DateTimeKind.Local).AddTicks(6342), 33, null, 0 },
                    { 15, new DateTime(2021, 10, 3, 13, 6, 56, 175, DateTimeKind.Local).AddTicks(6185), 20, new DateTime(2021, 10, 19, 13, 6, 56, 175, DateTimeKind.Local).AddTicks(6185), 7, null, 3 },
                    { 16, new DateTime(2021, 3, 14, 11, 57, 13, 146, DateTimeKind.Local).AddTicks(1974), 8, new DateTime(2021, 3, 28, 11, 57, 13, 146, DateTimeKind.Local).AddTicks(1974), 31, null, 0 },
                    { 17, new DateTime(2021, 8, 18, 4, 4, 47, 491, DateTimeKind.Local).AddTicks(2686), 20, new DateTime(2021, 9, 2, 4, 4, 47, 491, DateTimeKind.Local).AddTicks(2686), 15, null, 2 },
                    { 18, new DateTime(2022, 1, 23, 22, 36, 10, 621, DateTimeKind.Local).AddTicks(4504), 11, new DateTime(2022, 2, 3, 22, 36, 10, 621, DateTimeKind.Local).AddTicks(4504), 30, null, 0 },
                    { 19, new DateTime(2022, 6, 30, 19, 11, 27, 699, DateTimeKind.Local).AddTicks(5999), 3, new DateTime(2022, 7, 16, 19, 11, 27, 699, DateTimeKind.Local).AddTicks(5999), 26, null, 2 },
                    { 20, new DateTime(2022, 9, 10, 22, 57, 30, 794, DateTimeKind.Local).AddTicks(5962), 21, new DateTime(2022, 10, 5, 22, 57, 30, 794, DateTimeKind.Local).AddTicks(5962), 33, null, 0 },
                    { 21, new DateTime(2021, 1, 31, 10, 31, 5, 835, DateTimeKind.Local).AddTicks(2446), 3, new DateTime(2021, 2, 18, 10, 31, 5, 835, DateTimeKind.Local).AddTicks(2446), 5, null, 0 },
                    { 22, new DateTime(2022, 8, 28, 13, 32, 54, 893, DateTimeKind.Local).AddTicks(9084), 2, new DateTime(2022, 9, 19, 13, 32, 54, 893, DateTimeKind.Local).AddTicks(9084), 39, null, 3 },
                    { 23, new DateTime(2021, 10, 15, 13, 6, 56, 175, DateTimeKind.Local).AddTicks(6185), 19, new DateTime(2021, 11, 9, 13, 6, 56, 175, DateTimeKind.Local).AddTicks(6185), 28, null, 1 },
                    { 24, new DateTime(2022, 4, 28, 1, 23, 54, 964, DateTimeKind.Local).AddTicks(5552), 11, new DateTime(2022, 5, 10, 1, 23, 54, 964, DateTimeKind.Local).AddTicks(5552), 13, null, 1 },
                    { 25, new DateTime(2022, 10, 26, 17, 6, 17, 33, DateTimeKind.Local).AddTicks(1108), 11, new DateTime(2022, 11, 23, 17, 6, 17, 33, DateTimeKind.Local).AddTicks(1108), 15, null, 1 }
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
                name: "IX_BorrowingHistories_BorrowerId",
                table: "BorrowingHistories",
                column: "BorrowerId");

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
