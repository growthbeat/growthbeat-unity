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

	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID	
		GrowthMessageAndroid.Initialize(applicationId, credentialId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthMessageInitializeWithApplicationId(applicationId, credentialId);
		#endif
	}
	
}
