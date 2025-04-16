using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore.EmployeeProfile.BusinessLayer.Utilities.CustomException
{
    public class BadRequestExcepton : Exception
    {
        public BadRequestExcepton() { }
        public BadRequestExcepton(string message) : base(message) { }
        public BadRequestExcepton(string message, Exception innerException) : base(message, innerException) { }
    }
}
