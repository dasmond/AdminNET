import request from '/@/utils/request';
enum Api {
  AddProductImages = '/api/productImages/add',
  DeleteProductImages = '/api/productImages/delete',
  UpdateProductImages = '/api/productImages/update',
  PageProductImages = '/api/productImages/page',
  DetailProductImages = '/api/productImages/detail',
}

// 增加产品图片
export const addProductImages = (params?: any) =>
	request({
		url: Api.AddProductImages,
		method: 'post',
		data: params,
	});

// 删除产品图片
export const deleteProductImages = (params?: any) => 
	request({
			url: Api.DeleteProductImages,
			method: 'post',
			data: params,
		});

// 编辑产品图片
export const updateProductImages = (params?: any) => 
	request({
			url: Api.UpdateProductImages,
			method: 'post',
			data: params,
		});

// 分页查询产品图片
export const pageProductImages = (params?: any) => 
	request({
			url: Api.PageProductImages,
			method: 'post',
			data: params,
		});

// 详情产品图片
export const detailProductImages = (id: any) => 
	request({
			url: Api.DetailProductImages,
			method: 'get',
			data: { id },
		});


