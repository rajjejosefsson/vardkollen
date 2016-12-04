namespace CareCheck.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedTodoListTable : DbMigration
    {
        public override void Up()
        {

            Sql(@"


           INSERT INTO TodoList(TaskId, ScheduleId, Isdone) VALUES (1, 1, 1);
           INSERT INTO TodoList(TaskId, ScheduleId, Isdone) VALUES (2, 2, 0);

           INSERT INTO TodoList(TaskId, ScheduleId, Isdone) VALUES (4, 3, 0);
           INSERT INTO TodoList(TaskId, ScheduleId, Isdone) VALUES (5, 4, 0);

           INSERT INTO TodoList(TaskId, ScheduleId, Isdone) VALUES (5, 5, 0);

");

        }

        public override void Down()
        {
        }
    }
}
