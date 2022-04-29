﻿using System;

namespace CustomDIFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class NamedAttribute : Attribute
    {
        public NamedAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
