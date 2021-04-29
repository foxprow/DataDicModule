import request from '@/utils/request'

export function addDataDic(data) {
    return request({
        url: '/data-dic',
        method: 'post',
        data
    })
}

export function updateDataDic(id, data) {
    return request({
        url: '/data-dic/' + id,
        method: 'put',
        data
    })
}

export function deleteDataDic(id) {
    return request({
        url: '/data-dic/' + id,
        method: 'delete'
    })
}

export function getDataDicInfo(id) {
    return request({
        url: '/data-dic/info/' + id,
        method: 'get'
    })
}

export function getDataDics(searchForm) {
    return request({
        url: '/data-dic/query',
        method: 'get',
        params: searchForm
    })
}