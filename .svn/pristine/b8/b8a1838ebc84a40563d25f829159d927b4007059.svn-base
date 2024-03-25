import request from '/@/utils/request';
enum Api {
  AddInventory = '/api/inventory/add',
  DeleteInventory = '/api/inventory/delete',
  UpdateInventory = '/api/inventory/update',
  PageInventory = '/api/inventory/page',
  DetailInventory = '/api/inventory/detail',
}

// 增加库存表
export const addInventory = (params?: any) =>
	request({
		url: Api.AddInventory,
		method: 'post',
		data: params,
	});

// 删除库存表
export const deleteInventory = (params?: any) => 
	request({
			url: Api.DeleteInventory,
			method: 'post',
			data: params,
		});

// 编辑库存表
export const updateInventory = (params?: any) => 
	request({
			url: Api.UpdateInventory,
			method: 'post',
			data: params,
		});

// 分页查询库存表
export const pageInventory = (params?: any) => 
	request({
			url: Api.PageInventory,
			method: 'post',
			data: params,
		});

// 详情库存表
export const detailInventory = (id: any) => 
	request({
			url: Api.DetailInventory,
			method: 'get',
			data: { id },
		});


