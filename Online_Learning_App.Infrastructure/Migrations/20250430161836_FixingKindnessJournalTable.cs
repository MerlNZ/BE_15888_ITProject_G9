using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Learning_App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingKindnessJournalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_KindnessJournals_Students_StudentId",
            //    table: "KindnessJournals");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_KindnessJournals",
            //    table: "KindnessJournals");

            //migrationBuilder.RenameTable(
            //    name: "KindnessJournals",
            //    newName: "KindnessJournal");

            //migrationBuilder.RenameIndex(
            //    name: "IX_KindnessJournals_StudentId",
            //    table: "KindnessJournal",
            //    newName: "IX_KindnessJournal_StudentId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_KindnessJournal",
            //    table: "KindnessJournal",
            //    column: "JournalId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_KindnessJournal_Students_StudentId",
            //    table: "KindnessJournal",
            //    column: "StudentId",
            //    principalTable: "Students",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_KindnessJournal_Students_StudentId",
            //    table: "KindnessJournal");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_KindnessJournal",
            //    table: "KindnessJournal");

            //migrationBuilder.RenameTable(
            //    name: "KindnessJournal",
            //    newName: "KindnessJournals");

            //migrationBuilder.RenameIndex(
            //    name: "IX_KindnessJournal_StudentId",
            //    table: "KindnessJournal",
            //    newName: "IX_KindnessJournal_StudentId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_KindnessJournals",
            //    table: "KindnessJournals",
            //    column: "JournalId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_KindnessJournal_Students_StudentId",
            //    table: "KindnessJournal",
            //    column: "StudentId",
            //    principalTable: "Students",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
