 namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        FieldInfo[] privateFields = 
                            type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                            .Where(x => x.IsPrivate)
                            .ToArray();
                        PrintFields(privateFields);
                        break;
                    case "protected":
                        FieldInfo[] protectedFields =
                            type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                            .Where(x => x.IsFamily)
                            .ToArray();
                        PrintFields(protectedFields);
                        break;
                    case "public":
                        FieldInfo[] publicFields =
                            type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                            .Where(x => x.IsPublic)
                            .ToArray();
                        PrintFields(publicFields);
                        break;
                    case "all":
                        FieldInfo[] allFields =
                            type.GetFields(BindingFlags.Public
                            | BindingFlags.NonPublic
                            | BindingFlags.Instance
                            | BindingFlags.Static);

                        PrintFields(allFields);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            foreach (FieldInfo field in fields)
            {
                string accsessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                Console.WriteLine($"{accsessModifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
