import request from '/@/utils/request';
enum Api {
  AddBusinessDictionaryConfiguration = '/api/businessDictionaryConfiguration/add',
  DeleteBusinessDictionaryConfiguration = '/api/businessDictionaryConfiguration/delete',
  UpdateBusinessDictionaryConfiguration = '/api/businessDictionaryConfiguration/update',
  PageBusinessDictionaryConfiguration = '/api/businessDictionaryConfiguration/page',
  DetailBusinessDictionaryConfiguration = '/api/businessDictionaryConfiguration/detail',
}

// 增加业务字典配置表
export const addBusinessDictionaryConfiguration = (params?: any) =>
	request({
		url: Api.AddBusinessDictionaryConfiguration,
		method: 'post',
		data: params,
	});

// 删除业务字典配置表
export const deleteBusinessDictionaryConfiguration = (params?: any) => 
	request({
			url: Api.DeleteBusinessDictionaryConfiguration,
			method: 'post',
			data: params,
		});

// 编辑业务字典配置表
export const updateBusinessDictionaryConfiguration = (params?: any) => 
	request({
			url: Api.UpdateBusinessDictionaryConfiguration,
			method: 'post',
			data: params,
		});

// 分页查询业务字典配置表
export const pageBusinessDictionaryConfiguration = (params?: any) => 
	request({
			url: Api.PageBusinessDictionaryConfiguration,
			method: 'post',
			data: params,
		});

// 详情业务字典配置表
export const detailBusinessDictionaryConfiguration = (id: any) => 
	request({
			url: Api.DetailBusinessDictionaryConfiguration,
			method: 'get',
			data: { id },
		});


