using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthAnalytics
{
	private static GrowthAnalytics instance = new GrowthAnalytics ();

	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport("__Internal")] static extern void AnalyticsInitializeWithApplicationId(string applicationID, string credentialId);
	[DllImport("__Internal")] static extern void AnalyticsTrack(string eventId);
	/*
	 * [DllImport("__Internal")] static extern void AnalyticsTrack(string applicationID, string credentialId);
	 * [DllImport("__Internal")] static extern void AnalyticsTrack(string applicationID, string credentialId);
	 * [DllImport("__Internal")] static extern void AnalyticsTrack(string applicationID, string credentialId);
	 */
	[DllImport("__Internal")] static extern void AnalyticsTag(string tagId, string value); 
	[DllImport("__Internal")] static extern void AnalyticsOpen();
	[DllImport("__Internal")] static extern void AnalyticsClose();
	[DllImport("__Internal")] static extern void AnalyticsPurchase(int price, string category, string product);
	[DllImport("__Internal")] static extern void AnalyticsSetUserId(string userId);
	[DllImport("__Internal")] static extern void AnalyticsSetName(string name);
	[DllImport("__Internal")] static extern void AnalyticsSetAge(int age);
	//	[DllImport("__Internal")] static extern void AnalyticsSetGender();
	[DllImport("__Internal")] static extern void AnalyticsSetLevel(int level);
	//	[DllImport("__Internal")] static extern void AnalyticsSetDevelopment();
	[DllImport("__Internal")] static extern void AnalyticsSetDeviceModel();
	[DllImport("__Internal")] static extern void AnalyticsSetOS();
	[DllImport("__Internal")] static extern void AnalyticsSetLanguage();
	[DllImport("__Internal")] static extern void AnalyticsSetTimeZone();
	[DllImport("__Internal")] static extern void AnalyticsSetTimeZoneOffset();
	[DllImport("__Internal")] static extern void AnalyticsSetAppVersion();
	[DllImport("__Internal")] static extern void AnalyticsSetRandom();
	[DllImport("__Internal")] static extern void AnalyticsSetAdvertisingId(string idfa);
	[DllImport("__Internal")] static extern void AnalyticsSetBasicTags();
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
		AnalyticsInitializeWithApplicationId(applicationId, credentialId);
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
		AnalyticsTag(tagId, value); 
		#endif
	}

	public void Track (string eventId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.track(eventId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsTrack(eventId);
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
		AnalyticsOpen(); 
		#endif
	}
	
	public void Close ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.close();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsClose(); 
		#endif
	}
	
	public void Purchase (int price, string category, string product)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.purchase(price, category, product);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsPurchase(price, category, product); 
		#endif
	}
	
	public void SetUserId (string userId)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setUserId(userId);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetUserId(userId); 
		#endif
	}
	
	public void SetName (string name)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setName(name);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetName(name); 
		#endif
	}
	
	public void SetAge (int age)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAge(age);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetAge(age); 
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
		AnalyticsSetLevel(level); 
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
		AnalyticsSetDeviceModel(); 
		#endif
	}
	
	public void SetOS ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setOS();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetOS(); 
		#endif
	}
	
	public void SetLanguage ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setLanguage();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetLanguage(); 
		#endif
	}
	
	public void SetTimeZone ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setTimeZone();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetTimeZone(); 
		#endif
	}
	
	public void SetTimeZoneOffset ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setTimeZoneOffset();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetTimeZoneOffset(); 
		#endif
	}
	
	public void SetAppVersion ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAppVersion();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetAppVersion(); 
		#endif
	}
	
	public void SetRandom ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setRandom();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetRandom(); 
		#endif
	}
	
	public void SetAdvertisingId (string idfa)
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setAdvertisingId(idfa);
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetAdvertisingId(idfa); 
		#endif
	}
	
	public void SetBasicTags ()
	{
		#if UNITY_ANDROID
		GrowthAnalyticsAndroid.setBasicTags();
		#elif UNITY_IPHONE && !UNITY_EDITOR
		AnalyticsSetBasicTags(); 
		#endif
	}

}
