namespace TestProjectOne
{
    public sealed class SaveData<T> : BaseExample<T>
    {
        public SaveData(T id) : base(id)
        {
            IdPlayer = id;
        }
    }

    public class BaseExample<T>
    {
        public T IdPlayer = default;

        public BaseExample(T id)
        {
            IdPlayer = id;
        }
    }
}