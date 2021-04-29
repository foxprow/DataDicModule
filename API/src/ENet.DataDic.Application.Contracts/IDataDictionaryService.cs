using ENet.DataDic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ENet.DataDic
{
    public interface IDataDictionaryService : IApplicationService
    {
        Task AddDataDicAsync(DataDictionaryAddOrUpdateDto input);

        Task UpdateDataDicAsync(int id, DataDictionaryAddOrUpdateDto input);

        Task DeleteDataDicAsync(int id);

        Task<bool> ExsitsAsync(string name, string key);

        Task<DataDictionaryInfoDto> GetDataDicInfoByIdAsync(int id);

        Task<DataDictionaryInfoDto> GetDataDicInfoByNameAsync(string name);

        Task<DataDictionaryInfoDto> GetDataDicInfoByKeyAsync(string key);

        Task<DataDictionaryInfoDto> GetDataDicInfoByNameKeyAsync(string name, string key);

        Task<List<DataDictionaryListDto>> GetDataDicListAsync();

        Task<IPagedResult<DataDictionaryListDto>> GetDataDicPageListAsync(DataDictionaryQueryDto input);
    }
}
