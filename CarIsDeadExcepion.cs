using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intec.Demo.OOP.Les13
{
    public class CarIsDeadException : ApplicationException
    {
        //private string messageDetail;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException()
        {
        }
        public CarIsDeadException(string message): base(message)
        {
        }
        public CarIsDeadException(string message, Exception inner): base(message,inner)
        {
        }

        public CarIsDeadException(string message,string cause, DateTime timeStamp):base(message)
        {
            //messageDetail = message;
            CauseOfError = cause;
            ErrorTimeStamp = timeStamp;
        }

        //public override string Message
        //{
        //    get { return string.Format("Car error Message: {0}", messageDetail); }
        //}

    }
}
