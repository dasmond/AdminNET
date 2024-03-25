import request from '/@/utils/request';
enum Api {
  AddBusinessDictionaryConfigurationDetails = '/api/businessDictionaryConfigurationDetails/add',
  DeleteBusinessDictionaryConfigurationDetails = '/api/businessDictionaryConfigurationDetails/delete',
  UpdateBusinessDictionaryConfigurationDetails = '/api/businessDictionaryConfigurationDetails/update',
  PageBusinessDictionaryConfigurationDetails = '/api/businessDictionaryConfigurationDetails/page',
  DetailBusinessDictionaryConfigurationDetails = '/api/businessDictionaryConfigurationDetails/detail',
}

// 增加业务字典配置详情表
export const addBusinessDictionaryConfigurationDetails = (params?: any) =>
	request({
		url: Api.AddBusinessDictionaryConfigurationDetails,
		method: 'post',
		data: params,
	});

// 删除业务字典配置详情表
export const deleteBusinessDictionaryConfigurationDetails = (params?: any) => 
	request({
			url: Api.DeleteBusinessDictionaryConfigurationDetails,
			method: 'post',
			data: params,
		});

// 编辑业务字典配置详情表
export const updateBusinessDictionaryConfigurationDetails = (params?: any) => 
	request({
			url: Api.UpdateBusinessDictionaryConfigurationDetails,
			method: 'post',
			data: params,
		});

// 分页查询业务字典配置详情表
export const pageBusinessDictionaryConfigurationDetails = (params?: any) => 
	request({
			url: Api.PageBusinessDictionaryConfigurationDetails,
			method: 'post',
			data: params,
		});

// 详情业务字典配置详情表
export const detailBusinessDictionaryConfigurationDetails = (id: any) => 
	request({
			url: Api.DetailBusinessDictionaryConfigurationDetails,
			method: 'get',
			data: { id },
		});


