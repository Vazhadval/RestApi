using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Domain
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
