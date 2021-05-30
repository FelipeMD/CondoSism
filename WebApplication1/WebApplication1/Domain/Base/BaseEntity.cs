using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Domain.Base
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}