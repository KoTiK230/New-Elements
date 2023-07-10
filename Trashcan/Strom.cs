/*using HarmonyLib;
using Database;
using System.Reflection;

namespace New_Elements
{
    class Strom
    {

        [HarmonyPatch()]
        static MethodBase TargetMethod()
        {
            return typeof(GameplaySeasons).GetMethod("ResourceSet parent");

        }
        public static class Storm
        {
            public static void Postfix(GameplaySeasons ResourceSet<GameplaySeason> __result)
            {
                __result.TemporalTearMeteorShowers = __result.Add(new GameplaySeason(nameof(TemporalTearMeteorShowers), GameplaySeason.Type.World, "EXPANSION1_ID", 1f, false, 0.0f).AddEvent(Db.Get().GameplayEvents.MeteorShowerFullereneEvent));
            }
        }
    }
}
*/