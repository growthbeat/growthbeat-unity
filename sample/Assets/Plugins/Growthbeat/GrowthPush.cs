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
	[DllImport("__Internal")] private static extern void growthPushSetTag(string name, string value);
	[DllImport("__Internal")] private static extern void growthPushTrackEvent(string name, string value);
	[DllImport("__Internal")] private static extern void growthPushSetDeviceTags();
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

	public void SetTag (string name)
	{
		SetTag (name, null);
	}

	public void SetTag (string name, string value)
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.SetTag(name, value);l
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetTag(name, value);
		#endif
	}

	public void TrackEvent(string name)
	{
		TrackEvent (name, null);
	}

	public void TrackEvent (string name, string value)
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.TrackEvent(name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushTrackEvent(name, value);
		#endif 
	}

	public void setDeviceTags ()
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.SetDeviceTags;
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetDeviceTags();
		#endif
	}
		
}
