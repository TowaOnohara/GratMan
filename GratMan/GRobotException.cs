using System;
using Microsoft.SPOT;

namespace GratMan
{

    public class GRobotBaseException : Exception
    {
        public GRobotBaseException(string Message) : base(Message) 
        {
        } 
    }
    public class NotInstalled : GRobotBaseException
    {
        public NotInstalled(string Message) : base(Message) { } 

    }
}
