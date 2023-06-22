using System;

namespace TekGain.DAL.ErrorHandler
{
    public class ServiceException : Exception
    {
        public ServiceException() : base()
        {

        }

        public ServiceException(string message) : base(message)
        {

        }
    }
}