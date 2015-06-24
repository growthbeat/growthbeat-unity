//
//  GrowthAnalyticsAndroid.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GrowthAnalyticsAndroid
{
	
	private static GrowthAnalyticsAndroid instance = new GrowthAnalyticsAndroid ();
	
	public static GrowthAnalyticsAndroid GetInstance ()
	{
		return GrowthAnalyticsAndroid.instance;
	}
	
	#if UNITY_ANDROID
	private static AndroidJavaObject growthAnalytics;
	#endif
	
	private GrowthAnalyticsAndroid()
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics" ))
		{
			growthAnalytics = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
		}
		#endif
	}
	
	public void Tag (string tagId, string value)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("tag", tagId, value);
		#endif
	}

	public void Tag (string _namespace, string tagId, string value)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("tag", _namespace, tagId, value, null);
		#endif
	}
	
	public void Track(string eventId, Dictionary<string, string> properties,GrowthAnalytics.TrackOption option)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		
		using (AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap"))
		{
			putMap(hashMap, properties);
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$TrackOption" );
			AndroidJavaObject optionObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(option == GrowthAnalytics.TrackOption.TrackOptionOnce ? "ONCE" : "COUNTER");
			growthAnalytics.Call("track",eventId, hashMap, optionObject);
		}
		#endif
	}

	public void Track(string _namespace, string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		
		using (AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap"))
		{
			putMap(hashMap, properties);
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$TrackOption" );
			AndroidJavaObject optionObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(option == GrowthAnalytics.TrackOption.TrackOptionOnce ? "ONCE" : "COUNTER");
			growthAnalytics.Call("track", _namespace, name, hashMap, optionObject);
		}
		#endif
	}

	private void putMap(AndroidJavaObject map, Dictionary<string, string> properties) {
		System.IntPtr method_Put = AndroidJNIHelper.GetMethodID (map.GetRawClass (), "put",
			                                                         "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			object[] args = new object[2];
			foreach (KeyValuePair<string, string> kvp in properties)
			{
				using (AndroidJavaObject k = new AndroidJavaObject("java.lang.String", kvp.Key))
				{
					using (AndroidJavaObject v = new AndroidJavaObject("java.lang.String", kvp.Value))
					{
						args [0] = k;
						args [1] = v;
						AndroidJNI.CallObjectMethod (map.GetRawObject (),
						                             method_Put, AndroidJNIHelper.CreateJNIArgArray (args));
					}
				}
			}
	}
	
	public void Open()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("open");
		#endif
	}
	
	public void Close()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("close");
		#endif
	}
	
	public void Purchase(int price, string category, string product)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("purchase", price, category, product);
		#endif
	}
	
	public void SetUserId(string userId)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setUserId", userId);
		#endif
	}
	
	public void SetName(string name)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setName", name);
		#endif
	}
	
	public void SetAge(int age)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAge", age);
		#endif
	}
	
	
	public void SetGender(GrowthAnalytics.Gender gender)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$Gender" );
		AndroidJavaObject genderObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(gender == GrowthAnalytics.Gender.GenderMale ? "MALE" : "FEMALE");
		growthAnalytics.Call("setGender",genderObject);
		#endif
	}
	
	public void SetLevel(int level)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setLevel",level);
		#endif
	}
	
	public void SetDevelopment(bool development)
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setDevelopment",development);
		#endif
	}
	
	public void SetDeviceModel()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setDeviceModel");
		#endif
	}
	
	public void SetOS()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setOS");
		#endif
	}
	
	public void SetLanguage()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setLanguage");
		#endif
	}
	
	public void SetTimeZone()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setTimeZone");
		#endif
	}
	
	public void SetTimeZoneOffset()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setTimeZoneOffset");
		#endif
	}
	
	public void SetAppVersion() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAppVersion");
		#endif
	}
	
	public void SetRandom()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setRandom");
		#endif
	}
	
	public void SetAdvertisingId()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAdvertisingId");
		#endif
	}
	
	public void SetBasicTags()
	{
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setBasicTags");
		#endif
	}
	
}
