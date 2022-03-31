﻿// <auto-generated />
using System;
using System.Reflection;
using EFCoreMovies.Entities.Keyless;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace EFCoreMovies.CompiledModels
{
    internal partial class MovieWithCountsEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "EFCoreMovies.Entities.Keyless.MovieWithCounts",
                typeof(MovieWithCounts),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(MovieWithCounts).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MovieWithCounts).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var amountActors = runtimeEntityType.AddProperty(
                "AmountActors",
                typeof(int),
                propertyInfo: typeof(MovieWithCounts).GetProperty("AmountActors", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MovieWithCounts).GetField("<AmountActors>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            amountActors.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var amountCinemas = runtimeEntityType.AddProperty(
                "AmountCinemas",
                typeof(int),
                propertyInfo: typeof(MovieWithCounts).GetProperty("AmountCinemas", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MovieWithCounts).GetField("<AmountCinemas>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            amountCinemas.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var amountGenres = runtimeEntityType.AddProperty(
                "AmountGenres",
                typeof(int),
                propertyInfo: typeof(MovieWithCounts).GetProperty("AmountGenres", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MovieWithCounts).GetField("<AmountGenres>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            amountGenres.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var title = runtimeEntityType.AddProperty(
                "Title",
                typeof(string),
                propertyInfo: typeof(MovieWithCounts).GetProperty("Title", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MovieWithCounts).GetField("<Title>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 150);
            title.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewDefinitionSql", null);
            runtimeEntityType.AddAnnotation("Relational:ViewName", "MoviesWithCounts");
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}