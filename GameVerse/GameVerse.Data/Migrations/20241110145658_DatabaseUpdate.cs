using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_ParticipantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_BuyerId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GamesUsersCompleted");

            migrationBuilder.DropTable(
                name: "GamesUsersCurrentlyPlaying");

            migrationBuilder.DropTable(
                name: "GameUserWishlists");

            migrationBuilder.DropIndex(
                name: "IX_Games_BuyerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Events_ParticipantId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1f1f041c-0d3f-4129-9786-9e512ff8dd2e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2b51cb10-fc8c-451f-be6d-1e1e6b5c6f6b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3670fd26-416b-4861-a40e-f79eaa302738"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("539bdd64-0254-48ec-96a3-380fa77892fe"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("59938758-c7fd-415a-a6c6-d29125b44905"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7aec9fe0-98e6-42a8-b257-c4fb27a735c9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("828af93b-2ddc-4aa4-a339-23515f679155"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("832224b9-4be8-4376-a97c-06be783a97d1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8ff2a777-4c7d-4e61-a12d-76fee3ae6966"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("90db7c19-754b-4f3d-9995-dfd920c1867e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9d5dc154-7f02-4557-b41e-ac5e44e5d096"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a44aa10b-e88f-4228-b64d-cdaf1cd73d9f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b963ee5f-f9a9-4e94-8a45-062ab12f2801"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ba3b12b3-68bf-4d16-a7d3-ee06d179eb19"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c3e3bab7-189c-4912-b084-489435bff10c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c4cad2e6-1163-4a0a-93ad-3eafb8477009"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cf65c644-5bba-4db3-bb3f-d4c00d641d06"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cfc02970-8ba2-4d6f-ab99-19930fbabbfa"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ed76c77a-e62f-435d-9155-8117d4206452"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fd12adef-8e19-4e51-8ac2-10140f4281f0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("09ba3485-57c8-447c-b9bf-c4d1f1f9c188"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("11a05741-9826-48f7-84b4-7a396176ffb3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("27cbfbf6-2da9-42b4-8701-2f743752234e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2f071061-295c-4c37-964c-c419a996ec9a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3f62de1a-820b-41cf-8f15-8208ba3a1cfd"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4b3ac231-0bab-4a9c-b678-1f51469f557d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("5c4bbf5b-1701-49b4-8797-b1db7b15c56c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("76d39400-53b2-4e1b-9efe-ab5a2cf00a55"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7e6ea11c-c26e-4d83-800d-8bc4d95379f0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8101f54b-80d1-4018-bf9b-182efde5d41c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("929c7be7-9bca-44d9-92cf-12f82a30c7e0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("938550fd-bd98-4666-b279-e6d6bef44f60"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("977899a9-7ce1-4f09-b6d6-fe73fc4c2466"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a8a551ff-4199-4358-bfa0-420f63d4ed79"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b06bdb8e-16f2-46dc-8d18-0d08d064641f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b3df4eae-3fbc-40cd-bdf2-42df969827b7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b4fd7bcf-df43-4b8c-b37a-6801491bdac2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c3d8f5e0-5105-49da-adde-414d9d4d9e3e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("d1dad50b-bab9-45dd-95f0-5280f8ffb400"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fd518716-ca99-4d3b-8096-594db826e3b1"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("018a1bcc-5c98-496e-b9e9-136c66d9a5ae"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0e012237-23e3-41a6-97e9-6e2c7b142c21"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("32a79bd1-39ce-4853-bed1-cc08a42dc3d9"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("599b7a00-854b-44e3-87d6-f57cd0ed4e61"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("740c2a63-a242-4a9e-854a-08cad82a0448"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("788d61d0-70f8-41af-9354-a1ae17106946"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7cf4eaac-52c9-4d0c-8f4b-6b9043550ed2"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("99edbf19-f8f3-4876-9e91-6d59bf2a454b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c067a59b-9b60-4ed8-9bb7-055a1f54d465"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("d5268419-cbeb-49b5-adf5-559febc2888e"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("db6a6f8b-5956-4af8-aa8e-36c143e4062a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("e0734304-a71f-41fe-9bfc-6349fbc0463f"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ecab5dd0-7609-41db-90f6-20942905cd65"));

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Carts");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "GamesCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "EventsCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventsCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "UserBoughtGames",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoughtOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoughtGames", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserBoughtGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserBoughtGames_Games_GameId",
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
                    { new Guid("021a02fa-9127-4147-9284-7ce3df10f38e"), "Adventure" },
                    { new Guid("0d8e11be-199e-4bc4-98fd-66dfb4bfb907"), "RPG" },
                    { new Guid("1e6eed83-371d-4106-98c0-6463470b19cf"), "Simulation" },
                    { new Guid("2a611bcb-4726-43fd-b524-55e76070510d"), "Real-time strategy" },
                    { new Guid("40a797bf-9bb5-42e3-b55b-3190a9ff9101"), "Sports" },
                    { new Guid("496d9cb9-acdb-4ede-ad8f-58e19ad612a8"), "Action RPG" },
                    { new Guid("49bde3f2-1a54-4bfe-973c-3be9c636bfd4"), "Survival" },
                    { new Guid("4d34cd9b-6299-45e0-a664-a310f57bdfdb"), "Racing" },
                    { new Guid("51e2e3f3-99a6-4568-9cd2-caf520f892c5"), "First-Person Shooter" },
                    { new Guid("6038380a-4667-415c-9c95-f1efb2cac3f1"), "Action-adventure" },
                    { new Guid("82384a87-023c-437c-af47-2bd975cd6873"), "Platformer" },
                    { new Guid("922a5a07-feaf-4d38-9aa2-9c8e331dedf2"), "Stealth" },
                    { new Guid("93884e99-bdbf-49f2-b1e3-89f061f56c17"), "Fighting" },
                    { new Guid("b50f7940-a0a9-4549-9937-0724dc236e3c"), "Party" },
                    { new Guid("bf089794-b88e-48cc-9374-64dba299a7c3"), "Casual" },
                    { new Guid("cd549c89-673c-48a5-8cd9-7c898e652183"), "Battle Royale" },
                    { new Guid("dadf0817-2adf-423c-bad7-b50f3728104e"), "Shooter" },
                    { new Guid("f0801154-09da-4fbe-90de-ab37c9968fa6"), "Strategy game" },
                    { new Guid("f173c537-f06a-41b3-aa14-6228bbec03c7"), "Puzzle" },
                    { new Guid("f1d06f1f-d27a-49b9-a8f9-67d6956af804"), "Action" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13dd27ce-3234-4d34-86d4-8ffeb6bc2ec5"), "Sega Mega Drive" },
                    { new Guid("2d48c7a6-4dd6-45fb-9169-70cfc402cb39"), "PlayStation 2" },
                    { new Guid("429dd553-70ea-4ed0-a8f6-37a7f61277d7"), "Nintendo Wii" },
                    { new Guid("473963dc-bf3d-418e-a886-e054e042f230"), "Game Boy" },
                    { new Guid("4cc69470-b761-493d-9f7e-53c497d8cc88"), "Super Nintendo" },
                    { new Guid("52c8dc7e-18c7-44a3-bb57-4e7e77bf5fdd"), "Xbox Series X" },
                    { new Guid("545c71d9-f093-4a4d-9253-c83ac8c5a558"), "Xbox One" },
                    { new Guid("56adb7e7-fed0-42ad-9dd3-74ad2f3e36af"), "PlayStation Vita" },
                    { new Guid("603e194f-0d2f-495f-846e-770964b48355"), "PlayStation 4" },
                    { new Guid("63169dda-ff4b-40df-a019-b8ecefbb108d"), "Xbox 360" },
                    { new Guid("71bbfc35-71a2-4a76-89d2-1772890d780e"), "PC" },
                    { new Guid("83e71586-a302-4ce6-b987-459ab06390a5"), "PlayStation 5" },
                    { new Guid("91dff5d1-6a40-40ba-b20a-baaa58fd373f"), "PlayStation Portable" },
                    { new Guid("98965174-931f-4129-8bb9-abc6fa2213cc"), "Mac" },
                    { new Guid("a0e1b369-8f57-47b3-8438-97fec8b1c63f"), "PlayStation 3" },
                    { new Guid("a564545d-f0d3-42b8-8c0f-4598d63e5946"), "Nintendo Switch" },
                    { new Guid("c1f8067e-bb4e-4846-bf93-55b3e68897cf"), "PlayStation 1" },
                    { new Guid("f585ab08-94ba-49a0-807e-47dad8f56139"), "Game Boy Advanced" },
                    { new Guid("fe7edfff-32c7-476f-b74a-17dd2df72238"), "Linux" },
                    { new Guid("ff8da72d-3644-441b-a7cd-828d3b976124"), "Nintendo DS" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("288390eb-bee2-4aaa-99a1-30e9d0728b23"), "PEGI 16 " },
                    { new Guid("34c4cc58-3dad-4ae2-89f2-7b4c32446778"), "Violence" },
                    { new Guid("46fb6313-b685-48a5-a31c-c34f893ea668"), "Drugs" },
                    { new Guid("6a95299f-88c7-4631-b27e-96554f6a0d5c"), "Bad Language" },
                    { new Guid("766f9444-30e6-417a-b25e-fc68ca5da0a4"), "Gambling" },
                    { new Guid("85bfab37-b894-4f86-9991-6b35de2596fc"), "PEGI 7" },
                    { new Guid("8cdcfdf8-457b-450f-9eed-1f55f3a8875f"), "In-Game Purchases" },
                    { new Guid("8dc82b7a-977b-4b6f-a388-d084761ba99a"), "PEGI 12" },
                    { new Guid("92f47502-eba2-48f3-8e3b-130b9908b822"), "PEGI 3" },
                    { new Guid("93ddee36-ee8e-48dd-8f8c-cebe76318db7"), "Sex" },
                    { new Guid("b14e132a-4089-40c4-be03-bcb4b7db89eb"), "PEGI 18" },
                    { new Guid("c178d71e-8b2b-457f-969e-3df022d14875"), "Discrimination" },
                    { new Guid("cb6458b8-c247-429b-b4a0-27c2b1ef83b3"), "Fear" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBoughtGames_UserId",
                table: "UserBoughtGames",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBoughtGames");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("021a02fa-9127-4147-9284-7ce3df10f38e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0d8e11be-199e-4bc4-98fd-66dfb4bfb907"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1e6eed83-371d-4106-98c0-6463470b19cf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2a611bcb-4726-43fd-b524-55e76070510d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("40a797bf-9bb5-42e3-b55b-3190a9ff9101"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("496d9cb9-acdb-4ede-ad8f-58e19ad612a8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("49bde3f2-1a54-4bfe-973c-3be9c636bfd4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4d34cd9b-6299-45e0-a664-a310f57bdfdb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("51e2e3f3-99a6-4568-9cd2-caf520f892c5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6038380a-4667-415c-9c95-f1efb2cac3f1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("82384a87-023c-437c-af47-2bd975cd6873"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("922a5a07-feaf-4d38-9aa2-9c8e331dedf2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("93884e99-bdbf-49f2-b1e3-89f061f56c17"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b50f7940-a0a9-4549-9937-0724dc236e3c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bf089794-b88e-48cc-9374-64dba299a7c3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cd549c89-673c-48a5-8cd9-7c898e652183"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("dadf0817-2adf-423c-bad7-b50f3728104e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f0801154-09da-4fbe-90de-ab37c9968fa6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f173c537-f06a-41b3-aa14-6228bbec03c7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f1d06f1f-d27a-49b9-a8f9-67d6956af804"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("13dd27ce-3234-4d34-86d4-8ffeb6bc2ec5"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2d48c7a6-4dd6-45fb-9169-70cfc402cb39"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("429dd553-70ea-4ed0-a8f6-37a7f61277d7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("473963dc-bf3d-418e-a886-e054e042f230"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4cc69470-b761-493d-9f7e-53c497d8cc88"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("52c8dc7e-18c7-44a3-bb57-4e7e77bf5fdd"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("545c71d9-f093-4a4d-9253-c83ac8c5a558"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("56adb7e7-fed0-42ad-9dd3-74ad2f3e36af"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("603e194f-0d2f-495f-846e-770964b48355"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("63169dda-ff4b-40df-a019-b8ecefbb108d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("71bbfc35-71a2-4a76-89d2-1772890d780e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("83e71586-a302-4ce6-b987-459ab06390a5"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("91dff5d1-6a40-40ba-b20a-baaa58fd373f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("98965174-931f-4129-8bb9-abc6fa2213cc"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a0e1b369-8f57-47b3-8438-97fec8b1c63f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a564545d-f0d3-42b8-8c0f-4598d63e5946"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c1f8067e-bb4e-4846-bf93-55b3e68897cf"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f585ab08-94ba-49a0-807e-47dad8f56139"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fe7edfff-32c7-476f-b74a-17dd2df72238"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ff8da72d-3644-441b-a7cd-828d3b976124"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("288390eb-bee2-4aaa-99a1-30e9d0728b23"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("34c4cc58-3dad-4ae2-89f2-7b4c32446778"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("46fb6313-b685-48a5-a31c-c34f893ea668"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("6a95299f-88c7-4631-b27e-96554f6a0d5c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("766f9444-30e6-417a-b25e-fc68ca5da0a4"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("85bfab37-b894-4f86-9991-6b35de2596fc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8cdcfdf8-457b-450f-9eed-1f55f3a8875f"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8dc82b7a-977b-4b6f-a388-d084761ba99a"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("92f47502-eba2-48f3-8e3b-130b9908b822"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("93ddee36-ee8e-48dd-8f8c-cebe76318db7"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b14e132a-4089-40c4-be03-bcb4b7db89eb"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c178d71e-8b2b-457f-969e-3df022d14875"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("cb6458b8-c247-429b-b4a0-27c2b1ef83b3"));

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "GamesCarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesCarts");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "EventsCarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventsCarts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Games",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The game buyer unique identifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The user that bought ticket for the event");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesUsersCompleted_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesUsersCurrentlyPlaying_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserWishlists_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f1f041c-0d3f-4129-9786-9e512ff8dd2e"), "Party" },
                    { new Guid("2b51cb10-fc8c-451f-be6d-1e1e6b5c6f6b"), "Action" },
                    { new Guid("3670fd26-416b-4861-a40e-f79eaa302738"), "RPG" },
                    { new Guid("539bdd64-0254-48ec-96a3-380fa77892fe"), "Action RPG" },
                    { new Guid("59938758-c7fd-415a-a6c6-d29125b44905"), "Shooter" },
                    { new Guid("7aec9fe0-98e6-42a8-b257-c4fb27a735c9"), "Platformer" },
                    { new Guid("828af93b-2ddc-4aa4-a339-23515f679155"), "Sports" },
                    { new Guid("832224b9-4be8-4376-a97c-06be783a97d1"), "First-Person Shooter" },
                    { new Guid("8ff2a777-4c7d-4e61-a12d-76fee3ae6966"), "Battle Royale" },
                    { new Guid("90db7c19-754b-4f3d-9995-dfd920c1867e"), "Fighting" },
                    { new Guid("9d5dc154-7f02-4557-b41e-ac5e44e5d096"), "Real-time strategy" },
                    { new Guid("a44aa10b-e88f-4228-b64d-cdaf1cd73d9f"), "Stealth" },
                    { new Guid("b963ee5f-f9a9-4e94-8a45-062ab12f2801"), "Survival" },
                    { new Guid("ba3b12b3-68bf-4d16-a7d3-ee06d179eb19"), "Casual" },
                    { new Guid("c3e3bab7-189c-4912-b084-489435bff10c"), "Simulation" },
                    { new Guid("c4cad2e6-1163-4a0a-93ad-3eafb8477009"), "Strategy game" },
                    { new Guid("cf65c644-5bba-4db3-bb3f-d4c00d641d06"), "Racing" },
                    { new Guid("cfc02970-8ba2-4d6f-ab99-19930fbabbfa"), "Puzzle" },
                    { new Guid("ed76c77a-e62f-435d-9155-8117d4206452"), "Adventure" },
                    { new Guid("fd12adef-8e19-4e51-8ac2-10140f4281f0"), "Action-adventure" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09ba3485-57c8-447c-b9bf-c4d1f1f9c188"), "Nintendo DS" },
                    { new Guid("11a05741-9826-48f7-84b4-7a396176ffb3"), "Linux" },
                    { new Guid("27cbfbf6-2da9-42b4-8701-2f743752234e"), "Xbox Series X" },
                    { new Guid("2f071061-295c-4c37-964c-c419a996ec9a"), "PlayStation 5" },
                    { new Guid("3f62de1a-820b-41cf-8f15-8208ba3a1cfd"), "Game Boy Advanced" },
                    { new Guid("4b3ac231-0bab-4a9c-b678-1f51469f557d"), "PlayStation Portable" },
                    { new Guid("5c4bbf5b-1701-49b4-8797-b1db7b15c56c"), "PlayStation Vita" },
                    { new Guid("76d39400-53b2-4e1b-9efe-ab5a2cf00a55"), "PlayStation 1" },
                    { new Guid("7e6ea11c-c26e-4d83-800d-8bc4d95379f0"), "Nintendo Wii" },
                    { new Guid("8101f54b-80d1-4018-bf9b-182efde5d41c"), "Xbox 360" },
                    { new Guid("929c7be7-9bca-44d9-92cf-12f82a30c7e0"), "Game Boy" },
                    { new Guid("938550fd-bd98-4666-b279-e6d6bef44f60"), "Mac" },
                    { new Guid("977899a9-7ce1-4f09-b6d6-fe73fc4c2466"), "PlayStation 4" },
                    { new Guid("a8a551ff-4199-4358-bfa0-420f63d4ed79"), "Xbox One" },
                    { new Guid("b06bdb8e-16f2-46dc-8d18-0d08d064641f"), "Sega Mega Drive" },
                    { new Guid("b3df4eae-3fbc-40cd-bdf2-42df969827b7"), "Super Nintendo" },
                    { new Guid("b4fd7bcf-df43-4b8c-b37a-6801491bdac2"), "PC" },
                    { new Guid("c3d8f5e0-5105-49da-adde-414d9d4d9e3e"), "PlayStation 3" },
                    { new Guid("d1dad50b-bab9-45dd-95f0-5280f8ffb400"), "Nintendo Switch" },
                    { new Guid("fd518716-ca99-4d3b-8096-594db826e3b1"), "PlayStation 2" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("018a1bcc-5c98-496e-b9e9-136c66d9a5ae"), "Sex" },
                    { new Guid("0e012237-23e3-41a6-97e9-6e2c7b142c21"), "PEGI 3" },
                    { new Guid("32a79bd1-39ce-4853-bed1-cc08a42dc3d9"), "PEGI 16 " },
                    { new Guid("599b7a00-854b-44e3-87d6-f57cd0ed4e61"), "Fear" },
                    { new Guid("740c2a63-a242-4a9e-854a-08cad82a0448"), "PEGI 12" },
                    { new Guid("788d61d0-70f8-41af-9354-a1ae17106946"), "PEGI 18" },
                    { new Guid("7cf4eaac-52c9-4d0c-8f4b-6b9043550ed2"), "Gambling" },
                    { new Guid("99edbf19-f8f3-4876-9e91-6d59bf2a454b"), "Drugs" },
                    { new Guid("c067a59b-9b60-4ed8-9bb7-055a1f54d465"), "Bad Language" },
                    { new Guid("d5268419-cbeb-49b5-adf5-559febc2888e"), "In-Game Purchases" },
                    { new Guid("db6a6f8b-5956-4af8-aa8e-36c143e4062a"), "PEGI 7" },
                    { new Guid("e0734304-a71f-41fe-9bfc-6349fbc0463f"), "Discrimination" },
                    { new Guid("ecab5dd0-7609-41db-90f6-20942905cd65"), "Violence" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_BuyerId",
                table: "Games",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParticipantId",
                table: "Events",
                column: "ParticipantId");

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
        }
    }
}
