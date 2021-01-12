using System;

namespace EFCorePractice.Model
{
    public class BattleHero
    {
        public Guid HeroId { get; set; }
        public Guid BattleId { get; set; }

        public Battle Battle { get; set; }
        public Hero Hero { get; set; }
    }
}