using BepInEx;
using MonoMod.Cil;
using System;
using System.Reflection;
using UnityEngine.InputSystem;
using MonoMod.RuntimeDetour;
using GameNetcodeStuff;

namespace NoTerminalSway
{
    [BepInPlugin(modGUID,modName,"9.2.8.0")]
    public class NoSwayPlugin : BaseUnityPlugin
    {
        public const string modGUID = "grug.lethalcompany.NoTerminalSway";
        public const string modName = "No Terminal Sway";
        public void Awake()
        {
            Hook hudManagerHook = new(
            typeof(PlayerControllerB).GetMethod(nameof(PlayerControllerB.Update), (BindingFlags)int.MaxValue),
            (Action<PlayerControllerB> original, PlayerControllerB self) =>
            {
                if (self.inTerminalMenu)
                {
                    self.playerActions.Disable();
                }
                else
                {
                    self.playerActions.Enable();
                }
                original(self);
            });
        }
    }
}
