using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class NovelException : Exception
    {
        public NovelException()
        {

        }

        public NovelException(string message) : base(message)
        {

        }

        public NovelException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
