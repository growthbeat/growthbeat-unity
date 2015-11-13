//
//  GrowthAnalytics.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthAnalytics
{
	private static GrowthAnalytics instance = new GrowthAnalytics ();
	
	public static GrowthAnalytics GetInstance ()
	{
		return GrowthAnalytics.instance;
	}
	
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
	
	public void Tag (string name)
	{
		Tag (name, null);
	}
	
	public void Tag (string name, string value)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Tag(name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Tag(name, value); 
		#endif
	}

	public void Tag (string _namespace, string name, string value)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Tag(_namespace, name, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Tag(_namespace, name, value); 
		#endif
	}
	
	public void Track (string name)
	{
		Track (name, new Dictionary<string, string>(), 0);
	}
	
	public void Track (string name, Dictionary<string, string> properties)
	{
		Track (name, properties, 0);
	}
	
	public void Track (string name, TrackOption option)
	{
		Track (name, new Dictionary<string, string>(), option);
	}
	
	public void Track (string name, Dictionary<string, string> properties, TrackOption option)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Track(name, properties, option);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Track(name, properties, (int)option);
		#endif
	}

	public void Track (string _namespace, string name, Dictionary<string, string> properties, TrackOption option)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Track(_namespace, name, properties, option);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Track(_namespace, name, properties, (int)option);
		#endif
	}
	
	public void Open ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Open();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Open(); 
		#endif
	}
	
	public void Close ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Close();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Close(); 
		#endif
	}
	
	public void Purchase (int price, string category, string product)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().Purchase(price, category, product);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().Purchase(price, category, product); 
		#endif
	}
	
	public void SetUserId (string userId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetUserId(userId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetUserId(userId); 
		#endif
	}
	
	public void SetName (string name)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetName(name);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetName(name); 
		#endif
	}
	
	public void SetAge (int age)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetAge(age);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetAge(age); 
		#endif
	}
	
	public void SetGender(Gender gender) {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetGender(gender); 
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetGender((int)gender); 
		#endif
	}
	
	public void SetLevel (int level)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetLevel(level);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetLevel(level); 
		#endif
	}
	
	public void SetDevelopment (bool development) {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetDevelopment(development);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetDevelopment(development); 
		#endif
	}
	
	public void SetDeviceModel ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetDeviceModel();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetDeviceModel(); 
		#endif
	}
	
	public void SetOS ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetOS();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetOS(); 
		#endif
	}
	
	public void SetLanguage ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetLanguage();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetLanguage(); 
		#endif
	}
	
	public void SetTimeZone ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetTimeZone();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetTimeZone(); 
		#endif
	}
	
	public void SetTimeZoneOffset ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetTimeZoneOffset();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetTimeZoneOffset(); 
		#endif
	}
	
	public void SetAppVersion ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetAppVersion();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetAppVersion(); 
		#endif
	}
	
	public void SetRandom ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetRandom();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetRandom(); 
		#endif
	}
	
	public void SetAdvertisingId ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetAdvertisingId();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetAdvertisingId(); 
		#endif
	}

	public void SetTrackingEnable ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetTrackingEnabled();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetTrackingEnabled(); 
		#endif
	}
	
	public void SetBasicTags ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.GetInstance().SetBasicTags();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.GetInstance().SetBasicTags(); 
		#endif
	}
	
}
