using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ENet.DataDic
{
    public class DataDictionary : Entity<int>, IMultiTenant
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public Guid? TenantId { get; set; }
    }
}
