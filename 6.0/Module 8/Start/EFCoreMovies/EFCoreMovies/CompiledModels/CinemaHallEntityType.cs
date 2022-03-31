﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace EFCoreMovies.CompiledModels
{
    internal partial class CinemaHallEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "EFCoreMovies.Entities.CinemaHall",
                typeof(CinemaHall),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(CinemaHall).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var cinemaHallType = runtimeEntityType.AddProperty(
                "CinemaHallType",
                typeof(CinemaHallType),
                propertyInfo: typeof(CinemaHall).GetProperty("CinemaHallType", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<CinemaHallType>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                providerPropertyType: typeof(string));
            cinemaHallType.AddAnnotation("Relational:DefaultValue", CinemaHallType.TwoDimensions);
            cinemaHallType.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var cost = runtimeEntityType.AddProperty(
                "Cost",
                typeof(decimal),
                propertyInfo: typeof(CinemaHall).GetProperty("Cost", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<Cost>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                precision: 9,
                scale: 2);
            cost.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var currency = runtimeEntityType.AddProperty(
                "Currency",
                typeof(Currency),
                propertyInfo: typeof(CinemaHall).GetProperty("Currency", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<Currency>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new CurrencyToSymbolConverter());
            currency.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var theCinemaId = runtimeEntityType.AddProperty(
                "TheCinemaId",
                typeof(int),
                propertyInfo: typeof(CinemaHall).GetProperty("TheCinemaId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<TheCinemaId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            theCinemaId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { theCinemaId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("TheCinemaId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Restrict,
                required: true);

            var cinema = declaringEntityType.AddNavigation("Cinema",
                runtimeForeignKey,
                onDependent: true,
                typeof(Cinema),
                propertyInfo: typeof(CinemaHall).GetProperty("Cinema", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<Cinema>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var cinemaHalls = principalEntityType.AddNavigation("CinemaHalls",
                runtimeForeignKey,
                onDependent: false,
                typeof(HashSet<CinemaHall>),
                propertyInfo: typeof(Cinema).GetProperty("CinemaHalls", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Cinema).GetField("<CinemaHalls>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeSkipNavigation CreateSkipNavigation1(RuntimeEntityType declaringEntityType, RuntimeEntityType targetEntityType, RuntimeEntityType joinEntityType)
        {
            var skipNavigation = declaringEntityType.AddSkipNavigation(
                "Movies",
                targetEntityType,
                joinEntityType.FindForeignKey(
                    new[] { joinEntityType.FindProperty("CinemaHallsId") },
                    declaringEntityType.FindKey(new[] { declaringEntityType.FindProperty("Id") }),
                    declaringEntityType),
                true,
                false,
                typeof(HashSet<Movie>),
                propertyInfo: typeof(CinemaHall).GetProperty("Movies", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(CinemaHall).GetField("<Movies>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var inverse = targetEntityType.FindSkipNavigation("CinemaHalls");
            if (inverse != null)
            {
                skipNavigation.Inverse = inverse;
                inverse.Inverse = skipNavigation;
            }

            return skipNavigation;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "CinemaHalls");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
