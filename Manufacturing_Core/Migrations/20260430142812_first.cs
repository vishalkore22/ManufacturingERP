using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manufacturing_Core.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Bio = table.Column<string>(type: "Varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "MAccountTypes",
                columns: table => new
                {
                    PkAccountTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "Varchar(150)", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    FkBankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAccountTypes", x => x.PkAccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MAddresses",
                columns: table => new
                {
                    PkAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CurrentAddress = table.Column<bool>(type: "bit", nullable: false),
                    CurrentAddressLine1 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    CurrentAddressLine2 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Country = table.Column<string>(type: "Varchar(50)", nullable: false),
                    State = table.Column<string>(type: "Varchar(50)", nullable: false),
                    City = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Pin = table.Column<string>(type: "Varchar(6)", nullable: false),
                    PhNo = table.Column<string>(type: "Varchar(15)", nullable: false),
                    PermAddress = table.Column<bool>(type: "bit", nullable: false),
                    PermAddressLine1 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    PermAddressLine2 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    PermCountry = table.Column<string>(type: "Varchar(50)", nullable: true),
                    PermState = table.Column<string>(type: "Varchar(50)", nullable: true),
                    PermCity = table.Column<string>(type: "Varchar(50)", nullable: true),
                    PermPin = table.Column<string>(type: "Varchar(6)", nullable: true),
                    PermPhNo = table.Column<string>(type: "Varchar(15)", nullable: true),
                    OfficeAddress = table.Column<bool>(type: "bit", nullable: true),
                    OfficeAddressLine1 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    OfficeAddressLine2 = table.Column<string>(type: "Varchar(200)", nullable: false),
                    OfficeCountry = table.Column<string>(type: "Varchar(50)", nullable: true),
                    OfficeState = table.Column<string>(type: "Varchar(50)", nullable: true),
                    OfficeCity = table.Column<string>(type: "Varchar(50)", nullable: true),
                    OfficePin = table.Column<string>(type: "Varchar(50)", nullable: true),
                    OfficePhNo = table.Column<string>(type: "Varchar(50)", nullable: true),
                    EMailId = table.Column<string>(type: "Varchar(100)", nullable: true),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    FKLedgerNo = table.Column<int>(type: "int", nullable: false),
                    FkSupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAddresses", x => x.PkAddressId);
                });

            migrationBuilder.CreateTable(
                name: "MMetarials",
                columns: table => new
                {
                    PkMatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    MatName = table.Column<string>(type: "varchar(150)", nullable: false),
                    MatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MatUnit = table.Column<int>(type: "int", nullable: true),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SACode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MMetarials", x => x.PkMatId);
                });

            migrationBuilder.CreateTable(
                name: "MProducts",
                columns: table => new
                {
                    PkProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdCode = table.Column<string>(type: "Varchar(50)", nullable: false),
                    ProdName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProdDescription = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProdQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProdImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MProducts", x => x.PkProdId);
                });

            migrationBuilder.CreateTable(
                name: "MPurchaseOrders",
                columns: table => new
                {
                    PO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PO_Number = table.Column<string>(type: "Varchar(13)", nullable: false),
                    PO_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Supplier_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment_Terms = table.Column<string>(type: "Varchar(100)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GSTPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GSTAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "Varchar(500)", nullable: false),
                    Currency = table.Column<string>(type: "Varchar(10)", nullable: false),
                    PO_Status = table.Column<string>(type: "Varchar(25)", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approved_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSyncronized = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPurchaseOrders", x => x.PO_ID);
                });

            migrationBuilder.CreateTable(
                name: "MSuppliers",
                columns: table => new
                {
                    PkSupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierCode = table.Column<string>(type: "Varchar(25)", nullable: true),
                    SupplierName = table.Column<string>(type: "varchar(250)", nullable: false),
                    ShortName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LicenceId = table.Column<string>(type: "varchar(25)", nullable: true),
                    VATNo = table.Column<string>(type: "varchar(25)", nullable: true),
                    CSTNo = table.Column<string>(type: "varchar(25)", nullable: true),
                    TINno = table.Column<string>(type: "varchar(25)", nullable: true),
                    GSTIn = table.Column<string>(type: "varchar(25)", nullable: true),
                    IsCreatedBy = table.Column<string>(type: "varchar(25)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUpdatedBy = table.Column<string>(type: "varchar(25)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSuppliers", x => x.PkSupId);
                });

            migrationBuilder.CreateTable(
                name: "MTypes",
                columns: table => new
                {
                    PkTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCode = table.Column<string>(type: "Varchar(50)", nullable: false),
                    TypeName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    TypeDescription = table.Column<string>(type: "Varchar(50)", nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(150)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(150)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTypes", x => x.PkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MWarehouses",
                columns: table => new
                {
                    PkWarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    MWarehousesPkWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWarehouses", x => x.PkWarehouseId);
                    table.ForeignKey(
                        name: "FK_MWarehouses_MWarehouses_MWarehousesPkWarehouseId",
                        column: x => x.MWarehousesPkWarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "TrInventoryViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInventoryViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrPORequirementCollections",
                columns: table => new
                {
                    PkRequirementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementNumber = table.Column<string>(type: "Varchar(15)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkOrderNumber = table.Column<string>(type: "Varchar(15)", nullable: false),
                    BOMNumber = table.Column<string>(type: "Varchar(10)", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockAvailableQty = table.Column<int>(type: "int", nullable: false),
                    PurchaseQty = table.Column<int>(type: "int", nullable: false),
                    RequirementSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequirementStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPORequirementCollections", x => x.PkRequirementID);
                });

            migrationBuilder.CreateTable(
                name: "TrRequirementCollections",
                columns: table => new
                {
                    RequirementCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    Designation = table.Column<string>(type: "Varchar(100)", nullable: true),
                    NumberOfEmployeesRequired = table.Column<int>(type: "int", nullable: true),
                    SelectionCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(Max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrRequirementCollections", x => x.RequirementCollectionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MBooks",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "Varchar(250)", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBooks", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_MBooks_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID");
                });

            migrationBuilder.CreateTable(
                name: "MBanks",
                columns: table => new
                {
                    PkBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "Varchar(250)", nullable: false),
                    BranchName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    IFSCCode = table.Column<string>(type: "Varchar(25)", nullable: false),
                    MICRCode = table.Column<string>(type: "Varchar(25)", nullable: false),
                    AccountNo = table.Column<string>(type: "Varchar(25)", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    FkAccountTypeId = table.Column<int>(type: "int", nullable: false),
                    FkBankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBanks", x => x.PkBankId);
                    table.ForeignKey(
                        name: "FK_MBanks_MAccountTypes_FkAccountTypeId",
                        column: x => x.FkAccountTypeId,
                        principalTable: "MAccountTypes",
                        principalColumn: "PkAccountTypeId");
                });

            migrationBuilder.CreateTable(
                name: "TrInventoryTransaction",
                columns: table => new
                {
                    PkInTransId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkMatId = table.Column<int>(type: "int", nullable: false),
                    MatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkWarehouseId = table.Column<int>(type: "int", nullable: false),
                    Warehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInventoryTransaction", x => x.PkInTransId);
                    table.ForeignKey(
                        name: "FK_TrInventoryTransaction_MMetarials_FkMatId",
                        column: x => x.FkMatId,
                        principalTable: "MMetarials",
                        principalColumn: "PkMatId");
                });

            migrationBuilder.CreateTable(
                name: "MPurchaseOrderDetails",
                columns: table => new
                {
                    PODetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PO_ID = table.Column<int>(type: "int", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderPO_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPurchaseOrderDetails", x => x.PODetailID);
                    table.ForeignKey(
                        name: "FK_MPurchaseOrderDetails_MPurchaseOrders_PurchaseOrderPO_ID",
                        column: x => x.PurchaseOrderPO_ID,
                        principalTable: "MPurchaseOrders",
                        principalColumn: "PO_ID");
                });

            migrationBuilder.CreateTable(
                name: "MCategory",
                columns: table => new
                {
                    PkCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "Varchar(100)", nullable: false),
                    FkTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "Varchar(1000)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCategory", x => x.PkCatId);
                    table.ForeignKey(
                        name: "FK_MCategory_MTypes_FkTypeId",
                        column: x => x.FkTypeId,
                        principalTable: "MTypes",
                        principalColumn: "PkTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLocations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_MLocations_MWarehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "MLedgers",
                columns: table => new
                {
                    PKLedgerNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNumber = table.Column<string>(type: "Varchar(20)", nullable: false),
                    LedgerUserNo = table.Column<string>(type: "Varchar(20)", nullable: false),
                    LedgerName = table.Column<string>(type: "Varchar(250)", nullable: false),
                    OpeningBalance = table.Column<string>(type: "Varchar(250)", nullable: true),
                    ContactPerson = table.Column<string>(type: "Varchar(500)", nullable: true),
                    FaxNo = table.Column<string>(type: "Varchar(20)", nullable: true),
                    CSTNo = table.Column<string>(type: "Varchar(50)", nullable: true),
                    BSTNo = table.Column<string>(type: "Varchar(20)", nullable: true),
                    IncomeTaxNo = table.Column<string>(type: "Varchar(20)", nullable: true),
                    VATNo = table.Column<string>(type: "Varchar(20)", nullable: true),
                    SaleTaxNo = table.Column<string>(type: "Varchar(20)", nullable: true),
                    PANNo = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    ExciseRegestrationNo = table.Column<string>(type: "Varchar(15)", nullable: true),
                    ServiceTaxRegNo = table.Column<string>(type: "Varchar(15)", nullable: true),
                    IsServiceTaxApply = table.Column<bool>(type: "bit", nullable: false),
                    WebSite = table.Column<string>(type: "Varchar(20)", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    FkBankId = table.Column<int>(type: "int", nullable: false),
                    GSTINNo = table.Column<string>(type: "Varchar(15)", nullable: false),
                    UINNo = table.Column<string>(type: "Varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLedgers", x => x.PKLedgerNo);
                    table.ForeignKey(
                        name: "FK_MLedgers_MBanks_FkBankId",
                        column: x => x.FkBankId,
                        principalTable: "MBanks",
                        principalColumn: "PkBankId");
                });

            migrationBuilder.CreateTable(
                name: "MItems",
                columns: table => new
                {
                    PkItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "Varchar(10)", nullable: false),
                    ItemName = table.Column<string>(type: "Varchar(250)", nullable: false),
                    ItemDescription = table.Column<string>(type: "Varchar(500)", nullable: false),
                    FkCatId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    ItemQty = table.Column<int>(type: "int", nullable: false),
                    ItemRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemUnit = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HSNCODE = table.Column<string>(type: "Varchar(20)", nullable: false),
                    SACODE = table.Column<string>(type: "Varchar(20)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    MTypePkTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MItems", x => x.PkItemId);
                    table.ForeignKey(
                        name: "FK_MItems_MCategory_FkCatId",
                        column: x => x.FkCatId,
                        principalTable: "MCategory",
                        principalColumn: "PkCatId");
                    table.ForeignKey(
                        name: "FK_MItems_MTypes_MTypePkTypeId",
                        column: x => x.MTypePkTypeId,
                        principalTable: "MTypes",
                        principalColumn: "PkTypeId");
                });

            migrationBuilder.CreateTable(
                name: "MSubcategory",
                columns: table => new
                {
                    PkSubCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkCatId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCreatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdatedBy = table.Column<string>(type: "Varchar(250)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSubcategory", x => x.PkSubCatId);
                    table.ForeignKey(
                        name: "FK_MSubcategory_MCategory_FkCatId",
                        column: x => x.FkCatId,
                        principalTable: "MCategory",
                        principalColumn: "PkCatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MSubcategory_MTypes_FkTypeId",
                        column: x => x.FkTypeId,
                        principalTable: "MTypes",
                        principalColumn: "PkTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCurrentStocks",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaterialPkMatId = table.Column<int>(type: "int", nullable: true),
                    WarehousePkWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCurrentStocks", x => new { x.MaterialId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_TrCurrentStocks_MLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MLocations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_TrCurrentStocks_MMetarials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "MMetarials",
                        principalColumn: "PkMatId");
                    table.ForeignKey(
                        name: "FK_TrCurrentStocks_MMetarials_MaterialPkMatId",
                        column: x => x.MaterialPkMatId,
                        principalTable: "MMetarials",
                        principalColumn: "PkMatId");
                    table.ForeignKey(
                        name: "FK_TrCurrentStocks_MWarehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                    table.ForeignKey(
                        name: "FK_TrCurrentStocks_MWarehouses_WarehousePkWarehouseId",
                        column: x => x.WarehousePkWarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "TrInventories",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    ReferenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSynchronized = table.Column<bool>(type: "bit", nullable: false),
                    WarehousePkWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInventories", x => new { x.MaterialId, x.WarehouseId, x.TransactionDate });
                    table.ForeignKey(
                        name: "FK_TrInventories_MLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MLocations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_TrInventories_MMetarials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "MMetarials",
                        principalColumn: "PkMatId");
                    table.ForeignKey(
                        name: "FK_TrInventories_MWarehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                    table.ForeignKey(
                        name: "FK_TrInventories_MWarehouses_WarehousePkWarehouseId",
                        column: x => x.WarehousePkWarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                });

            migrationBuilder.CreateTable(
                name: "TrStockLedgers",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockLedgerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehousePkWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrStockLedgers", x => new { x.MaterialId, x.WarehouseId, x.TransactionDate });
                    table.ForeignKey(
                        name: "FK_TrStockLedgers_MLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MLocations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_TrStockLedgers_MMetarials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "MMetarials",
                        principalColumn: "PkMatId");
                    table.ForeignKey(
                        name: "FK_TrStockLedgers_MWarehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
                    table.ForeignKey(
                        name: "FK_TrStockLedgers_MWarehouses_WarehousePkWarehouseId",
                        column: x => x.WarehousePkWarehouseId,
                        principalTable: "MWarehouses",
                        principalColumn: "PkWarehouseId");
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
                name: "IX_MBanks_FkAccountTypeId",
                table: "MBanks",
                column: "FkAccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MBooks_AuthorID",
                table: "MBooks",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_MCategory_FkTypeId",
                table: "MCategory",
                column: "FkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MItems_FkCatId",
                table: "MItems",
                column: "FkCatId");

            migrationBuilder.CreateIndex(
                name: "IX_MItems_MTypePkTypeId",
                table: "MItems",
                column: "MTypePkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MLedgers_FkBankId",
                table: "MLedgers",
                column: "FkBankId");

            migrationBuilder.CreateIndex(
                name: "IX_MLocations_WarehouseId",
                table: "MLocations",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MPurchaseOrderDetails_PurchaseOrderPO_ID",
                table: "MPurchaseOrderDetails",
                column: "PurchaseOrderPO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MSubcategory_FkCatId",
                table: "MSubcategory",
                column: "FkCatId");

            migrationBuilder.CreateIndex(
                name: "IX_MSubcategory_FkTypeId",
                table: "MSubcategory",
                column: "FkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MWarehouses_MWarehousesPkWarehouseId",
                table: "MWarehouses",
                column: "MWarehousesPkWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrentStocks_LocationId",
                table: "TrCurrentStocks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrentStocks_MaterialPkMatId",
                table: "TrCurrentStocks",
                column: "MaterialPkMatId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrentStocks_WarehouseId",
                table: "TrCurrentStocks",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrentStocks_WarehousePkWarehouseId",
                table: "TrCurrentStocks",
                column: "WarehousePkWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInventories_LocationId",
                table: "TrInventories",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInventories_WarehouseId",
                table: "TrInventories",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInventories_WarehousePkWarehouseId",
                table: "TrInventories",
                column: "WarehousePkWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInventoryTransaction_FkMatId",
                table: "TrInventoryTransaction",
                column: "FkMatId");

            migrationBuilder.CreateIndex(
                name: "IX_TrStockLedgers_LocationId",
                table: "TrStockLedgers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrStockLedgers_WarehouseId",
                table: "TrStockLedgers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrStockLedgers_WarehousePkWarehouseId",
                table: "TrStockLedgers",
                column: "WarehousePkWarehouseId");
        }

        /// <inheritdoc />
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
                name: "MAddresses");

            migrationBuilder.DropTable(
                name: "MBooks");

            migrationBuilder.DropTable(
                name: "MItems");

            migrationBuilder.DropTable(
                name: "MLedgers");

            migrationBuilder.DropTable(
                name: "MProducts");

            migrationBuilder.DropTable(
                name: "MPurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "MSubcategory");

            migrationBuilder.DropTable(
                name: "MSuppliers");

            migrationBuilder.DropTable(
                name: "TrCurrentStocks");

            migrationBuilder.DropTable(
                name: "TrInventories");

            migrationBuilder.DropTable(
                name: "TrInventoryTransaction");

            migrationBuilder.DropTable(
                name: "TrInventoryViewModels");

            migrationBuilder.DropTable(
                name: "TrPORequirementCollections");

            migrationBuilder.DropTable(
                name: "TrRequirementCollections");

            migrationBuilder.DropTable(
                name: "TrStockLedgers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MBanks");

            migrationBuilder.DropTable(
                name: "MPurchaseOrders");

            migrationBuilder.DropTable(
                name: "MCategory");

            migrationBuilder.DropTable(
                name: "MLocations");

            migrationBuilder.DropTable(
                name: "MMetarials");

            migrationBuilder.DropTable(
                name: "MAccountTypes");

            migrationBuilder.DropTable(
                name: "MTypes");

            migrationBuilder.DropTable(
                name: "MWarehouses");
        }
    }
}
