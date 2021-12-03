using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}