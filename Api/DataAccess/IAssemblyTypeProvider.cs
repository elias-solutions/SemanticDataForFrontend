namespace Api.DataAccess
{
    using System;
    using System.Collections.Generic;

    public interface IAssemblyTypeProvider
    {
        IEnumerable<Type> GetAll();
    }
}