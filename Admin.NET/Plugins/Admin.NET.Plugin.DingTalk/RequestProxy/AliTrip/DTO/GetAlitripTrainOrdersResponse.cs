// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.NET.Plugin.DingTalk.RequestProxy.BaseTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Admin.NET.Plugin.DingTalk.RequestProxy.AliTrip.DTO;
public class GetAlitripTrainOrdersResponse : DingtalkResponseErrorSuccess
{
    /// <summary>
    /// 机票列表
    /// </summary>
    [JsonProperty("train_order_list")]
    [JsonPropertyName("train_order_list")]
    public List<TrainOrder> TrainOrderList { get; set; }
}

public class TrainOrder
{
    /// <summary>
    /// 机票订单id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonProperty("gmt_create")]
    [JsonPropertyName("gmt_create")]
    public DateTime GmtCreate { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonProperty("gmt_modified")]
    [JsonPropertyName("gmt_modified")]
    public DateTime GmtModified { get; set; }

    /// <summary>
    /// 企业id
    /// </summary>
    public string CorpId { get; set; }

    /// <summary>
    /// 企业名称
    /// </summary>
    [JsonProperty("corp_name")]
    [JsonPropertyName("corp_name")]
    public string CorpName { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 用户姓名
    /// </summary>
    [JsonProperty("user_name")]
    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    /// <summary>
    /// 部门id
    /// </summary>
    public string DeptId { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    [JsonProperty("dept_name")]
    [JsonPropertyName("dept_name")]
    public string DeptName { get; set; }

    /// <summary>
    /// 商旅申请单id
    /// </summary>
    [JsonProperty("apply_id")]
    [JsonPropertyName("apply_id")]
    public string ApplyId { get; set; }

    /// <summary>
    /// 联系人
    /// </summary>
    [JsonProperty("contact_name")]
    [JsonPropertyName("contact_name")]
    public string ContactName { get; set; }

    /// <summary>
    /// 出发站
    /// </summary>
    [JsonProperty("dep_station")]
    [JsonPropertyName("dep_station")]
    public string DepStation { get; set; }

    /// <summary>
    /// 到达站
    /// </summary>
    [JsonProperty("arr_station")]
    [JsonPropertyName("arr_station")]
    public string ArrStation { get; set; }

    /// <summary>
    /// 出发时间
    /// </summary>
    [JsonProperty("dep_time")]
    [JsonPropertyName("dep_time")]
    public DateTime DepTime { get; set; }

    /// <summary>
    /// 到达时间
    /// </summary>
    [JsonProperty("arr_time")]
    [JsonPropertyName("arr_time")]
    public DateTime ArrTime { get; set; }

    /// <summary>
    /// 车次
    /// </summary>
    [JsonProperty("train_number")]
    [JsonPropertyName("train_number")]
    public string TrainNumber { get; set; }

    /// <summary>
    /// 车次类型
    /// </summary>
    [JsonProperty("train_type")]
    [JsonPropertyName("train_type")]
    public string TrainType { get; set; }

    /// <summary>
    /// 座位类型
    /// </summary>
    [JsonProperty("seat_type")]
    [JsonPropertyName("seat_type")]
    public string SeatType { get; set; }

    /// <summary>
    /// 运行时长
    /// </summary>
    [JsonProperty("run_time")]
    [JsonPropertyName("run_time")]
    public string RunTime { get; set; }

    /// <summary>
    /// 12306票号
    /// </summary>
    [JsonProperty("ticket_no_12306")]
    [JsonPropertyName("ticket_no_12306")]
    public string TicketNo12306 { get; set; }

    /// <summary>
    /// 出发城市
    /// </summary>
    [JsonProperty("dep_city")]
    [JsonPropertyName("dep_city")]
    public string DepCity { get; set; }

    /// <summary>
    /// 到达城市
    /// </summary>
    [JsonProperty("arr_city")]
    [JsonPropertyName("arr_city")]
    public string ArrCity { get; set; }

    /// <summary>
    /// 乘客姓名
    /// </summary>
    [JsonProperty("rider_name")]
    [JsonPropertyName("rider_name")]
    public string RiderName { get; set; }

    /// <summary>
    /// 票的数量
    /// </summary>
    [JsonProperty("ticket_count")]
    [JsonPropertyName("ticket_count")]
    public int TicketCount { get; set; }

    /// <summary>
    /// 订单状态：0：待支付,1：出票中,2：已关闭,3：改签成功,4：退票成功,5：出票完成,6：退票申请中,7：改签申请中,8：已出票/已发货,9：出票失败,10：改签失败,11：退票失败
    /// </summary>
    public StatusEnum Status { get; set; }

    public enum StatusEnum
    {
        待支付 = 0, 出票中, 已关闭, 改签成功, 退票成功, 出票完成, 退票申请中, 改签申请中, 已出票or已发货, 出票失败, 改签失败, 退票失败
    }

    /// <summary>
    /// 发票信息对象
    /// </summary>
    public InvoiceDomain Invoice { get; set; }

    /// <summary>
    /// 成本中心对象
    /// </summary>
    [JsonProperty("cost_center")]
    [JsonPropertyName("cost_center")]
    public CostCenterDomain CostCenter { get; set; }

    /// <summary>
    /// 价目信息
    /// </summary>
    [JsonProperty("price_info_list")]
    [JsonPropertyName("price_info_list")]
    public TrainPriceInfo PriceInfoList { get; set; }

    /// <summary>
    /// 第三方行程id
    /// </summary>
    [JsonProperty("thirdpart_itinerary_id")]
    [JsonPropertyName("thirdpart_itinerary_id")]
    public string ThirdpartItineraryId { get; set; }

    /// <summary>
    /// 出行人列表
    /// </summary>
    [JsonProperty("user_affiliate_list")]
    [JsonPropertyName("user_affiliate_list")]
    public List<UserAffiliateDomain> UserAffiliateList { get; set; }

    /// <summary>
    /// 第三方申请单ID
    /// </summary>
    [JsonProperty("thirdpart_apply_id")]
    [JsonPropertyName("thirdpart_apply_id")]
    public string ThirdpartApplyId { get; set; }

    /// <summary>
    /// 申请单名称
    /// </summary>
    [JsonProperty("btrip_title")]
    [JsonPropertyName("btrip_title")]
    public string BtripTitle { get; set; }
}

/// <summary>
/// 价目信息
/// </summary>
public class TrainPriceInfo
{
    /// <summary>
    /// 价格
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 资金流向:1:支出，2:收入
    /// </summary>
    public TrainPriceTypeEnum Type { get; set; }

    public enum TrainPriceTypeEnum
    {
        支出 = 1, 收入
    }

    /// <summary>
    /// 交易类目
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// 结算方式:1：个人现付，2:企业现付,4:企业月结，8、企业预存
    /// </summary>
    [JsonProperty("pay_type")]
    [JsonPropertyName("pay_type")]
    public int PayType { get; set; }

    public enum TrainPricePayTypeEnum
    {
        个人现付 = 1, 企业现付 = 2, 企业月结 = 4, 企业预存 = 8
    }

    /// <summary>
    /// 流水创建时间
    /// </summary>
    [JsonProperty("gmt_create")]
    [JsonPropertyName("gmt_create")]
    public DateTime GmtCreate { get; set; }

    /// <summary>
    /// 乘机人，多个用‘,’分割
    /// </summary>
    [JsonProperty("passenger_name")]
    [JsonPropertyName("passenger_name")]
    public string PassengerName { get; set; }
}