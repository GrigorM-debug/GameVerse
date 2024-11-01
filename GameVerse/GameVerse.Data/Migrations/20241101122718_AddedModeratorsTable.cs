using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedModeratorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_PublisherId",
                table: "Events");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moderators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParticipantId",
                table: "Events",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_UserId",
                table: "Moderators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Moderators_PublisherId",
                table: "Events",
                column: "PublisherId",
                principalTable: "Moderators",
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
                name: "FK_Events_Moderators_PublisherId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropIndex(
                name: "IX_Events_ParticipantId",
                table: "Events");

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

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Events");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_PublisherId",
                table: "Events",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
