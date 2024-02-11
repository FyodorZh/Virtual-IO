// using System;
// using System.Collections.Generic;
//
// namespace vIO
// {
//     public abstract class StreamCore<T> : IStreamCore<T>, IObservable<bool>
//     {
//         private readonly List<IActor<T>> _actors = new List<IActor<T>>();
//
//         public IObservable<bool> IsValid => this;
//
//         protected StreamCore()
//         {
//             _actors.Add(this);
//         }
//
//         protected void AddActor(IActor<T> actor)
//         {
//             _actors.Add(actor);
//         }
//
//         IDisposable IObservable<bool>.Subscribe(IObserver<bool> observer)
//         {
//             throw new NotImplementedException();
//         }
//         
//         public bool QueryActor<TActor>(out TActor? actor) 
//             where TActor : class, IActor<T>
//         {
//             foreach (var a in _actors)
//             {
//                 if (a is TActor asActor)
//                 {
//                     actor = asActor;
//                     return true;
//                 }
//             }
//
//             actor = null;
//             return false;
//         }
//
//         public IEnumerable<IActor<T>> ListAllActors() => _actors;
//
//         public bool CheckIsValid()
//         {
//             return true;
//         }
//
//         protected virtual void Dispose(bool disposing)
//         {
//             // Invalidate
//             if (disposing)
//             {
//             }
//         }
//
//         public void Dispose()
//         {
//             Dispose(true);
//             GC.SuppressFinalize(this);
//         }
//
//         ~StreamCore()
//         {
//             Dispose(false);
//         }
//     }
// }