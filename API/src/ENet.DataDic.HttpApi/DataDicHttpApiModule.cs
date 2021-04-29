using Localization.Resources.AbpUi;
using ENet.DataDic.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ENet.DataDic
{
    [DependsOn(
        typeof(DataDicApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DataDicHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DataDicHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DataDicResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
