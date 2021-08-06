using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InitCbSendMessageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCodeBookDefaultValue("Cb_SendMessageType");
            migrationBuilder.InsertData("Cb_SendMessageType",
              new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
              new object[] { Guid.NewGuid(), false, true, true, "EMAIL", "EMAIL", "EMAIL", true, 1 });
            migrationBuilder.InsertData("Cb_SendMessageType",
              new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
            new object[] { Guid.NewGuid(), false, true, true, "SMS", "SMS", "SMS", true, 2 });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
