using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

public class GrowthPush {

		public enum Environment {
				Unknown = 0,
				Development = 1,
				Production = 2
		}

		public static void Initialize(string applicationId, string credentialId, Environment environment, bool debug) {
				#if UNITY_ANDROID
				#elif UNITY_IPHONE
					GrowthPushIOS.Initialize(applicationId, credentialId, environment, debug); 
				#endif

		}

		public static void Initialize(string applicationId, string credentialId, Environment environment, bool debug, string senderId) {
				#if UNITY_ANDROID	
					GrowthPushAndroid.Initialize(applicationId, secret, environment, debug, senderId);
				#elif UNITY_IPHONE
					Initialize(applicationId, credentialId, environment, debug);
				#endif
		}

//		public static void TrackEvent(string name) {
//				TrackEvent(name, null);
//		}
//
//		public static void TrackEvent(string name, string value) {
//				#if UNITY_ANDROID
//					GrowthPushAndroid.TrackEvent(name, value);
//				#elif UNITY_IPHONE
//					GrowthPushIOS.TrackEvent(name, value);
//				#endif
//		}
//
//		public static void SetTag(string name) {
//				SetTag(name, null);
//		}
//
//		public static void SetTag (string name, string value) {
//				#if UNITY_ANDROID
//					GrowthPushAndroid.SetTag(name, value);
//				#elif UNITY_IPHONE
//					GrowthPushIOS.SetTag(name, value);
//				#endif
//		}
//
//		public static void SetDeviceTags () {
//				#if UNITY_ANDROID
//					GrowthPushAndroid.SetDeviceTags();
//				#elif UNITY_IPHONE
//					GrowthPushIOS.SetDeviceTags();
//				#endif
//		}
//
//		public static void ClearBadge () {
//				#if UNITY_IPHONE
//					GrowthPushIOS.ClearBadge();
//				#endif
//		}
		
}
