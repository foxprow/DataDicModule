using ENet.DataDic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ENet.DataDic
{
    public abstract class DataDicController : AbpController
    {
        protected DataDicController()
        {
            LocalizationResource = typeof(DataDicResource);
        }
    }
}
