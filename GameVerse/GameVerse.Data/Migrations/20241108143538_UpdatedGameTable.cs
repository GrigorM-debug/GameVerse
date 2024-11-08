using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
