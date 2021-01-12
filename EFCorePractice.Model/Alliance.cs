using System;
using System.Collections.Generic;

namespace EFCorePractice.Model
{
    public class Alliance
    {
        public Alliance()
        {
            Members = new List<Player>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public Player Leader { get; set; }
        public List<Player> Members { get; set; }
    }
}
