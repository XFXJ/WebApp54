namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RowVersion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instructor", newName: "Person");
            AddColumn("dbo.Department", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime());
            AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime());
            DropTable("dbo.Student");
            AlterStoredProcedure(
                "dbo.Department_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Department]([Name], [Budget], [StartDate], [InstructorID])
                      VALUES (@Name, @Budget, @StartDate, @InstructorID)
                      
                      DECLARE @DepartmentID int
                      SELECT @DepartmentID = [DepartmentID]
                      FROM [dbo].[Department]
                      WHERE @@ROWCOUNT > 0 AND [DepartmentID] = scope_identity()
                      
                      SELECT t0.[DepartmentID], t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            AlterStoredProcedure(
                "dbo.Department_Update",
                p => new
                    {
                        DepartmentID = p.Int(),
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[Department]
                      SET [Name] = @Name, [Budget] = @Budget, [StartDate] = @StartDate, [InstructorID] = @InstructorID
                      WHERE (([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            AlterStoredProcedure(
                "dbo.Department_Delete",
                p => new
                    {
                        DepartmentID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Department]
                      WHERE (([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Person", "HireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Person", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Person", "Discriminator");
            DropColumn("dbo.Person", "EnrollmentDate");
            DropColumn("dbo.Department", "RowVersion");
            RenameTable(name: "dbo.Person", newName: "Instructor");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
