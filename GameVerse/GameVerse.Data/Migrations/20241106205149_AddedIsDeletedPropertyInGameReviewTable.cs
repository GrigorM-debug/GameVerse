using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedPropertyInGameReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GameReviews",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete flag");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a057827-ba24-4e06-8544-bbeb5379173c"), "Casual" },
                    { new Guid("2252693e-a6ee-432c-9232-43670c6fca56"), "Action-adventure" },
                    { new Guid("24ee5d63-fa9f-476f-a9c8-eb3b66faf577"), "Adventure" },
                    { new Guid("2f01e4d4-8da9-48bd-8c0a-cc8fc2219d99"), "Action" },
                    { new Guid("471c81fd-eb69-4dbb-9c41-a1b507ca839d"), "Survival" },
                    { new Guid("5ceed236-1080-4e7d-81f8-f76bb7e40a62"), "Strategy game" },
                    { new Guid("76788d49-1500-4072-8152-dd2ad33d503e"), "Party" },
                    { new Guid("76eae1ea-182b-4256-aac1-2457accebeef"), "Action RPG" },
                    { new Guid("7e44d2ea-c861-41d6-b61b-7cce1f17f2b8"), "Sports" },
                    { new Guid("895c7c28-bf25-4bfa-bfe9-31a1b356583d"), "RPG" },
                    { new Guid("9184c106-b0af-49a2-930b-3e23fd3345c2"), "Stealth" },
                    { new Guid("979569e6-9bd0-4f3d-8647-ba93c5cf8b85"), "Battle Royale" },
                    { new Guid("9a6c0a96-c314-427c-b20c-03db748fe0c1"), "Shooter" },
                    { new Guid("a2ee69c9-1d55-4c21-aaa6-6fec4def5bdf"), "Racing" },
                    { new Guid("b827f242-1236-4b1e-927f-ac916fded411"), "First-Person Shooter" },
                    { new Guid("c06dc363-dec9-40e6-a4fd-72d45ad90a76"), "Fighting" },
                    { new Guid("c528e4d5-51cc-4765-b31e-8b6fb8a5f667"), "Real-time strategy" },
                    { new Guid("d18cdeab-5ca6-4f03-9cf4-9cdfba32cd75"), "Puzzle" },
                    { new Guid("d76c248e-b442-4040-9b31-f874466442aa"), "Simulation" },
                    { new Guid("f51d1840-29ec-43e6-88f2-25bc8d96b19c"), "Platformer" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01ce70a6-c638-4774-b028-c158250c625d"), "Sega Mega Drive" },
                    { new Guid("02e63749-b83c-4bff-b97a-0bdad5664f69"), "Mac" },
                    { new Guid("07892f65-2ed2-4475-a9f6-f2c5928e1bd5"), "Nintendo DS" },
                    { new Guid("17d5ca00-c933-4d77-be1a-3afffae9beaf"), "Game Boy Advanced" },
                    { new Guid("2a316e9a-1fa1-4c68-89d2-445a71eb614e"), "PC" },
                    { new Guid("622d59bc-2dad-46e7-8adc-32b1c5e7e432"), "Xbox 360" },
                    { new Guid("7be082f5-52a3-4f79-a028-686fe5ad113f"), "Nintendo Switch" },
                    { new Guid("7c645af2-3f81-403e-abd0-e00f25386657"), "Super Nintendo" },
                    { new Guid("7f03bd4d-875a-4080-887d-db8a3656fc34"), "Game Boy" },
                    { new Guid("8366dbaa-7070-47d9-91eb-bb95e87e06b9"), "PlayStation 2" },
                    { new Guid("84c9a520-c11d-4aa7-a56e-303e637caa01"), "PlayStation Portable" },
                    { new Guid("95c89626-93f7-4df1-b9c4-68b72b5b0121"), "PlayStation 1" },
                    { new Guid("964fcf67-baef-49c1-960c-b3d879b1563a"), "Nintendo Wii" },
                    { new Guid("a9194715-a5a9-46f0-b0aa-523c9c4a7801"), "Xbox One" },
                    { new Guid("b72e203f-ad1e-47a8-ba23-060216650f24"), "PlayStation 3" },
                    { new Guid("bdbe7bda-07ef-4349-b7c8-b8f6277380dd"), "Linux" },
                    { new Guid("be850f54-3205-4256-9714-7ef8f576861f"), "Xbox Series X" },
                    { new Guid("e345c0b8-22c9-4615-b3d1-822eead2bda8"), "PlayStation Vita" },
                    { new Guid("ef95d1d5-d375-48b5-ac73-1a8e35c6664d"), "PlayStation 5" },
                    { new Guid("f6996c27-14c3-439d-a21c-c15c1439d1dd"), "PlayStation 4" }
                });

            migrationBuilder.InsertData(
                table: "Restrictions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ad83d99-fa0f-460a-8ff5-cc8d9bfcc2fc"), "PEGI 18" },
                    { new Guid("19386f7a-327e-4912-beb9-04154e7f3f0f"), "PEGI 7" },
                    { new Guid("2d921dea-e168-4901-8388-8db70ea4b148"), "Fear" },
                    { new Guid("3e234311-8b19-448b-9bf0-185471428b31"), "Gambling" },
                    { new Guid("53f94405-7ecc-401b-bca0-f3c18d79dcd8"), "In-Game Purchases" },
                    { new Guid("631d6565-169b-43bf-a145-1af20d6c17d9"), "Drugs" },
                    { new Guid("65d298fb-e4c5-44e0-9082-77b05c723762"), "Sex" },
                    { new Guid("9480a7e7-8af7-48b2-b524-5fbdaec7811c"), "PEGI 16 " },
                    { new Guid("a23f81aa-f413-4e20-b9a6-8a61fcba5e56"), "Bad Language" },
                    { new Guid("b21b8316-cfd1-4f9c-9d93-0f8e7c2a8531"), "PEGI 12" },
                    { new Guid("b43b3fc9-afc1-4c24-aaea-238904852576"), "Violence" },
                    { new Guid("b478806c-f622-4625-bb68-d581b696b8ed"), "PEGI 3" },
                    { new Guid("d9393601-0201-480c-a3d3-2d5ac62ef5ad"), "Discrimination" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0a057827-ba24-4e06-8544-bbeb5379173c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2252693e-a6ee-432c-9232-43670c6fca56"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("24ee5d63-fa9f-476f-a9c8-eb3b66faf577"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2f01e4d4-8da9-48bd-8c0a-cc8fc2219d99"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("471c81fd-eb69-4dbb-9c41-a1b507ca839d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5ceed236-1080-4e7d-81f8-f76bb7e40a62"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("76788d49-1500-4072-8152-dd2ad33d503e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("76eae1ea-182b-4256-aac1-2457accebeef"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7e44d2ea-c861-41d6-b61b-7cce1f17f2b8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("895c7c28-bf25-4bfa-bfe9-31a1b356583d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9184c106-b0af-49a2-930b-3e23fd3345c2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("979569e6-9bd0-4f3d-8647-ba93c5cf8b85"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9a6c0a96-c314-427c-b20c-03db748fe0c1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a2ee69c9-1d55-4c21-aaa6-6fec4def5bdf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b827f242-1236-4b1e-927f-ac916fded411"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c06dc363-dec9-40e6-a4fd-72d45ad90a76"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c528e4d5-51cc-4765-b31e-8b6fb8a5f667"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d18cdeab-5ca6-4f03-9cf4-9cdfba32cd75"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d76c248e-b442-4040-9b31-f874466442aa"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f51d1840-29ec-43e6-88f2-25bc8d96b19c"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("01ce70a6-c638-4774-b028-c158250c625d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("02e63749-b83c-4bff-b97a-0bdad5664f69"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("07892f65-2ed2-4475-a9f6-f2c5928e1bd5"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("17d5ca00-c933-4d77-be1a-3afffae9beaf"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("2a316e9a-1fa1-4c68-89d2-445a71eb614e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("622d59bc-2dad-46e7-8adc-32b1c5e7e432"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7be082f5-52a3-4f79-a028-686fe5ad113f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7c645af2-3f81-403e-abd0-e00f25386657"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("7f03bd4d-875a-4080-887d-db8a3656fc34"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("8366dbaa-7070-47d9-91eb-bb95e87e06b9"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("84c9a520-c11d-4aa7-a56e-303e637caa01"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("95c89626-93f7-4df1-b9c4-68b72b5b0121"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("964fcf67-baef-49c1-960c-b3d879b1563a"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("a9194715-a5a9-46f0-b0aa-523c9c4a7801"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("b72e203f-ad1e-47a8-ba23-060216650f24"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("bdbe7bda-07ef-4349-b7c8-b8f6277380dd"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("be850f54-3205-4256-9714-7ef8f576861f"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("e345c0b8-22c9-4615-b3d1-822eead2bda8"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("ef95d1d5-d375-48b5-ac73-1a8e35c6664d"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("f6996c27-14c3-439d-a21c-c15c1439d1dd"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("0ad83d99-fa0f-460a-8ff5-cc8d9bfcc2fc"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("19386f7a-327e-4912-beb9-04154e7f3f0f"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("2d921dea-e168-4901-8388-8db70ea4b148"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("3e234311-8b19-448b-9bf0-185471428b31"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("53f94405-7ecc-401b-bca0-f3c18d79dcd8"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("631d6565-169b-43bf-a145-1af20d6c17d9"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("65d298fb-e4c5-44e0-9082-77b05c723762"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("9480a7e7-8af7-48b2-b524-5fbdaec7811c"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("a23f81aa-f413-4e20-b9a6-8a61fcba5e56"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b21b8316-cfd1-4f9c-9d93-0f8e7c2a8531"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b43b3fc9-afc1-4c24-aaea-238904852576"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("b478806c-f622-4625-bb68-d581b696b8ed"));

            migrationBuilder.DeleteData(
                table: "Restrictions",
                keyColumn: "Id",
                keyValue: new Guid("d9393601-0201-480c-a3d3-2d5ac62ef5ad"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GameReviews");

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
        }
    }
}
