import request from '/@/utils/request';
enum Api {
  AddManufacturerModel = '/api/manufacturerModel/add',
  DeleteManufacturerModel = '/api/manufacturerModel/delete',
  UpdateManufacturerModel = '/api/manufacturerModel/update',
  PageManufacturerModel = '/api/manufacturerModel/page',
  DetailManufacturerModel = '/api/manufacturerModel/detail',
}

// 增加制造商型号
export const addManufacturerModel = (params?: any) =>
	request({
		url: Api.AddManufacturerModel,
		method: 'post',
		data: params,
	});

// 删除制造商型号
export const deleteManufacturerModel = (params?: any) => 
	request({
			url: Api.DeleteManufacturerModel,
			method: 'post',
			data: params,
		});

// 编辑制造商型号
export const updateManufacturerModel = (params?: any) => 
	request({
			url: Api.UpdateManufacturerModel,
			method: 'post',
			data: params,
		});

// 分页查询制造商型号
export const pageManufacturerModel = (params?: any) => 
	request({
			url: Api.PageManufacturerModel,
			method: 'post',
			data: params,
		});

// 详情制造商型号
export const detailManufacturerModel = (id: any) => 
	request({
			url: Api.DetailManufacturerModel,
			method: 'get',
			data: { id },
		});


