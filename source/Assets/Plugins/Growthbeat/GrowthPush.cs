//
//  GrowthPush.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthPush {

	private static GrowthPush instance = new GrowthPush ();

	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void growthPushInitializeWithApplicationId(string applicationId, string credentialId, int environment);
	[DllImport("__Internal")] private static extern void growthPushRequestDeviceToken();
	[DllImport("__Internal")] private static extern void growthPushSetDeviceToken(string deviceToken);
	[DllImport("__Internal")] private static extern void growthPushClearBadge();
	#endif

	public static GrowthPush GetInstance ()
	{
		return GrowthPush.instance;
	}

	public enum Environment
	{
		Unknown = 0,
		Development = 1,
		Production = 2
	}

	public void Initialize (string applicationId, string credentialId, Environment environment)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushInitializeWithApplicationId(applicationId, credentialId, (int)environment);
		#endif
	}

	public void Initialize (string applicationId, string credentialId, Environment environment, bool debug, string senderId)
	{
		#if UNITY_ANDROID	
		GrowthPushAndroid.GetInstance ().Initialize(applicationId, credentialId, environment, debug, senderId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		Initialize(applicationId, credentialId, environment);
		#endif
	}

	public void RequestDeviceToken ()
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushRequestDeviceToken();
		#endif
	}

	public void SetDeviceToken (string deviceToken)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetDeviceToken(deviceToken);
		#endif
	}

	public void ClearBadge ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthPushClearBadge();
		#endif
	}
		
}
