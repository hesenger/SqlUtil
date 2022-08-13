using FluentMigrator;
using SqlUtil.Schema;
using SqlUtil.Tests.Models;

namespace SqlUtil.Tests.Migrations;

[Migration(202208131042)]
public class CreateUserGroupTables : Migration
{
    public override void Up()
    {
        var names = new DefaultNamingConvention();
        var group = new Group();
        var user = new User();

        Create.Table(names.Pluralize(group.GetType().Name))
            .WithColumn(nameof(group.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(group.Name)).AsString();

        Create.Table(names.Pluralize(user.GetType().Name))
            .WithColumn(nameof(user.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(user.Name)).AsString()
            .WithColumn(nameof(user.Group) + "Id").AsInt32()
                .ForeignKey(names.Pluralize(group.GetType().Name), nameof(group.Id));
    }

    public override void Down()
    {
        var names = new DefaultNamingConvention();
        var group = new Group();
        var user = new User();

        Delete.Table(names.Pluralize(user.GetType().Name));
        Delete.Table(names.Pluralize(group.GetType().Name));
    }
}