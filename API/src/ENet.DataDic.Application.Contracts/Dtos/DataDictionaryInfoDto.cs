﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ENet.DataDic.Dtos
{
    public class DataDictionaryInfoDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
