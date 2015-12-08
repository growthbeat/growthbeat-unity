﻿//
//  GrowthbeatComponent.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System.Collections;
#if UNITY_IPHONE
using NotificationServices = UnityEngine.iOS.NotificationServices;
#endif

public class GrowthbeatComponent : MonoBehaviour
{
  	bool tokenSent = false;

	void Awake ()
	{
		Growthbeat.GetInstance ().Initialize ("PIaD6TaVt7wvKwao", "FD2w93wXcWlb68ILOObsKz5P3af9oVMo");
		IntentHandlerWrapper.InitializeIntentHandlers ();
		IntentHandlerWrapper.AddNoopIntentHandler ();
		IntentHandlerWrapper.AddUrlIntentHandler ();
		IntentHandlerWrapper.AddCustomIntentHandler ("GrowthbeatObject");
		GrowthLink.GetInstance().Initialize ("PIaD6TaVt7wvKwao", "FD2w93wXcWlb68ILOObsKz5P3af9oVMo");
		GrowthPush.GetInstance ().RequestDeviceToken ("1000565500410", GrowthPush.Environment.Development);
		Growthbeat.GetInstance ().Start ();
		GrowthAnalytics.GetInstance ().SetBasicTags ();
		GrowthPush.GetInstance ().ClearBadge ();

	}   
	
	void Start ()
	{
	}
	
	void Update ()
	{
	#if UNITY_IPHONE
		if (!tokenSent) {
			byte[] token = NotificationServices.deviceToken;
			if (token != null) {
				GrowthPush.GetInstance ().SetDeviceToken(System.BitConverter.ToString(token));
				tokenSent = true;
			}
		}
	#endif
	}

	void OnDisable ()
	{
		Growthbeat.GetInstance ().Stop ();
	}

	void HandleCustomIntent(string json) {
		Debug.Log ("HandleCustomIntent");
	}


}
  