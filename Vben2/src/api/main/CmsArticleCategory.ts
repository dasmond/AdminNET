import { defHttp } from '/@/utils/http/axios';
enum Api {
  AddCmsArticleCategory = '/CmsArticleCategory/add',
  DeleteCmsArticleCategory = '/CmsArticleCategory/delete',
  UpdateCmsArticleCategory = '/CmsArticleCategory/edit',
  GetCmsArticleCategoryPage = '/CmsArticleCategory/page',
  GetCmsWebsiteDropdown = '/CmsArticleCategory/CmsWebsiteDropdown',
  GetCmsWebsiteTree = '/CmsArticleCategory/CmsWebsiteTree',
}

//增加文章分类
export function addCmsArticleCategory(params: any) {
  return defHttp.post<any>({ url: Api.AddCmsArticleCategory, params });
}
//删除文章分类
export function deleteCmsArticleCategory(params: any) {
  return defHttp.post<any>({ url: Api.DeleteCmsArticleCategory, params });
}
//编辑文章分类
export function updateCmsArticleCategory(params: any) {
  return defHttp.post<any>({ url: Api.UpdateCmsArticleCategory, params });
}
//分页查询文章分类
export function getCmsArticleCategoryPageList(params?: any) {
  return defHttp.get<any>({ url: Api.GetCmsArticleCategoryPage, params });
}
export function getCmsWebsiteDropdown() {
  return defHttp.get<any>({ url: Api.GetCmsWebsiteDropdown });
}
export function getCmsWebsiteTree() {
  return defHttp.get<any>({ url: Api.GetCmsWebsiteTree });
}
