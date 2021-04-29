using ENet.DataDic.Localization;
using Volo.Abp.Application.Services;

namespace ENet.DataDic
{
    public abstract class DataDicAppService : ApplicationService
    {
        protected DataDicAppService()
        {
            LocalizationResource = typeof(DataDicResource);
            ObjectMapperContext = typeof(DataDicApplicationModule);
        }
    }
}
