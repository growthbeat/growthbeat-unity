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

	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void gp_requestDeviceToken(int environment);
	[DllImport("__Internal")] private static extern void gp_setDeviceToken(string deviceToken);
	[DllImport("__Internal")] private static extern void gp_clearBadge();
	[DllImport("__Internal")] private static extern void gp_setTag(string name, string value);
	[DllImport("__Internal")] private static extern void gp_trackEvent(string name, string value);
	[DllImport("__Internal")] private static extern void gp_setDeviceTags();
	[DllImport("__Internal")] private static extern void gp_setBaseUrl(string baseUrl);
	#endif

	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaObject growthPush;
	#endif

	private GrowthPush()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass gpclass = new AndroidJavaClass( "com.growthpush.GrowthPush" ))
		{
			growthPush = gpclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#endif
	}

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

	public void RequestDeviceToken (string senderId, Environment environment)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass environmentClass = new AndroidJavaClass( "com.growthpush.model.Environment" ))
		{
			AndroidJavaObject environmentObject = environmentClass.GetStatic<AndroidJavaObject>(environment == GrowthPush.Environment.Production ? "production" : "development");
			growthPush.Call("requestRegistrationId", senderId, environmentObject);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_requestDeviceToken((int)environment);
		#endif
	}

	public void RequestDeviceToken (Environment environment)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		#elif UNITY_IPHONE && !UNITY_EDITOR
		RequestDeviceToken(null, environment);
		#endif
	}

	public void SetDeviceToken (string deviceToken)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_setDeviceToken(deviceToken);
		#endif
	}

	public void ClearBadge ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		gp_clearBadge();
		#endif
	}

	public void SetTag (string name)
	{
		SetTag (name, null);
	}

	public void SetTag (string name, string value)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		growthPush.Call("setTag", name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_setTag(name, value);
		#endif
	}

	public void TrackEvent(string name)
	{
		TrackEvent (name, null);
	}

	public void TrackEvent (string name, string value)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		growthPush.Call("trackEvent", name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_trackEvent(name, value);
		#endif
	}

	public void SetDeviceTags ()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		growthPush.Call("setDeviceTags");
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_setDeviceTags();
		#endif
	}

	public void SetBaseUrl(string baseUrl)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		AndroidJavaObject httpClient = growthPush.Call<AndroidJavaObject>("getHttpClient");
		httpClient.Call("setBaseUrl", baseUrl);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gp_setBaseUrl(baseUrl);
		#endif	
	}

}
