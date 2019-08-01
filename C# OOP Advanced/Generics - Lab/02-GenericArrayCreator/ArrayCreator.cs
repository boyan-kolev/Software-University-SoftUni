namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length ,T item)
        {
            T[] genericArray = new T[length];

            for (int i = 0; i < genericArray.Length; i++)
            {
                genericArray[i] = item;
            }

            return genericArray;
        }
    }
}
