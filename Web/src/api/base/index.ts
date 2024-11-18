import {uploadFile} from '/@/api/system/uploadFile';
import request from '/@/utils/request';

// 接口基类
export const useBaseApi = (module: string) => {
    const baseUrl = `/api/${module}/`;
    return {
        request,
        uploadFile,
        baseUrl: baseUrl,
        page: (data: any) => request({
            url: baseUrl + "page",
            method: 'post',
            data,
        }),
        detail: (id: any) => request({
            url: baseUrl + "detail",
            method: 'get',
            data: { id },
        }),
        dropdownData: (data: any) => request({
            url: baseUrl + "dropdownData",
            method: 'post',
            data,
        }),
        add: (data: any) => request({
            url: baseUrl + 'add',
            method: 'post',
            data
        }),
        update: (data: any) => request({
            url: baseUrl + 'update',
            method: 'post',
            data
        }),
        setStatus: (data: any) => request({
            url: baseUrl + 'setStatus',
            method: 'post',
            data
        }),
        delete: (data: any) => request({
            url: baseUrl + 'delete',
            method: 'post',
            data
        }),
        batchDelete: (data: any) => request({
            url: baseUrl + 'batchDelete',
            method: 'post',
            data
        }),
        exportData: (data: any) => request({
            responseType: 'arraybuffer',
            url: baseUrl + 'export',
            method: 'post',
            data
        }),
        downloadTemplate: () => request({
            responseType: 'arraybuffer',
            url: baseUrl + 'import',
            method: 'get',
        }),
        importData: (file: any) => {
            const formData = new FormData();
	        formData.append('file', file);
            return request({
                headers: { 'Content-Type': 'multipart/form-data;charset=UTF-8' },
                responseType: 'arraybuffer',
                url: baseUrl + 'import',
                method: 'post',
                data: formData,
            });
        },
        
    }
}