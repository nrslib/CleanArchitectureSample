using System;

namespace Presentation.Libs.Exceptions
{
    public class TargetIdNotFoundException : Exception
    {
        public TargetIdNotFoundException(long id) { }
    }
}
