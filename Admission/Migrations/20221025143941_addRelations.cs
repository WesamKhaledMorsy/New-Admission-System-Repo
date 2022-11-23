using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admission.Migrations
{
    public partial class addRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Universities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoundId",
                table: "Tracks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InterviewerId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoundId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrackId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Statuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Rounds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Interviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InterviewerId",
                table: "Interviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Interviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Interviewers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Grades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Genders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentStudent",
                columns: table => new
                {
                    DocumentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStudent", x => new { x.DocumentsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_DocumentStudent_Documents_DocumentsId",
                        column: x => x.DocumentsId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Universities_AdminId",
                table: "Universities",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AdminId",
                table: "Tracks",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_RoundId",
                table: "Tracks",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdminId",
                table: "Students",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GenderId",
                table: "Students",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_InterviewerId",
                table: "Students",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoundId",
                table: "Students",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StatusId",
                table: "Students",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TrackId",
                table: "Students",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_AdminId",
                table: "Statuses",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_AdminId",
                table: "Rounds",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_AdminId",
                table: "Interviews",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_StudentId",
                table: "Interviews",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewers_AdminId",
                table: "Interviewers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AdminId",
                table: "Grades",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_AdminId",
                table: "Genders",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AdminId",
                table: "Documents",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStudent_StudentsId",
                table: "DocumentStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Admins_AdminId",
                table: "Documents",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Admins_AdminId",
                table: "Genders",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Admins_AdminId",
                table: "Grades",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewers_Admins_AdminId",
                table: "Interviewers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Admins_AdminId",
                table: "Interviews",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Students_StudentId",
                table: "Interviews",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Admins_AdminId",
                table: "Rounds",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Admins_AdminId",
                table: "Statuses",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Admins_AdminId",
                table: "Students",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Interviewers_InterviewerId",
                table: "Students",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rounds_RoundId",
                table: "Students",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Statuses_StatusId",
                table: "Students",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Admins_AdminId",
                table: "Tracks",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Rounds_RoundId",
                table: "Tracks",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Admins_AdminId",
                table: "Universities",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Admins_AdminId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Admins_AdminId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Admins_AdminId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviewers_Admins_AdminId",
                table: "Interviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Admins_AdminId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Students_StudentId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Admins_AdminId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Admins_AdminId",
                table: "Statuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Admins_AdminId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Genders_GenderId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Interviewers_InterviewerId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rounds_RoundId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Statuses_StatusId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tracks_TrackId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Admins_AdminId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Rounds_RoundId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Admins_AdminId",
                table: "Universities");

            migrationBuilder.DropTable(
                name: "DocumentStudent");

            migrationBuilder.DropIndex(
                name: "IX_Universities_AdminId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AdminId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_RoundId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Students_AdminId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GenderId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_InterviewerId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoundId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StatusId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TrackId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_AdminId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_AdminId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_AdminId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_StudentId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviewers_AdminId",
                table: "Interviewers");

            migrationBuilder.DropIndex(
                name: "IX_Grades_AdminId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Genders_AdminId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AdminId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "InterviewerId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewerId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Interviewers");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Documents");
        }
    }
}
