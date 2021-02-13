using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class Result:IResult
    {
        public bool succces { get; }
        public string message { get; }

        public Result(bool succes,string message):this(succes)
        {
            this.message = message;
        }

        public Result(bool success)
        {
            this.succces = success;
        }
    }
}
