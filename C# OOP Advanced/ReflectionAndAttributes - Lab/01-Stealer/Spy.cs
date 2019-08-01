using System;
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
}

