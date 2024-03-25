import request from '/@/utils/request';
enum Api {
  AddAssetRegister = '/api/assetRegister/add',
  DeleteAssetRegister = '/api/assetRegister/delete',
  UpdateAssetRegister = '/api/assetRegister/update',
  PageAssetRegister = '/api/assetRegister/page',
  DetailAssetRegister = '/api/assetRegister/detail',
}

// 增加资产登记表
export const addAssetRegister = (params?: any) =>
	request({
		url: Api.AddAssetRegister,
		method: 'post',
		data: params,
	});

// 删除资产登记表
export const deleteAssetRegister = (params?: any) => 
	request({
			url: Api.DeleteAssetRegister,
			method: 'post',
			data: params,
		});

// 编辑资产登记表
export const updateAssetRegister = (params?: any) => 
	request({
			url: Api.UpdateAssetRegister,
			method: 'post',
			data: params,
		});

// 分页查询资产登记表
export const pageAssetRegister = (params?: any) => 
	request({
			url: Api.PageAssetRegister,
			method: 'post',
			data: params,
		});

// 详情资产登记表
export const detailAssetRegister = (id: any) => 
	request({
			url: Api.DetailAssetRegister,
			method: 'get',
			data: { id },
		});


