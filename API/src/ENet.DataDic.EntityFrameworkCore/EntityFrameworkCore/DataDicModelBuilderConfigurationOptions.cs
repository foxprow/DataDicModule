using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ENet.DataDic.EntityFrameworkCore
{
    public class DataDicModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DataDicModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}