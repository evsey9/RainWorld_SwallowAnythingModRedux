using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using On;



namespace SwallowAnythingMod
{
    class ReleaseGraspPatch
    {
        public static void Patch()
        {
            On.Player.ReleaseGrasp += Player_ReleaseGrasp;
        }

        private static void Player_ReleaseGrasp(On.Player.orig_ReleaseGrasp orig, Player self, int grasp)
        {
            if (self.input[0].pckp == true && self.input[1].pckp == false && self.input[0].y == 0 && self.input[0].thrw == false && (self.Grabability(self.grasps[grasp]?.grabbed) == Player.ObjectGrabability.TwoHands || self.Grabability(self.grasps[grasp]?.grabbed) == Player.ObjectGrabability.Drag))
            {
            }
            else
            {
                orig(self, grasp);
            }
        }
    }
}
