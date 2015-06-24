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
	[DllImport("__Internal")] private static extern void growthPushRequestDeviceToken();
	[DllImport("__Internal")] private static extern void growthPushSetDeviceToken(string deviceToken);
	[DllImport("__Internal")] private static extern void growthPushClearBadge();
	#endif

	public static GrowthPush GetInstance ()
	{
		return GrowthPush.instance;
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
