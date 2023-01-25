using BepInEx;

namespace SwallowAnythingMod
{
    [BepInPlugin("drwoof.swallowanythingmod", "Swallow Anything Mod", "1.3.0")]
    public class SwallowAnythingMod : BaseUnityPlugin
    {
        public SwallowAnythingMod()
        {
            CanBeSwallowedPatch.Patch();
            ReleaseGraspPatch.Patch();
            SlugOnBackPatch.Patch();
            CanEatMeatPatch.Patch();
            CanMaulCreaturePatch.Patch();
        }
    }
}
