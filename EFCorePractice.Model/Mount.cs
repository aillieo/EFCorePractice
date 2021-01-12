using System;
using System.ComponentModel.DataAnnotations;

namespace EFCorePractice.Model
{
    public class Mount
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
