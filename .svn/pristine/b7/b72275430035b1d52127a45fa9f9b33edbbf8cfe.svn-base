import request from '/@/utils/request';
enum Api {
  AddTAclFunction = '/api/tAclFunction/add',
  DeleteTAclFunction = '/api/tAclFunction/delete',
  UpdateTAclFunction = '/api/tAclFunction/update',
  PageTAclFunction = '/api/tAclFunction/page',
  DetailTAclFunction = '/api/tAclFunction/detail',
}

// 增加数据权限
export const addTAclFunction = (params?: any) =>
	request({
		url: Api.AddTAclFunction,
		method: 'post',
		data: params,
	});

// 删除数据权限
export const deleteTAclFunction = (params?: any) => 
	request({
			url: Api.DeleteTAclFunction,
			method: 'post',
			data: params,
		});

// 编辑数据权限
export const updateTAclFunction = (params?: any) => 
	request({
			url: Api.UpdateTAclFunction,
			method: 'post',
			data: params,
		});

// 分页查询数据权限
export const pageTAclFunction = (params?: any) => 
	request({
			url: Api.PageTAclFunction,
			method: 'post',
			data: params,
		});

// 详情数据权限
export const detailTAclFunction = (id: any) => 
	request({
			url: Api.DetailTAclFunction,
			method: 'get',
			data: { id },
		});


