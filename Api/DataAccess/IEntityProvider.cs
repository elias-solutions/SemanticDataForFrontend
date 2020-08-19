namespace Api.DataAccess
{
    using System;
    using System.Collections.Generic;

    public interface IEntityProvider
    {
        IEnumerable<Type> GetAll();
    }
}