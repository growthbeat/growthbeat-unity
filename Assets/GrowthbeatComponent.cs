//
//  GrowthbeatComponent.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System.Collections;

public class GrowthbeatComponent : MonoBehaviour {
	
	void Awake ()
	{
		Growthbeat.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
	}
	
	void Start ()
	{
		//GrowthBeat
		Growthbeat.GetInstance ().Start ();
		Growthbeat.GetInstance ().Stop ();
		Growthbeat.GetInstance ().SetLoggerSilent (true);
		Growthbeat.GetInstance ().SetLoggerSilent (false);

		//GrowthAnalytics
		GrowthAnalytics.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
		GrowthAnalytics.GetInstance ().Open ();
		GrowthAnalytics.GetInstance ().Tag ("TagTest");
		GrowthAnalytics.GetInstance ().Tag ("TagTest_Number", "1234");
		GrowthAnalytics.GetInstance ().Track ("TrackEvent");
		GrowthAnalytics.GetInstance ().Purchase (1234, "Category", "product");
		GrowthAnalytics.GetInstance ().SetUserId ("UserId");
		GrowthAnalytics.GetInstance ().SetName ("Name");
		GrowthAnalytics.GetInstance ().SetAge (1234);
		GrowthAnalytics.GetInstance ().SetGender (GrowthAnalytics.Gender.GenderFemale);
		GrowthAnalytics.GetInstance ().SetLevel (1234);
		GrowthAnalytics.GetInstance ().SetDevelopment (true);
		GrowthAnalytics.GetInstance ().SetDevelopment (false);
		GrowthAnalytics.GetInstance ().SetDeviceModel ();
		GrowthAnalytics.GetInstance ().SetOS ();
		GrowthAnalytics.GetInstance ().SetLanguage ();
		GrowthAnalytics.GetInstance ().SetTimeZone ();
		GrowthAnalytics.GetInstance ().SetTimeZoneOffset ();
		GrowthAnalytics.GetInstance ().SetAppVersion ();
		GrowthAnalytics.GetInstance ().SetRandom ();
		GrowthAnalytics.GetInstance ().SetAdvertisingId();
		GrowthAnalytics.GetInstance ().SetBasicTags();
		GrowthAnalytics.GetInstance ().Close ();

		//GrowthPush
		GrowthPush.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23", GrowthPush.Environment.Development);
		GrowthPush.GetInstance ().RequestDeviceToken ();
		GrowthPush.GetInstance ().SetDeviceToken ("DeviceToken");
		GrowthPush.GetInstance ().ClearBadge ();

		//GrowthMessage
		GrowthMessage.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
	}
	
	void Update ()
	{
		
	}
}
