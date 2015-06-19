//
//  Growthbeat.h
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
	[DllImport("__Internal")] static extern void growthbeatInitializeWithApplicationId(string applicationId, string credentialId);
	[DllImport("__Internal")] static extern void growthbeatStart();
	[DllImport("__Internal")] static extern void growthbeatStop();
	[DllImport("__Internal")] static extern void growthbeatSetLoggerSilent(bool silent);
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
	
	public void Initialize (string applicationId, string credentialId, string senderId, bool debug)
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthbeat.Call("initialize", activity, applicationId, credentialId, senderId, debug);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatInitializeWithApplicationId(applicationId, credentialId);
		#endif
		
	}

	public void Start ()
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("start");
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatStart();
		#endif
	}

	public void Stop ()
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("stop");
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatStop();
		#endif
	}

	public void SetLoggerSilent (bool silent)
	{
		#if UNITY_ANDROID
		if (growthbeat == null)
			return;
		growthbeat.Call("setLoggerSilent", silent);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatSetLoggerSilent(silent);
		#endif
	}
	
}
