

namespace Admin.NET.Application.Service;

public class TestOrderInfoInput : BaseIdInput
{
}

public class TestOrderInfoPageInput : BasePageInput
{

    /// <summary>
    /// 搜索值
    /// </summary>
    public string SearchValue { get; set; }


}

public class TestOrderInfoListInput
{

    /// <summary>
    /// 搜索值
    /// </summary>
    public string SearchValue { get; set; }


}

public class TestOrderInfoAddInput : TestOrderInfo
{
    

}

public class TestOrderInfoUpdateInput : TestOrderInfoAddInput
{

}

public class TestOrderInfoDeleteInput : BaseIdInput
{

}



