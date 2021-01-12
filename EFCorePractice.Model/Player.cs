using System;
using System.Collections.Generic;

namespace EFCorePractice.Model
{
    // 联赛
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Hero> Members { get; set; } = new List<Hero>();
    }
}
