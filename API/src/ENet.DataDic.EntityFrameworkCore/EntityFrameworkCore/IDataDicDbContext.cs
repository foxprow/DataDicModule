using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ENet.DataDic.EntityFrameworkCore
{
    [ConnectionStringName(DataDicDbProperties.ConnectionStringName)]
    public interface IDataDicDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}