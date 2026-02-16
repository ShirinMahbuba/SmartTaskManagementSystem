using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSTMS.Migrations
{
    /// <inheritdoc />
    public partial class mg02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_ProjectTaskStatus_ProjectTaskStatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskPriority_TaskPriorityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TeamMember_TeamMemberId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_Task_ProjectTaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Task_ProjectTaskId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Task_DependsOnTaskId",
                table: "TaskDependency");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_Task_ProjectTaskId",
                table: "TaskDependency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "ProjectTask");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TeamMemberId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_TeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TaskPriorityId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_TaskPriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ProjectTaskStatusId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectTaskStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ProjectId",
                table: "ProjectTask",
                newName: "IX_ProjectTask_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_ProjectTaskStatus_ProjectTaskStatusId",
                table: "ProjectTask",
                column: "ProjectTaskStatusId",
                principalTable: "ProjectTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_TaskPriority_TaskPriorityId",
                table: "ProjectTask",
                column: "TaskPriorityId",
                principalTable: "TaskPriority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTask_TeamMember_TeamMemberId",
                table: "ProjectTask",
                column: "TeamMemberId",
                principalTable: "TeamMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_ProjectTask_ProjectTaskId",
                table: "TaskAttachments",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_ProjectTask_ProjectTaskId",
                table: "TaskComments",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_ProjectTask_DependsOnTaskId",
                table: "TaskDependency",
                column: "DependsOnTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_ProjectTask_ProjectTaskId",
                table: "TaskDependency",
                column: "ProjectTaskId",
                principalTable: "ProjectTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_ProjectTaskStatus_ProjectTaskStatusId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_Project_ProjectId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_TaskPriority_TaskPriorityId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTask_TeamMember_TeamMemberId",
                table: "ProjectTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAttachments_ProjectTask_ProjectTaskId",
                table: "TaskAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_ProjectTask_ProjectTaskId",
                table: "TaskComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_ProjectTask_DependsOnTaskId",
                table: "TaskDependency");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDependency_ProjectTask_ProjectTaskId",
                table: "TaskDependency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTask",
                table: "ProjectTask");

            migrationBuilder.RenameTable(
                name: "ProjectTask",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_TeamMemberId",
                table: "Task",
                newName: "IX_Task_TeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_TaskPriorityId",
                table: "Task",
                newName: "IX_Task_TaskPriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectTaskStatusId",
                table: "Task",
                newName: "IX_Task_ProjectTaskStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "Task",
                newName: "IX_Task_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ProjectTaskStatus_ProjectTaskStatusId",
                table: "Task",
                column: "ProjectTaskStatusId",
                principalTable: "ProjectTaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskPriority_TaskPriorityId",
                table: "Task",
                column: "TaskPriorityId",
                principalTable: "TaskPriority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TeamMember_TeamMemberId",
                table: "Task",
                column: "TeamMemberId",
                principalTable: "TeamMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAttachments_Task_ProjectTaskId",
                table: "TaskAttachments",
                column: "ProjectTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Task_ProjectTaskId",
                table: "TaskComments",
                column: "ProjectTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Task_DependsOnTaskId",
                table: "TaskDependency",
                column: "DependsOnTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDependency_Task_ProjectTaskId",
                table: "TaskDependency",
                column: "ProjectTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
