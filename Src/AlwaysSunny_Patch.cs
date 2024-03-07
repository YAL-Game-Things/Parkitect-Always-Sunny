using HarmonyLib;
using Parkitect.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace AlwaysSunny {
	[HarmonyPatch]
	public class AlwaysSunny_Patch_WeatherController_calculateNewWeather {
		static MethodBase TargetMethod() => AccessTools.Method(typeof(WeatherController), "calculateNewWeather");

		static MethodBase WeatherController_startWeather = AccessTools.Method(typeof(WeatherController), "startWeather");

		[HarmonyPrefix]
		public static bool Prefix(WeatherController __instance) {
			if (__instance.IsRaining || __instance.Weather is WeatherController.Cloudy) {
				WeatherController.WeatherType weather = new WeatherController.Sunny(1f);
				WeatherController_startWeather.Invoke(__instance, new object[] {
					weather,
					false,
				});
				Debug.Log("Shine on!");
			}
			return false;
		}
	}
}
