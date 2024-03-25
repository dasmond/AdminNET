import request from '/@/utils/request';
enum Api {
  AddWarehouseInformation = '/api/warehouseInformation/add',
  DeleteWarehouseInformation = '/api/warehouseInformation/delete',
  UpdateWarehouseInformation = '/api/warehouseInformation/update',
  PageWarehouseInformation = '/api/warehouseInformation/page',
  DetailWarehouseInformation = '/api/warehouseInformation/detail',
}

// 增加仓库资料表
export const addWarehouseInformation = (params?: any) =>
	request({
		url: Api.AddWarehouseInformation,
		method: 'post',
		data: params,
	});

// 删除仓库资料表
export const deleteWarehouseInformation = (params?: any) => 
	request({
			url: Api.DeleteWarehouseInformation,
			method: 'post',
			data: params,
		});

// 编辑仓库资料表
export const updateWarehouseInformation = (params?: any) => 
	request({
			url: Api.UpdateWarehouseInformation,
			method: 'post',
			data: params,
		});

// 分页查询仓库资料表
export const pageWarehouseInformation = (params?: any) => 
	request({
			url: Api.PageWarehouseInformation,
			method: 'post',
			data: params,
		});

// 详情仓库资料表
export const detailWarehouseInformation = (id: any) => 
	request({
			url: Api.DetailWarehouseInformation,
			method: 'get',
			data: { id },
		});


