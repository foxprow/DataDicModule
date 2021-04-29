using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ENet.DataDic.EntityFrameworkCore
{
    [ConnectionStringName(DataDicDbProperties.ConnectionStringName)]
    public class DataDicDbContext : AbpDbContext<DataDicDbContext>, IDataDicDbContext
    {
        public DbSet<DataDictionary> DataDictionaries { get; set; }

        public DataDicDbContext(DbContextOptions<DataDicDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDataDic();
        }
    }
}