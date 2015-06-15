using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class GrowthPushIOS {
	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void growthPushInitializeWithApplicationId(string applicationId, string credentialId, int environment);
	[DllImport("__Internal")] private static extern void growthPushRequestDeviceToken();
	[DllImport("__Internal")] private static extern void growthPushSetDeviceToken(string deviceToken);
	[DllImport("__Internal")] private static extern void growthPushClearBadge();
	#endif

	public static void Initialize (string applicationId, string credentialId, GrowthPush.Environment environment) {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthPushInitializeWithApplicationId(applicationId, credentialId, (int)environment);
		#endif
	}

	public static void RequestDeviceToken () {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthPushRequestDeviceToken();
		#endif
	}

	public static void SerDeviceToken (string deviceToken) {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetDeviceToken(deviceToken);
		#endif
	}

	public static void ClearBadge () {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthPushClearBadge();
		#endif
	}

};
