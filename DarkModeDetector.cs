using System.Runtime.InteropServices;
using UnityEngine;

namespace FramePush.DarkModeDetect
{
	public static class DarkModeDetector
	{
#if UNITY_IOS
		[DllImport("__Internal")]
		private static extern int _FP_DarkModeDetector_getCurrentMode();
#endif
		
		public static Mode CurrentMode
		{
			get
			{
#if UNITY_EDITOR
				return Mode.Unspecified;
#elif UNITY_ANDROID
				using (var clazz = new AndroidJavaClass("com.framepush.darkmodedetect.DarkModeDetector")) {
					using (var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
						using (var activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity")) {
							switch (clazz.CallStatic<int>("getCurrentMode", activity)) {
								case 2:
									return Mode.Dark;
								case 1:
									return Mode.Light;
							}
						}
					}
				}

				return Mode.Unspecified;
#elif UNITY_IOS
				switch (_FP_DarkModeDetector_getCurrentMode()) {
					case 2:
						return Mode.Dark;
					case 1:
						return Mode.Light;
				}
				
				return Mode.Unspecified;
#else
				return Mode.Unspecified;
#endif
			}
		}
	}
}