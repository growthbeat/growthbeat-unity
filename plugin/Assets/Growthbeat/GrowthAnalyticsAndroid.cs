//
//  GrowthAnalyticsAndroid.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
#if UNITY_ANDROID
using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class GrowthAnalyticsAndroid : IGrowthAnalytics
{

	private AndroidJavaObject growthAnalytics;
	public GrowthAnalyticsAndroid()
	{
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics" ))
		{
			growthAnalytics = gbcclass.CallStatic<AndroidJavaObject>("getInstance");
		}
	}

	public void Tag (string name)
	{
		Tag (name, null);
	}

	public void Tag (string name, string value)
	{
		growthAnalytics.Call("tag", name, value);
	}

	public void Tag (string _namespace, string name, string value)
	{
		growthAnalytics.Call("tag", _namespace, name, value, null);
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

	public void Track(string name, Dictionary<string, string> properties,GrowthAnalytics.TrackOption option)
	{

		using (AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap"))
		{
			System.IntPtr method_Put = AndroidJNIHelper.GetMethodID (hashMap.GetRawClass (), "put",
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
						AndroidJNI.CallObjectMethod (hashMap.GetRawObject (),
						                             method_Put, AndroidJNIHelper.CreateJNIArgArray (args));
					}
				}
			}
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$TrackOption" );
			AndroidJavaObject optionObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(option == GrowthAnalytics.TrackOption.TrackOptionOnce ? "ONCE" : "COUNTER");
			growthAnalytics.Call("track",name, hashMap, optionObject);
		}
	}

	public void Track(string _namespace, string name, Dictionary<string, string> properties, GrowthAnalytics.TrackOption option) {

		using (AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap"))
		{
			System.IntPtr method_Put = AndroidJNIHelper.GetMethodID (hashMap.GetRawClass (), "put",
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
						AndroidJNI.CallObjectMethod (hashMap.GetRawObject (),
						                             method_Put, AndroidJNIHelper.CreateJNIArgArray (args));
					}
				}
			}
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$TrackOption" );
			AndroidJavaObject optionObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(option == GrowthAnalytics.TrackOption.TrackOptionOnce ? "ONCE" : "COUNTER");
			growthAnalytics.Call("track", _namespace, name, hashMap, optionObject, null);
		}
	}

	public void Open()
	{
		growthAnalytics.Call("open");
	}

	public void Close()
	{
		growthAnalytics.Call("close");
	}

	public void Purchase(int price, string category, string product)
	{
		growthAnalytics.Call("purchase", price, category, product);
	}

	public void SetUserId(string userId)
	{
		growthAnalytics.Call("setUserId", userId);
	}

	public void SetName(string name)
	{
		growthAnalytics.Call("setName", name);
	}

	public void SetAge(int age)
	{
		growthAnalytics.Call("setAge", age);
	}
	
	public void SetGender(GrowthAnalytics.Gender gender)
	{
		AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$Gender" );
		AndroidJavaObject genderObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(gender == GrowthAnalytics.Gender.GenderMale ? "MALE" : "FEMALE");
		growthAnalytics.Call("setGender",genderObject);
	}

	public void SetLevel(int level)
	{
		growthAnalytics.Call("setLevel",level);
	}

	public void SetDevelopment(bool development)
	{
		growthAnalytics.Call("setDevelopment",development);
	}

	public void SetDeviceModel()
	{
		growthAnalytics.Call("setDeviceModel");
	}

	public void SetOS()
	{
		growthAnalytics.Call("setOS");
	}

	public void SetLanguage()
	{
		growthAnalytics.Call("setLanguage");
	}

	public void SetTimeZone()
	{
		growthAnalytics.Call("setTimeZone");
	}

	public void SetTimeZoneOffset()
	{
		growthAnalytics.Call("setTimeZoneOffset");
	}

	public void SetAppVersion() {
		growthAnalytics.Call("setAppVersion");
	}

	public void SetRandom()
	{
		growthAnalytics.Call("setRandom");
	}

	public void SetAdvertisingId()
	{
		growthAnalytics.Call("setAdvertisingId");
	}

	public void SetTrackingEnabled() 
	{
		growthAnalytics.Call("setTrackingEnabled");
	}

	public void SetBasicTags()
	{
		growthAnalytics.Call("setBasicTags");
	}

	public void SetBaseUrl(string baseUrl)
	{
		AndroidJavaObject httpClient = growthAnalytics.Call<AndroidJavaObject>("getHttpClient");
		httpClient.Call("setBaseUrl", baseUrl);
	}

}
#endif