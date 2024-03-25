import request from '/@/utils/request';
enum Api {
  AddPriceReporting = '/api/priceReporting/add',
  DeletePriceReporting = '/api/priceReporting/delete',
  UpdatePriceReporting = '/api/priceReporting/update',
  PagePriceReporting = '/api/priceReporting/page',
  DetailPriceReporting = '/api/priceReporting/detail',
}

// 增加销售价格报备表
export const addPriceReporting = (params?: any) =>
	request({
		url: Api.AddPriceReporting,
		method: 'post',
		data: params,
	});

// 删除销售价格报备表
export const deletePriceReporting = (params?: any) => 
	request({
			url: Api.DeletePriceReporting,
			method: 'post',
			data: params,
		});

// 编辑销售价格报备表
export const updatePriceReporting = (params?: any) => 
	request({
			url: Api.UpdatePriceReporting,
			method: 'post',
			data: params,
		});

// 分页查询销售价格报备表
export const pagePriceReporting = (params?: any) => 
	request({
			url: Api.PagePriceReporting,
			method: 'post',
			data: params,
		});

// 详情销售价格报备表
export const detailPriceReporting = (id: any) => 
	request({
			url: Api.DetailPriceReporting,
			method: 'get',
			data: { id },
		});


