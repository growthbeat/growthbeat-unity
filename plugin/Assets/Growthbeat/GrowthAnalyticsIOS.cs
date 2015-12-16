//
//  GrowthAnalyticsIOS.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
#if UNITY_IPHONE
using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class GrowthAnalyticsiOS : IGrowthAnalytics
{

	[DllImport("__Internal")] static extern void ga_track(string name, string properties, int option);
	[DllImport("__Internal")] static extern void ga_trackWithNamespace(string _namespace, string name, string properties, int option);
	[DllImport("__Internal")] static extern void ga_tag(string name, string value);
	[DllImport("__Internal")] static extern void ga_tagWithNamespace(string _namespace, string name, string value);
	[DllImport("__Internal")] static extern void ga_open();
	[DllImport("__Internal")] static extern void ga_close();
	[DllImport("__Internal")] static extern void ga_purchase(int price, string category, string product);
	[DllImport("__Internal")] static extern void ga_setUserId(string userId);
	[DllImport("__Internal")] static extern void ga_setName(string name);
	[DllImport("__Internal")] static extern void ga_setAge(int age);
	[DllImport("__Internal")] static extern void ga_setGender(int gender);
	[DllImport("__Internal")] static extern void ga_setLevel(int level);
	[DllImport("__Internal")] static extern void ga_setDevelopment(bool development);
	[DllImport("__Internal")] static extern void ga_setDeviceModel();
	[DllImport("__Internal")] static extern void ga_setOS();
	[DllImport("__Internal")] static extern void ga_setLanguage();
	[DllImport("__Internal")] static extern void ga_setTimeZone();
	[DllImport("__Internal")] static extern void ga_setTimeZoneOffset();
	[DllImport("__Internal")] static extern void ga_setAppVersion();
	[DllImport("__Internal")] static extern void ga_setRandom();
	[DllImport("__Internal")] static extern void ga_setAdvertisingId();
	[DllImport("__Internal")] static extern void ga_setTrackingEnabled();
	[DllImport("__Internal")] static extern void ga_setBasicTags();
	[DllImport("__Internal")] static extern void ga_setBaseUrl(string baseUrl);

	public void Tag (string name)
	{
		Tag (name, null);
	}

	public void Tag (string name, string value)
	{
		ga_tag(name, value);
	}

	public void Tag (string _namespace, string name, string value)
	{
		ga_tagWithNamespace(_namespace, name, value);
	}

	public void Track (string name)
	{
		Track (name, new Dictionary<string, string>(), GrowthAnalytics.TrackOption.TrackOptionDefault);
	}
	
	public void Track (string name, Dictionary<string, string> properties)
	{
		Track (name, properties, GrowthAnalytics.TrackOption.TrackOptionDefault);
	}
	
	public void Track (string name, GrowthAnalytics.TrackOption option)
	{
		Track (name, new Dictionary<string, string>(), option);
	}


	public void Track (string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option)
	{
		ga_track(name, GetLine(properties), (int)option);
	}

	public void Track (string _namespace, string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option)
	{
		ga_trackWithNamespace(_namespace, name, GetLine(properties), (int)option);
	}

	private string GetLine (Dictionary<string, string> dictionary)
	{
		StringBuilder builder = new StringBuilder();
		foreach (KeyValuePair<string, string> pair in dictionary)
		{
			builder.Append("{").Append(pair.Key).Append(":").Append(pair.Value).Append("},");
		}
		string result = builder.ToString();
		result = result.TrimEnd(',');
		return result;
	}

	public void Open ()
	{
		ga_open();
	}

	public void Close ()
	{
		ga_close();
	}

	public void Purchase (int price, string category, string product)
	{
		ga_purchase(price, category, product);
	}

	public void SetUserId (string userId)
	{
		ga_setUserId(userId);
	}

	public void SetName (string name)
	{
		ga_setName(name);
	}

	public void SetAge (int age)
	{
		ga_setAge(age);
	}

	public void SetGender(GrowthAnalytics.Gender gender) {
		ga_setGender((int)gender);
	}

	public void SetLevel (int level)
	{
		ga_setLevel(level);
	}

	public void SetDevelopment (bool development) {
		ga_setDevelopment(development);
	}

	public void SetDeviceModel ()
	{
		ga_setDeviceModel();
	}

	public void SetOS ()
	{
		ga_setOS();
	}

	public void SetLanguage ()
	{
		ga_setLanguage();
	}

	public void SetTimeZone ()
	{
		ga_setTimeZone();
	}

	public void SetTimeZoneOffset ()
	{
		ga_setTimeZoneOffset();
	}

	public void SetAppVersion ()
	{
		ga_setAppVersion();
	}

	public void SetRandom ()
	{
		ga_setRandom();
	}

	public void SetAdvertisingId ()
	{
		ga_setAdvertisingId();
	}

	public void SetTrackingEnabled()
	{
		ga_setTrackingEnabled();
	}

	public void SetBasicTags ()
	{
		ga_setBasicTags();
	}

	public void SetBaseUrl(string baseUrl)
	{
		ga_setBaseUrl(baseUrl);	
	}

}
#endif