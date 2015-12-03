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
	[DllImport("__Internal")] private static extern void requestDeviceToken(int environment);
	[DllImport("__Internal")] private static extern void setDeviceToken(string deviceToken);
	[DllImport("__Internal")] private static extern void clearBadge();
	[DllImport("__Internal")] private static extern void setTag(string name, string value);
	[DllImport("__Internal")] private static extern void trackEvent(string name, string value);
	[DllImport("__Internal")] private static extern void setDeviceTags();
	[DllImport("__Internal")] private static extern void growthPushSetBaseUrl(string baseUrl);
	#endif

	public static GrowthPush GetInstance ()
	{
		return GrowthPush.instance;
	}

	public void RequestDeviceToken (string senderId, Environment environment)
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.GetInstance().RequestRegistrationId(senderId, environment);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		requestDeviceToken((int)environment);
		#endif
	}

	public void RequestDeviceToken (Environment environment)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		RequestDeviceToken(null, environment);
		#endif
	}

	public void SetDeviceToken (string deviceToken)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		setDeviceToken(deviceToken);
		#endif
	}

	public void ClearBadge ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		clearBadge();
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
		setTag(name, value);
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
		trackEvent(name, value);
		#endif
	}

	public void SetDeviceTags ()
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.GetInstance().SetDeviceTags();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		setDeviceTags();
		#endif
	}

	public void SetBaseUrl(string baseUrl)
	{
		#if UNITY_ANDROID
		GrowthPushAndroid.GetInstance().SetBaseUrl(baseUrl);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthPushSetBaseUrl(baseUrl);
		#endif	
	}

}
