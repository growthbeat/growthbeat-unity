//
//  Growthbeat.cs
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

public class Growthbeat
{
	private static Growthbeat instance = new Growthbeat ();

	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport("__Internal")] static extern void gb_setLoggerSilent(bool silent);
	[DllImport("__Internal")] static extern void gb_setBaseUrl(string url);
	#endif

	public static Growthbeat GetInstance ()
	{
		return Growthbeat.instance;
	}

	#if UNITY_ANDROID && !UNITY_EDITOR
	private static AndroidJavaObject growthbeat;
	#endif

	public Growthbeat() {
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.Growthbeat" )) {
			growthbeat = gbcclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#endif
	}

	public void SetLoggerSilent (bool silent)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (growthbeat == null)
			return;
		growthbeat.Call("setLoggerSilent", silent);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_setLoggerSilent(silent);
		#endif
	}


	public void setBaseUrl (string baseUrl)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.GrowthbeatCore" )) {
			AndroidJavaObject growthbeatCore = gbcclass.CallStatic<AndroidJavaObject>("getInstance");
			AndroidJavaObject httpClient = growthbeatCore.Call<AndroidJavaObject>("getHttpClient");
			httpClient.Call("setBaseUrl", baseUrl);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_setBaseUrl(baseUrl);
		#endif
	}

}
