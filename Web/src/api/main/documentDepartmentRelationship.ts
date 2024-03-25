import request from '/@/utils/request';
enum Api {
  AddDocumentDepartmentRelationship = '/api/documentDepartmentRelationship/add',
  DeleteDocumentDepartmentRelationship = '/api/documentDepartmentRelationship/delete',
  UpdateDocumentDepartmentRelationship = '/api/documentDepartmentRelationship/update',
  PageDocumentDepartmentRelationship = '/api/documentDepartmentRelationship/page',
  DetailDocumentDepartmentRelationship = '/api/documentDepartmentRelationship/detail',
}

// 增加文件-部门关系表
export const addDocumentDepartmentRelationship = (params?: any) =>
	request({
		url: Api.AddDocumentDepartmentRelationship,
		method: 'post',
		data: params,
	});

// 删除文件-部门关系表
export const deleteDocumentDepartmentRelationship = (params?: any) => 
	request({
			url: Api.DeleteDocumentDepartmentRelationship,
			method: 'post',
			data: params,
		});

// 编辑文件-部门关系表
export const updateDocumentDepartmentRelationship = (params?: any) => 
	request({
			url: Api.UpdateDocumentDepartmentRelationship,
			method: 'post',
			data: params,
		});

// 分页查询文件-部门关系表
export const pageDocumentDepartmentRelationship = (params?: any) => 
	request({
			url: Api.PageDocumentDepartmentRelationship,
			method: 'post',
			data: params,
		});

// 详情文件-部门关系表
export const detailDocumentDepartmentRelationship = (id: any) => 
	request({
			url: Api.DetailDocumentDepartmentRelationship,
			method: 'get',
			data: { id },
		});


