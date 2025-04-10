namespace SwallowAnythingMod
{
	class CanMaulCreaturePatch
	{
		private static bool Player_CanMaulCreature(On.Player.orig_CanMaulCreature orig, Player self, Creature testCreature)
		{
			bool origCanMaulCreature = orig(self, testCreature);
			// If the player is crouching, it indicates they want to swallow the creature and not maul them.
			if (self.standing)
				return origCanMaulCreature;
			else
				return false;
		}
		public static void Patch()
		{
			On.Player.CanMaulCreature += Player_CanMaulCreature;
		}
	}
}
