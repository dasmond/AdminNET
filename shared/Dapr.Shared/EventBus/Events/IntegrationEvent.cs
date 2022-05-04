namespace Dapr.Shared ;

public record IntegrationEvent
{
    public Guid Id { get; }

    public DateTime CreationDate { get; }

    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
}

/// <summary>
/// 添加异常事件
/// </summary>
/// <param name="ClassName"></param>
/// <param name="MethodName"></param>
/// <param name="ExceptionName"></param>
/// <param name="ExceptionMsg"></param>
/// <param name="ExceptionSource"></param>
/// <param name="StackTrace"></param>
/// <param name="ParamsObj"></param>
/// <param name="UserName"></param>
/// <param name="RealName"></param>
public record AddExLogEvent(
    string ClassName,
    string MethodName,
    string ExceptionName,
    string ExceptionMsg,
    string ExceptionSource,
    string StackTrace,
    string ParamsObj,
    long UserId,
    string UserName,
    string RealName)
    : IntegrationEvent;

/// <summary>
/// 添加操作日志事件
/// </summary>
/// <param name="Success"></param>
/// <param name="Ip"></param>
/// <param name="Location"></param>
/// <param name="Browser"></param>
/// <param name="Os"></param>
/// <param name="Url"></param>
/// <param name="ReqMethod"></param>
/// <param name="ClassName"></param>
/// <param name="MethodName"></param>
/// <param name="Param"></param>
/// <param name="Result"></param>
/// <param name="ElapsedTime"></param>
/// <param name="UserName"></param>
/// <param name="RealName"></param>
public record AddOpLogEvent(
    bool Success,
    string Ip,
    string Location,
    string Browser,
    string Os,
    string Url,
    string ClassName,
    string MethodName,
    string ReqMethod,
    string Param,
    string Result,
    long ElapsedTime,
    long UserId,
    string UserName,
    string RealName)
    : IntegrationEvent;
