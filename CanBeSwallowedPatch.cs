namespace SwallowAnythingMod
{
    class CanBeSwallowedPatch
    {
        private static bool Player_CanBeSwallowed(On.Player.orig_CanBeSwallowed orig, Player self, PhysicalObject testObj)
        {
            orig(self, testObj);
            return true;
        }
        public static void Patch()
        {
            On.Player.CanBeSwallowed += Player_CanBeSwallowed;
        }
    }
}
