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