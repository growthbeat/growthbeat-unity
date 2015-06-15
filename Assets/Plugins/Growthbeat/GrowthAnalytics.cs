//
//  GrowthAnalytics.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthAnalytics
{
	private static GrowthAnalytics instance = new GrowthAnalytics ();

	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport("__Internal")] static extern void growthAnalyticsInitializeWithApplicationId(string applicationID, string credentialId);
	[DllImport("__Internal")] static extern void growthAnalyticsTrack(string eventId);
	/*
	 * [DllImport("__Internal")] static extern void growthAnalyticsTrack(string applicationID, string credentialId);
	 * [DllImport("__Internal")] static extern void growthAnalyticsTrack(string applicationID, string credentialId);
	 * [DllImport("__Internal")] static extern void growthAnalyticsTrack(string applicationID, string credentialId);
	 */
	[DllImport("__Internal")] static extern void growthAnalyticsTag(string tagId, string value); 
	[DllImport("__Internal")] static extern void growthAnalyticsOpen();
	[DllImport("__Internal")] static extern void growthAnalyticsClose();
	[DllImport("__Internal")] static extern void growthAnalyticsPurchase(int price, string category, string product);
	[DllImport("__Internal")] static extern void growthAnalyticsSetUserId(string userId);
	[DllImport("__Internal")] static extern void growthAnalyticsSetName(string name);
	[DllImport("__Internal")] static extern void growthAnalyticsSetAge(int age);
	//	[DllImport("__Internal")] static extern void growthAnalyticsSetGender();
	[DllImport("__Internal")] static extern void growthAnalyticsSetLevel(int level);
	//	[DllImport("__Internal")] static extern void growthAnalyticsSetDevelopment();
	[DllImport("__Internal")] static extern void growthAnalyticsSetDeviceModel();
	[DllImport("__Internal")] static extern void growthAnalyticsSetOS();
	[DllImport("__Internal")] static extern void growthAnalyticsSetLanguage();
	[DllImport("__Internal")] static extern void growthAnalyticsSetTimeZone();
	[DllImport("__Internal")] static extern void growthAnalyticsSetTimeZoneOffset();
	[DllImport("__Internal")] static extern void growthAnalyticsSetAppVersion();
	[DllImport("__Internal")] static extern void growthAnalyticsSetRandom();
	[DllImport("__Internal")] static extern void growthAnalyticsSetAdvertisingId(string idfa);
	[DllImport("__Internal")] static extern void growthAnalyticsSetBasicTags();
	#endif

	public static GrowthAnalytics GetInstance ()
	{
		return GrowthAnalytics.instance;
	}

	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.Initialize(applicationId, credentialId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsInitializeWithApplicationId(applicationId, credentialId);
		#endif
	}

	public void Tag (string tagId)
	{
		Tag(tagId, null);
	}
	
	public void Tag (string tagId, string value)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.tag(tagId, value);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTag(tagId, value); 
		#endif
	}

	public void Track (string eventId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.track(eventId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsTrack(eventId);
		#endif
	}

	/*public void Track(string eventId) {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.track(eventId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.track(eventId); 
		#endif
	}

	public void Track(string eventId) {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.track(eventId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.track(eventId); 
		#endif
	}

	public void Track(string eventId) {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.track(eventId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		GrowthAnalyticsIOS.track(eventId); 
		#endif
	}*/



	public void Open ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.open();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsOpen(); 
		#endif
	}
	
	public void Close ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.close();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsClose(); 
		#endif
	}
	
	public void Purchase (int price, string category, string product)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.purchase(price, category, product);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsPurchase(price, category, product); 
		#endif
	}
	
	public void SetUserId (string userId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setUserId(userId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetUserId(userId); 
		#endif
	}
	
	public void SetName (string name)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setName(name);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetName(name); 
		#endif
	}
	
	public void SetAge (int age)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAge(age);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAge(age); 
		#endif
	}

	/*
	public void SetGender() {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.open();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		open(); 
		#endif
	}*/
	
	public void SetLevel (int level)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setLevel(level);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetLevel(level); 
		#endif
	}

	/*
	public void SetDevelopment() {
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.open();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsOpen(); 
		#endif
	}*/

	public void SetDeviceModel ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setDeviceModel();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetDeviceModel(); 
		#endif
	}
	
	public void SetOS ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setOS();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetOS(); 
		#endif
	}
	
	public void SetLanguage ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setLanguage();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetLanguage(); 
		#endif
	}
	
	public void SetTimeZone ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setTimeZone();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetTimeZone(); 
		#endif
	}
	
	public void SetTimeZoneOffset ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setTimeZoneOffset();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetTimeZoneOffset(); 
		#endif
	}
	
	public void SetAppVersion ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAppVersion();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAppVersion(); 
		#endif
	}
	
	public void SetRandom ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setRandom();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetRandom(); 
		#endif
	}
	
	public void SetAdvertisingId (string idfa)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAdvertisingId(idfa);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetAdvertisingId(idfa); 
		#endif
	}
	
	public void SetBasicTags ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setBasicTags();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		growthAnalyticsSetBasicTags(); 
		#endif
	}

}
