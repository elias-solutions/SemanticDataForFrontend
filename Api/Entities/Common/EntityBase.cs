namespace Api.Entities.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class EntityBase
    {
        [Key] public Guid Identifier { get; set; }
    }
}