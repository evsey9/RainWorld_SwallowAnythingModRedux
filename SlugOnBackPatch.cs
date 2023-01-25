using System.Reflection;
using MonoMod.RuntimeDetour;

namespace SwallowAnythingMod
{
    class SlugOnBackPatch
    {
        public delegate bool orig_CanPutSlugToBack(Player self);
        private static bool ShouldBeAbleToPutSlugToBack(Player player, bool originalState)
        {
            if (!player.standing)
            {
                return originalState;
            } else
            {
                return false;
            }
        }
        public static bool Player_CanPutSlugToBack_get(orig_CanPutSlugToBack orig, Player self)
        {
            bool origResult = orig(self);
            return ShouldBeAbleToPutSlugToBack(self, origResult);
        }
        private static bool Player_CanIPutDeadSlugOnBack(On.Player.orig_CanIPutDeadSlugOnBack orig, Player self, Player pickUpCandidate)
        {
            bool origResult = orig(self, pickUpCandidate);
            return ShouldBeAbleToPutSlugToBack(self, origResult);
        }
        public static void Patch()
        {
            BindingFlags propFlags = BindingFlags.Instance | BindingFlags.Public;
            BindingFlags myMethodFlags = BindingFlags.Static | BindingFlags.Public;

            Hook playerSlugToBackHook = new Hook(
                typeof(Player).GetProperty("CanPutSlugToBack", propFlags).GetGetMethod(),
                typeof(SlugOnBackPatch).GetMethod("Player_CanPutSlugToBack_get", myMethodFlags));

            On.Player.CanIPutDeadSlugOnBack += Player_CanIPutDeadSlugOnBack;
        }
    }
}
