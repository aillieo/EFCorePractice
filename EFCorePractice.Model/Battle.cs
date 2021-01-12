using System;
using System.Collections.Generic;

namespace EFCorePractice.Model
{
    public class Battle
    {
        public Battle()
        {
            BattleHero = new List<BattleHero>();
        }
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public List<BattleHero> BattleHero { get; set; }
    }
}
