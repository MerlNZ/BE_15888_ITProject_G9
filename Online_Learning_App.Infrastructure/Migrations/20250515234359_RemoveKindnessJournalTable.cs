using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Learning_App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKindnessJournalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "KindnessJournal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "KindnessJournal",
            //    columns: table => new
            //    {
            //        JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Emoji = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EntryText = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KindnessJournal", x => x.JournalId);
            //        table.ForeignKey(
            //            name: "FK_KindnessJournal_Students_StudentId",
            //            column: x => x.StudentId,
            //            principalTable: "Students",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_KindnessJournal_StudentId",
            //    table: "KindnessJournal",
            //    column: "StudentId");
        }
    }
}
