import request from '/@/utils/request';
enum Api {
  AddTAclRoleFunction = '/api/tAclRoleFunction/add',
  DeleteTAclRoleFunction = '/api/tAclRoleFunction/delete',
  UpdateTAclRoleFunction = '/api/tAclRoleFunction/update',
  PageTAclRoleFunction = '/api/tAclRoleFunction/page',
  DetailTAclRoleFunction = '/api/tAclRoleFunction/detail',
}

// 增加数据权限角色表
export const addTAclRoleFunction = (params?: any) =>
	request({
		url: Api.AddTAclRoleFunction,
		method: 'post',
		data: params,
	});

// 删除数据权限角色表
export const deleteTAclRoleFunction = (params?: any) => 
	request({
			url: Api.DeleteTAclRoleFunction,
			method: 'post',
			data: params,
		});

// 编辑数据权限角色表
export const updateTAclRoleFunction = (params?: any) => 
	request({
			url: Api.UpdateTAclRoleFunction,
			method: 'post',
			data: params,
		});

// 分页查询数据权限角色表
export const pageTAclRoleFunction = (params?: any) => 
	request({
			url: Api.PageTAclRoleFunction,
			method: 'post',
			data: params,
		});

// 详情数据权限角色表
export const detailTAclRoleFunction = (id: any) => 
	request({
			url: Api.DetailTAclRoleFunction,
			method: 'get',
			data: { id },
		});


