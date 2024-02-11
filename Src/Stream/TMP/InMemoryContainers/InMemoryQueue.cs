// using System;
// using System.Collections.Generic;
//
// namespace vIO.InMemoryContainers
// {
//     public class InMemoryQueue<T> : StreamCore<T>
//     {
//         private readonly Queue<T> _queue = new Queue<T>();
//
//         public InMemoryQueue()
//         {
//             QueueReader reader = new QueueReader(this, _queue);
//             QueueWriter writer = new QueueWriter(this, _queue);
//             AddActor(reader);
//             AddActor(writer);
//         }
//
//         private class QueueReader : IStreamReader<T>
//         {
//             private readonly StreamCore<T> _core;
//             private readonly Queue<T> _queue;
//
//             public QueueReader(StreamCore<T> core, Queue<T> queue)
//             {
//                 _core = core;
//                 _queue = queue;
//             }
//             
//             public (bool, T?) ReadOne()
//             {
//                 if (_core.CheckIsValid() && _queue.TryDequeue(out var value))
//                 {
//                     return (true, value);
//                 }
//
//                 return (false, default);
//             }
//
//             public int ReadMany(Span<T> dst)
//             {
//                 if (!_core.CheckIsValid())
//                 {
//                     return 0;
//                 }
//             
//                 int count = dst.Length;
//                 for (int i = 0; i < count; ++i)
//                 {
//                     if (_queue.TryDequeue(out var value))
//                     {
//                         dst[i] = value;
//                     }
//                     else
//                     {
//                         return i;
//                     }
//                 }
//
//                 return count;
//             }
//         }
//
//         private class QueueWriter : IStreamWriter<T>
//         {
//             private readonly StreamCore<T> _core;
//             private readonly Queue<T> _queue;
//             
//             public QueueWriter(StreamCore<T> core, Queue<T> queue)
//             {
//                 _core = core;
//                 _queue = queue;
//             }
//             
//             public bool WriteOne(T value)
//             {
//                 if (!_core.CheckIsValid())
//                 {
//                     return false;
//                 }
//
//                 _queue.Enqueue(value);
//                 return true;
//             }
//
//             public int WriteMany(Span<T> values)
//             {
//                 if (!_core.CheckIsValid())
//                 {
//                     return 0;
//                 }
//
//                 foreach (var v in values)
//                 {
//                     _queue.Enqueue(v);
//                 }
//
//                 return values.Length;
//             }
//         }
//     }
// }