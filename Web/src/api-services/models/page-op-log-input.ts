/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET 通用权限开发平台
 * 让 .NET 开发更简单、更通用、更流行。整合最新技术，模块插件式开发，前后端分离，开箱即用。<br/><u><b><font color='FF0000'> 👮不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！</font></b></u>
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import { Filter } from './filter';
import { Search } from './search';
 /**
 * 
 *
 * @export
 * @interface PageOpLogInput
 */
export interface PageOpLogInput {

    /**
     * @type {Search}
     * @memberof PageOpLogInput
     */
    search?: Search;

    /**
     * 模糊查询关键字
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    keyword?: string | null;

    /**
     * @type {Filter}
     * @memberof PageOpLogInput
     */
    filter?: Filter;

    /**
     * 当前页码
     *
     * @type {number}
     * @memberof PageOpLogInput
     */
    page?: number;

    /**
     * 页码容量
     *
     * @type {number}
     * @memberof PageOpLogInput
     */
    pageSize?: number;

    /**
     * 排序字段
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    field?: string | null;

    /**
     * 排序方向
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    order?: string | null;

    /**
     * 降序排序
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    descStr?: string | null;

    /**
     * 开始时间
     *
     * @type {Date}
     * @memberof PageOpLogInput
     */
    startTime?: Date | null;

    /**
     * 结束时间
     *
     * @type {Date}
     * @memberof PageOpLogInput
     */
    endTime?: Date | null;

    /**
     * 账号
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    account?: string | null;

    /**
     * 操作用时
     *
     * @type {number}
     * @memberof PageOpLogInput
     */
    elapsed?: number | null;

    /**
     * 状态
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    status?: string | null;

    /**
     * IP地址
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    remoteIp?: string | null;

    /**
     * 租户Id
     *
     * @type {number}
     * @memberof PageOpLogInput
     */
    tenantId?: number;

    /**
     * 方法名称
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    actionName?: string | null;

    /**
     * 模块名称
     *
     * @type {string}
     * @memberof PageOpLogInput
     */
    controllerName?: string | null;
}
