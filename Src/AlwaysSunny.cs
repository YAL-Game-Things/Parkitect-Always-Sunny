using System;
using System.Collections.Generic;
using System.Linq;
using Parkitect;
using UnityEngine;
using HarmonyLib;
using System.Windows.Markup;
using System.IO;
using MiniJSON;
using Mono.Security.Authenticode;

namespace NoRandomEvents {
    public class AlwaysSunny : AbstractMod
    {
        public const string VERSION_NUMBER = "1.0.0";
        public override string getIdentifier() => "cc.yal.AlwaysSunny";
        public override string getName() => "Always Sunny";
        public override string getDescription() => @"Disables rain/storms";

        public override string getVersionNumber() => VERSION_NUMBER;
        public override bool isMultiplayerModeCompatible() => true;
        public override bool isRequiredByAllPlayersInMultiplayerMode() => true;

        public static AlwaysSunny Instance;
        private Harmony _harmony;

        public override void onEnabled() {
            Instance = this;

            Debug.Log("[AlwaysSunny] Doing a Harmony patch!");
			_harmony = new Harmony(getIdentifier());
			_harmony.PatchAll();
			Debug.Log("[AlwaysSunny] Patched alright!");
		}

        public override void onDisabled() {
            _harmony?.UnpatchAll(getIdentifier());
		}
    }
}
