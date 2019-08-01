using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true)]
public class SoftUniAttribute : Attribute
{
    public SoftUniAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
