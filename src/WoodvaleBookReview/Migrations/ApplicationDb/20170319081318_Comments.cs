using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WoodvaleBookReview.Migrations.ApplicationDb
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reviews_ReviewID",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_ReviewID",
                table: "Comment",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ReviewID",
                table: "Comment",
                newName: "IX_Comments_ReviewID");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_ReviewID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reviews_ReviewID",
                table: "Comments",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReviewID",
                table: "Comments",
                newName: "IX_Comment_ReviewID");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");
        }
    }
}
