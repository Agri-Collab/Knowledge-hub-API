// api/Models/Exceptions/BadRequestException.cs (or api/Exceptions/BadRequestException.cs)
using System;

namespace api.Models.Exceptions // Or 'api.Exceptions' if you created a separate folder/project
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}