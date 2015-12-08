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

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void initializeWithApplicationId(string applicationId, string credentialId);
	[DllImport("__Internal")] static extern void start();
	[DllImport("__Internal")] static extern void stop();
	[DllImport("__Internal")] static extern void setLoggerSilent(bool silent);
	[DllImport("__Internal")] static extern void growthbeatSetBaseUrl(string url);
	#endif

	public static Growthbeat GetInstance ()
	{
		return Growthbeat.instance;
	}

	#if UNITY_ANDROID
	private static AndroidJavaObject growthbeat;
	#endif

	private Growthbeat() {
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.Growthbeat" )) {
			growthbeat = gbcclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#endif
	}
	
	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthbeat.Call("initialize", activity, applicationId, credentialId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		initializeWithApplicationId(applicationId, credentialId);
		#endif
	}

	public void Start ()
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("start");
		#elif UNITY_IPHONE && !UNITY_EDITOR
		start();
		#endif
	}

	public void Stop ()
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("stop");
		#elif UNITY_IPHONE && !UNITY_EDITOR
		stop();
		#endif
	}

	public void SetLoggerSilent (bool silent)
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("setLoggerSilent", silent);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		setLoggerSilent(silent);
		#endif
	}


	public void setBaseUrl (string baseUrl)
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.GrowthbeatCore" )) {
			AndroidJavaObject growthbeatCore = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
			AndroidJavaObject httpClient = growthbeatCore.Call<AndroidJavaObject>("getHttpClient");
			httpClient.Call("setBaseUrl", baseUrl);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatSetBaseUrl(baseUrl);
		#endif
	}
	

	public void setBaseUrl (string baseUrl)
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.GrowthbeatCore" )) {
			AndroidJavaObject growthbeatCore = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
			AndroidJavaObject httpClient = growthbeatCore.Call<AndroidJavaObject>("getHttpClient");
			httpClient.Call("setBaseUrl", baseUrl);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatSetBaseUrl(baseUrl);
		#endif
	}

}
