//
//  GrowthPushAndroid.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System.Collections;
using System;

public class GrowthPushAndroid
{

	private static GrowthPushAndroid instance = new GrowthPushAndroid();

	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaObject growthPush;
	#endif

	public static GrowthPushAndroid GetInstance ()
	{
		return GrowthPushAndroid.instance;
	}

	private GrowthPushAndroid()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass gpclass = new AndroidJavaClass( "com.growthpush.GrowthPush" ))
		{
			growthPush = gpclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#endif
	}

	public void RequestRegistrationId (string senderId, Environment environment)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (growthPush == null)
			return;

		AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthpush.model.Environment" );
		AndroidJavaObject environmentObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(environment == GrowthPush.Environment.Production ? "Production" : "Development");
		growthPush.Call("requestRegistrationId", senderId, environmentObject);
		#endif
	}

	public void SetTag(string name, string value)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(growthPush == null)
			return;

		growthPush.Call("setTag", name, value);
		#endif

	}

	public void TrackEvent(string name, string value)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(growthPush == null)
			return;

		growthPush.Call("trackEvent", name, value);
		#endif
	}

	public void SetDeviceTags ()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(growthPush == null)
			return;

		growthPush.Call("setDeviceTags");
		#endif
	}

}
