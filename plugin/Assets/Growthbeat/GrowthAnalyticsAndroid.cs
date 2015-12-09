//
//  GrowthAnalyticsAndroid.cs
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//
#if UNITY_ANDROID
namespace Growthbeat.Analytics
{

	using UnityEngine;
	using System;
	using System.Text;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Growthbeat;

	internal class GrowthAnalyticsAndroid : IGrowthAnalytics
	{

		private AndroidJavaObject growthAnalytics;
		private GrowthAnalyticsAndroid()
		{
			using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics" ))
			{
				growthAnalytics = gbcclass.CallStatic<AndroidJavaObject>("getInstance");
			}
		}

		public void Tag (string name, string value)
		{
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("tag", name, value);
		}

		public void Tag (string _namespace, string name, string value)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("tag", _namespace, name, value, null);
		}

		public void Track(string name, Dictionary<string, string> properties,GrowthAnalytics.TrackOption option)
		{
			
			if (growthAnalytics == null)
				return;

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
			
			if (growthAnalytics == null)
				return;

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
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("open");
		}

		public void Close()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("close");
		}

		public void Purchase(int price, string category, string product)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("purchase", price, category, product);
		}

		public void SetUserId(string userId)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setUserId", userId);
		}

		public void SetName(string name)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setName", name);
		}

		public void SetAge(int age)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setAge", age);
		}


		public void SetGender(GrowthAnalytics.Gender gender)
		{
			
			if (growthAnalytics == null)
				return;
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$Gender" );
			AndroidJavaObject genderObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(gender == GrowthAnalytics.Gender.GenderMale ? "MALE" : "FEMALE");
			growthAnalytics.Call("setGender",genderObject);
		}

		public void SetLevel(int level)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setLevel",level);
		}

		public void SetDevelopment(bool development)
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setDevelopment",development);
		}

		public void SetDeviceModel()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setDeviceModel");
		}

		public void SetOS()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setOS");
		}

		public void SetLanguage()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setLanguage");
		}

		public void SetTimeZone()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setTimeZone");
		}

		public void SetTimeZoneOffset()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setTimeZoneOffset");
		}

		public void SetAppVersion() {
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setAppVersion");
		}

		public void SetRandom()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setRandom");
		}

		public void SetAdvertisingId()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setAdvertisingId");
		}

		public void SetTrackingEnabled() 
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setTrackingEnabled");
		}

		public void SetBasicTags()
		{
			
			if (growthAnalytics == null)
				return;
			growthAnalytics.Call("setBasicTags");
		}

		public void SetBaseUrl(string baseUrl)
		{
			 && !UNITY_EDITOR
			if(growthAnalytics == null)
				return;
			AndroidJavaObject httpClient = growthAnalytics.Call<AndroidJavaObject>("getHttpClient");
			httpClient.Call("setBaseUrl", baseUrl);
		}

	}
}
#endif