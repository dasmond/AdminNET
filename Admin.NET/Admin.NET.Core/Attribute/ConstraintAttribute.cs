namespace Admin.NET.Core;

/// <summary>
/// 默认约束
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
public class ConstraintAttribute : Attribute
{
    public string defaultValue { get; set; }

    public ConstraintAttribute(string defaultValue)
    {
        this.defaultValue = defaultValue;
    }
}