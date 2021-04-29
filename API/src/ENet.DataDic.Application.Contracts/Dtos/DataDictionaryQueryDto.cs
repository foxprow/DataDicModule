using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ENet.DataDic.Dtos
{
    public class DataDictionaryQueryDto : PagedResultRequestDto
    {
        public string Name { get; set; }

        public string Key { get; set; }
    }
}
