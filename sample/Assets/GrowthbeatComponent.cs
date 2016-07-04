//
//  GrowthbeatComponent.cs
//
//  Created by Shigeru Ogawa on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
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
		GrowthPush.GetInstance ().Initialize (applicationId, credentialId, environment);
		IntentHandler.GetInstance ().AddNoopIntentHandler ();
		IntentHandler.GetInstance ().AddUrlIntentHandler ();
		IntentHandler.GetInstance ().AddCustomIntentHandler ("GrowthbeatComponent", "HandleCustomIntent");
		GrowthLink.GetInstance().Initialize (applicationId, credentialId);
		GrowthPush.GetInstance ().RequestDeviceToken (senderId);
		GrowthPush.GetInstance ().TrackEvent("Launch");

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
	}

	void HandleCustomIntent(string extra) {
		Debug.Log("Enter HandleCustomIntent");
		Debug.Log(extra);
	}

	public void ClickedRandom() {
	}

	public Toggle developmentToggle;

	public void ClickedDevelopment () {
		bool development = developmentToggle.isOn ? true : false;
	}

	public InputField levelField;

	public void EndInputLevel () {
		string level = levelField.text;
	}

	public void ShowMessage (string udid) {
		GrowthPush.GetInstance ().RenderMessage (udid);
	}

	public InputField itemField;
	public InputField priceField;

	public void ClickedPurchase () {
		string item = itemField.text;
		GrowthPush.GetInstance ().TrackEvent (item, "", "GrowthbeatComponent", "ShowMessage");
		string price = priceField.text;
	}

}
  