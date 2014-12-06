using System;
using Microsoft.SPOT;

namespace GratMan
{
    public class Log
    {
        public static void WriteLine(string message)
        {
            Trace.Print(message);
        }
    }
}
