//
//  GrowthAnalyticsIOS.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthAnalyticsIOS {

	private static GrowthAnalyticsIOS instance = new GrowthAnalyticsIOS ();

	public static GrowthAnalyticsIOS GetInstance ()
	{
		return GrowthAnalyticsIOS.instance;
	}

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void growthAnalyticsTrack(string name, string properties, int option);
	[DllImport("__Internal")] static extern void growthAnalyticsTrackWithNamespace(string _namespace, string name, string properties, int option);
	[DllImport("__Internal")] static extern void growthAnalyticsTag(string name, string value);
	[DllImport("__Internal")] static extern void growthAnalyticsTagWithNamespace(string _namespace, string name, string value);
	[DllImport("__Internal")] static extern void growthAnalyticsOpen();
	[DllImport("__Internal")] static extern void growthAnalyticsClose();
	[DllImport("__Internal")] static extern void growthAnalyticsPurchase(int price, string category, string product);
	[DllImport("__Internal")] static extern void growthAnalyticsSetUserId(string userId);
	[DllImport("__Internal")] static extern void growthAnalyticsSetName(string name);
	[DllImport("__Internal")] static extern void growthAnalyticsSetAge(int age);
	[DllImport("__Internal")] static extern void growthAnalyticsSetGender(int gender);
	[DllImport("__Internal")] static extern void growthAnalyticsSetLevel(int level);
	[DllImport("__Internal")] static extern void growthAnalyticsSetDevelopment(bool development);
	[DllImport("__Internal")] static extern void growthAnalyticsSetDeviceModel();
	[DllImport("__Internal")] static extern void growthAnalyticsSetOS();
	[DllImport("__Internal")] static extern void growthAnalyticsSetLanguage();
	[DllImport("__Internal")] static extern void growthAnalyticsSetTimeZone();
	[DllImport("__Internal")] static extern void growthAnalyticsSetTimeZoneOffset();
	[DllImport("__Internal")] static extern void growthAnalyticsSetAppVersion();
	[DllImport("__Internal")] static extern void growthAnalyticsSetRandom();
	[DllImport("__Internal")] static extern void growthAnalyticsSetAdvertisingId();
	[DllImport("__Internal")] static extern void growthAnalyticsSeTrackingEnabled();
	[DllImport("__Internal")] static extern void growthAnalyticsSetBasicTags();
	#endif

	public void Tag (string name, string value)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTag(name, value);
		#endif
	}


	public void Tag (string _namespace, string name, string value)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTagWithNamespace(_namespace, name, value);
		#endif
	}

	public void Track (string name, Dictionary<string, string> properties, int option)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTrack(name, GetLine(properties), option);
		#endif
	}


	public void Track (string _namespace, string name, Dictionary<string, string> properties, int option)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTrackWithNamespace(_namespace, name, GetLine(properties), option);
		#endif
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
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsOpen();
		#endif
	}

	public void Close ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsClose();
		#endif
	}

	public void Purchase (int price, string category, string product)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsPurchase(price, category, product);
		#endif
	}

	public void SetUserId (string userId)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetUserId(userId);
		#endif
	}

	public void SetName (string name)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetName(name);
		#endif
	}

	public void SetAge (int age)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAge(age);
		#endif
	}

	public void SetGender(int gender) {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetGender(gender);
		#endif
	}

	public void SetLevel (int level)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetLevel(level);
		#endif
	}

	public void SetDevelopment (bool development) {
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetDevelopment(development);
		#endif
	}

	public void SetDeviceModel ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetDeviceModel();
		#endif
	}

	public void SetOS ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetOS();
		#endif
	}

	public void SetLanguage ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetLanguage();
		#endif
	}

	public void SetTimeZone ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetTimeZone();
		#endif
	}

	public void SetTimeZoneOffset ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetTimeZoneOffset();
		#endif
	}

	public void SetAppVersion ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAppVersion();
		#endif
	}

	public void SetRandom ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetRandom();
		#endif
	}

	public void SetAdvertisingId ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAdvertisingId();
		#endif
	}

	public void SetTrackingEnabled()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSeTrackingEnabled();
		#endif
	}

	public void SetBasicTags ()
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetBasicTags();
		#endif
	}

}
