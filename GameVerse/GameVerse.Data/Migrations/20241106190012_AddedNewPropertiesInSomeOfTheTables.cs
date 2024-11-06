using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertiesInSomeOfTheTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Moderators_ModeratorId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ModeratorId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("07c7c969-0cb1-4401-8266-61b59e823fed"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0c76ce4c-1a92-462b-85f6-84e27056dfb8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("28f02ce8-f8e3-4ecc-bfcf-328382c1821b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2dba9b4e-bc76-4e7f-a290-6df33811af9f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2e2d1395-abd4-48dc-8e4c-5b5aa155ed58"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("38bad3ec-7561-4671-82bd-cf97e4135ffc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3e341ebc-d6f0-4684-9347-04885f64424e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("49e9844d-3c92-4c95-a80f-658858326ef4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("55475650-bf67-444e-92e4-0d2abdbfefee"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("738ee4fc-e51d-4149-b273-208e62819d1a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("74868dfb-1b41-4c14-b991-3c78d6ef8d58"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8176981d-0fa2-461e-bff0-c0b4ae53b1cf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8850f64d-c056-4278-afe1-8be07d923b10"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b317a3a4-2a11-41eb-8a94-2d9d9898c242"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cd345083-d77b-4ced-923f-f5adce8f541c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d9cb0a52-5665-4b26-9b85-1d99449aaf6b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e0f2a6c2-5dba-488d-a297-915c17ff69ec"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fb96842c-b839-4f67-9acd-0eb147419cd7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fc195f71-de1a-4b99-a2e0-e84fc632a204"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ff6b2af0-c523-45c2-ac3c-8eb904aa6f2d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("05b5fc78-6a5d-40c2-860a-eaac51d7cc0f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("15741f36-c8b1-406e-84c1-5d213a08a262"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("18377657-a5f6-4e07-9f19-a56cffa36378"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1f206c07-f0a3-44a5-905e-8cef3bf0a110"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3f4f9e1b-6895-4f10-b4e3-45bda184f564"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("62f4f067-d795-4620-8212-ef6e254d7383"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6ed9e834-8aa5-4e6e-bcab-c7e87cbf7388"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6ef6aa92-d2eb-4681-abd8-d86a57cd12af"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("727b83d2-b094-4b99-886e-9892baa44be7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8055274a-a55f-4aa4-ac71-03a22ea2426d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("87045936-9026-4768-bdf2-611932e08dca"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("99e26931-da16-42a8-b2d0-f517e1aede37"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a1235a8c-8a3c-43cc-8fd4-114021c9bec5"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ae90a995-a0bf-40c3-9fbe-46e2a7a6ea46"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("bfecbdec-44e6-4dec-9d52-0420bac3ffff"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c57c0ab7-bd22-4b89-a80e-0b458a777df9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("da3a5de1-4fa9-4e76-8d10-d66d13c44d46"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("df581f77-1066-4316-9786-5f17581e1f1e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e04de74c-14ec-4f29-a6f4-9e010c405ec1"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f925679c-bce2-4ae3-936f-3612803bb54c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0c7928aa-cfe1-4eee-a930-f1d3863e39af"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("538cb007-afc8-49a3-9e2e-2091ea62761b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("53cb12f3-62d8-4f6b-b7e7-1df03c4101af"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("5f1ac6e7-d4e7-48d1-9142-3c9f44fa62ba"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("66f4c8a0-546b-46d2-89f4-1643b4ceead6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9099a73a-294f-4e77-869c-3321392fbbcd"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9768487f-3c12-4f11-80be-0a81c7b1ecf3"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("97ccc56a-81fa-4e1f-bc65-bd9b2acb5b5a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("97ecfd7d-0ab2-49c7-b352-5278bddd14f6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ad9fecc6-3241-4207-96a2-4d95ef0f73dd"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("bec77ec2-200c-4d47-ba20-099819efef09"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("cd6f7d34-06f2-4217-b1af-7ccea8cd67fc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ff355cf8-ba95-4062-8f07-b4e41cf38614"));

            migrationBuilder.DropColumn(
                name: "ModeratorId",
                table: "Games");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Restrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The restriction unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The restriction unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The genre unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The genre unique indetifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestrictionId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The restriction unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The restriction unique indentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesRestrictions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique indentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesPlatforms",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The genre unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The genre unique indentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique indentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesGenres",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft Delete flag");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The game buyer unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The game buyer unique identifer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique identifier.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique indentifier.");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13c4e32c-13c1-425f-b80d-ce63399b46e5"), "Shooter" },
                    { new Guid("1d028cc9-adaf-475c-9f9f-4fcfe46b58e3"), "Battle Royale" },
                    { new Guid("20190a29-cb44-4600-bd89-c14baa0b02df"), "Stealth" },
                    { new Guid("31d02b97-cf1c-4696-8466-18be3d70eb2f"), "Fighting" },
                    { new Guid("344e903b-cc84-43fe-be02-f31d857aab3b"), "Party" },
                    { new Guid("5f83816c-82c1-45c2-a5df-e4ca48773066"), "Survival" },
                    { new Guid("66c5bbf8-78e2-45eb-9743-237a81c963d5"), "RPG" },
                    { new Guid("68a5fbbb-b5e6-4e7c-a11c-d2a115eaf22d"), "Racing" },
                    { new Guid("77ba4a38-8c51-4c75-867b-cc9df6dfda28"), "Real-time strategy" },
                    { new Guid("7a89ae23-64de-4222-9b9e-fd82d3c005ec"), "Casual" },
                    { new Guid("7eade593-23ee-4fd9-9389-7b6bd15ecfad"), "Action-adventure" },
                    { new Guid("8f109731-de11-4ed4-b877-b6a254af117e"), "Simulation" },
                    { new Guid("a77e06c6-88a9-4872-9562-ae0d75f6b1a2"), "Action" },
                    { new Guid("cb3969e6-2dcc-4699-a32f-574938b2b2b1"), "Adventure" },
                    { new Guid("cb3e088b-868a-4486-ad8c-ae1c01bc012d"), "Action RPG" },
                    { new Guid("d5a5b9c3-8d3e-457d-b173-bbdcda012b30"), "Platformer" },
                    { new Guid("ebdefae0-60a1-4cd4-b9ac-b8019cc90110"), "Strategy game" },
                    { new Guid("ee30fc9c-3c16-4d10-8919-f19d5335fc33"), "Sports" },
                    { new Guid("f4dbe79a-0fe7-44e5-8cba-15e41dc53aad"), "Puzzle" },
                    { new Guid("fcd1da4a-c9a4-41a6-9f72-46707904225e"), "First-Person Shooter" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1a39f9d3-192f-4160-ad4d-6cad3945b1d3"), "Super Nintendo" },
                    { new Guid("29feee7d-2524-4510-a6b5-474ef034902f"), "Nintendo Wii" },
                    { new Guid("2c05359c-6ea5-4059-8c46-0d94bcba45ca"), "Mac" },
                    { new Guid("3556fbce-901d-4308-a1cc-4d0465880bfe"), "Xbox Series X" },
                    { new Guid("3cc6af79-30cd-4581-b878-8d5341582748"), "Sega Mega Drive" },
                    { new Guid("402a5da5-b077-48d9-9d58-c129ad2907dd"), "Nintendo DS" },
                    { new Guid("465d443c-1b8d-4e98-90df-df836bc7c6d3"), "Xbox One" },
                    { new Guid("4b00295f-1fd4-47e7-92bc-d6bcd182ee06"), "PlayStation 3" },
                    { new Guid("58e405fc-b8f1-4ec3-b774-4222e9a99d1e"), "Game Boy" },
                    { new Guid("7de8f628-1240-4fd6-9423-b491b836a60f"), "Xbox 360" },
                    { new Guid("82a69914-8e3d-474b-9acf-c89ffd8996a0"), "PlayStation Vita" },
                    { new Guid("92025206-bb34-4bc1-bade-0f6e2557258e"), "PlayStation 4" },
                    { new Guid("96a483f1-219f-450b-85b8-41e33afcac07"), "PC" },
                    { new Guid("a96128d7-0196-41ef-bce0-d688e889b361"), "PlayStation 5" },
                    { new Guid("ac24cccc-56c8-42a6-9d72-744beaca3ac9"), "Game Boy Advanced" },
                    { new Guid("cf3b480b-1b12-42f3-9fdd-5af12abdf13f"), "PlayStation 1" },
                    { new Guid("dd5c459e-5233-42f1-baa3-fa0d818efdf7"), "PlayStation 2" },
                    { new Guid("dff9fa2a-adf6-456f-a8f3-33384962b142"), "Nintendo Switch" },
                    { new Guid("e12ee76b-edf5-4fbc-8b91-d6eafba17168"), "PlayStation Portable" },
                    { new Guid("f95aea67-5b7b-4b14-9f82-8be87f7bea3c"), "Linux" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11011949-e787-4754-a829-6c4a1aeeb51e"), "PEGI 18" },
                    { new Guid("360f40ed-e814-4499-b7e8-9c67d0a88238"), "PEGI 16 " },
                    { new Guid("479ac84f-42f7-4f54-9f63-316bda461881"), "Bad Language" },
                    { new Guid("59677e73-ac5b-4e42-ac30-625ee278cb89"), "Fear" },
                    { new Guid("6844497d-5ab7-4f88-809b-87f8de08c25e"), "Violence" },
                    { new Guid("73ef9075-0804-42c0-94c6-410ece94f92c"), "PEGI 3" },
                    { new Guid("7c58f456-29a4-4de0-bbe1-ab8259d0502f"), "Drugs" },
                    { new Guid("7e9cd6ab-8c9b-47a4-8974-73df9c8bb78d"), "PEGI 12" },
                    { new Guid("87d93875-7105-4646-8701-423830b6a9fa"), "Sex" },
                    { new Guid("8a19405b-480a-4483-bb16-b8868b860e1d"), "Gambling" },
                    { new Guid("8d4e7f11-d904-491b-b470-c1e8d026c4c2"), "PEGI 7" },
                    { new Guid("8da3b6df-2ada-4299-8369-49c97e0659f2"), "In-Game Purchases" },
                    { new Guid("f9bdca2e-9a6a-410e-8728-9d9796f83f1a"), "Discrimination" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Moderators_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Moderators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Moderators_PublisherId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("13c4e32c-13c1-425f-b80d-ce63399b46e5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1d028cc9-adaf-475c-9f9f-4fcfe46b58e3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("20190a29-cb44-4600-bd89-c14baa0b02df"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("31d02b97-cf1c-4696-8466-18be3d70eb2f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("344e903b-cc84-43fe-be02-f31d857aab3b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5f83816c-82c1-45c2-a5df-e4ca48773066"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("66c5bbf8-78e2-45eb-9743-237a81c963d5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("68a5fbbb-b5e6-4e7c-a11c-d2a115eaf22d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("77ba4a38-8c51-4c75-867b-cc9df6dfda28"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7a89ae23-64de-4222-9b9e-fd82d3c005ec"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7eade593-23ee-4fd9-9389-7b6bd15ecfad"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8f109731-de11-4ed4-b877-b6a254af117e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a77e06c6-88a9-4872-9562-ae0d75f6b1a2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cb3969e6-2dcc-4699-a32f-574938b2b2b1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cb3e088b-868a-4486-ad8c-ae1c01bc012d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d5a5b9c3-8d3e-457d-b173-bbdcda012b30"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ebdefae0-60a1-4cd4-b9ac-b8019cc90110"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ee30fc9c-3c16-4d10-8919-f19d5335fc33"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f4dbe79a-0fe7-44e5-8cba-15e41dc53aad"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fcd1da4a-c9a4-41a6-9f72-46707904225e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1a39f9d3-192f-4160-ad4d-6cad3945b1d3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("29feee7d-2524-4510-a6b5-474ef034902f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2c05359c-6ea5-4059-8c46-0d94bcba45ca"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3556fbce-901d-4308-a1cc-4d0465880bfe"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3cc6af79-30cd-4581-b878-8d5341582748"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("402a5da5-b077-48d9-9d58-c129ad2907dd"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("465d443c-1b8d-4e98-90df-df836bc7c6d3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4b00295f-1fd4-47e7-92bc-d6bcd182ee06"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("58e405fc-b8f1-4ec3-b774-4222e9a99d1e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7de8f628-1240-4fd6-9423-b491b836a60f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("82a69914-8e3d-474b-9acf-c89ffd8996a0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("92025206-bb34-4bc1-bade-0f6e2557258e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("96a483f1-219f-450b-85b8-41e33afcac07"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a96128d7-0196-41ef-bce0-d688e889b361"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ac24cccc-56c8-42a6-9d72-744beaca3ac9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("cf3b480b-1b12-42f3-9fdd-5af12abdf13f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("dd5c459e-5233-42f1-baa3-fa0d818efdf7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("dff9fa2a-adf6-456f-a8f3-33384962b142"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e12ee76b-edf5-4fbc-8b91-d6eafba17168"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f95aea67-5b7b-4b14-9f82-8be87f7bea3c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("11011949-e787-4754-a829-6c4a1aeeb51e"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("360f40ed-e814-4499-b7e8-9c67d0a88238"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("479ac84f-42f7-4f54-9f63-316bda461881"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("59677e73-ac5b-4e42-ac30-625ee278cb89"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("6844497d-5ab7-4f88-809b-87f8de08c25e"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("73ef9075-0804-42c0-94c6-410ece94f92c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7c58f456-29a4-4de0-bbe1-ab8259d0502f"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7e9cd6ab-8c9b-47a4-8974-73df9c8bb78d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("87d93875-7105-4646-8701-423830b6a9fa"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8a19405b-480a-4483-bb16-b8868b860e1d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8d4e7f11-d904-491b-b470-c1e8d026c4c2"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8da3b6df-2ada-4299-8369-49c97e0659f2"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("f9bdca2e-9a6a-410e-8728-9d9796f83f1a"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesRestrictions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesPlatforms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesGenres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Games");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Restrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The restriction unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The restriction unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Genres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The genre unique indetifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The genre unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestrictionId",
                table: "GamesRestrictions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The restriction unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The restriction unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesPlatforms",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The genre unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The genre unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "GamesGenres",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique indentifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The game buyer unique identifer",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The game buyer unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Games",
                type: "uniqueidentifier",
                nullable: false,
                comment: "The game unique indentifier.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The game unique identifier.");

            migrationBuilder.AddColumn<Guid>(
                name: "ModeratorId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07c7c969-0cb1-4401-8266-61b59e823fed"), "Party" },
                    { new Guid("0c76ce4c-1a92-462b-85f6-84e27056dfb8"), "Stealth" },
                    { new Guid("28f02ce8-f8e3-4ecc-bfcf-328382c1821b"), "Fighting" },
                    { new Guid("2dba9b4e-bc76-4e7f-a290-6df33811af9f"), "Puzzle" },
                    { new Guid("2e2d1395-abd4-48dc-8e4c-5b5aa155ed58"), "Adventure" },
                    { new Guid("38bad3ec-7561-4671-82bd-cf97e4135ffc"), "Shooter" },
                    { new Guid("3e341ebc-d6f0-4684-9347-04885f64424e"), "Strategy game" },
                    { new Guid("49e9844d-3c92-4c95-a80f-658858326ef4"), "RPG" },
                    { new Guid("55475650-bf67-444e-92e4-0d2abdbfefee"), "Simulation" },
                    { new Guid("738ee4fc-e51d-4149-b273-208e62819d1a"), "Action RPG" },
                    { new Guid("74868dfb-1b41-4c14-b991-3c78d6ef8d58"), "Battle Royale" },
                    { new Guid("8176981d-0fa2-461e-bff0-c0b4ae53b1cf"), "Survival" },
                    { new Guid("8850f64d-c056-4278-afe1-8be07d923b10"), "Platformer" },
                    { new Guid("b317a3a4-2a11-41eb-8a94-2d9d9898c242"), "Casual" },
                    { new Guid("cd345083-d77b-4ced-923f-f5adce8f541c"), "Sports" },
                    { new Guid("d9cb0a52-5665-4b26-9b85-1d99449aaf6b"), "Real-time strategy" },
                    { new Guid("e0f2a6c2-5dba-488d-a297-915c17ff69ec"), "Action" },
                    { new Guid("fb96842c-b839-4f67-9acd-0eb147419cd7"), "First-Person Shooter" },
                    { new Guid("fc195f71-de1a-4b99-a2e0-e84fc632a204"), "Action-adventure" },
                    { new Guid("ff6b2af0-c523-45c2-ac3c-8eb904aa6f2d"), "Racing" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05b5fc78-6a5d-40c2-860a-eaac51d7cc0f"), "PlayStation 2" },
                    { new Guid("15741f36-c8b1-406e-84c1-5d213a08a262"), "Game Boy" },
                    { new Guid("18377657-a5f6-4e07-9f19-a56cffa36378"), "PlayStation 3" },
                    { new Guid("1f206c07-f0a3-44a5-905e-8cef3bf0a110"), "Nintendo DS" },
                    { new Guid("3f4f9e1b-6895-4f10-b4e3-45bda184f564"), "PlayStation 1" },
                    { new Guid("62f4f067-d795-4620-8212-ef6e254d7383"), "Game Boy Advanced" },
                    { new Guid("6ed9e834-8aa5-4e6e-bcab-c7e87cbf7388"), "PC" },
                    { new Guid("6ef6aa92-d2eb-4681-abd8-d86a57cd12af"), "Nintendo Wii" },
                    { new Guid("727b83d2-b094-4b99-886e-9892baa44be7"), "Xbox 360" },
                    { new Guid("8055274a-a55f-4aa4-ac71-03a22ea2426d"), "Mac" },
                    { new Guid("87045936-9026-4768-bdf2-611932e08dca"), "Xbox One" },
                    { new Guid("99e26931-da16-42a8-b2d0-f517e1aede37"), "Super Nintendo" },
                    { new Guid("a1235a8c-8a3c-43cc-8fd4-114021c9bec5"), "Linux" },
                    { new Guid("ae90a995-a0bf-40c3-9fbe-46e2a7a6ea46"), "PlayStation Portable" },
                    { new Guid("bfecbdec-44e6-4dec-9d52-0420bac3ffff"), "Sega Mega Drive" },
                    { new Guid("c57c0ab7-bd22-4b89-a80e-0b458a777df9"), "PlayStation Vita" },
                    { new Guid("da3a5de1-4fa9-4e76-8d10-d66d13c44d46"), "Nintendo Switch" },
                    { new Guid("df581f77-1066-4316-9786-5f17581e1f1e"), "Xbox Series X" },
                    { new Guid("e04de74c-14ec-4f29-a6f4-9e010c405ec1"), "PlayStation 4" },
                    { new Guid("f925679c-bce2-4ae3-936f-3612803bb54c"), "PlayStation 5" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c7928aa-cfe1-4eee-a930-f1d3863e39af"), "Bad Language" },
                    { new Guid("538cb007-afc8-49a3-9e2e-2091ea62761b"), "Discrimination" },
                    { new Guid("53cb12f3-62d8-4f6b-b7e7-1df03c4101af"), "PEGI 3" },
                    { new Guid("5f1ac6e7-d4e7-48d1-9142-3c9f44fa62ba"), "PEGI 18" },
                    { new Guid("66f4c8a0-546b-46d2-89f4-1643b4ceead6"), "Fear" },
                    { new Guid("9099a73a-294f-4e77-869c-3321392fbbcd"), "Violence" },
                    { new Guid("9768487f-3c12-4f11-80be-0a81c7b1ecf3"), "PEGI 12" },
                    { new Guid("97ccc56a-81fa-4e1f-bc65-bd9b2acb5b5a"), "PEGI 16 " },
                    { new Guid("97ecfd7d-0ab2-49c7-b352-5278bddd14f6"), "In-Game Purchases" },
                    { new Guid("ad9fecc6-3241-4207-96a2-4d95ef0f73dd"), "Sex" },
                    { new Guid("bec77ec2-200c-4d47-ba20-099819efef09"), "Drugs" },
                    { new Guid("cd6f7d34-06f2-4217-b1af-7ccea8cd67fc"), "PEGI 7" },
                    { new Guid("ff355cf8-ba95-4062-8f07-b4e41cf38614"), "Gambling" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ModeratorId",
                table: "Games",
                column: "ModeratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Moderators_ModeratorId",
                table: "Games",
                column: "ModeratorId",
                principalTable: "Moderators",
                principalColumn: "Id");
        }
    }
}
