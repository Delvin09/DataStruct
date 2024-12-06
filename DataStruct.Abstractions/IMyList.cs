using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruct.Abstractions
{
    public interface IMyList : IMyCollection
    {
        int Count { get; }

        void Add(object? id);

        void Clear();
    }
}
