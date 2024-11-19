using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertiesInUserBoughtGamesAndEventRegistarionsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserBoughtGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketQuantity",
                table: "EventsRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1be8cd6a-3107-4601-b591-86129b8f7a80"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("245bb3c6-316a-403f-9435-dcfad447c8b2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2b69cc04-51a7-4b31-a1ab-5c48fd20d8bc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2fb908b5-69da-4ce2-8d29-d5b9215dcc02"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3d8fc619-a6c2-4d51-8753-4a536b74488f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("58b48cb0-9ce3-43ed-9c9a-31a9e78c7cbb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("719cfc72-73ef-442a-8e15-824e195e25d6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("775c3938-ac0b-4342-838e-986c0ab4f3e5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7b4cd394-1f50-45b8-aa47-bc5ba411696e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a2f16373-a111-4567-97b5-a5b08f87bf1a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b75958f4-2aca-4779-8c4a-a83fb1d8bf56"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("be5837a8-242f-4fe6-930c-1f7cf2f87867"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c23d5276-97af-47a9-872b-5f703eabe469"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c585b17d-4d4a-4938-b7f7-c73fdd8d6252"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ce0709a4-9bc6-41cd-a16e-9498e6c6c620"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d54bfee5-8784-40b3-b5e3-e1bed08b0503"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e39ca8bb-5af7-43f3-996e-6a23cd4613d8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e80e5f8e-1a60-446e-b1ff-234f685abb17"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ef18a665-27e2-4e44-950c-bb900da07f80"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f62dee2d-7edc-4697-a944-497392958cb8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("01477c90-9056-472c-99db-8254ac348d4d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("053ddee5-66ae-4b33-af05-b629264ea5bb"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("07720321-c28a-4643-a40d-078a27bf5029"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1cef75ca-d4b8-4166-9a7e-6fd244282ccc"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("22b1ec9c-bd92-41ed-bd73-eea6fd85a160"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3d4ca656-11ba-440f-8fa3-925de88b2eda"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("530c3a7c-eec4-46c1-8227-3621272aaa80"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6b59b544-1d92-4b83-bb24-9fc94dc8b86b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("74ae565f-0b4e-4673-abef-8056e13ed454"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("788955f1-8861-4aa7-8818-e906cb82d4ce"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7b47ec42-2935-44a4-a12d-14191b182c77"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8afa01bc-1d82-4e32-b89c-670b94614156"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a4c82b28-50c4-49d8-a482-6c879c0930a9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a9a88c43-af15-42d1-9924-1574112cefce"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c6d3e81e-da86-4224-a274-00cc0c812d17"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("dbe3f502-53ca-44ec-8f00-f7b125c62af5"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f17b81a3-252c-4e95-9a3a-bfd9f3f1a0a1"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f2efb391-8dc2-4bc7-b270-2ae5098c1298"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f3f89a78-df0b-444b-a5af-01f2c2c92a17"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f9de5879-8142-41cd-b950-9fe2938b46cc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("495e41a6-476c-4225-9f9a-508fbd1c5cc8"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("4964ee10-3997-4185-a8d2-e253a7f7c961"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("62202469-2ca1-460d-9ec6-240793e82644"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("84f9f133-7a17-420a-b18c-861babfce9d6"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("93a896e7-d23a-4049-90ca-5e387d31fb32"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("970927ea-980c-4c93-9701-9eae6bf17177"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b1c165f3-7e93-4269-a166-48e0dff6c998"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b94bc13a-7c40-46bc-9732-3e3da3ef7253"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("bda4f737-5199-4478-bbfb-5a982c204480"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c11f9f65-c7fc-418a-ad21-614d88e970e7"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c1e39eff-58d6-4585-8832-d9d7a8690ac4"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("c6d956e4-e548-4a72-8924-9b01f2b77f98"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("f995a836-e4cc-4a5e-a6c1-cac4c3880191"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserBoughtGames");

            migrationBuilder.DropColumn(
                name: "TicketQuantity",
                table: "EventsRegistrations");

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
    }
}
