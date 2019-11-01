using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.CreateTable(
                name: "ParkActivities",
                columns: table => new
                {
                    ParkActivityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkId = table.Column<int>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkActivities", x => x.ParkActivityId);
                    table.ForeignKey(
                        name: "FK_ParkActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkActivities_Parks_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parks",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrailName = table.Column<string>(nullable: true),
                    ParkId = table.Column<int>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    ChallengeRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailId);
                    table.ForeignKey(
                        name: "FK_Trails_Parks_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parks",
                        principalColumn: "ParkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Location", "ParkName" },
                values: new object[] { 1, "The Molalla River State Park is located in U.S. state of Oregon. It is a few miles north of Canby, and half a mile from the Canby Ferry. The park is south of the Willamette River and east of the Molalla River, at the confluence of the Pudding, Molalla and Willamette rivers.", "Canby, OR 97013", "Molalla River State Park" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Location", "ParkName" },
                values: new object[] { 2, "A popular campground and day-use area, Cape Lookout is located on a sand spit between Netarts Bay and the ocean, giving you a terrific view of the ocean with convenient access to the beach. Note: The beach at Cape Lookout is protected by a 50' wide cobble-sized stone revetment. The revetment helps prevent erosion and stabilizes the man-made dune that protects the campground. Visitors that wish to access the beach must walk through the revetment. Please be careful when on the cobble stones, as they can be unstable.", "45.36682,-123.962148", "Cape Lookout State Park" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "ChallengeRating", "Length", "ParkId", "TrailName" },
                values: new object[] { 1, 2, 5.0, 1, "Easy River Run" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "ChallengeRating", "Length", "ParkId", "TrailName" },
                values: new object[] { 2, 4, 2.3999999999999999, 2, "Cape Lookout Trail" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "ChallengeRating", "Length", "ParkId", "TrailName" },
                values: new object[] { 3, 1, 1.7, 2, "The Nature Trail" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "ChallengeRating", "Length", "ParkId", "TrailName" },
                values: new object[] { 4, 5, 17.0, 2, "Cape Trail Heights" });

            migrationBuilder.CreateIndex(
                name: "IX_ParkActivities_ActivityId",
                table: "ParkActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkActivities_ParkId",
                table: "ParkActivities",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_ParkId",
                table: "Trails",
                column: "ParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkActivities");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
