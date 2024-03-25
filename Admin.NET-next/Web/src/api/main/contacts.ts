import request from '/@/utils/request';
enum Api {
  AddContacts = '/api/contacts/add',
  DeleteContacts = '/api/contacts/delete',
  UpdateContacts = '/api/contacts/update',
  PageContacts = '/api/contacts/page',
  DetailContacts = '/api/contacts/detail',
}

// 增加客户联系人资料
export const addContacts = (params?: any) =>
	request({
		url: Api.AddContacts,
		method: 'post',
		data: params,
	});

// 删除客户联系人资料
export const deleteContacts = (params?: any) => 
	request({
			url: Api.DeleteContacts,
			method: 'post',
			data: params,
		});

// 编辑客户联系人资料
export const updateContacts = (params?: any) => 
	request({
			url: Api.UpdateContacts,
			method: 'post',
			data: params,
		});

// 分页查询客户联系人资料
export const pageContacts = (params?: any) => 
	request({
			url: Api.PageContacts,
			method: 'post',
			data: params,
		});

// 详情客户联系人资料
export const detailContacts = (id: any) => 
	request({
			url: Api.DetailContacts,
			method: 'get',
			data: { id },
		});


