using System;

namespace SmartHomeSystem.Domain.DomainBase
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AggregateRootAttribute : Attribute
    {
    }
}
