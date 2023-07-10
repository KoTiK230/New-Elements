/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klei.AI;
using Database;

namespace New_Elements
{
    public class GameplaySeasons : ResourceSet<GameplaySeason>
    {
        public GameplaySeason MeteorShowers;
        public GameplaySeason GassyMooteorShowers;
        public GameplaySeason TemporalTearMeteorShowers;
        public GameplaySeason NaturalRandomEvents;
        public GameplaySeason DupeRandomEvents;
        public GameplaySeason PrickleCropSeason;
        public GameplaySeason BonusEvents;
        public GameplaySeason RegolithMoonMeteorShowers;

        public GameplaySeasons(ResourceSet parent)
          : base(nameof(GameplaySeasons), parent)
        {
            this.MeteorShowers = this.Add(new GameplaySeason(nameof(MeteorShowers), GameplaySeason.Type.World, "", 14f, false, startActive: true).AddEvent(Db.Get().GameplayEvents.MeteorShowerIronEvent).AddEvent(Db.Get().GameplayEvents.MeteorShowerGoldEvent).AddEvent(Db.Get().GameplayEvents.MeteorShowerCopperEvent));
            this.RegolithMoonMeteorShowers = this.Add(new GameplaySeason(nameof(RegolithMoonMeteorShowers), GameplaySeason.Type.World, "EXPANSION1_ID", 20f, false, startActive: true).AddEvent(Db.Get().GameplayEvents.MeteorShowerDustEvent));
            this.TemporalTearMeteorShowers = this.Add(new GameplaySeason(nameof(TemporalTearMeteorShowers), GameplaySeason.Type.World, "EXPANSION1_ID", 1f, false, 0.0f).AddEvent(Db.Get().GameplayEvents.MeteorShowerFullereneEvent));
            this.GassyMooteorShowers = this.Add(new GameplaySeason(nameof(GassyMooteorShowers), GameplaySeason.Type.World, "EXPANSION1_ID", 20f, false, startActive: true).AddEvent(Db.Get().GameplayEvents.GassyMooteorEvent));
        }
    }
}
*/