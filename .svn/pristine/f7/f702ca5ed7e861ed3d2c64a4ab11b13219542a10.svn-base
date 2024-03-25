import request from '/@/utils/request';
enum Api {
  AddGoodsInformation = '/api/goodsInformation/add',
  DeleteGoodsInformation = '/api/goodsInformation/delete',
  UpdateGoodsInformation = '/api/goodsInformation/update',
  PageGoodsInformation = '/api/goodsInformation/page',
  DetailGoodsInformation = '/api/goodsInformation/detail',
}

// 增加商品资料表
export const addGoodsInformation = (params?: any) =>
	request({
		url: Api.AddGoodsInformation,
		method: 'post',
		data: params,
	});

// 删除商品资料表
export const deleteGoodsInformation = (params?: any) => 
	request({
			url: Api.DeleteGoodsInformation,
			method: 'post',
			data: params,
		});

// 编辑商品资料表
export const updateGoodsInformation = (params?: any) => 
	request({
			url: Api.UpdateGoodsInformation,
			method: 'post',
			data: params,
		});

// 分页查询商品资料表
export const pageGoodsInformation = (params?: any) => 
	request({
			url: Api.PageGoodsInformation,
			method: 'post',
			data: params,
		});

// 详情商品资料表
export const detailGoodsInformation = (id: any) => 
	request({
			url: Api.DetailGoodsInformation,
			method: 'get',
			data: { id },
		});


