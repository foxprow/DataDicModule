using System;
using System.Collections.Generic;
using System.Text;

namespace ENet.DataDic.Dtos
{
    public class DataDictionaryAddOrUpdateDto
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
