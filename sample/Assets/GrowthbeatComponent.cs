//
//  GrowthbeatComponent.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System.Collections;

public class GrowthbeatComponent : MonoBehaviour
{
	
	void Awake ()
	{
		Growthbeat.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23", "955057365401", true);
	}
	
	void Start ()
	{
		//GrowthBeat
		Growthbeat.GetInstance ().Start ();
		Growthbeat.GetInstance ().Stop ();
		Growthbeat.GetInstance ().SetLoggerSilent (true);

		//GrowthAnalytics
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
		GrowthAnalytics.GetInstance ().Close ();

		//GrowthPush
		GrowthPush.GetInstance ().ClearBadge ();

	}
	
	void Update ()
	{
		
	}
}
