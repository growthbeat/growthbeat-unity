﻿//
//  GrowthbeatComponent.cs
//
//  Created by Shigeru Ogawa on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
using UnityEngine;
using System.Collections;
using Growthbeat;
#if UNITY_IPHONE
using NotificationServices = UnityEngine.iOS.NotificationServices;
#endif

public class GrowthbeatComponent : MonoBehaviour
{
	#if UNITY_IPHONE
  	bool tokenSent = false;
  	#endif

  	public string applicationId = "";
  	public string credentialId = "";
  	public string senderId = "";
  	public GrowthPush.Environment environment = GrowthPush.Environment.Unknown;

	void Awake ()
	{
		GrowthbeatCore.GetInstance ().Initialize (applicationId, credentialId);
		IntentHandler.GetInstance ().AddNoopIntentHandler ();
		IntentHandler.GetInstance ().AddUrlIntentHandler ();
		IntentHandler.GetInstance ().AddCustomIntentHandler ("GrowthbeatComponent", "HandleCustomIntent");
		GrowthLink.GetInstance().Initialize (applicationId, credentialId);
		GrowthPush.GetInstance ().RequestDeviceToken (senderId, environment);
		GrowthbeatCore.GetInstance ().Start ();
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
				GrowthPush.GetInstance ().SetDeviceToken(System.BitConverter.ToString(token).Replace("-", "").ToLower());
				tokenSent = true;
			}
		}
	#endif
	}

	void OnDisable ()
	{
		GrowthbeatCore.GetInstance ().Stop ();
	}

	void HandleCustomIntent(string extra) {
		
	}

}
  