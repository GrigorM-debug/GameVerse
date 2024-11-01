using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class SomeFixesInTheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesPlatforms_Games_PlatformId",
                table: "GamesPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesPlatforms_Platforms_GameId",
                table: "GamesPlatforms");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("17f7da99-ef87-4439-bcf5-0e5745d503c1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("250edbc7-6e3c-4408-bd8f-126e101d8b65"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("29d39f41-b35d-4bde-a066-fb25e97eba03"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("37b5af83-5972-49b3-935c-73d40ed42450"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5c763cb7-7d78-454e-9e8e-215a6d3c8221"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5d6f50c8-30a0-41ae-8bbf-130efd4eba6f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("67a0fba1-6c3b-48be-8b0e-5f1207d96ff7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("68a504fb-67b6-4150-b022-c0c18181f396"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6b4e8124-fda1-4356-993c-64f1e23c4b8a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6e76b75a-f8f0-4809-bbce-4dac3f1e0ce7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("75fec1c0-f5dc-4540-bda0-46b2f42ab55a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7e7a48cf-a781-400d-bf21-82c63508148b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8bf36bf0-6ef5-4692-9d7f-6164873bddf1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("93e9684c-6743-41ef-bdf0-57671ad8c75f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b5250e25-c3ed-4c48-b8ec-7c6e828b9d1c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cb0521cb-8c95-4f21-bcc0-0f3a3c49da6b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("daf02669-8b06-42c0-a824-097d40878d0f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("db536178-a9db-4e4c-8475-648f51300c04"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f3a8902d-cc5a-4ff7-9d1e-24a9b2529e74"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fb403daa-49a1-472d-a887-4a30dee4ca05"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("090dd149-30ee-4046-b42c-712b1811cede"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0b3e823a-2e1f-4331-a7c1-12f69627229a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("178de0d3-b664-438f-bba6-8b58c8cb6640"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("17e3fba9-a042-4ece-8b39-4c9eda940474"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2e3ffd25-27be-4f74-807c-579182fb2e09"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("55f01289-183d-4055-9d64-03b1eea3eef8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("5841816d-9567-4911-80f8-9ea8c911d516"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6adfbae0-75f1-4163-b6fe-2dd264e323b6"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("81df3c20-29da-4e4e-b1be-95e006f88320"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a5240db2-3849-4d64-82f6-af5ea2a7351e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b9d82e2f-3574-4851-a675-2c8005340612"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c0916c0d-1440-41d3-ad46-848a1416ad03"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c2657693-20b0-4ac5-b9d4-14c8467dbbc0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("cacab35c-185d-4ff6-9579-945163b09a39"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("d3544ad8-0a24-4a5d-81b9-b456cbec26f8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("d465413c-e647-4fc1-b63d-55d949664932"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("d49ee78d-4e48-4a8d-a8df-616868fdf7b3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e337c3bb-89bb-47c8-8e63-6a2ccdacff57"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e89f1552-defb-4b6f-a007-b551c24ab77f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f5b61b2c-b37e-4fe8-9a17-b3597ec5a15a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("08d0b5f0-9bf6-4d54-bd00-ad956d8dbb6a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0d801351-fd34-449a-bc6e-b793845a5e10"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("141cadd5-5922-471d-9347-2ed29dd392a6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("195ffae3-d495-4fa3-a97f-6eefc6fea627"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("29842574-5051-43e6-be8a-b8cf76b443e5"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("2bbdf9ec-1b37-4038-937b-608daef26d23"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("2de1b53a-9ba7-498f-90aa-9ce282947433"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("34f391c5-189a-4ab8-940b-3872efd01e79"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("55080ecb-7355-40e0-990a-0518c73c50b6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9dff0e9e-1b43-46de-98e9-d8cb64be4b37"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("a1a7f771-a504-4899-9b91-76a8c1534581"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c248774f-cd05-414c-8af0-00a8a2c6a324"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c9f1bc01-30db-40cd-aa6b-865d4bef2324"));

            migrationBuilder.AlterTable(
                name: "Restrictions",
                comment: "Game Restriction");

            migrationBuilder.AlterTable(
                name: "Platforms",
                comment: "Game Platform");

            migrationBuilder.AlterTable(
                name: "Moderators",
                comment: "Moderator in GameVerse System");

            migrationBuilder.AlterTable(
                name: "Genres",
                comment: "Game Genre");

            migrationBuilder.AlterTable(
                name: "GamesRestrictions",
                comment: "Established many-to-many relation between Games and Restrictions Tables");

            migrationBuilder.AlterTable(
                name: "GamesPlatforms",
                comment: "Established many-to-many relation between Game and Platform tables");

            migrationBuilder.AlterTable(
                name: "GamesGenres",
                comment: "Established many-to-many relation between Game and Genre tables");

            migrationBuilder.AlterTable(
                name: "Games",
                comment: "Game to Buy");

            migrationBuilder.AlterTable(
                name: "GameReviews",
                comment: "Game Review");

            migrationBuilder.AlterTable(
                name: "Events",
                comment: "Gaming Event");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "The User in the GameVerse system");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                comment: "User indetifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Moderator unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestrictionId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The restriction unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatformId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The platform unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The genre unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game publisher unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The game buyer unique identifer");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeratorId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The user that bought ticket for the event",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Events",
                type: "float",
                nullable: false,
                comment: "Event location length coordinate",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Events",
                type: "float",
                nullable: false,
                comment: "Event location width coordinate",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft Delete flag",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("140f317d-a5eb-49ce-a72b-adb5ce901808"), "RPG" },
                    { new Guid("1a6d814b-1851-4d43-8379-9f8663168d41"), "Shooter" },
                    { new Guid("233ed329-59d1-4580-a66b-998dece785b6"), "Puzzle" },
                    { new Guid("23639a61-94fb-4a57-8d5b-a1ead6c5de6c"), "Battle Royale" },
                    { new Guid("4a2777e5-5ad9-438b-b360-f2bc255c250d"), "Fighting" },
                    { new Guid("4c90341a-a6b5-46f8-a573-258f6c0c62bc"), "Real-time strategy" },
                    { new Guid("4e7e1a45-2e8f-48ca-afbe-02795d6c19cd"), "Stealth" },
                    { new Guid("5c36d592-ebbd-4bf8-8261-4a9388737b2d"), "Action RPG" },
                    { new Guid("864e4532-e73e-4b1f-bfab-1e7f9514716c"), "Action" },
                    { new Guid("8b2cfe29-f967-40af-978a-c8585ae75cd2"), "Strategy game" },
                    { new Guid("909c38ab-6f59-490a-9fa3-21789060928b"), "Action-adventure" },
                    { new Guid("b0d8fb72-bb3c-4c8e-9672-04fb9f68d88a"), "Adventure" },
                    { new Guid("c40c61e7-336c-4a50-9ba2-2c58a97915cb"), "Casual" },
                    { new Guid("c689ae29-6d53-4cc3-8cec-98e264c578a6"), "Platformer" },
                    { new Guid("e3b0a8cd-bfe0-4ed5-834b-2ab58c64384e"), "First-Person Shooter" },
                    { new Guid("e8f7abe3-eaee-49fa-9d1e-879c258e0c31"), "Simulation" },
                    { new Guid("ea84768b-d336-4d03-9f1c-8f5427e6f1f2"), "Party" },
                    { new Guid("ed41dbe7-a963-403f-a6e1-bf5e6e94ea1c"), "Survival" },
                    { new Guid("ed85f717-37cc-4ec5-820b-a8576ace59bc"), "Sports" },
                    { new Guid("f710fba5-2457-4e18-ba1d-4843055ce0e2"), "Racing" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1598ef63-b583-4348-8671-861cea084f4a"), "Super Nintendo" },
                    { new Guid("352cc0aa-9918-446a-8cac-27e4b9306d3c"), "PlayStation Portable" },
                    { new Guid("4eb1dd9f-ab06-4cbb-a0a7-2c92377bd421"), "PlayStation Vita" },
                    { new Guid("5bea4806-fe4f-4a44-8dc7-28fb9e588d0f"), "PlayStation 5" },
                    { new Guid("66ec3597-fdfb-4b09-ac62-681edf2390d9"), "Linux" },
                    { new Guid("6719e821-4074-484f-86af-4f169cb2c507"), "PlayStation 1" },
                    { new Guid("6c920905-e921-4900-a227-3687d4bc48ca"), "Nintendo DS" },
                    { new Guid("709f04e0-8398-4473-a6cd-26ce3278fa03"), "Xbox Series X" },
                    { new Guid("71b1ce76-2268-47f2-b9e8-79e064084119"), "Xbox One" },
                    { new Guid("747734ee-2371-49e5-b35c-b84dac53840d"), "PC" },
                    { new Guid("79a97a77-0bb5-4125-88b9-c48244a81a48"), "PlayStation 4" },
                    { new Guid("8947b547-c8e9-4e09-b28a-45b6297d6564"), "PlayStation 2" },
                    { new Guid("9fc7e32d-4531-448e-b35d-262e86785a1b"), "Sega Mega Drive" },
                    { new Guid("aaaffcfc-4f64-4e76-9b4e-a84a6682f1a6"), "Game Boy" },
                    { new Guid("ac04dfb1-a83d-40da-8630-ca97901e8f3e"), "Nintendo Wii" },
                    { new Guid("c1e9808c-62d2-4436-98e6-33a4544b6fda"), "Mac" },
                    { new Guid("e1c2484d-d4e5-41a1-9cfd-c3724b7ff155"), "Nintendo Switch" },
                    { new Guid("e2ce1ff1-3013-4a88-b0c0-8502156ee5f3"), "Xbox 360" },
                    { new Guid("e3a5b98e-fb33-4e52-84e7-e9afe35e1d9f"), "Game Boy Advanced" },
                    { new Guid("f93ef075-e631-446a-b406-e36e91c43272"), "PlayStation 3" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20611352-e5d4-4163-adf0-cac172707672"), "Sex" },
                    { new Guid("52a80403-3a5d-4efc-bd33-ff9e7c11a53c"), "In-Game Purchases" },
                    { new Guid("69635366-b000-4c46-a218-2f0c597acbe2"), "Discrimination" },
                    { new Guid("6aad0f35-deb8-40ca-b9c5-f6991cf503d5"), "PEGI 16 " },
                    { new Guid("7c4a0010-f0c7-4d65-bb37-89d55f49c555"), "Violence" },
                    { new Guid("8530df07-5be1-4716-b85e-808761aba942"), "Fear" },
                    { new Guid("92f1f1c0-3a64-4a18-a26c-640a66c7afc5"), "Bad Language" },
                    { new Guid("9320bac7-1a9a-448e-8d08-25a72276114b"), "PEGI 18" },
                    { new Guid("96b992a9-d923-4199-9737-693b8d93fe37"), "PEGI 12" },
                    { new Guid("9dabaf16-bb61-481a-bcaa-f14458beba1a"), "PEGI 3" },
                    { new Guid("c87ca73c-12e9-474c-8049-f9d42b936cc3"), "PEGI 7" },
                    { new Guid("fcd46fb2-1692-4a35-80bb-a5b5e9b0fa53"), "Drugs" },
                    { new Guid("fd14d634-7a04-41fc-9066-b5e8d858cbbc"), "Gambling" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_BuyerId",
                table: "Games",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ModeratorId",
                table: "Games",
                column: "ModeratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_BuyerId",
                table: "Games",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Moderators_ModeratorId",
                table: "Games",
                column: "ModeratorId",
                principalTable: "Moderators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesPlatforms_Games_GameId",
                table: "GamesPlatforms",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesPlatforms_Platforms_PlatformId",
                table: "GamesPlatforms",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_BuyerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Moderators_ModeratorId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesPlatforms_Games_GameId",
                table: "GamesPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesPlatforms_Platforms_PlatformId",
                table: "GamesPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_Games_BuyerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ModeratorId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("140f317d-a5eb-49ce-a72b-adb5ce901808"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1a6d814b-1851-4d43-8379-9f8663168d41"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("233ed329-59d1-4580-a66b-998dece785b6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("23639a61-94fb-4a57-8d5b-a1ead6c5de6c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4a2777e5-5ad9-438b-b360-f2bc255c250d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4c90341a-a6b5-46f8-a573-258f6c0c62bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4e7e1a45-2e8f-48ca-afbe-02795d6c19cd"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5c36d592-ebbd-4bf8-8261-4a9388737b2d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("864e4532-e73e-4b1f-bfab-1e7f9514716c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8b2cfe29-f967-40af-978a-c8585ae75cd2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("909c38ab-6f59-490a-9fa3-21789060928b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b0d8fb72-bb3c-4c8e-9672-04fb9f68d88a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c40c61e7-336c-4a50-9ba2-2c58a97915cb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c689ae29-6d53-4cc3-8cec-98e264c578a6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e3b0a8cd-bfe0-4ed5-834b-2ab58c64384e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e8f7abe3-eaee-49fa-9d1e-879c258e0c31"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ea84768b-d336-4d03-9f1c-8f5427e6f1f2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ed41dbe7-a963-403f-a6e1-bf5e6e94ea1c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ed85f717-37cc-4ec5-820b-a8576ace59bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f710fba5-2457-4e18-ba1d-4843055ce0e2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1598ef63-b583-4348-8671-861cea084f4a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("352cc0aa-9918-446a-8cac-27e4b9306d3c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4eb1dd9f-ab06-4cbb-a0a7-2c92377bd421"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("5bea4806-fe4f-4a44-8dc7-28fb9e588d0f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("66ec3597-fdfb-4b09-ac62-681edf2390d9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6719e821-4074-484f-86af-4f169cb2c507"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6c920905-e921-4900-a227-3687d4bc48ca"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("709f04e0-8398-4473-a6cd-26ce3278fa03"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("71b1ce76-2268-47f2-b9e8-79e064084119"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("747734ee-2371-49e5-b35c-b84dac53840d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("79a97a77-0bb5-4125-88b9-c48244a81a48"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8947b547-c8e9-4e09-b28a-45b6297d6564"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9fc7e32d-4531-448e-b35d-262e86785a1b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("aaaffcfc-4f64-4e76-9b4e-a84a6682f1a6"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ac04dfb1-a83d-40da-8630-ca97901e8f3e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c1e9808c-62d2-4436-98e6-33a4544b6fda"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e1c2484d-d4e5-41a1-9cfd-c3724b7ff155"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e2ce1ff1-3013-4a88-b0c0-8502156ee5f3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e3a5b98e-fb33-4e52-84e7-e9afe35e1d9f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f93ef075-e631-446a-b406-e36e91c43272"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("20611352-e5d4-4163-adf0-cac172707672"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("52a80403-3a5d-4efc-bd33-ff9e7c11a53c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("69635366-b000-4c46-a218-2f0c597acbe2"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("6aad0f35-deb8-40ca-b9c5-f6991cf503d5"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7c4a0010-f0c7-4d65-bb37-89d55f49c555"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8530df07-5be1-4716-b85e-808761aba942"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("92f1f1c0-3a64-4a18-a26c-640a66c7afc5"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9320bac7-1a9a-448e-8d08-25a72276114b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("96b992a9-d923-4199-9737-693b8d93fe37"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9dabaf16-bb61-481a-bcaa-f14458beba1a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c87ca73c-12e9-474c-8049-f9d42b936cc3"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("fcd46fb2-1692-4a35-80bb-a5b5e9b0fa53"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("fd14d634-7a04-41fc-9066-b5e8d858cbbc"));

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ModeratorId",
                table: "Games");

            migrationBuilder.AlterTable(
                name: "Restrictions",
                oldComment: "Game Restriction");

            migrationBuilder.AlterTable(
                name: "Platforms",
                oldComment: "Game Platform");

            migrationBuilder.AlterTable(
                name: "Moderators",
                oldComment: "Moderator in GameVerse System");

            migrationBuilder.AlterTable(
                name: "Genres",
                oldComment: "Game Genre");

            migrationBuilder.AlterTable(
                name: "GamesRestrictions",
                oldComment: "Established many-to-many relation between Games and Restrictions Tables");

            migrationBuilder.AlterTable(
                name: "GamesPlatforms",
                oldComment: "Established many-to-many relation between Game and Platform tables");

            migrationBuilder.AlterTable(
                name: "GamesGenres",
                oldComment: "Established many-to-many relation between Game and Genre tables");

            migrationBuilder.AlterTable(
                name: "Games",
                oldComment: "Game to Buy");

            migrationBuilder.AlterTable(
                name: "GameReviews",
                oldComment: "Game Review");

            migrationBuilder.AlterTable(
                name: "Events",
                oldComment: "Gaming Event");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "The User in the GameVerse system");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "User indetifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Moderator unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestrictionId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The restriction unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlatformId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The platform unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The genre unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game publisher unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The user that bought ticket for the event");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Events",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Event location length coordinate");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Events",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Event location width coordinate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false,
                oldComment: "Soft Delete flag");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17f7da99-ef87-4439-bcf5-0e5745d503c1"), "Casual" },
                    { new Guid("250edbc7-6e3c-4408-bd8f-126e101d8b65"), "Sports" },
                    { new Guid("29d39f41-b35d-4bde-a066-fb25e97eba03"), "Puzzle" },
                    { new Guid("37b5af83-5972-49b3-935c-73d40ed42450"), "First-Person Shooter" },
                    { new Guid("5c763cb7-7d78-454e-9e8e-215a6d3c8221"), "Adventure" },
                    { new Guid("5d6f50c8-30a0-41ae-8bbf-130efd4eba6f"), "Real-time strategy" },
                    { new Guid("67a0fba1-6c3b-48be-8b0e-5f1207d96ff7"), "Platformer" },
                    { new Guid("68a504fb-67b6-4150-b022-c0c18181f396"), "Shooter" },
                    { new Guid("6b4e8124-fda1-4356-993c-64f1e23c4b8a"), "Fighting" },
                    { new Guid("6e76b75a-f8f0-4809-bbce-4dac3f1e0ce7"), "Action RPG" },
                    { new Guid("75fec1c0-f5dc-4540-bda0-46b2f42ab55a"), "RPG" },
                    { new Guid("7e7a48cf-a781-400d-bf21-82c63508148b"), "Survival" },
                    { new Guid("8bf36bf0-6ef5-4692-9d7f-6164873bddf1"), "Action-adventure" },
                    { new Guid("93e9684c-6743-41ef-bdf0-57671ad8c75f"), "Stealth" },
                    { new Guid("b5250e25-c3ed-4c48-b8ec-7c6e828b9d1c"), "Battle Royale" },
                    { new Guid("cb0521cb-8c95-4f21-bcc0-0f3a3c49da6b"), "Simulation" },
                    { new Guid("daf02669-8b06-42c0-a824-097d40878d0f"), "Strategy game" },
                    { new Guid("db536178-a9db-4e4c-8475-648f51300c04"), "Action" },
                    { new Guid("f3a8902d-cc5a-4ff7-9d1e-24a9b2529e74"), "Racing" },
                    { new Guid("fb403daa-49a1-472d-a887-4a30dee4ca05"), "Party" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("090dd149-30ee-4046-b42c-712b1811cede"), "Xbox One" },
                    { new Guid("0b3e823a-2e1f-4331-a7c1-12f69627229a"), "PlayStation Portable" },
                    { new Guid("178de0d3-b664-438f-bba6-8b58c8cb6640"), "PlayStation 1" },
                    { new Guid("17e3fba9-a042-4ece-8b39-4c9eda940474"), "PlayStation Vita" },
                    { new Guid("2e3ffd25-27be-4f74-807c-579182fb2e09"), "Nintendo Wii" },
                    { new Guid("55f01289-183d-4055-9d64-03b1eea3eef8"), "Game Boy" },
                    { new Guid("5841816d-9567-4911-80f8-9ea8c911d516"), "PlayStation 5" },
                    { new Guid("6adfbae0-75f1-4163-b6fe-2dd264e323b6"), "PlayStation 3" },
                    { new Guid("81df3c20-29da-4e4e-b1be-95e006f88320"), "Linux" },
                    { new Guid("a5240db2-3849-4d64-82f6-af5ea2a7351e"), "Game Boy Advanced" },
                    { new Guid("b9d82e2f-3574-4851-a675-2c8005340612"), "PC" },
                    { new Guid("c0916c0d-1440-41d3-ad46-848a1416ad03"), "PlayStation 2" },
                    { new Guid("c2657693-20b0-4ac5-b9d4-14c8467dbbc0"), "Nintendo DS" },
                    { new Guid("cacab35c-185d-4ff6-9579-945163b09a39"), "Sega Mega Drive" },
                    { new Guid("d3544ad8-0a24-4a5d-81b9-b456cbec26f8"), "Xbox Series X" },
                    { new Guid("d465413c-e647-4fc1-b63d-55d949664932"), "Mac" },
                    { new Guid("d49ee78d-4e48-4a8d-a8df-616868fdf7b3"), "PlayStation 4" },
                    { new Guid("e337c3bb-89bb-47c8-8e63-6a2ccdacff57"), "Super Nintendo" },
                    { new Guid("e89f1552-defb-4b6f-a007-b551c24ab77f"), "Xbox 360" },
                    { new Guid("f5b61b2c-b37e-4fe8-9a17-b3597ec5a15a"), "Nintendo Switch" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08d0b5f0-9bf6-4d54-bd00-ad956d8dbb6a"), "PEGI 18" },
                    { new Guid("0d801351-fd34-449a-bc6e-b793845a5e10"), "Discrimination" },
                    { new Guid("141cadd5-5922-471d-9347-2ed29dd392a6"), "Gambling" },
                    { new Guid("195ffae3-d495-4fa3-a97f-6eefc6fea627"), "Violence" },
                    { new Guid("29842574-5051-43e6-be8a-b8cf76b443e5"), "Bad Language" },
                    { new Guid("2bbdf9ec-1b37-4038-937b-608daef26d23"), "PEGI 7" },
                    { new Guid("2de1b53a-9ba7-498f-90aa-9ce282947433"), "Sex" },
                    { new Guid("34f391c5-189a-4ab8-940b-3872efd01e79"), "PEGI 12" },
                    { new Guid("55080ecb-7355-40e0-990a-0518c73c50b6"), "In-Game Purchases" },
                    { new Guid("9dff0e9e-1b43-46de-98e9-d8cb64be4b37"), "PEGI 16 " },
                    { new Guid("a1a7f771-a504-4899-9b91-76a8c1534581"), "PEGI 3" },
                    { new Guid("c248774f-cd05-414c-8af0-00a8a2c6a324"), "Fear" },
                    { new Guid("c9f1bc01-30db-40cd-aa6b-865d4bef2324"), "Drugs" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesPlatforms_Games_PlatformId",
                table: "GamesPlatforms",
                column: "PlatformId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesPlatforms_Platforms_GameId",
                table: "GamesPlatforms",
                column: "GameId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
