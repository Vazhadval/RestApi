using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi.Domain
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
