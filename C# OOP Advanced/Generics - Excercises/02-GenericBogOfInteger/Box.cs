namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T info;

        public T Info
        {
            get { return info; }
            set { info = value; }
        }

        public override string ToString()
        {
            return $"{this.Info.GetType().FullName}: {this.Info}";
        }

    }
}
