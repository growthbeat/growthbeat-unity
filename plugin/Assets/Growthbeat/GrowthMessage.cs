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

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void gm_setBaseUrl(string baseUrl);
	#endif

	#if UNITY_ANDROID
	private AndroidJavaObject growthMessage;
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

	private static GrowthMessage instance = new GrowthMessage ();
	public static GrowthMessage GetInstance ()
	{
		return GrowthMessage.instance;
	}

	public void SetBaseUrl(string baseUrl)
	{
		#if UNITY_ANDROID
		if(growthMessage == null)
			return;
		AndroidJavaObject httpClient = growthMessage.Call<AndroidJavaObject>("getHttpClient");
		httpClient.Call("setBaseUrl", baseUrl);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gm_setBaseUrl(baseUrl);
		#endif	
	}
	
}