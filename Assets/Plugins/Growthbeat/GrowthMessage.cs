//
//  GrowthMessage.cs
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

public class GrowthMessage
{
	
	private static GrowthMessage instance = new GrowthMessage ();
	
	#if UNITY_IPHONE
	[DllImport("__Internal")] private static extern void growthMessageInitializeWithApplicationId(string applicationId, string credentialId);
	#endif

	public static GrowthMessage GetInstance ()
	{
		return GrowthMessage.instance;
	}

	#if UNITY_ANDROID
	private static AndroidJavaObject growthMessage;
	#endif
	
	private GrowthMessage()
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.message.GrowthMessage" ))
		{
			growthMessage = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
		}
		#endif
	}

	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID	
		if (growthMessage == null)
			return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthMessage.Call("initialize", activity, applicationId, credentialId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthMessageInitializeWithApplicationId(applicationId, credentialId);
		#endif
	}
	
}
