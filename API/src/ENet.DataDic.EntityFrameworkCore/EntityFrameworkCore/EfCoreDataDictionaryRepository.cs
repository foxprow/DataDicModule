using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ENet.DataDic.EntityFrameworkCore
{
    public class EfCoreDataDictionaryRepository : EfCoreRepository<IDataDicDbContext, DataDictionary, int>, IDataDictionaryRepository
    {
        public EfCoreDataDictionaryRepository(IDbContextProvider<IDataDicDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<DataDictionary> FindByIdAsync(int id)
        {
            return await (await GetDbSetAsync()).FindAsync(id);
        }

        public async Task<DataDictionary> FindByNameAsync(string name)
        {
            return await (await GetDbSetAsync()).Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<DataDictionary> FindByKeyAsync(string key)
        {
            return await (await GetDbSetAsync()).Where(x => x.Key == key).FirstOrDefaultAsync();
        }

        public async Task<DataDictionary> FindByNameKeyAsync(string name, string key)
        {
            return await (await GetDbSetAsync()).Where(x => x.Name == name && x.Key == key).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(string name, string key, int? id)
        {
            return await (await GetDbSetAsync()).WhereIf(!string.IsNullOrEmpty(name), x => x.Name == name)
                    .WhereIf(!string.IsNullOrEmpty(key), x => x.Key == key)
                    .WhereIf(id != null, x => x.Id != id.Value)
                    .AnyAsync();
        }

        public async Task<List<DataDictionary>> GetDataDictionaryListAsync()
        {
            return await (await GetDbSetAsync()).ToListAsync();
        }

        public async Task<long> GetCountAsync(string name, string key)
        {
            var query = await GetDataDictionaryQueryable(name, key);
            return await query.LongCountAsync();
        }

        public async Task<List<DataDictionary>> GetDataDictionaryPageListAsync(string name, string key, int skipCount, int maxResultCount)
        {
            var query = await GetDataDictionaryQueryable(name, key);
            return await query.Skip(skipCount).Take((skipCount + 1) * maxResultCount).ToListAsync();
        }

        private async Task<IQueryable<DataDictionary>> GetDataDictionaryQueryable(string name, string key)
        {
            return (await GetDbSetAsync()).WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name))
                   .WhereIf(!string.IsNullOrEmpty(key), x => x.Key.Contains(key)).AsQueryable();
        }
    }
}
