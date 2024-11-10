using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTotalPricePropertyInGameCartAndEventCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TotalPrice",
                table: "GamesCarts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "EventsCarts");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03ac0783-0a08-4bd9-8f17-aa606fbc017a"), "Party" },
                    { new Guid("08f366d9-75d0-43da-977b-c5e19c872021"), "Action RPG" },
                    { new Guid("2718f78a-37ca-4765-8e22-d3c832a31516"), "Casual" },
                    { new Guid("3c0e6583-e6c7-4e42-9fa3-78a3332f1db7"), "First-Person Shooter" },
                    { new Guid("3f13a323-70f6-4d1a-ab7e-046090c140ff"), "Real-time strategy" },
                    { new Guid("514f04c3-4625-467e-bca5-0018b1f14cc2"), "Puzzle" },
                    { new Guid("67618717-aeba-4804-9757-6f8bcf34c865"), "Stealth" },
                    { new Guid("693e0f48-c26b-469b-b894-5fa4dbcb7473"), "Strategy game" },
                    { new Guid("7451f8f4-f4ee-4d31-830e-620927d9e91b"), "Racing" },
                    { new Guid("85e24bfb-59f0-4e1a-b3a9-d88d15c7f878"), "Action" },
                    { new Guid("88f554d1-bbf0-4af4-9df7-a81a7c0efd8c"), "Platformer" },
                    { new Guid("9028e96d-45aa-4287-a890-c21f398acfe0"), "Adventure" },
                    { new Guid("a08579ea-6a7e-44e4-bdb3-1d2a9fe8f5ca"), "RPG" },
                    { new Guid("a45723f6-e16a-4491-8977-28602fcf500c"), "Shooter" },
                    { new Guid("a7a3fae6-8687-4eea-a6a2-2d80a33c207b"), "Simulation" },
                    { new Guid("abde9f2d-2338-4e30-afc2-7bdac1609892"), "Battle Royale" },
                    { new Guid("b9a367b1-d35b-41ca-89b0-6b67d1207597"), "Action-adventure" },
                    { new Guid("bec9eeef-d0b2-4b1d-bb81-3c26b2f8fbf4"), "Survival" },
                    { new Guid("d074840f-bfd4-4f32-ae53-c0664160be8b"), "Sports" },
                    { new Guid("e182e831-74f0-43ed-9cc9-f9d544725d4f"), "Fighting" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13490717-1b40-42ee-be1a-b52374fd37a9"), "PlayStation 5" },
                    { new Guid("1469192f-864a-4236-8e49-be17136ee69f"), "Xbox 360" },
                    { new Guid("1fb01658-393a-4ef4-8eea-b9ce3ea2abce"), "PlayStation Vita" },
                    { new Guid("2a7fe431-61f4-48a5-b033-d54317670ebe"), "Game Boy Advanced" },
                    { new Guid("4745cec9-1948-400c-9814-28b920303e33"), "Mac" },
                    { new Guid("5275e25b-d02f-45b7-9be6-2e7e11aa427a"), "Nintendo Wii" },
                    { new Guid("5afa5b4d-f307-4226-8a10-462fb21ae54b"), "Xbox Series X" },
                    { new Guid("6d24cddf-0fe8-4f55-8918-f03d9f61dbad"), "PlayStation 3" },
                    { new Guid("7976282f-6517-43bd-aecb-01a8fa5623bc"), "Super Nintendo" },
                    { new Guid("7d2305de-5271-48cf-96e0-b6d920cdacbc"), "Linux" },
                    { new Guid("817ab59b-4b50-4b94-a7db-b2d90914fdc8"), "Nintendo Switch" },
                    { new Guid("879c6694-ad40-4fc4-b507-e87f8dee434f"), "PlayStation Portable" },
                    { new Guid("9df6d2c8-c460-4700-ae48-ff09723242da"), "PlayStation 4" },
                    { new Guid("c565845c-08ab-4feb-b7cc-fad630735ab8"), "PC" },
                    { new Guid("d083eb0b-2d60-4ab2-af57-4190f1d9aa30"), "Game Boy" },
                    { new Guid("e10ca5d5-bbf7-49f7-b832-4827207741d4"), "PlayStation 2" },
                    { new Guid("e8039323-0431-46bc-8992-67d1e6d65295"), "Sega Mega Drive" },
                    { new Guid("f9ff55c1-c2a8-41bc-b155-8b3f637f9ccb"), "Xbox One" },
                    { new Guid("fe2c0f1f-1353-4ac6-b354-0be906cd6ff7"), "Nintendo DS" },
                    { new Guid("ff4921e3-34d1-44fa-b36c-05feb00d22c6"), "PlayStation 1" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("194f34b5-acc9-437e-9b94-acfd396b6a55"), "PEGI 3" },
                    { new Guid("20827825-3a74-4950-be85-74ea9cf7d6a5"), "PEGI 18" },
                    { new Guid("3701649d-0fc6-46df-b061-cca3341b6e79"), "PEGI 12" },
                    { new Guid("5964e70a-bcd3-4311-ae39-a1ff1b44d966"), "Bad Language" },
                    { new Guid("5de67ffd-6676-4faf-b6cc-7f0c501f532c"), "PEGI 7" },
                    { new Guid("7854dd0e-0c78-4ad1-92b6-ec81ebae4717"), "Drugs" },
                    { new Guid("82d291aa-23a1-4130-8e4b-40956d3a8aef"), "Fear" },
                    { new Guid("86f487af-8dee-4abb-b246-ca91bc0d75ca"), "PEGI 16 " },
                    { new Guid("ce8e6eb9-33ec-46e5-80e1-15041a330574"), "In-Game Purchases" },
                    { new Guid("e00b61eb-c1dc-4264-98ef-4a71eca07eed"), "Sex" },
                    { new Guid("eaef0c16-6da2-4433-9512-a91a24fae85d"), "Discrimination" },
                    { new Guid("f61b481a-ae59-452b-a580-7e8755b687ff"), "Violence" },
                    { new Guid("facc2326-7628-449f-93eb-64bf485c8ec8"), "Gambling" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("03ac0783-0a08-4bd9-8f17-aa606fbc017a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("08f366d9-75d0-43da-977b-c5e19c872021"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2718f78a-37ca-4765-8e22-d3c832a31516"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3c0e6583-e6c7-4e42-9fa3-78a3332f1db7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3f13a323-70f6-4d1a-ab7e-046090c140ff"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("514f04c3-4625-467e-bca5-0018b1f14cc2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("67618717-aeba-4804-9757-6f8bcf34c865"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("693e0f48-c26b-469b-b894-5fa4dbcb7473"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7451f8f4-f4ee-4d31-830e-620927d9e91b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("85e24bfb-59f0-4e1a-b3a9-d88d15c7f878"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("88f554d1-bbf0-4af4-9df7-a81a7c0efd8c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9028e96d-45aa-4287-a890-c21f398acfe0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a08579ea-6a7e-44e4-bdb3-1d2a9fe8f5ca"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a45723f6-e16a-4491-8977-28602fcf500c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a7a3fae6-8687-4eea-a6a2-2d80a33c207b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("abde9f2d-2338-4e30-afc2-7bdac1609892"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b9a367b1-d35b-41ca-89b0-6b67d1207597"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bec9eeef-d0b2-4b1d-bb81-3c26b2f8fbf4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d074840f-bfd4-4f32-ae53-c0664160be8b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e182e831-74f0-43ed-9cc9-f9d544725d4f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("13490717-1b40-42ee-be1a-b52374fd37a9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1469192f-864a-4236-8e49-be17136ee69f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1fb01658-393a-4ef4-8eea-b9ce3ea2abce"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2a7fe431-61f4-48a5-b033-d54317670ebe"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("4745cec9-1948-400c-9814-28b920303e33"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("5275e25b-d02f-45b7-9be6-2e7e11aa427a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("5afa5b4d-f307-4226-8a10-462fb21ae54b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6d24cddf-0fe8-4f55-8918-f03d9f61dbad"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7976282f-6517-43bd-aecb-01a8fa5623bc"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7d2305de-5271-48cf-96e0-b6d920cdacbc"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("817ab59b-4b50-4b94-a7db-b2d90914fdc8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("879c6694-ad40-4fc4-b507-e87f8dee434f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9df6d2c8-c460-4700-ae48-ff09723242da"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c565845c-08ab-4feb-b7cc-fad630735ab8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("d083eb0b-2d60-4ab2-af57-4190f1d9aa30"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e10ca5d5-bbf7-49f7-b832-4827207741d4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e8039323-0431-46bc-8992-67d1e6d65295"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f9ff55c1-c2a8-41bc-b155-8b3f637f9ccb"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("fe2c0f1f-1353-4ac6-b354-0be906cd6ff7"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ff4921e3-34d1-44fa-b36c-05feb00d22c6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("194f34b5-acc9-437e-9b94-acfd396b6a55"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("20827825-3a74-4950-be85-74ea9cf7d6a5"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("3701649d-0fc6-46df-b061-cca3341b6e79"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("5964e70a-bcd3-4311-ae39-a1ff1b44d966"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("5de67ffd-6676-4faf-b6cc-7f0c501f532c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7854dd0e-0c78-4ad1-92b6-ec81ebae4717"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("82d291aa-23a1-4130-8e4b-40956d3a8aef"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("86f487af-8dee-4abb-b246-ca91bc0d75ca"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ce8e6eb9-33ec-46e5-80e1-15041a330574"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("e00b61eb-c1dc-4264-98ef-4a71eca07eed"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("eaef0c16-6da2-4433-9512-a91a24fae85d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("f61b481a-ae59-452b-a580-7e8755b687ff"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("facc2326-7628-449f-93eb-64bf485c8ec8"));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "GamesCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "EventsCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
        }
    }
}
