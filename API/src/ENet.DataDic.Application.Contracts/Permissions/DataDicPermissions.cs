using Volo.Abp.Reflection;

namespace ENet.DataDic.Permissions
{
    public class DataDicPermissions
    {
        public const string GroupName = "DataDic";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DataDicPermissions));
        }
    }
}