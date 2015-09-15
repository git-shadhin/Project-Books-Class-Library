using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace SCL
{
    class ZeroIdException : Exception
    {
        public ZeroIdException() : base("Id must be different form 0") { }
    }

    class EmptyBookTitleException : Exception
    {
        public EmptyBookTitleException() : base("The book title is empty") { }
    }

    class EmptyAuthorNameException : Exception
    {
        public EmptyAuthorNameException() : base("The author name is empty") { }
    }

    class EmptyPhotoPathException : Exception
    {
        public EmptyPhotoPathException() : base("The photo path is empty") { }
    }

    class EmptyCategory : Exception
    {
        public EmptyCategory():base("A proper cateogory must be indicated"){}
    }
    
}
