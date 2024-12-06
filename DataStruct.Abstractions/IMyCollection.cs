namespace DataStruct.Abstractions
{
    public interface IMyCollection<T>
    {
        int Count { get; }

        void Add(T? id);

        void Clear();
    }
}