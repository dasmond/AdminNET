import request from '/@/utils/request';
enum Api {
  AddManufacturerInformation = '/api/manufacturerInformation/add',
  DeleteManufacturerInformation = '/api/manufacturerInformation/delete',
  UpdateManufacturerInformation = '/api/manufacturerInformation/update',
  PageManufacturerInformation = '/api/manufacturerInformation/page',
  DetailManufacturerInformation = '/api/manufacturerInformation/detail',
}

// 增加制造商资料
export const addManufacturerInformation = (params?: any) =>
	request({
		url: Api.AddManufacturerInformation,
		method: 'post',
		data: params,
	});

// 删除制造商资料
export const deleteManufacturerInformation = (params?: any) => 
	request({
			url: Api.DeleteManufacturerInformation,
			method: 'post',
			data: params,
		});

// 编辑制造商资料
export const updateManufacturerInformation = (params?: any) => 
	request({
			url: Api.UpdateManufacturerInformation,
			method: 'post',
			data: params,
		});

// 分页查询制造商资料
export const pageManufacturerInformation = (params?: any) => 
	request({
			url: Api.PageManufacturerInformation,
			method: 'post',
			data: params,
		});

// 详情制造商资料
export const detailManufacturerInformation = (id: any) => 
	request({
			url: Api.DetailManufacturerInformation,
			method: 'get',
			data: { id },
		});


