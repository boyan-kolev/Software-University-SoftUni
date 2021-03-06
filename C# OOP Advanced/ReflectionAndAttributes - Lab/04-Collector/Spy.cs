﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsName)
    {
        Type type = Type.GetType(className);
        object instance = Activator.CreateInstance(type);

        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fields.Where(x => fieldsName.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return sb.ToString().TrimEnd();

    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);
        object instance = Activator.CreateInstance(type);
        FieldInfo[] fields = type.GetFields(BindingFlags.Public
            | BindingFlags.Instance | BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        var nonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var getter in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        foreach (var setter in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            if (setter.IsPrivate == false)
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        object instance = Activator.CreateInstance(type);
        var nonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var privateMethod in nonPublicMethods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type type = Type.GetType(className);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public 
            | BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}

