using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ENet.DataDic
{
    [DependsOn(
        typeof(DataDicDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DataDicApplicationContractsModule : AbpModule
    {

    }
}
