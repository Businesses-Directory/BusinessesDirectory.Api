using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessesDirectoriesApi.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "administration");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "location");

            migrationBuilder.CreateTable(
                name: "BusinessType",
                schema: "administration",
                columns: table => new
                {
                    BusinessTypeId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    BusinessTypeRecordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    BusinessTypeNormalizedName = table.Column<string>(maxLength: 100, nullable: false),
                    BusinessTypeDescription = table.Column<string>(maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BusinessTypeId_PK", x => x.BusinessTypeId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "location",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CountryRecordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryNormalizedName = table.Column<string>(maxLength: 100, nullable: false),
                    IsoTwo = table.Column<string>(maxLength: 2, nullable: false),
                    IsoThree = table.Column<string>(maxLength: 3, nullable: false),
                    IsoNumber = table.Column<long>(maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CountryId_PK", x => x.CountryId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "location",
                columns: table => new
                {
                    StateId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    CountryId = table.Column<Guid>(nullable: false),
                    StateRecordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(maxLength: 100, nullable: false),
                    StateNormalizedName = table.Column<string>(maxLength: 100, nullable: false),
                    StateCode = table.Column<string>(maxLength: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StateId_CountryId_PK", x => new { x.StateId, x.CountryId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Country_To_State_FK",
                        column: x => x.CountryId,
                        principalSchema: "location",
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "location",
                columns: table => new
                {
                    CityId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    StateId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    CityRecordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    CityNormalizedName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CityId_StateId_CountryId_PK", x => new { x.CityId, x.StateId, x.CountryId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "State_To_City_FK",
                        columns: x => new { x.StateId, x.CountryId },
                        principalSchema: "location",
                        principalTable: "State",
                        principalColumns: new[] { "StateId", "CountryId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                schema: "dbo",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    BusinessRecordId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(maxLength: 300, nullable: false),
                    BusinessTypeId = table.Column<Guid>(nullable: false),
                    BusinessEmail = table.Column<string>(maxLength: 100, nullable: false),
                    BusinessDescription = table.Column<string>(maxLength: 600, nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BusinessDaysAndHours = table.Column<string>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    InFacebookAs = table.Column<string>(maxLength: 100, nullable: true),
                    InInstagramAs = table.Column<string>(maxLength: 100, nullable: true),
                    HasDelivery = table.Column<bool>(nullable: false),
                    HasCarryOut = table.Column<bool>(nullable: false),
                    HasAthMovil = table.Column<bool>(nullable: false),
                    InUberEats = table.Column<bool>(nullable: false),
                    InDameUnBite = table.Column<bool>(nullable: false),
                    InUva = table.Column<bool>(nullable: false),
                    IsOperational = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BusinessId_Primary_Key", x => x.BusinessId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "BusinessType_To_Business_Fk",
                        column: x => x.BusinessTypeId,
                        principalSchema: "administration",
                        principalTable: "BusinessType",
                        principalColumn: "BusinessTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "City_To_Business_Fk",
                        columns: x => new { x.CityId, x.StateId, x.CountryId },
                        principalSchema: "location",
                        principalTable: "City",
                        principalColumns: new[] { "CityId", "StateId", "CountryId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "BusinessRecordId_AIK",
                schema: "administration",
                table: "BusinessType",
                column: "BusinessTypeRecordId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "BusinessRecordId_AIK",
                schema: "dbo",
                table: "Business",
                column: "BusinessRecordId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "BusinessTypeId_To_BusinessTable_FK",
                schema: "dbo",
                table: "Business",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "CityId_StateId_CountryId_To_BusinessTable_FK",
                schema: "dbo",
                table: "Business",
                columns: new[] { "CityId", "StateId", "CountryId" });

            migrationBuilder.CreateIndex(
                name: "CityRecordId_AIK",
                schema: "location",
                table: "City",
                column: "CityRecordId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "StateId_CountryId_To_CityTable_FK",
                schema: "location",
                table: "City",
                columns: new[] { "StateId", "CountryId" });

            migrationBuilder.CreateIndex(
                name: "CountryRecordId_AIK",
                schema: "location",
                table: "Country",
                column: "CountryRecordId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "CountryId_To_StateTable_FK",
                schema: "location",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "StateRecordId_AIK",
                schema: "location",
                table: "State",
                column: "StateRecordId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BusinessType",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "City",
                schema: "location");

            migrationBuilder.DropTable(
                name: "State",
                schema: "location");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "location");
        }
    }
}
