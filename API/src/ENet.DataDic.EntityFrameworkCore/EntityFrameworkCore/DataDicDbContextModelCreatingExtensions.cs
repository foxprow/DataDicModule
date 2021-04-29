using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ENet.DataDic.EntityFrameworkCore
{
    public static class DataDicDbContextModelCreatingExtensions
    {
        public static void ConfigureDataDic(
            this ModelBuilder builder,
            Action<DataDicModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DataDicModelBuilderConfigurationOptions(
                DataDicDbProperties.DbTablePrefix,
                DataDicDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<DataDictionary>(b =>
            {
                b.ToTable("ZkDataDic");
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasColumnType("varchar(30)").IsRequired();
                b.Property(x => x.Key).HasColumnType("varchar(30)").IsRequired();
            });
        }
    }
}