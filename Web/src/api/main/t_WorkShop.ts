import request from '/@/utils/request';
enum Api {
  AddT_WorkShop = '/api/t_WorkShop/add',
  DeleteT_WorkShop = '/api/t_WorkShop/delete',
  UpdateT_WorkShop = '/api/t_WorkShop/update',
  PageT_WorkShop = '/api/t_WorkShop/page',
  GetSysOrgOrgIdDropdown = '/api/t_WorkShop/SysOrgOrgIdDropdown',
}

// 增加车间
export const addT_WorkShop = (params?: any) =>
	request({
		url: Api.AddT_WorkShop,
		method: 'post',
		data: params,
	});

// 删除车间
export const deleteT_WorkShop = (params?: any) => 
	request({
			url: Api.DeleteT_WorkShop,
			method: 'post',
			data: params,
		});

// 编辑车间
export const updateT_WorkShop = (params?: any) => 
	request({
			url: Api.UpdateT_WorkShop,
			method: 'post',
			data: params,
		});

// 分页查询车间
export const pageT_WorkShop = (params?: any) => 
	request({
			url: Api.PageT_WorkShop,
			method: 'post',
			data: params,
		});

export const getSysOrgOrgIdDropdown = () =>
		request({
		url: Api.GetSysOrgOrgIdDropdown,
		method: 'get'
		});

