using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Collector.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Deposits",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountType = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Term = table.Column<int>(nullable: true),
                    InterestRate = table.Column<double>(nullable: true),
                    AccountStatus = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    DateLastPositive = table.Column<DateTime>(nullable: false),
                    LastDepositDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    ClosedDate = table.Column<DateTime>(nullable: false),
                    LastImportDate = table.Column<DateTime>(nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(nullable: false),
                    TotalDueAmount = table.Column<double>(nullable: false),
                    DuePrincipal = table.Column<double>(nullable: false),
                    DueLateCharges = table.Column<double>(nullable: true),
                    AverageMonthlyBalance = table.Column<double>(nullable: true),
                    AverageMonthlyDeposits = table.Column<double>(nullable: true),
                    OpenDeposit = table.Column<double>(nullable: true),
                    LastDepositAmount = table.Column<double>(nullable: true),
                    CurrentBalance = table.Column<double>(nullable: false),
                    UncollectableFunds = table.Column<double>(nullable: false),
                    SocialSecuritDeposit = table.Column<bool>(nullable: false),
                    StudentLoanDeposit = table.Column<bool>(nullable: false),
                    VeteranDeposit = table.Column<bool>(nullable: false),
                    TimesLate30Days = table.Column<int>(nullable: true),
                    TimesLate60Days = table.Column<int>(nullable: true),
                    TimesLate90Days = table.Column<int>(nullable: true),
                    TimesLate180days = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Deposits_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Term = table.Column<int>(nullable: true),
                    InterestRate = table.Column<double>(nullable: true),
                    CreditScore = table.Column<int>(nullable: true),
                    AccountStatus = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    FirstPaymentDate = table.Column<DateTime>(nullable: false),
                    LastPaymentDate = table.Column<DateTime>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    ClosedDate = table.Column<DateTime>(nullable: false),
                    LastImportDate = table.Column<DateTime>(nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(nullable: false),
                    TotalDueAmount = table.Column<double>(nullable: false),
                    DuePrincipal = table.Column<double>(nullable: false),
                    DueInterest = table.Column<double>(nullable: false),
                    DueLateCharges = table.Column<double>(nullable: false),
                    DueEscrow = table.Column<double>(nullable: false),
                    OriginalAmount = table.Column<double>(nullable: false),
                    PrincipalAmount = table.Column<double>(nullable: false),
                    CreditLimit = table.Column<double>(nullable: true),
                    EscrowBalance = table.Column<double>(nullable: true),
                    AmountInSuspense = table.Column<double>(nullable: true),
                    LastPaymentAmount = table.Column<double>(nullable: true),
                    MonthlyPayment = table.Column<double>(nullable: true),
                    TodaysPayOffAmount = table.Column<double>(nullable: true),
                    PierDiem = table.Column<double>(nullable: true),
                    ChargedOffAmount = table.Column<double>(nullable: true),
                    TimesLate30Days = table.Column<int>(nullable: true),
                    TimesLate60Days = table.Column<int>(nullable: true),
                    TimesLate90Days = table.Column<int>(nullable: true),
                    TimesLate180days = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loans_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PostalCode2 = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false),
                    LoanID = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => new { x.LoanID, x.MemberID });
                    table.ForeignKey(
                        name: "FK_Borrowers_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowers_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    ContactInfo = table.Column<string>(nullable: true),
                    ContactDescription = table.Column<string>(nullable: true),
                    ExtCode = table.Column<string>(nullable: true),
                    Fax = table.Column<bool>(nullable: true),
                    SMS = table.Column<bool>(nullable: true),
                    Mobile = table.Column<bool>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: true),
                    ClientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false),
                    DepositID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositors", x => new { x.DepositID, x.MemberID });
                    table.ForeignKey(
                        name: "FK_Depositors_Deposits_DepositID",
                        column: x => x.DepositID,
                        principalTable: "Deposits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Depositors_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collaterals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    PropertyValue = table.Column<double>(nullable: true),
                    PropertyPercentage = table.Column<double>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: true),
                    LoanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaterals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Collaterals_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collaterals_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientID",
                table: "Addresses",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MemberID",
                table: "Addresses",
                column: "MemberID");

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
                name: "IX_Borrowers_MemberID",
                table: "Borrowers",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Collaterals_AddressID",
                table: "Collaterals",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Collaterals_LoanID",
                table: "Collaterals",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ClientID",
                table: "Contacts",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MemberID",
                table: "Contacts",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Depositors_MemberID",
                table: "Depositors",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_ClientID",
                table: "Deposits",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientID",
                table: "Loans",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClientID",
                table: "Members",
                column: "ClientID");
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
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Collaterals");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
