//
//  IGrowthAnalytics.cs
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2015/12/09.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
namespace Growthbeat.Analytics {

	using UnityEngine;
	using System;
	using System.Text;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	
	internal interface IGrowthAnalytics {

		void Tag (string name);
	
		void Tag (string name, string value);

		void Tag (string _namespace, string name, string value);
		
		void Track (string name);
		
		void Track (string name, Dictionary<string, string> properties);
		
		void Track (string name, GrowthAnalytics.TrackOption option);
		
		void Track (string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option);

		void Track (string _namespace, string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option);
		
		void Open ();
		
		void Close ();
		
		void Purchase (int price, string category, string product);
		
		void SetUserId (string userId);
		
		void SetName (string name);
		
		void SetAge (int age);
		
		void SetGender(GrowthAnalytics.Gender gender);
		
		void SetLevel (int level);
		
		void SetDevelopment (bool development);
		
		void SetDeviceModel ();
		
		void SetOS ();
		
		void SetLanguage ();
		
		void SetTimeZone ();
		
		void SetTimeZoneOffset ();
		
		void SetAppVersion ();
		
		void SetRandom ();
		
		void SetAdvertisingId ();

		void SetTrackingEnable ();
		
		void SetBasicTags ();

		void SetBaseUrl(string baseUrl);

	}

}