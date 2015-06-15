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
		//Growthbeat.GetInstance ().Initialize ("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
//		GrowthAnalytics.GetInstance().Initialize("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
		GrowthPush.GetInstance().Initialize("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23", GrowthPush.Environment.Development);
//		GrowthMessage.GetInstance().Initialize("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
	}
	
	void Start ()
	{
		Growthbeat.GetInstance ().Start ();
	}
	
	void Update ()
	{
		
	}
}
