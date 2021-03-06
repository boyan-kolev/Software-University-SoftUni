﻿using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public 
            | BindingFlags.Static | BindingFlags.Instance);

        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(x => x.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}

