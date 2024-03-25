import request from '/@/utils/request';
enum Api {
  AddProcessingFactoryContacts = '/api/processingFactoryContacts/add',
  DeleteProcessingFactoryContacts = '/api/processingFactoryContacts/delete',
  UpdateProcessingFactoryContacts = '/api/processingFactoryContacts/update',
  PageProcessingFactoryContacts = '/api/processingFactoryContacts/page',
  DetailProcessingFactoryContacts = '/api/processingFactoryContacts/detail',
}

// 增加加工厂联系人资料
export const addProcessingFactoryContacts = (params?: any) =>
	request({
		url: Api.AddProcessingFactoryContacts,
		method: 'post',
		data: params,
	});

// 删除加工厂联系人资料
export const deleteProcessingFactoryContacts = (params?: any) => 
	request({
			url: Api.DeleteProcessingFactoryContacts,
			method: 'post',
			data: params,
		});

// 编辑加工厂联系人资料
export const updateProcessingFactoryContacts = (params?: any) => 
	request({
			url: Api.UpdateProcessingFactoryContacts,
			method: 'post',
			data: params,
		});

// 分页查询加工厂联系人资料
export const pageProcessingFactoryContacts = (params?: any) => 
	request({
			url: Api.PageProcessingFactoryContacts,
			method: 'post',
			data: params,
		});

// 详情加工厂联系人资料
export const detailProcessingFactoryContacts = (id: any) => 
	request({
			url: Api.DetailProcessingFactoryContacts,
			method: 'get',
			data: { id },
		});


