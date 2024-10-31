using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPublisherIdPropertyInEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("05184314-9326-4e65-b560-d913142f993c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("08733cf5-fc36-42ff-b616-3129d7843f88"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("18169f3e-41a5-4b2a-8b8c-d8274ab88cbb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b22eeed-6a19-419a-b786-f6c30cd3a4b7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("501e8e9e-4da0-4942-bc43-6de9f67ceae0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("52a5b04c-000f-49df-b0ce-0c3efb02beea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5502c0eb-978c-4e2d-8bde-09fdb0a7283f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("899aae4c-0144-4eeb-b56f-c204332195ea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9d3b8645-26fe-428e-98a9-2c64883e7eb4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b352cce6-3cec-4896-8354-f98fe4799f82"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b520d2c0-d551-45c5-802e-f07563164304"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b97e41d0-038d-436a-8a0c-68330f90a71f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bc27424b-d957-4679-8c31-670ed540dd4e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c3df8f83-1f64-457c-9f84-8bcf32eaf610"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c76b7a6d-b804-45e6-81cd-3a718cdb67e2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cf50cc02-de6d-4db4-a800-39aca6560b76"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cfcb1974-30d9-4503-b60d-d024f86ce1d3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d8be7865-79a5-4f8a-8abc-38d3a76ae5f0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("dbad333f-9a28-4bfe-991c-3dfc0cb6b534"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e94dfb2a-ae9e-490b-8128-881d3b3e0b83"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("157fd96b-55fe-4fb6-a311-1b17bc9964f3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("20b7df08-ff00-4996-880f-5fbaff6a1a69"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("29476c25-34d2-4f47-81b1-1c3ceb438f8f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2f596b18-f14b-4c03-a234-df736f81a161"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("39c26e96-e41b-4afb-8460-cbaed909a6fb"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4b541bf0-1e91-471d-b39a-f5e0503675e1"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4fada622-53fc-49a5-bc2c-69f7e84426af"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("69d1905b-af73-4bba-83eb-46dac99b67e3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6b557837-8fc4-41e0-a122-130a903ba1fa"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("728731da-b427-41a6-a810-a68dc6472a2a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("77bdff3f-4895-4bee-bc10-aeb4613a7c05"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7d454134-2891-430b-8247-7473cf759c6b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8740ed17-58e8-4b47-be06-bf5e98d23bff"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8d20be52-ee05-455f-9731-f6094109c898"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("abf64c65-8396-470c-ace2-67ab737a064b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b30ea05c-3aef-495a-a7d9-d37e64ab807a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b58e1bdb-5805-4079-842d-0a07e3b531a4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca33c75e-8cff-4305-9361-fd552c359753"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("edd9d020-4d87-41ee-8a3d-6ef07fa72564"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f3dec853-1519-4955-bfd4-235ab36512b6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("159da2bb-bb22-4292-959e-6886c5620a37"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("41671010-9380-40a6-9809-e7c66f1abc4a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("5d7c69ac-d3d7-45d4-833f-d376a04da097"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("6897caef-8f47-4a97-a4e8-1411b94f730b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("6cd73919-545c-42de-b7dc-a123399b6399"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7d7df725-5f5c-4d7b-b8ce-949f3cf78dac"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8fb3bd43-d3e8-4be8-b4b6-c657e992cbd1"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b1021c5d-ec10-4728-8108-42d8708d84d8"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b288ad6f-f214-48ab-b9cc-4e1ffea813e7"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b369ecea-0e58-44a0-9275-392d951f7c9e"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b3edf455-e826-4975-9764-d6fb631a9495"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("bfb6cd24-0bf8-4d13-8c2b-1164cb712913"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("d628949d-cf45-4dfa-b6ab-942e93b16cfb"));

            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The event's publisher unique id");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0007a562-b60b-42cf-ba9e-17be95be3267"), "Stealth" },
                    { new Guid("04d1fb77-8338-417d-91a0-26d1db1be62e"), "Action RPG" },
                    { new Guid("09c27529-6cfd-4ca7-b6b9-e1cb00e95dca"), "Strategy game" },
                    { new Guid("1bf91e49-0862-4ef8-b11a-5da89d6cf03e"), "Fighting" },
                    { new Guid("1fde522c-a48d-4ef2-ab69-3ee3ca682f4f"), "Battle Royale" },
                    { new Guid("33356524-feba-4ce0-a87c-019b7a2caf2d"), "Action-adventure" },
                    { new Guid("3b807b16-64a7-4e64-9ae1-652ccd7c1f0a"), "Adventure" },
                    { new Guid("414c692f-37fb-43c0-be7e-d1a277351d56"), "Simulation" },
                    { new Guid("547de739-b289-4a87-9020-f6315b7772f0"), "Platformer" },
                    { new Guid("8c9384a2-6b2f-4137-bfc0-84a97ae08bfe"), "First-Person Shooter" },
                    { new Guid("8d0c75e0-63d5-4ca4-82c7-ea18150d3670"), "Racing" },
                    { new Guid("8e116e58-fc30-4551-b585-e13696b04f46"), "Real-time strategy" },
                    { new Guid("90d5cc95-c4fb-48c1-b4e2-3aa953660e2e"), "Sports" },
                    { new Guid("a3de9359-c327-4391-8801-e5475cc479f0"), "Survival" },
                    { new Guid("b39ab132-e44a-4d11-843f-b2a32505eb9d"), "Action" },
                    { new Guid("c0243796-60c0-4983-a7ff-544da357095e"), "Party" },
                    { new Guid("c4a117f8-4e19-4980-a878-6f3cca65b7ea"), "RPG" },
                    { new Guid("e21ee275-ae0e-4d78-94cc-d82ca7482e61"), "Puzzle" },
                    { new Guid("f305e866-fc6d-4e16-aef5-f87e2c834e2d"), "Shooter" },
                    { new Guid("f66aa583-3dbe-481c-b78b-8ee88d5750c8"), "Casual" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ace8fa9-4275-42f7-8045-6db40c3f07b0"), "PC" },
                    { new Guid("24baaed4-7fa0-4c81-b59e-d41230f00f88"), "PlayStation 1" },
                    { new Guid("2f857239-ea2b-4c69-9723-4225a434e547"), "PlayStation Vita" },
                    { new Guid("430127f1-b1f8-4eea-8282-48c79b8a460c"), "PlayStation 3" },
                    { new Guid("55c40d4a-0e13-4585-8a4b-f618f02b8e2e"), "Game Boy" },
                    { new Guid("664e4398-b866-4263-aca9-a68de7f0a593"), "Nintendo Wii" },
                    { new Guid("6cebfc5e-e347-4319-bde8-ab94eef8be95"), "Xbox Series X" },
                    { new Guid("72ad898d-181a-40be-ae3c-70fdcbc4cd9f"), "Nintendo Switch" },
                    { new Guid("858dc6d5-59b6-434e-b5e6-1326f94acf67"), "PlayStation 4" },
                    { new Guid("86029527-bf3b-47de-8399-856ad12da41d"), "Linux" },
                    { new Guid("9317c113-3a68-4c14-827e-e471c7138f9d"), "PlayStation Portable" },
                    { new Guid("9af9321e-b4f5-4b40-82fe-0b29f1f6ec59"), "PlayStation 5" },
                    { new Guid("9f2e14f7-33fe-4c9c-ad2c-b6afccec4dd8"), "Sega Mega Drive" },
                    { new Guid("a7d0de8f-3408-4625-a524-6ffb86911a6e"), "Super Nintendo" },
                    { new Guid("ba144241-dafd-4396-9733-0e181ed7f622"), "Xbox One" },
                    { new Guid("c77ce95b-6747-4653-8832-20c00cafbd61"), "Xbox 360" },
                    { new Guid("e32cf9bd-714b-4d2f-ae1b-828caeed96d9"), "Mac" },
                    { new Guid("e4bb9354-c959-4c8b-9d6c-cfe37dbe52e7"), "Game Boy Advanced" },
                    { new Guid("ed3efda5-a570-4374-8a3a-b013f2e81aaa"), "Nintendo DS" },
                    { new Guid("ffbdbcc5-d672-4476-910c-1bda93116fa0"), "PlayStation 2" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c903066-8e6b-4f86-a401-9fe6c593b6b1"), "Bad Language" },
                    { new Guid("3bb2162e-7e52-44c2-8e8d-d26011b9e37d"), "In-Game Purchases" },
                    { new Guid("45fdf7da-0992-49df-944f-079a908ffc72"), "Fear" },
                    { new Guid("681a9d69-e435-409d-8a29-caf293f561ba"), "PEGI 7" },
                    { new Guid("69397915-4ac8-42f2-b5f2-a9b690015d3f"), "Gambling" },
                    { new Guid("844dd4bf-4ce8-4b3d-b1ff-392e05e14a9b"), "PEGI 3" },
                    { new Guid("bd24a54c-d03d-4d2d-9491-9e48b1eda672"), "PEGI 18" },
                    { new Guid("c5379622-66bf-422f-beb0-fa8f74e5d75b"), "Violence" },
                    { new Guid("cf1e834a-332c-4796-ada0-8b6caded364e"), "Drugs" },
                    { new Guid("d437ce2d-3e36-4191-9bd9-e3dfb04b54c5"), "Sex" },
                    { new Guid("d677a8bd-fa5f-4183-87e6-6f3cbc820639"), "Discrimination" },
                    { new Guid("e859b9ef-0cb1-4b2f-9513-d50bb26d2325"), "PEGI 12" },
                    { new Guid("ffc4b093-f552-4ff3-b6ea-c4e24982053b"), "PEGI 16 " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PublisherId",
                table: "Events",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_PublisherId",
                table: "Events",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_PublisherId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PublisherId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0007a562-b60b-42cf-ba9e-17be95be3267"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("04d1fb77-8338-417d-91a0-26d1db1be62e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("09c27529-6cfd-4ca7-b6b9-e1cb00e95dca"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1bf91e49-0862-4ef8-b11a-5da89d6cf03e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1fde522c-a48d-4ef2-ab69-3ee3ca682f4f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("33356524-feba-4ce0-a87c-019b7a2caf2d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3b807b16-64a7-4e64-9ae1-652ccd7c1f0a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("414c692f-37fb-43c0-be7e-d1a277351d56"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("547de739-b289-4a87-9020-f6315b7772f0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8c9384a2-6b2f-4137-bfc0-84a97ae08bfe"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8d0c75e0-63d5-4ca4-82c7-ea18150d3670"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8e116e58-fc30-4551-b585-e13696b04f46"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("90d5cc95-c4fb-48c1-b4e2-3aa953660e2e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a3de9359-c327-4391-8801-e5475cc479f0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b39ab132-e44a-4d11-843f-b2a32505eb9d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c0243796-60c0-4983-a7ff-544da357095e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c4a117f8-4e19-4980-a878-6f3cca65b7ea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e21ee275-ae0e-4d78-94cc-d82ca7482e61"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f305e866-fc6d-4e16-aef5-f87e2c834e2d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f66aa583-3dbe-481c-b78b-8ee88d5750c8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0ace8fa9-4275-42f7-8045-6db40c3f07b0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("24baaed4-7fa0-4c81-b59e-d41230f00f88"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2f857239-ea2b-4c69-9723-4225a434e547"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("430127f1-b1f8-4eea-8282-48c79b8a460c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("55c40d4a-0e13-4585-8a4b-f618f02b8e2e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("664e4398-b866-4263-aca9-a68de7f0a593"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6cebfc5e-e347-4319-bde8-ab94eef8be95"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("72ad898d-181a-40be-ae3c-70fdcbc4cd9f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("858dc6d5-59b6-434e-b5e6-1326f94acf67"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("86029527-bf3b-47de-8399-856ad12da41d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9317c113-3a68-4c14-827e-e471c7138f9d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9af9321e-b4f5-4b40-82fe-0b29f1f6ec59"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9f2e14f7-33fe-4c9c-ad2c-b6afccec4dd8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a7d0de8f-3408-4625-a524-6ffb86911a6e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ba144241-dafd-4396-9733-0e181ed7f622"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c77ce95b-6747-4653-8832-20c00cafbd61"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e32cf9bd-714b-4d2f-ae1b-828caeed96d9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e4bb9354-c959-4c8b-9d6c-cfe37dbe52e7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ed3efda5-a570-4374-8a3a-b013f2e81aaa"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ffbdbcc5-d672-4476-910c-1bda93116fa0"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0c903066-8e6b-4f86-a401-9fe6c593b6b1"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("3bb2162e-7e52-44c2-8e8d-d26011b9e37d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("45fdf7da-0992-49df-944f-079a908ffc72"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("681a9d69-e435-409d-8a29-caf293f561ba"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("69397915-4ac8-42f2-b5f2-a9b690015d3f"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("844dd4bf-4ce8-4b3d-b1ff-392e05e14a9b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("bd24a54c-d03d-4d2d-9491-9e48b1eda672"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c5379622-66bf-422f-beb0-fa8f74e5d75b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("cf1e834a-332c-4796-ada0-8b6caded364e"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("d437ce2d-3e36-4191-9bd9-e3dfb04b54c5"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("d677a8bd-fa5f-4183-87e6-6f3cbc820639"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("e859b9ef-0cb1-4b2f-9513-d50bb26d2325"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ffc4b093-f552-4ff3-b6ea-c4e24982053b"));

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Events");

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
        }
    }
}
