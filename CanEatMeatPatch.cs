namespace SwallowAnythingMod
{
	class CanEatMeatPatch
	{
		private static bool Player_CanEatMeat(On.Player.orig_CanEatMeat orig, Player self, Creature testCreature)
		{
			bool origCanEatMeat = orig(self, testCreature);
			// If the player is standing, it indicates they want to swallow the creature and not eat the corpse.
			if (!self.standing)
				return origCanEatMeat;
			else
				return false;
		}
		public static void Patch()
		{
			On.Player.CanEatMeat += Player_CanEatMeat;
		}
	}
}
