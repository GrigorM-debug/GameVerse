using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "The FirstName of the ApplicationUser"),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "The LastName of the ApplicationUser"),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The event unique identifier"),
                    Topic = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The topic of the event"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The description of the event"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The event starting date and time"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The event end date and time"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false, comment: "The event's number of seats"),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price for ticket"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The event image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The genre unique indetifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the genre")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The platform unique identifier."),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The name of the platform")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The restriction unique indentifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the restriction")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The game unique indentifier."),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "The title of the Game."),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The description of the Game"),
                    PublishingStudio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The current Game's Publishing Studio"),
                    YearPublished = table.Column<int>(type: "int", nullable: false, comment: "The Year on which the Game was published"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The Date when the Game is added"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price of the Game"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The image url of the game"),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false, comment: "Тhe available quantity of the game in the store"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The type of the game."),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsRegistrations",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsRegistrations", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventsRegistrations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventsRegistrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EventsCarts",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsCarts", x => new { x.EventId, x.CartId });
                    table.ForeignKey(
                        name: "FK_EventsCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventsCarts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GameReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The review unique identifier"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The content of the review"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "The review rating"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the review is created"),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Тhe id of the game the review is about"),
                    ReviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the User who wrote the review for the current game")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GameReviews_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesCarts",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesCarts", x => new { x.GameId, x.CartId });
                    table.ForeignKey(
                        name: "FK_GamesCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesCarts_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesGenres",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesGenres", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GamesGenres_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesPlatforms",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesPlatforms", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamesPlatforms_Games_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesPlatforms_Platforms_GameId",
                        column: x => x.GameId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesRestrictions",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestrictionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesRestrictions", x => new { x.GameId, x.RestrictionId });
                    table.ForeignKey(
                        name: "FK_GamesRestrictions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesRestrictions_Restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesUsersCompleted",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the Game added in User completed games list"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the User"),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the game is completed")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesUsersCompleted", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GamesUsersCompleted_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesUsersCompleted_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GamesUsersCurrentlyPlaying",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the game added in User currently playing games list"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the user"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesUsersCurrentlyPlaying", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GamesUsersCurrentlyPlaying_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GamesUsersCurrentlyPlaying_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GameUserWishlists",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the game added in the Wishlist"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The id of the User"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the item is added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserWishlists", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GameUserWishlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GameUserWishlists_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05184314-9326-4e65-b560-d913142f993c"), "Stealth" },
                    { new Guid("08733cf5-fc36-42ff-b616-3129d7843f88"), "Party" },
                    { new Guid("18169f3e-41a5-4b2a-8b8c-d8274ab88cbb"), "Racing" },
                    { new Guid("4b22eeed-6a19-419a-b786-f6c30cd3a4b7"), "RPG" },
                    { new Guid("501e8e9e-4da0-4942-bc43-6de9f67ceae0"), "Platformer" },
                    { new Guid("52a5b04c-000f-49df-b0ce-0c3efb02beea"), "Action RPG" },
                    { new Guid("5502c0eb-978c-4e2d-8bde-09fdb0a7283f"), "Action" },
                    { new Guid("899aae4c-0144-4eeb-b56f-c204332195ea"), "Action-adventure" },
                    { new Guid("9d3b8645-26fe-428e-98a9-2c64883e7eb4"), "Puzzle" },
                    { new Guid("b352cce6-3cec-4896-8354-f98fe4799f82"), "Sports" },
                    { new Guid("b520d2c0-d551-45c5-802e-f07563164304"), "Real-time strategy" },
                    { new Guid("b97e41d0-038d-436a-8a0c-68330f90a71f"), "Fighting" },
                    { new Guid("bc27424b-d957-4679-8c31-670ed540dd4e"), "Adventure" },
                    { new Guid("c3df8f83-1f64-457c-9f84-8bcf32eaf610"), "Shooter" },
                    { new Guid("c76b7a6d-b804-45e6-81cd-3a718cdb67e2"), "Simulation" },
                    { new Guid("cf50cc02-de6d-4db4-a800-39aca6560b76"), "First-Person Shooter" },
                    { new Guid("cfcb1974-30d9-4503-b60d-d024f86ce1d3"), "Strategy game" },
                    { new Guid("d8be7865-79a5-4f8a-8abc-38d3a76ae5f0"), "Casual" },
                    { new Guid("dbad333f-9a28-4bfe-991c-3dfc0cb6b534"), "Battle Royale" },
                    { new Guid("e94dfb2a-ae9e-490b-8128-881d3b3e0b83"), "Survival" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("157fd96b-55fe-4fb6-a311-1b17bc9964f3"), "Super Nintendo" },
                    { new Guid("20b7df08-ff00-4996-880f-5fbaff6a1a69"), "Nintendo Wii" },
                    { new Guid("29476c25-34d2-4f47-81b1-1c3ceb438f8f"), "Mac" },
                    { new Guid("2f596b18-f14b-4c03-a234-df736f81a161"), "PlayStation Portable" },
                    { new Guid("39c26e96-e41b-4afb-8460-cbaed909a6fb"), "PlayStation 3" },
                    { new Guid("4b541bf0-1e91-471d-b39a-f5e0503675e1"), "Xbox 360" },
                    { new Guid("4fada622-53fc-49a5-bc2c-69f7e84426af"), "PlayStation 4" },
                    { new Guid("69d1905b-af73-4bba-83eb-46dac99b67e3"), "Game Boy" },
                    { new Guid("6b557837-8fc4-41e0-a122-130a903ba1fa"), "PlayStation 1" },
                    { new Guid("728731da-b427-41a6-a810-a68dc6472a2a"), "PlayStation Vita" },
                    { new Guid("77bdff3f-4895-4bee-bc10-aeb4613a7c05"), "Sega Mega Drive" },
                    { new Guid("7d454134-2891-430b-8247-7473cf759c6b"), "Xbox One" },
                    { new Guid("8740ed17-58e8-4b47-be06-bf5e98d23bff"), "PlayStation 2" },
                    { new Guid("8d20be52-ee05-455f-9731-f6094109c898"), "Nintendo Switch" },
                    { new Guid("abf64c65-8396-470c-ace2-67ab737a064b"), "Linux" },
                    { new Guid("b30ea05c-3aef-495a-a7d9-d37e64ab807a"), "PlayStation 5" },
                    { new Guid("b58e1bdb-5805-4079-842d-0a07e3b531a4"), "PC" },
                    { new Guid("ca33c75e-8cff-4305-9361-fd552c359753"), "Xbox Series X" },
                    { new Guid("edd9d020-4d87-41ee-8a3d-6ef07fa72564"), "Nintendo DS" },
                    { new Guid("f3dec853-1519-4955-bfd4-235ab36512b6"), "Game Boy Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("159da2bb-bb22-4292-959e-6886c5620a37"), "PEGI 3" },
                    { new Guid("41671010-9380-40a6-9809-e7c66f1abc4a"), "PEGI 12" },
                    { new Guid("5d7c69ac-d3d7-45d4-833f-d376a04da097"), "Gambling" },
                    { new Guid("6897caef-8f47-4a97-a4e8-1411b94f730b"), "PEGI 18" },
                    { new Guid("6cd73919-545c-42de-b7dc-a123399b6399"), "Discrimination" },
                    { new Guid("7d7df725-5f5c-4d7b-b8ce-949f3cf78dac"), "Drugs" },
                    { new Guid("8fb3bd43-d3e8-4be8-b4b6-c657e992cbd1"), "In-Game Purchases" },
                    { new Guid("b1021c5d-ec10-4728-8108-42d8708d84d8"), "Sex" },
                    { new Guid("b288ad6f-f214-48ab-b9cc-4e1ffea813e7"), "Fear" },
                    { new Guid("b369ecea-0e58-44a0-9275-392d951f7c9e"), "Violence" },
                    { new Guid("b3edf455-e826-4975-9764-d6fb631a9495"), "PEGI 16 " },
                    { new Guid("bfb6cd24-0bf8-4d13-8c2b-1164cb712913"), "Bad Language" },
                    { new Guid("d628949d-cf45-4dfa-b6ab-942e93b16cfb"), "PEGI 7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsCarts_CartId",
                table: "EventsCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsRegistrations_UserId",
                table: "EventsRegistrations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_GameId",
                table: "GameReviews",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_ReviewerId",
                table: "GameReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesCarts_CartId",
                table: "GamesCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesGenres_GenreId",
                table: "GamesGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesPlatforms_PlatformId",
                table: "GamesPlatforms",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesRestrictions_RestrictionId",
                table: "GamesRestrictions",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsersCompleted_UserId",
                table: "GamesUsersCompleted",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesUsersCurrentlyPlaying_UserId",
                table: "GamesUsersCurrentlyPlaying",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserWishlists_UserId",
                table: "GameUserWishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EventsCarts");

            migrationBuilder.DropTable(
                name: "EventsRegistrations");

            migrationBuilder.DropTable(
                name: "GameReviews");

            migrationBuilder.DropTable(
                name: "GamesCarts");

            migrationBuilder.DropTable(
                name: "GamesGenres");

            migrationBuilder.DropTable(
                name: "GamesPlatforms");

            migrationBuilder.DropTable(
                name: "GamesRestrictions");

            migrationBuilder.DropTable(
                name: "GamesUsersCompleted");

            migrationBuilder.DropTable(
                name: "GamesUsersCurrentlyPlaying");

            migrationBuilder.DropTable(
                name: "GameUserWishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
