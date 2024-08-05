using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ModifyUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.Sql("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Users]') AND type in (N'PK')) ALTER TABLE [Users] DROP CONSTRAINT [PK_Users]");

            // Drop foreign key constraints referencing this column (if any exist)
            migrationBuilder.Sql(@"
            DECLARE @SQL NVARCHAR(MAX) = N'';
            SELECT @SQL += N'
            ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id))
            + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + 
            ' DROP CONSTRAINT ' + QUOTENAME(name) + ';'
            FROM sys.foreign_keys
            WHERE referenced_object_id = OBJECT_ID('Users');
            EXEC sp_executesql @SQL;
        ");

            // Alter the column
            migrationBuilder.Sql("ALTER TABLE [Users] ALTER COLUMN [Id] nvarchar(450) NOT NULL");

            // Add the primary key constraint back
            migrationBuilder.Sql("ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY ([Id])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This is a destructive change, so we can't easily revert it.
            // If you need to revert, you'd need to handle data conversion carefully.
            migrationBuilder.Sql("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PK_Users]') AND type in (N'PK')) ALTER TABLE [Users] DROP CONSTRAINT [PK_Users]");
            migrationBuilder.Sql("ALTER TABLE [Users] ALTER COLUMN [Id] int NOT NULL");
            migrationBuilder.Sql("ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY ([Id])");
        }
    }
}
