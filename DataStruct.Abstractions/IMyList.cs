using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Abstractions
{
    public interface IMyList<T> : IMyCollection<T>
    {
        T? this[int index] { get; set; }

        int IndexOf(T? item);

        void RemoveAt(int index);
    }
}
