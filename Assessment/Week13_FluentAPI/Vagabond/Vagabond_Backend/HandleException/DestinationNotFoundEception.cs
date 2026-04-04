using System;

namespace Vagabond_Backend.HandleException
{
    public class DestinationNotFoundException : Exception
    {
        public DestinationNotFoundException()
            : base("Destination not found.")
        {
        }

        public DestinationNotFoundException(int id)
            : base($"Destination with ID {id} was not found.")
        {
        }

        public DestinationNotFoundException(string message)
            : base(message)
        {
        }
    }
}