using System;

namespace SaleAppExample.Exceptions;

public class NotFoundEntityException: Exception
{
    public NotFoundEntityException()
        : base()
    {
    }

    public NotFoundEntityException(string message)
        : base(message)
    {
    }
}