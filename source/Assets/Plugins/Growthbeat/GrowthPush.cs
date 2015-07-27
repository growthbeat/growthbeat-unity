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

	public enum Environment {
		Unknown = 0,
		Development = 1,
		Production = 2
	}

	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void growthPushRequestDeviceToken(int environment);
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

	public void RequestDeviceToken (Environment environment)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushRequestDeviceToken((int)environment);
		#endif
	}

	public void SetDeviceToken (string deviceToken)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetDeviceToken(deviceToken);
		#endif
	}

	public void RequestRegistrationId (string senderId)
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.GetInstance().RequestRegistrationId(senderId); 
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
		GrowthPushAndroid.GetInstance().SetTag(name, value);
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
		GrowthPushAndroid.GetInstance().TrackEvent(name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushTrackEvent(name, value);
		#endif 
	}
	
	public void SetDeviceTags ()
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.GetInstance().SetDeviceTags();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetDeviceTags();
		#endif
	}

}
