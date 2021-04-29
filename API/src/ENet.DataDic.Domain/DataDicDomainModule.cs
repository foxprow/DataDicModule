using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ENet.DataDic
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DataDicDomainSharedModule)
    )]
    public class DataDicDomainModule : AbpModule
    {

    }
}
