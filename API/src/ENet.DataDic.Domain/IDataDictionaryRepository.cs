using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ENet.DataDic
{
    public interface IDataDictionaryRepository : IBasicRepository<DataDictionary, int>
    {
        Task<DataDictionary> FindByIdAsync(int id);

        Task<DataDictionary> FindByNameAsync(string name);

        Task<DataDictionary> FindByKeyAsync(string key);

        Task<DataDictionary> FindByNameKeyAsync(string name, string key);

        Task<bool> ExistsAsync(string name, string key, int? id);

        Task<List<DataDictionary>> GetDataDictionaryListAsync();

        Task<long> GetCountAsync(string name, string key);

        Task<List<DataDictionary>> GetDataDictionaryPageListAsync(string name, string key, int skipCount, int maxResultCount);
    }
}
