import request from '/@/utils/request';
enum Api {
  AddProductAttachments = '/api/productAttachments/add',
  DeleteProductAttachments = '/api/productAttachments/delete',
  UpdateProductAttachments = '/api/productAttachments/update',
  PageProductAttachments = '/api/productAttachments/page',
  DetailProductAttachments = '/api/productAttachments/detail',
}

// 增加商品附件
export const addProductAttachments = (params?: any) =>
	request({
		url: Api.AddProductAttachments,
		method: 'post',
		data: params,
	});

// 删除商品附件
export const deleteProductAttachments = (params?: any) => 
	request({
			url: Api.DeleteProductAttachments,
			method: 'post',
			data: params,
		});

// 编辑商品附件
export const updateProductAttachments = (params?: any) => 
	request({
			url: Api.UpdateProductAttachments,
			method: 'post',
			data: params,
		});

// 分页查询商品附件
export const pageProductAttachments = (params?: any) => 
	request({
			url: Api.PageProductAttachments,
			method: 'post',
			data: params,
		});

// 详情商品附件
export const detailProductAttachments = (id: any) => 
	request({
			url: Api.DetailProductAttachments,
			method: 'get',
			data: { id },
		});


