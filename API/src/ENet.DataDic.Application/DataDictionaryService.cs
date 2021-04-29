using ENet.DataDic.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ENet.DataDic
{
    public class DataDictionaryService : ApplicationService, IDataDictionaryService
    {
        private readonly IDataDictionaryRepository _dataDictionaryRepository;

        public DataDictionaryService(IDataDictionaryRepository dataDictionaryRepository)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
        }

        public async Task AddDataDicAsync(DataDictionaryAddOrUpdateDto input)
        {
            if (await ExsitsAsync(input.Name, input.Key))
            {
                throw new UserFriendlyException($"名称：{input.Name}，键：{input.Key}，已存在");
            }

            var entity = ObjectMapper.Map<DataDictionaryAddOrUpdateDto, DataDictionary>(input);
            entity.TenantId = CurrentTenant.Id;
            await _dataDictionaryRepository.InsertAsync(entity);
        }

        public async Task UpdateDataDicAsync(int id, DataDictionaryAddOrUpdateDto input)
        {
            if (await ExsitsAsync(input.Name, input.Key, id))
            {
                throw new UserFriendlyException($"名称：{input.Name}，键：{input.Key}，已存在");
            }

            var entity = await _dataDictionaryRepository.FindByIdAsync(id);
            ObjectMapper.Map(input, entity);
            await _dataDictionaryRepository.UpdateAsync(entity);
        }

        public async Task DeleteDataDicAsync(int id)
        {
            var entity = await _dataDictionaryRepository.FindByIdAsync(id);
            await _dataDictionaryRepository.DeleteAsync(entity);
        }

        public async Task<bool> ExsitsAsync(string name, string key)
        {
            return await ExsitsAsync(name, key, null);
        }

        private async Task<bool> ExsitsAsync(string name, string key, int? id)
        {
            return await _dataDictionaryRepository.ExistsAsync(name, key, id);
        }

        public async Task<DataDictionaryInfoDto> GetDataDicInfoByIdAsync(int id)
        {
            var entity = await _dataDictionaryRepository.FindByIdAsync(id);
            return ObjectMapper.Map<DataDictionary, DataDictionaryInfoDto>(entity);
        }

        public async Task<DataDictionaryInfoDto> GetDataDicInfoByNameAsync(string name)
        {
            var entity = await _dataDictionaryRepository.FindByNameAsync(name);
            return ObjectMapper.Map<DataDictionary, DataDictionaryInfoDto>(entity);
        }

        public async Task<DataDictionaryInfoDto> GetDataDicInfoByKeyAsync(string key)
        {
            var entity = await _dataDictionaryRepository.FindByKeyAsync(key);
            return ObjectMapper.Map<DataDictionary, DataDictionaryInfoDto>(entity);
        }

        public async Task<DataDictionaryInfoDto> GetDataDicInfoByNameKeyAsync(string name, string key)
        {
            var entity = await _dataDictionaryRepository.FindByNameKeyAsync(name, key);
            return ObjectMapper.Map<DataDictionary, DataDictionaryInfoDto>(entity);
        }

        public async Task<List<DataDictionaryListDto>> GetDataDicListAsync()
        {
            var list = await _dataDictionaryRepository.GetDataDictionaryListAsync();
            return ObjectMapper.Map<List<DataDictionary>, List<DataDictionaryListDto>>(list);
        }

        public async Task<IPagedResult<DataDictionaryListDto>> GetDataDicPageListAsync(DataDictionaryQueryDto input)
        {
            var count = await _dataDictionaryRepository.GetCountAsync(input.Name, input.Key);
            var data = await _dataDictionaryRepository.GetDataDictionaryPageListAsync(input.Name, input.Key, input.SkipCount, input.MaxResultCount);
            return new PagedResultDto<DataDictionaryListDto>(count, ObjectMapper.Map<List<DataDictionary>, List<DataDictionaryListDto>>(data));
        }
    }
}
