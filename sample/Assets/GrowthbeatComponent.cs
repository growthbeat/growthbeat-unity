//
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
		Growthbeat.GetInstance ().Initialize ("OrXmgFYkGQkqDBtT", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23", true);
		GrowthPush.GetInstance ().RequestDeviceToken ();
		GrowthPush.GetInstance ().RequestRegistrationId ("955057365401");
	} 
	
	void Start ()
	{
		//GrowthBeat
		Growthbeat.GetInstance ().Start ();
		Growthbeat.GetInstance ().Stop ();   
		  
		//GrowthAnalytics
		GrowthAnalytics.GetInstance ().Open ();
		GrowthAnalytics.GetInstance ().SetBasicTags ();
		GrowthAnalytics.GetInstance ().Tag ("TagTest");
		GrowthAnalytics.GetInstance ().Tag ("TagTest_Number", "1234");
		GrowthAnalytics.GetInstance ().Track ("TrackEvent");
		GrowthAnalytics.GetInstance ().Purchase (1234, "Category", "product");
		GrowthAnalytics.GetInstance (). SetUserId ("UserId");
		GrowthAnalytics.GetInstance ().SetName ("Name");
		GrowthAnalytics.GetInstance ().SetAge (1234);
		GrowthAnalytics.GetInstance ().SetGender (GrowthAnalytics.Gender.GenderFemale);
		GrowthAnalytics.GetInstance ().SetLevel (1234);
		GrowthAnalytics.GetInstance ().SetDevelopment (true);
		GrowthAnalytics.GetInstance ().Close ();

		//GrowthPush
		GrowthPush.GetInstance ().ClearBadge ();
		GrowthPush.GetInstance ().SetTag ("TagTest");
		GrowthPush.GetInstance ().SetTag ("userId", "123");
		GrowthPush.GetInstance ().TrackEvent ("Launch");
		GrowthPush.GetInstance ().TrackEvent ("Purchace", "100");
		GrowthPush.GetInstance ().SetDeviceTags ();
 
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
}
  