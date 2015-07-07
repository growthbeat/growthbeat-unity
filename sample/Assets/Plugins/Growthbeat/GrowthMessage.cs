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

	public static GrowthMessage GetInstance ()
	{
		return GrowthMessage.instance;
	}

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
	
}
