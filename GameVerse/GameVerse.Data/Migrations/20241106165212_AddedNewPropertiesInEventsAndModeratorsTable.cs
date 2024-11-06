using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertiesInEventsAndModeratorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                comment: "User identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "User indetifier");

            migrationBuilder.AddColumn<int>(
                name: "TotalEventsCreated",
                table: "Moderators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Total Events created by the Moderator");

            migrationBuilder.AddColumn<int>(
                name: "TotalGamesCreated",
                table: "Moderators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Total Games Created by the Moderator");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Event status");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "TotalEventsCreated",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "TotalGamesCreated",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Moderators",
                type: "uniqueidentifier",
                nullable: false,
                comment: "User indetifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "User identifier");

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
        }
    }
}
