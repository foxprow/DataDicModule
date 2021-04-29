using ENet.DataDic.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ENet.DataDic
{
    [RemoteService]
    [Route("api")]
    [Authorize]
    public class DataDictionaryController : DataDicController
    {
        private readonly IDataDictionaryService _dataDictionaryService;

        public DataDictionaryController(IDataDictionaryService dataDictionaryService)
        {
            _dataDictionaryService = dataDictionaryService;
        }

        [HttpPost("data-dic")]
        public async Task<ActionResult> AddDataDicAsync(DataDictionaryAddOrUpdateDto input)
        {
            await _dataDictionaryService.AddDataDicAsync(input);
            return Ok();
        }

        [HttpPut("data-dic/{id}")]
        public async Task<ActionResult> UpdateDataDicAsync(int id, DataDictionaryAddOrUpdateDto input)
        {
            await _dataDictionaryService.UpdateDataDicAsync(id, input);
            return Ok();
        }

        [HttpDelete("data-dic/{id}")]
        public async Task<ActionResult> DeleteDataDicAsync(int id)
        {
            await _dataDictionaryService.DeleteDataDicAsync(id);
            return Ok();
        }

        [HttpGet("data-dic/{name}/{key}")]
        public async Task<ActionResult> ExsitsAsync(string name, string key)
        {
            return Ok(await _dataDictionaryService.ExsitsAsync(name, key));
        }

        [HttpGet("data-dic/info/{id}")]
        public async Task<ActionResult> GetDataDicInfoByIdAsync(int id)
        {
            return Ok(await _dataDictionaryService.GetDataDicInfoByIdAsync(id));
        }

        [HttpGet("data-dic/info/name/{name}")]
        public async Task<ActionResult> GetDataDicInfoByNameAsync(string name)
        {
            return Ok(await _dataDictionaryService.GetDataDicInfoByNameAsync(name));
        }

        [HttpGet("data-dic/info/key/{key}")]
        public async Task<ActionResult> GetDataDicInfoByKeyAsync(string key)
        {
            return Ok(await _dataDictionaryService.GetDataDicInfoByKeyAsync(key));
        }

        [HttpGet("data-dic/info/{name}/{key}")]
        public async Task<ActionResult> GetDataDicInfoByNameKeyAsync(string name, string key)
        {
            return Ok(await _dataDictionaryService.GetDataDicInfoByNameKeyAsync(name, key));
        }

        [HttpGet("data-dic")]
        public async Task<ActionResult> GetDataDicListAsync()
        {
            return Ok(await _dataDictionaryService.GetDataDicListAsync());
        }

        [HttpGet("data-dic/query")]
        public async Task<ActionResult> GetDataDicPageListAsync(DataDictionaryQueryDto input)
        {
            return Ok(await _dataDictionaryService.GetDataDicPageListAsync(input));
        }
    }
}
