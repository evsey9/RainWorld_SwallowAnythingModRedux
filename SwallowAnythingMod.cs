using BepInEx;

using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace SwallowAnythingMod
{
	[BepInPlugin("drwoof.swallowanythingmod", "Swallow Anything Mod", "1.4.0")]
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
