import request from '/@/utils/request';
enum Api {
  AddProjectData = '/api/projectData/add',
  DeleteProjectData = '/api/projectData/delete',
  UpdateProjectData = '/api/projectData/update',
  PageProjectData = '/api/projectData/page',
  DetailProjectData = '/api/projectData/detail',
}

// 增加项目表
export const addProjectData = (params?: any) =>
	request({
		url: Api.AddProjectData,
		method: 'post',
		data: params,
	});

// 删除项目表
export const deleteProjectData = (params?: any) => 
	request({
			url: Api.DeleteProjectData,
			method: 'post',
			data: params,
		});

// 编辑项目表
export const updateProjectData = (params?: any) => 
	request({
			url: Api.UpdateProjectData,
			method: 'post',
			data: params,
		});

// 分页查询项目表
export const pageProjectData = (params?: any) => 
	request({
			url: Api.PageProjectData,
			method: 'post',
			data: params,
		});

// 详情项目表
export const detailProjectData = (id: any) => 
	request({
			url: Api.DetailProjectData,
			method: 'get',
			data: { id },
		});


