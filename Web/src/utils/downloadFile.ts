/**
 * 下载文件
 * @param url 下载链接
 * @param filename 文件名
 */
export function downloadFile(url: string, filename: string | undefined = undefined) {
    const urlSplit = url.split('/');
    filename = filename || urlSplit[urlSplit.length - 1];

    const link = document.createElement('a');
    link.setAttribute('download', filename);
    link.href = url;

    document.body.appendChild(link);
    link.click();

    document.body.removeChild(link);
    window.URL.revokeObjectURL(url);
}

/**
 * 文件流下载
 * @param res
 */
export function downloadStreamFile(res: any) {
    const contentType = res.headers['content-type'];
    const contentDisposition = res.headers['content-disposition'];
    const filename = decodeURIComponent(contentDisposition.split('; ')[1].split('=')[1])
    const blob = res.data instanceof Blob ? res.data : new Blob([res.data], { type: contentType });
    downloadFile(window.URL.createObjectURL(blob), filename);
}