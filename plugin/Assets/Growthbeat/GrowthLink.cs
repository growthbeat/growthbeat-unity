//
//  GrowthMessage.cs
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2015/12/09.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class GrowthLink {
	
	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void gl_initializeWithApplicationId(string applicationId, string credentialId);
	[DllImport("__Internal")] static extern void gl_handleOpenUrl(string url);
	#endif
	
	#if UNITY_ANDROID
	private static AndroidJavaObject growthLink;
	#endif
	
	private GrowthLink()
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.link.GrowthLink" )) {
			growthLink = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
		}
		#endif
	}

	private static GrowthLink instance = new GrowthLink ();
	public static GrowthLink GetInstance ()
	{
		return GrowthLink.instance;
	}
	
	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID
		if (growthLink == null)
			return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthLink.Call("initialize", activity, applicationId, credentialId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gl_initializeWithApplicationId(applicationId, credentialId);
		#endif
	}

}
