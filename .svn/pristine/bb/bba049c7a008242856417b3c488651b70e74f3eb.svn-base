import request from '/@/utils/request';
enum Api {
  AddSaleOrder = '/api/saleOrder/add',
  DeleteSaleOrder = '/api/saleOrder/delete',
  UpdateSaleOrder = '/api/saleOrder/update',
  PageSaleOrder = '/api/saleOrder/page',
  DetailSaleOrder = '/api/saleOrder/detail',
}

// 增加销售订单
export const addSaleOrder = (params?: any) =>
	request({
		url: Api.AddSaleOrder,
		method: 'post',
		data: params,
	});

// 删除销售订单
export const deleteSaleOrder = (params?: any) => 
	request({
			url: Api.DeleteSaleOrder,
			method: 'post',
			data: params,
		});

// 编辑销售订单
export const updateSaleOrder = (params?: any) => 
	request({
			url: Api.UpdateSaleOrder,
			method: 'post',
			data: params,
		});

// 分页查询销售订单
export const pageSaleOrder = (params?: any) => 
	request({
			url: Api.PageSaleOrder,
			method: 'post',
			data: params,
		});

// 详情销售订单
export const detailSaleOrder = (id: any) => 
	request({
			url: Api.DetailSaleOrder,
			method: 'get',
			data: { id },
		});


