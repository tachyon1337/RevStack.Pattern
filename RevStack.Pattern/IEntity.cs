using System;

namespace RevStack.Pattern
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
