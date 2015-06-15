using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthPush {

	private static GrowthPush instance = new GrowthPush ();

	public static GrowthPush GetInstance ()
	{
		return GrowthPush.instance;
	}

	public enum Environment {
		Unknown = 0,
		Development = 1,
		Production = 2
	}

	public static void Initialize (string applicationId, string credentialId, Environment environment) {
		#if UNITY_ANDROID
		#elif UNITY_IPHONE
		GrowthPushIOS.Initialize(applicationId, credentialId, environment); 
		#endif
	}

	public static void Initialize (string applicationId, string credentialId, Environment environment, bool debug, string senderId) {
		#if UNITY_ANDROID	
		GrowthPushAndroid.Initialize(applicationId, secret, environment, debug, senderId);
		#elif UNITY_IPHONE
		Initialize(applicationId, credentialId, environment);
		#endif
	}

	public static void RequestDeviceToken () {
		#if UNITY_ANDROID
		GrowthPushAndroid.RequestDeviceToken();
		#elif UNITY_IPHONE
		GrowthPushIOS.RequestDeviceToken();
		#endif
	}

	public static void SerDeviceToken (string deviceToken) {
		#if UNITY_ANDROID
		GrowthPushAndroid.SerDeviceToken(deviceToken);
		#elif UNITY_IPHONE
		GrowthPushIOS.SerDeviceToken(deviceToken);
		#endif
	}

	public static void ClearBadge () {
		#if UNITY_IPHONE
		GrowthPushIOS.ClearBadge();
		#endif
	}
		
}
