//
//  GrowthAnalytics.cs
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2015/12/09.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
namespace Growthbeat {
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Growthbeat.Analytics;

	internal class GrowthAnalytics {

		public enum Gender
		{
			GenderNone = 0,
			GenderMale = 1,
			GenderFemale = 2
		}
		
		public enum TrackOption
		{
			TrackOptionDefault = 0,
			TrackOptionOnce = 1,
			TrackOptionCounter = 2
		}

		private static IGrowthAnalytics instance = null;
		
		public static IGrowthAnalytics GetInstance()
		{
			if(GrowthAnalytics.instance != null) {

				#if UNITY_IPHONE
				instance = new GrowthAnalyticsiOS ();
				#elif UNITY_ANDROID
				instance = new GrowthAnalyticsAndroid ();
				#endif
			}

			return GrowthAnalytics.instance;
		}

	}

}