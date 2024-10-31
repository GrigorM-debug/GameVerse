using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedPropertyInEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05f00105-c000-4f4d-844a-e0e217ff42a2"), "Fighting" },
                    { new Guid("0fcc4505-83f6-4276-b268-d6c7ea48402c"), "Adventure" },
                    { new Guid("2e02e914-b81f-49b1-a28c-89b86066bba2"), "Action-adventure" },
                    { new Guid("33383948-7c5e-42de-aec4-14b0d18badf9"), "Casual" },
                    { new Guid("3fa27922-2c4c-49a3-a207-88d485439212"), "Shooter" },
                    { new Guid("4e82394b-88b3-4e89-9bd8-ea3fb21e5d80"), "Real-time strategy" },
                    { new Guid("5eeb30fa-a6f8-490b-9f2b-bfea886ad618"), "Strategy game" },
                    { new Guid("6b3661b7-6a7d-40f7-9ffd-b744d07f948c"), "Party" },
                    { new Guid("6eb8d501-49aa-457a-8f2d-f7dd8cb24fae"), "Puzzle" },
                    { new Guid("7e211896-510c-4797-8cee-cbc7a5239637"), "Racing" },
                    { new Guid("808dc0c0-33d3-4ea3-a05d-257148eb00d5"), "First-Person Shooter" },
                    { new Guid("8979d25a-d652-481a-ae00-e6a31389d4a5"), "Survival" },
                    { new Guid("8dc8d8e8-b283-4db2-a515-ed43ffc5a8a8"), "Simulation" },
                    { new Guid("90c4ea97-9917-433d-9d77-231633c42b7d"), "Action" },
                    { new Guid("9e148861-783e-476e-a18e-cf524424a1bc"), "Sports" },
                    { new Guid("a2141947-060d-4beb-8ad1-697d57340d13"), "Battle Royale" },
                    { new Guid("a9285727-9cd4-4305-a38a-9f3fe6cfe58f"), "Platformer" },
                    { new Guid("afc2506f-ff46-4905-95f4-56f0f96fca57"), "Action RPG" },
                    { new Guid("d7ba6ea5-48cf-4c5b-a87f-a636eb469131"), "RPG" },
                    { new Guid("de198588-5a4d-4269-80d1-5d697ee71cdb"), "Stealth" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00b8a953-990a-493a-a0f5-b1384c02f31e"), "Super Nintendo" },
                    { new Guid("078c9699-9581-464b-a447-8e33174b3711"), "Xbox 360" },
                    { new Guid("0d780e45-ff66-4bb1-922d-065dd19fdd98"), "Xbox One" },
                    { new Guid("0fd678b7-262e-46ab-823c-5d147937bba3"), "Nintendo Wii" },
                    { new Guid("135e5b8f-d55a-4860-8ccb-16ff773f919d"), "PlayStation 3" },
                    { new Guid("241e814b-2306-4778-803d-45790b963827"), "PlayStation 1" },
                    { new Guid("281e7009-76ce-4935-9f1b-7b91696412a0"), "Game Boy" },
                    { new Guid("48cc1ced-60cf-4a44-8aa2-9e94b5f16d68"), "Mac" },
                    { new Guid("49637b3c-307e-4cce-bcc8-fbcd14ed1db4"), "Xbox Series X" },
                    { new Guid("513edc3e-200d-4b14-875a-cb73e76f3d78"), "PlayStation 5" },
                    { new Guid("6a81d834-1b99-4726-8f61-73e75bd518d3"), "Nintendo Switch" },
                    { new Guid("824ec8e3-9dde-4a8a-b909-0612d57d3c3a"), "PlayStation 4" },
                    { new Guid("9f702e1b-4b91-4430-a8ec-a37ebda29401"), "Nintendo DS" },
                    { new Guid("bcf2e886-6edb-42d0-a157-c0d0eaa9605c"), "PlayStation Portable" },
                    { new Guid("befcd023-0cfa-4dae-9bbf-6c86042fe31a"), "Linux" },
                    { new Guid("ee7e4a45-6734-405a-9b5c-f6186f935c00"), "PlayStation 2" },
                    { new Guid("f1a3f414-29f0-4aee-a835-ac908c022df3"), "Sega Mega Drive" },
                    { new Guid("fabee5d4-10c2-4221-8d33-c03439b0ab62"), "PC" },
                    { new Guid("fabfe00d-b28b-409a-815f-534dad5ed744"), "Game Boy Advanced" },
                    { new Guid("fe4f4b14-920f-40ba-ae6e-42401c7a98fa"), "PlayStation Vita" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f13a236-2b47-4924-9d67-f89b93cb509c"), "Discrimination" },
                    { new Guid("1f7dcb43-6f5b-455f-a84c-d760070b4308"), "Violence" },
                    { new Guid("20ece0e4-6c0e-4cf7-8280-6fb3c59e289a"), "Gambling" },
                    { new Guid("24742a10-cc8e-4c54-899c-e6de12f60c4d"), "PEGI 18" },
                    { new Guid("29ba9307-271f-455a-a1cc-21fdc5c22d86"), "Bad Language" },
                    { new Guid("35f8cc66-3afa-40de-bfdf-d6313db979bb"), "Drugs" },
                    { new Guid("4431e1a5-9e75-4916-9fcd-0a29e3ee27af"), "PEGI 7" },
                    { new Guid("787c3b96-eedf-446b-bef7-de1694f35f15"), "PEGI 16 " },
                    { new Guid("899089c2-5f4b-4c4b-a0c7-e5483d734d99"), "PEGI 12" },
                    { new Guid("9c9eab4f-ce67-4271-8fdd-eb4367c948f8"), "Sex" },
                    { new Guid("e942d451-dbc9-4366-ae68-0a1f1d43eacc"), "In-Game Purchases" },
                    { new Guid("eb4b39fc-c55c-49f0-8ab2-c66fee41fe14"), "PEGI 3" },
                    { new Guid("fcc5c4ec-518f-432f-bdfb-1025bc3acc55"), "Fear" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("05f00105-c000-4f4d-844a-e0e217ff42a2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0fcc4505-83f6-4276-b268-d6c7ea48402c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2e02e914-b81f-49b1-a28c-89b86066bba2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("33383948-7c5e-42de-aec4-14b0d18badf9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3fa27922-2c4c-49a3-a207-88d485439212"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4e82394b-88b3-4e89-9bd8-ea3fb21e5d80"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5eeb30fa-a6f8-490b-9f2b-bfea886ad618"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6b3661b7-6a7d-40f7-9ffd-b744d07f948c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6eb8d501-49aa-457a-8f2d-f7dd8cb24fae"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7e211896-510c-4797-8cee-cbc7a5239637"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("808dc0c0-33d3-4ea3-a05d-257148eb00d5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8979d25a-d652-481a-ae00-e6a31389d4a5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8dc8d8e8-b283-4db2-a515-ed43ffc5a8a8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("90c4ea97-9917-433d-9d77-231633c42b7d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9e148861-783e-476e-a18e-cf524424a1bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a2141947-060d-4beb-8ad1-697d57340d13"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a9285727-9cd4-4305-a38a-9f3fe6cfe58f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("afc2506f-ff46-4905-95f4-56f0f96fca57"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d7ba6ea5-48cf-4c5b-a87f-a636eb469131"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("de198588-5a4d-4269-80d1-5d697ee71cdb"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("00b8a953-990a-493a-a0f5-b1384c02f31e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("078c9699-9581-464b-a447-8e33174b3711"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0d780e45-ff66-4bb1-922d-065dd19fdd98"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0fd678b7-262e-46ab-823c-5d147937bba3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("135e5b8f-d55a-4860-8ccb-16ff773f919d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("241e814b-2306-4778-803d-45790b963827"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("281e7009-76ce-4935-9f1b-7b91696412a0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("48cc1ced-60cf-4a44-8aa2-9e94b5f16d68"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("49637b3c-307e-4cce-bcc8-fbcd14ed1db4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("513edc3e-200d-4b14-875a-cb73e76f3d78"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6a81d834-1b99-4726-8f61-73e75bd518d3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("824ec8e3-9dde-4a8a-b909-0612d57d3c3a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9f702e1b-4b91-4430-a8ec-a37ebda29401"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("bcf2e886-6edb-42d0-a157-c0d0eaa9605c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("befcd023-0cfa-4dae-9bbf-6c86042fe31a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ee7e4a45-6734-405a-9b5c-f6186f935c00"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f1a3f414-29f0-4aee-a835-ac908c022df3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fabee5d4-10c2-4221-8d33-c03439b0ab62"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fabfe00d-b28b-409a-815f-534dad5ed744"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fe4f4b14-920f-40ba-ae6e-42401c7a98fa"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0f13a236-2b47-4924-9d67-f89b93cb509c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("1f7dcb43-6f5b-455f-a84c-d760070b4308"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("20ece0e4-6c0e-4cf7-8280-6fb3c59e289a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("24742a10-cc8e-4c54-899c-e6de12f60c4d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("29ba9307-271f-455a-a1cc-21fdc5c22d86"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("35f8cc66-3afa-40de-bfdf-d6313db979bb"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("4431e1a5-9e75-4916-9fcd-0a29e3ee27af"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("787c3b96-eedf-446b-bef7-de1694f35f15"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("899089c2-5f4b-4c4b-a0c7-e5483d734d99"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9c9eab4f-ce67-4271-8fdd-eb4367c948f8"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("e942d451-dbc9-4366-ae68-0a1f1d43eacc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("eb4b39fc-c55c-49f0-8ab2-c66fee41fe14"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("fcc5c4ec-518f-432f-bdfb-1025bc3acc55"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Events");

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
        }
    }
}
