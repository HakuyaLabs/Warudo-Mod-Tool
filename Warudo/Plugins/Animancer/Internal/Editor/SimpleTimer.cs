using System;
using System.Diagnostics;
using System;
using Object = UnityEngine.Object;

namespace Animancer
{
    public struct SimpleTimer : IDisposable
    {
        public static readonly Stopwatch Stopwatch = Stopwatch.StartNew();
        public static double CurrentTime => throw new NotImplementedException();
        public string name;
        public double startTime;
        public double total;
        const string Format = "0.000";
        public bool IsStarted => throw new NotImplementedException();
        public SimpleTimer(string name)
        {
            throw new NotImplementedException();
        }

        public static SimpleTimer Start(string name = null) => throw new NotImplementedException();
        public bool Start()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}