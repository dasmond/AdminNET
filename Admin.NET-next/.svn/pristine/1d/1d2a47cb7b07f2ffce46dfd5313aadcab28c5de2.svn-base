import request from '/@/utils/request';
enum Api {
  AddSaleOfGoods = '/api/saleOfGoods/add',
  DeleteSaleOfGoods = '/api/saleOfGoods/delete',
  UpdateSaleOfGoods = '/api/saleOfGoods/update',
  PageSaleOfGoods = '/api/saleOfGoods/page',
  DetailSaleOfGoods = '/api/saleOfGoods/detail',
}

// 增加销售商品
export const addSaleOfGoods = (params?: any) =>
	request({
		url: Api.AddSaleOfGoods,
		method: 'post',
		data: params,
	});

// 删除销售商品
export const deleteSaleOfGoods = (params?: any) => 
	request({
			url: Api.DeleteSaleOfGoods,
			method: 'post',
			data: params,
		});

// 编辑销售商品
export const updateSaleOfGoods = (params?: any) => 
	request({
			url: Api.UpdateSaleOfGoods,
			method: 'post',
			data: params,
		});

// 分页查询销售商品
export const pageSaleOfGoods = (params?: any) => 
	request({
			url: Api.PageSaleOfGoods,
			method: 'post',
			data: params,
		});

// 详情销售商品
export const detailSaleOfGoods = (id: any) => 
	request({
			url: Api.DetailSaleOfGoods,
			method: 'get',
			data: { id },
		});


