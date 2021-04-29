using ENet.DataDic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ENet.DataDic.Permissions
{
    public class DataDicPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DataDicPermissions.GroupName, L("Permission:DataDic"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DataDicResource>(name);
        }
    }
}