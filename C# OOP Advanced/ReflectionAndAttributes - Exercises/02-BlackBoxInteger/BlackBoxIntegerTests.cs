using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        Type type = typeof(BlackBoxInteger);
        object instance = Activator.CreateInstance(type, true);
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] inputArgs = input.Split("_");
            string command = inputArgs[0];
            int value = int.Parse(inputArgs[1]);
            MethodInfo method = type
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(x => x.Name == command);

            method.Invoke(instance, new object[] { value });

            FieldInfo field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = field.GetValue(instance);
            Console.WriteLine(result);

            input = Console.ReadLine();
        }

    }
}

