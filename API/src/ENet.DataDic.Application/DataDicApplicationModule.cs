using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace ENet.DataDic
{
    [DependsOn(
        typeof(DataDicDomainModule),
        typeof(DataDicApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DataDicApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DataDicApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<DataDicApplicationModule>(validate: true);
            });
        }
    }
}
