using System;
using System.Collections.Generic;

namespace vIO
{
    public interface IMainActor<T> : IActor<T>
    {
        IObservable<bool> IsValid { get; }
        
        bool QueryActor<TActor>(out TActor? actor) where TActor : class, IActor<T>;
        IEnumerable<IActor<T>> ListAllActors();
    }
}