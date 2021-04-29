using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ENet.DataDic.EntityFrameworkCore
{
    public class DataDicHttpApiHostMigrationsDbContext : AbpDbContext<DataDicHttpApiHostMigrationsDbContext>
    {
        public DataDicHttpApiHostMigrationsDbContext(DbContextOptions<DataDicHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureDataDic();
        }
    }
}
