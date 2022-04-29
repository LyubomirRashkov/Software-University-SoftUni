using System;

namespace CustomDIFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}
