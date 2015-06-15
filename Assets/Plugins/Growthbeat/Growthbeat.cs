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
	
	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.Growthbeat" )) {
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
			gbcclass.CallStatic<AndroidJavaObject>("getInstance").Call("initialize", activity, applicationId, credentialId);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatInitializeWithApplicationId(applicationId, credentialId);
		#endif
		
	}

	public void Start ()
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatStart();
		#endif
	}

	public void Stop ()
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatStop();
		#endif
	}

	public void SetLoggerSilent (bool silent)
	{
		#if UNITY_ANDROID
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthbeatSetLoggerSilent(silent);
		#endif
	}
	
}
