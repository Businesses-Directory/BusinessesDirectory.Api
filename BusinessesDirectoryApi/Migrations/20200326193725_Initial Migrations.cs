using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessesDirectoryApi.Migrations
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BusinessDescription = table.Column<string>(maxLength: 600, nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BusinessDaysAndHours = table.Column<string>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    InFacebookAs = table.Column<string>(nullable: true),
                    InInstagramAs = table.Column<string>(nullable: true),
                    HasDelivery = table.Column<bool>(nullable: false),
                    HasCarryOut = table.Column<bool>(nullable: false),
                    HasAthMovil = table.Column<bool>(nullable: false),
                    InUberEats = table.Column<bool>(nullable: false),
                    InDameUnBite = table.Column<bool>(nullable: false),
                    InUva = table.Column<bool>(nullable: false),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Business",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
