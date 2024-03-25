import request from '/@/utils/request';
enum Api {
  AddSaleOrderDetails = '/api/saleOrderDetails/add',
  DeleteSaleOrderDetails = '/api/saleOrderDetails/delete',
  UpdateSaleOrderDetails = '/api/saleOrderDetails/update',
  PageSaleOrderDetails = '/api/saleOrderDetails/page',
  DetailSaleOrderDetails = '/api/saleOrderDetails/detail',
}

// 增加销售订单详情
export const addSaleOrderDetails = (params?: any) =>
	request({
		url: Api.AddSaleOrderDetails,
		method: 'post',
		data: params,
	});

// 删除销售订单详情
export const deleteSaleOrderDetails = (params?: any) => 
	request({
			url: Api.DeleteSaleOrderDetails,
			method: 'post',
			data: params,
		});

// 编辑销售订单详情
export const updateSaleOrderDetails = (params?: any) => 
	request({
			url: Api.UpdateSaleOrderDetails,
			method: 'post',
			data: params,
		});

// 分页查询销售订单详情
export const pageSaleOrderDetails = (params?: any) => 
	request({
			url: Api.PageSaleOrderDetails,
			method: 'post',
			data: params,
		});

// 详情销售订单详情
export const detailSaleOrderDetails = (id: any) => 
	request({
			url: Api.DetailSaleOrderDetails,
			method: 'get',
			data: { id },
		});


