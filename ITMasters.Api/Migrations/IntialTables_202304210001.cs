using FluentMigrator;

namespace ITMasters.Api.Migrations;

[Migration(202304210001)]
public class InitialTables_202304210001:Migration
{
    public override void Up()
    {
        Create.Table("Posts")
            .WithColumn("Id").AsGuid().NotNullable()
            .PrimaryKey().WithDefaultValue("NEWID()")
            .WithColumn("Title").AsString(60).NotNullable()
            .WithColumn("Content").AsString(5000).NotNullable()
            .WithColumn("Image").AsString().Nullable()
            .WithColumn("PostDate").AsDateTime().NotNullable()
            .WithColumn("CreateBy").AsString(50).NotNullable();

        Create.Table("Comments")
            .WithColumn("Id").AsGuid().NotNullable()
            .PrimaryKey().WithDefaultValue("NEWID()")
            .WithColumn("Content").AsString(300).Nullable()
            .WithColumn("UserName").AsString(50).Nullable()
            .WithColumn("CommentDate").AsDateTime().NotNullable()
            .WithColumn("PostId").AsGuid().NotNullable()
                .ForeignKey("Posts", "Id")
                .OnDelete(System.Data.Rule.Cascade);

    }

    public override void Down()
    {
        Delete.Table("Posts");
        Delete.Table("Comments");
    }
}