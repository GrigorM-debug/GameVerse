using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStatusPropertyFromEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00152330-43f4-46d7-9389-efba23f67694"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("05bd0540-3d01-4c75-bc95-405be243a143"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0f7c7314-4944-4f1c-8977-0f65648a50d4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("19736a39-9e75-4160-b3e2-5d0d81198ba7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1e7bc1ce-c122-403f-9290-162c26bb6067"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3aa07b3e-f07d-49e8-a1d6-9a7169164828"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3aec436f-4e09-4af3-91b8-e9a491aac50a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5afe7450-082b-42f3-8b23-1d4a77fde6df"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("682060dd-8821-47f9-8798-829ffbcb22e4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("775592af-741b-48ac-8a7f-9f2b1388ee13"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8a27f24d-6f0c-489f-b4f4-2115d97c587b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8cbf854d-6d8e-47ac-84ad-111fbd74bf47"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8efa9199-ac89-45b5-9d50-8feca9420813"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9e2b8d16-5c74-48dc-b74b-c3d82b128979"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("be3b07b8-e441-4340-a378-36b251e6b53e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cf867774-6fd9-4ef7-b3c2-d41d544d56d8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d0dbb414-a8a7-4c73-877c-1bafd8eae416"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f3951de1-219d-4d94-a52c-3315d8afa27e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f47973b8-daf9-4bd1-a0d4-ec3fff3f472a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fd48e092-b2da-44a0-8792-08eb00c3639a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("08c2a542-1547-48a8-be54-e47a6fed01c3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("1b96f535-9fc4-4351-b869-d4a73510bc77"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2321ce6b-a51a-423f-8d42-b4843bb76e14"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2e881251-f3e2-4559-871b-ac0d451d54f2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("33676f43-3e10-4e17-a140-9108783695ce"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("34170297-d04e-48a9-bd30-93f6b30ccde2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3829e26e-58d0-42db-a90a-ac71d505af05"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("59cc1468-2907-4742-9512-a03f952241fa"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("6e8a698f-b930-424f-abd9-f4e24e3e22d8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("71ec76bb-0731-43bd-878b-bf140455d2de"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9668760f-09b3-45f1-9f7c-108d4ddd9309"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("97302672-8b7d-48a0-a55c-d94c5bbfdc0e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("9e05e80b-b630-4979-aea3-d871ec115799"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a598dbf4-6ad9-409e-8f56-a6d44967d88b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c32b1657-65fc-4435-b835-b6642357c0b2"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c53982c9-99d2-4b7f-9024-594efeb440b3"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("c6def783-3d80-4a5e-a460-b99c5f65cd23"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("dd1704fd-9d2c-460d-8f25-7c1417842a8b"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e4f4c418-6d29-4c49-b215-c7068eb47ac4"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f5a07151-4a25-4bda-bd44-32bfb6a20142"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("22a1037d-ce25-4d7d-b0e2-55d316976e05"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("3634342b-aa0f-4e75-a462-4d98f9771950"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("4d59b187-0d07-4a02-aa62-b87e1ca8f72b"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7a30c46d-f11b-4d9d-9528-ce48ddeb67b0"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("7d9d7298-97c4-42bd-8b5c-e17d16f2d93c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("8bd0e646-a246-4d18-b651-3799747e3acc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9fdf5c03-ba71-4e59-a6cc-a7b50dadc6f9"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("a550f187-b261-4886-9603-42ce4dca0e45"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("ad3a9e2e-3ba5-46de-a164-90425b01932d"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b3b4612d-ff3e-4e87-a238-a19c64f67d24"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("cf812975-9075-4e96-a109-b3486a0ad0ff"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("e182f26e-e318-4cdf-87d4-e0483bafea50"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("f8bb1b89-eb02-4833-950a-87dff66ca5b6"));

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
                    { new Guid("1be8cd6a-3107-4601-b591-86129b8f7a80"), "Party" },
                    { new Guid("245bb3c6-316a-403f-9435-dcfad447c8b2"), "Adventure" },
                    { new Guid("2b69cc04-51a7-4b31-a1ab-5c48fd20d8bc"), "First-Person Shooter" },
                    { new Guid("2fb908b5-69da-4ce2-8d29-d5b9215dcc02"), "Fighting" },
                    { new Guid("3d8fc619-a6c2-4d51-8753-4a536b74488f"), "Sports" },
                    { new Guid("58b48cb0-9ce3-43ed-9c9a-31a9e78c7cbb"), "Action RPG" },
                    { new Guid("719cfc72-73ef-442a-8e15-824e195e25d6"), "Simulation" },
                    { new Guid("775c3938-ac0b-4342-838e-986c0ab4f3e5"), "Action" },
                    { new Guid("7b4cd394-1f50-45b8-aa47-bc5ba411696e"), "Survival" },
                    { new Guid("a2f16373-a111-4567-97b5-a5b08f87bf1a"), "Platformer" },
                    { new Guid("b75958f4-2aca-4779-8c4a-a83fb1d8bf56"), "Action-adventure" },
                    { new Guid("be5837a8-242f-4fe6-930c-1f7cf2f87867"), "Real-time strategy" },
                    { new Guid("c23d5276-97af-47a9-872b-5f703eabe469"), "Shooter" },
                    { new Guid("c585b17d-4d4a-4938-b7f7-c73fdd8d6252"), "Puzzle" },
                    { new Guid("ce0709a4-9bc6-41cd-a16e-9498e6c6c620"), "Casual" },
                    { new Guid("d54bfee5-8784-40b3-b5e3-e1bed08b0503"), "Strategy game" },
                    { new Guid("e39ca8bb-5af7-43f3-996e-6a23cd4613d8"), "RPG" },
                    { new Guid("e80e5f8e-1a60-446e-b1ff-234f685abb17"), "Racing" },
                    { new Guid("ef18a665-27e2-4e44-950c-bb900da07f80"), "Stealth" },
                    { new Guid("f62dee2d-7edc-4697-a944-497392958cb8"), "Battle Royale" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01477c90-9056-472c-99db-8254ac348d4d"), "Xbox One" },
                    { new Guid("053ddee5-66ae-4b33-af05-b629264ea5bb"), "Nintendo DS" },
                    { new Guid("07720321-c28a-4643-a40d-078a27bf5029"), "Super Nintendo" },
                    { new Guid("1cef75ca-d4b8-4166-9a7e-6fd244282ccc"), "Linux" },
                    { new Guid("22b1ec9c-bd92-41ed-bd73-eea6fd85a160"), "PlayStation Vita" },
                    { new Guid("3d4ca656-11ba-440f-8fa3-925de88b2eda"), "Xbox 360" },
                    { new Guid("530c3a7c-eec4-46c1-8227-3621272aaa80"), "PlayStation 2" },
                    { new Guid("6b59b544-1d92-4b83-bb24-9fc94dc8b86b"), "Mac" },
                    { new Guid("74ae565f-0b4e-4673-abef-8056e13ed454"), "PlayStation 5" },
                    { new Guid("788955f1-8861-4aa7-8818-e906cb82d4ce"), "PlayStation 1" },
                    { new Guid("7b47ec42-2935-44a4-a12d-14191b182c77"), "Nintendo Switch" },
                    { new Guid("8afa01bc-1d82-4e32-b89c-670b94614156"), "Sega Mega Drive" },
                    { new Guid("a4c82b28-50c4-49d8-a482-6c879c0930a9"), "Game Boy Advanced" },
                    { new Guid("a9a88c43-af15-42d1-9924-1574112cefce"), "PC" },
                    { new Guid("c6d3e81e-da86-4224-a274-00cc0c812d17"), "Game Boy" },
                    { new Guid("dbe3f502-53ca-44ec-8f00-f7b125c62af5"), "Nintendo Wii" },
                    { new Guid("f17b81a3-252c-4e95-9a3a-bfd9f3f1a0a1"), "Xbox Series X" },
                    { new Guid("f2efb391-8dc2-4bc7-b270-2ae5098c1298"), "PlayStation Portable" },
                    { new Guid("f3f89a78-df0b-444b-a5af-01f2c2c92a17"), "PlayStation 3" },
                    { new Guid("f9de5879-8142-41cd-b950-9fe2938b46cc"), "PlayStation 4" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("495e41a6-476c-4225-9f9a-508fbd1c5cc8"), "PEGI 3" },
                    { new Guid("4964ee10-3997-4185-a8d2-e253a7f7c961"), "PEGI 18" },
                    { new Guid("62202469-2ca1-460d-9ec6-240793e82644"), "Bad Language" },
                    { new Guid("84f9f133-7a17-420a-b18c-861babfce9d6"), "Fear" },
                    { new Guid("93a896e7-d23a-4049-90ca-5e387d31fb32"), "Sex" },
                    { new Guid("970927ea-980c-4c93-9701-9eae6bf17177"), "Gambling" },
                    { new Guid("b1c165f3-7e93-4269-a166-48e0dff6c998"), "Drugs" },
                    { new Guid("b94bc13a-7c40-46bc-9732-3e3da3ef7253"), "Violence" },
                    { new Guid("bda4f737-5199-4478-bbfb-5a982c204480"), "PEGI 12" },
                    { new Guid("c11f9f65-c7fc-418a-ad21-614d88e970e7"), "PEGI 16 " },
                    { new Guid("c1e39eff-58d6-4585-8832-d9d7a8690ac4"), "PEGI 7" },
                    { new Guid("c6d956e4-e548-4a72-8924-9b01f2b77f98"), "In-Game Purchases" },
                    { new Guid("f995a836-e4cc-4a5e-a6c1-cac4c3880191"), "Discrimination" }
                });
        }
    }
}
