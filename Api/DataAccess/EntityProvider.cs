namespace Api.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions.Pack;

    public class EntityProvider : IEntityProvider
    {
        private static readonly Lazy<IEnumerable<Type>> LazyTypes = new Lazy<IEnumerable<Type>>(() => new AssemblyTypeProvider().GetAll().Where(t => TypeExtensions.HasCustomAttribute<EntityAttribute>(t)).ToList());

        public IEnumerable<Type> GetAll()
        {
            return LazyTypes.Value;
        }
    }
}