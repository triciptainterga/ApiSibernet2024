using System;

namespace WebApiReport.Infrastructure.Attributes.CommaSeparated

{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class CommaSeparatedAttribute : Attribute
    {
    }
}
