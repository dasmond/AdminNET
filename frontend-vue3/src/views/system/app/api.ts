import { AppApi } from '/@/api_base/apis/app-api';
import { defHttp } from '/@/utils/http/axios';
import {
  AppOutput,
  UpdateAppInput,
} from '/@/api_base/models';
import {
  EditRecordRow} from '/@/components/Table';



const appApi = new AppApi(undefined, undefined, defHttp.getAxios());

export async function getList(options?: any) : Promise<AppOutput | null > {
  try {
    const app = await appApi.sysAppListGet(options);
    return app.data.data;
  }catch (error) {
    return null;
  }
}

export async function updateData(record:EditRecordRow,options?: any) {
  let body : UpdateAppInput = {
    id:record["id"],
    name: record["name"],
    code:record["code"],
    active:record["active"],
    status:record["status"],
    sort:record["sort"],
  };
  //console.log(body);
  return await appApi.sysAppEditPost(body,options);

}



export async function getPage(name?: string, code?: string, searchValue?: string, pageNo?: number, pageSize?: number, searchBeginTime?: string, searchEndTime?: string, sortField?: string, sortOrder?: string, descStr?: string, options?: any) : Promise<any | null > {
  try {
    const app = await appApi.sysAppPageGet(name,code,searchValue,pageNo,pageSize,searchBeginTime,searchEndTime,sortField,sortOrder,descStr,options);
    //console.log(app.data.data.rows);
    return app.data.data.rows;
  }catch (error) {
    return null;
  }
}
