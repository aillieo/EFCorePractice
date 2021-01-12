using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePractice.Model
{
    //运动员
    public class Hero
    {
        public Hero()
        {
            Equipment = new List<Equipment>();
        }
        public Guid Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAchieved { get; set; }

        public List<Equipment> Equipment { get; set; }

        public Guid MountId { get; set; }

        public Mount Mount { get; set; }
    }
}