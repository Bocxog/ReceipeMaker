using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Receipe.Data.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delicious",
                table: "Receipes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Healthy",
                table: "Receipes",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PrepareTime",
                table: "Receipes",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Optional = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ReceipeId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    VolumeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Receipes_ReceipeId",
                        column: x => x.ReceipeId,
                        principalTable: "Receipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ReceipeId",
                table: "Requirements",
                column: "ReceipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ResourceId",
                table: "Requirements",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropColumn(
                name: "Delicious",
                table: "Receipes");

            migrationBuilder.DropColumn(
                name: "Healthy",
                table: "Receipes");

            migrationBuilder.DropColumn(
                name: "PrepareTime",
                table: "Receipes");
        }
    }
}
