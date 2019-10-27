using UnityEngine;

namespace FramePush.DarkModeDetect
{
	public class DarkModeDetector
	{
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
#else
				return Mode.Unspecified;
#endif
			}
		}
	}
}