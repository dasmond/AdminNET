import request from '/@/utils/request';
enum Api {
  AddT_WorkGroup = '/api/t_WorkGroup/add',
  DeleteT_WorkGroup = '/api/t_WorkGroup/delete',
  UpdateT_WorkGroup = '/api/t_WorkGroup/update',
  PageT_WorkGroup = '/api/t_WorkGroup/page',
  GetT_WorkShopWorkShopIDDropdown = '/api/t_WorkGroup/T_WorkShopWorkShopIDDropdown',
}

// 增加生产中心
export const addT_WorkGroup = (params?: any) =>
	request({
		url: Api.AddT_WorkGroup,
		method: 'post',
		data: params,
	});

// 删除生产中心
export const deleteT_WorkGroup = (params?: any) => 
	request({
			url: Api.DeleteT_WorkGroup,
			method: 'post',
			data: params,
		});

// 编辑生产中心
export const updateT_WorkGroup = (params?: any) => 
	request({
			url: Api.UpdateT_WorkGroup,
			method: 'post',
			data: params,
		});

// 分页查询生产中心
export const pageT_WorkGroup = (params?: any) => 
	request({
			url: Api.PageT_WorkGroup,
			method: 'post',
			data: params,
		});

export const getT_WorkShopWorkShopIDDropdown = () =>
		request({
		url: Api.GetT_WorkShopWorkShopIDDropdown,
		method: 'get'
		});

