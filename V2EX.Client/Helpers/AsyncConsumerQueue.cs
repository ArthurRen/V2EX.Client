using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using V2EX.Client.Utils;

namespace V2EX.Client.Helpers
{
    public class AsyncConsumerQueue<TProduct>
    {
        private readonly Queue<TProduct> _queue;
        private readonly object _lock = new object();
        private readonly Action<TProduct> _consumer;
        private readonly AutoResetEvent _waitHandle;

        public ConsumerStatus Status { get; private set; } = ConsumerStatus.Stopped;

        public AsyncConsumerQueue(Action<TProduct> consumer)
        {
            Predication.CheckNotNull(consumer);
            _consumer = consumer;
            _queue = new Queue<TProduct>();
            _waitHandle = new AutoResetEvent(false);
        }

        public void Start()
        {
            if (Status != ConsumerStatus.Stopped)
                throw new InvalidOperationException("The consumer is not stopped");
            Status = ConsumerStatus.Running;
            Task.Factory.StartNew(Consume, TaskCreationOptions.LongRunning);
        }

        public void Stop()
        {
            if (Status != ConsumerStatus.Running)
                return;
            Status = ConsumerStatus.Stopping;
            _waitHandle.WaitOne();
        }

        private bool TryDequeue(ref TProduct product)
        {
            lock (_lock)
            {
                if (_queue.Count == 0)
                    return false;
                product = _queue.Dequeue();
                return true;
            }
        }

        public void Enqueue(TProduct product)
        {
            lock (_lock)
            {
                _queue.Enqueue(product);
            }
        }

        private void Consume()
        {
            var product = default(TProduct);
            while (Status == ConsumerStatus.Running)
            {
                if (!TryDequeue(ref product))
                    Thread.Sleep(100);
                else
                    _consumer?.Invoke(product);
            }
            _queue.Clear();
            _waitHandle.Reset();
            Status = ConsumerStatus.Stopped;
        }

        public enum ConsumerStatus
        {
            /// <summary>
            /// Consumer is running
            /// </summary>
            Running = 0,
            /// <summary>
            /// Consumer has stopped
            /// </summary>
            Stopped ,
            /// <summary>
            /// Consumer is stopping & clear resources
            /// </summary>
            Stopping ,
        }
    }
}
