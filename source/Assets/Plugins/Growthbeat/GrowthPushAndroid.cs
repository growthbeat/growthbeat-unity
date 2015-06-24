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
	private AndroidJavaObject growthPush;
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

}
