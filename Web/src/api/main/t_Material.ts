import request from '/@/utils/request';
enum Api {
  AddT_Material = '/api/t_Material/add',
  DeleteT_Material = '/api/t_Material/delete',
  UpdateT_Material = '/api/t_Material/update',
  PageT_Material = '/api/t_Material/page',
  GetSysOrgOrgIDDropdown = '/api/t_Material/SysOrgOrgIDDropdown',
}

// 增加物料管理
export const addT_Material = (params?: any) =>
	request({
		url: Api.AddT_Material,
		method: 'post',
		data: params,
	});

// 删除物料管理
export const deleteT_Material = (params?: any) => 
	request({
			url: Api.DeleteT_Material,
			method: 'post',
			data: params,
		});

// 编辑物料管理
export const updateT_Material = (params?: any) => 
	request({
			url: Api.UpdateT_Material,
			method: 'post',
			data: params,
		});

// 分页查询物料管理
export const pageT_Material = (params?: any) => 
	request({
			url: Api.PageT_Material,
			method: 'post',
			data: params,
		});

export const getSysOrgOrgIDDropdown = () =>
		request({
		url: Api.GetSysOrgOrgIDDropdown,
		method: 'get'
		});

