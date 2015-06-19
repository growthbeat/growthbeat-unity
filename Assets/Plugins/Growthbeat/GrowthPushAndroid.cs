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
	private static AndroidJavaObject growthPush;
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

	public void Initialize(string applicationId, string credentialId, GrowthPush.Environment environment, bool debug, string senderId)
	{
		instance.PrivateInitialize(applicationId, credentialId, environment, debug, senderId);
	}

	private void PrivateInitialize(string applicationId, string credentialId, GrowthPush.Environment environment, bool debug, string senderId)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (growthPush == null)
			return;
		AndroidJavaClass  environmentClass = new AndroidJavaClass("com.growthpush.model.Environment"); 
		AndroidJavaObject environmentObject = environmentClass.GetStatic<AndroidJavaObject>(environment == GrowthPush.Environment.Production ? "production" : "development"); 
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthPush.Call<AndroidJavaObject>("initialize", activity, applicationId, credentialId, environmentObject, debug);
		growthPush.Call<AndroidJavaObject>("register", senderId);
		#endif
	}

}
