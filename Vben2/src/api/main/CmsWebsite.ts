import { defHttp } from '/@/utils/http/axios';
enum Api {
  AddCmsWebsite = '/CmsWebsite/add',
  DeleteCmsWebsite = '/CmsWebsite/delete',
  UpdateCmsWebsite = '/CmsWebsite/edit',
  GetCmsWebsitePage = '/CmsWebsite/pageList',
}

//增加站点
export function addCmsWebsite(params: any) {
  return defHttp.post<any>({ url: Api.AddCmsWebsite, params });
}
//删除站点
export function deleteCmsWebsite(params: any) {
  return defHttp.post<any>({ url: Api.DeleteCmsWebsite, params });
}
//编辑站点
export function updateCmsWebsite(params: any) {
  return defHttp.post<any>({ url: Api.UpdateCmsWebsite, params });
}
//分页查询站点
export function getCmsWebsitePageList(params?: any) {
  return defHttp.get<any>({ url: Api.GetCmsWebsitePage, params });
}
