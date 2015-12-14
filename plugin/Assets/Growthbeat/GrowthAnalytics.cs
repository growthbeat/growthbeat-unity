//
//  GrowthAnalytics.cs
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2015/12/09.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthAnalytics {

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

	private IGrowthAnalytics growthAnalyticsInterface = GrowthAnalyticsFactory.GenerateInstance ();
	private static GrowthAnalytics instance = new GrowthAnalytics ();

	public static GrowthAnalytics GetInstance()
	{
		return GrowthAnalytics.instance;
	}

	public void Tag (string name)
	{
		this.growthAnalyticsInterface.Tag (name);
	}

	public void Tag (string name, string value)
	{
		this.growthAnalyticsInterface.Tag (name, value);
	}

	public void Tag (string _namespace, string name, string value)
	{
		this.growthAnalyticsInterface.Tag (_namespace, name, value);
	}

	public void Track (string name)
	{
		this.growthAnalyticsInterface.Track (name, new Dictionary<string, string>(), GrowthAnalytics.TrackOption.TrackOptionDefault);
	}
	
	public void Track (string name, Dictionary<string, string> properties)
	{
		this.growthAnalyticsInterface.Track (name, properties, GrowthAnalytics.TrackOption.TrackOptionDefault);
	}
	
	public void Track (string name, GrowthAnalytics.TrackOption option)
	{
		this.growthAnalyticsInterface.Track (name, new Dictionary<string, string>(), option);
	}


	public void Track (string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option)
	{
		this.growthAnalyticsInterface.Track (name, properties, option);
	}

	public void Track (string _namespace, string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option)
	{
		this.growthAnalyticsInterface.Track (_namespace, name, properties, option);
	}

	public void Open ()
	{
		this.growthAnalyticsInterface.Open ();
	}

	public void Close ()
	{
		this.growthAnalyticsInterface.Close ();
	}

	public void Purchase (int price, string category, string product)
	{
		this.growthAnalyticsInterface.Purchase (price, category, product);
	}

	public void SetUserId (string userId)
	{
		this.growthAnalyticsInterface.SetUserId(userId);
	}

	public void SetName (string name)
	{
		this.growthAnalyticsInterface.SetName(name);
	}

	public void SetAge (int age)
	{
		this.growthAnalyticsInterface.SetAge(age);
	}

	public void SetGender(GrowthAnalytics.Gender gender) {
		this.growthAnalyticsInterface.SetGender(gender);
	}

	public void SetLevel (int level)
	{
		this.growthAnalyticsInterface.SetLevel(level);
	}

	public void SetDevelopment (bool development) {
		this.growthAnalyticsInterface.SetDevelopment(development);
	}

	public void SetDeviceModel ()
	{
		this.growthAnalyticsInterface.SetDeviceModel();
	}

	public void SetOS ()
	{
		this.growthAnalyticsInterface.SetOS();
	}

	public void SetLanguage ()
	{
		this.growthAnalyticsInterface.SetLanguage();
	}

	public void SetTimeZone ()
	{
		this.growthAnalyticsInterface.SetTimeZone();
	}

	public void SetTimeZoneOffset ()
	{
		this.growthAnalyticsInterface.SetTimeZoneOffset();
	}

	public void SetAppVersion ()
	{
		this.growthAnalyticsInterface.SetAppVersion();
	}

	public void SetRandom ()
	{
		this.growthAnalyticsInterface.SetRandom();
	}

	public void SetAdvertisingId ()
	{
		this.growthAnalyticsInterface.SetAdvertisingId();
	}

	public void SetTrackingEnabled()
	{
		this.growthAnalyticsInterface.SetTrackingEnabled();
	}

	public void SetBasicTags ()
	{
		this.growthAnalyticsInterface.SetBasicTags();
	}

	public void SetBaseUrl(string baseUrl)
	{
		this.growthAnalyticsInterface.SetBaseUrl(baseUrl);	
	}

}
