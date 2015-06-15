using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class GrowthPushIOS {

		#if UNITY_IPHONE
			[DllImport("__Internal")] private static extern void growthPushInitializeWithApplicationId(string applicationID, string credentialId, int environment, bool debug);
//			[DllImport("__Internal")] private static extern void growthPushTrackEvent(string name, string value);
//			[DllImport("__Internal")] private static extern void growthPushSetTag(string name, string value);
//			[DllImport("__Internal")] private static extern void growthPushSetDeviceTags();
//			[DllImport("__Internal")] private static extern void growthPushClearBadge();
		#endif

		public static void Initialize(string applicationID, string credentialId, GrowthPush.Environment environment, bool debug) {
				#if UNITY_IPHONE && !UNITY_EDITOR
					growthPushInitializeWithApplicationId(applicationID, credentialId, (int)environment, debug);
				#endif
		}

//		public static void TrackEvent(string name, string value) {
//				#if UNITY_IPHONE && !UNITY_EDITOR
//					growthPushTrackEvent(name, value);
//				#endif
//		}
//
//		public static void SetTag(string name, string value) {
//				#if UNITY_IPHONE && !UNITY_EDITOR
//					growthPushSetTag(name, value);
//				#endif
//		}
//
//		public static void SetDeviceTags() {
//				#if UNITY_IPHONE && !UNITY_EDITOR
//					growthPushSetDeviceTags();
//				#endif
//		}
//
//		public static void ClearBadge() {
//				#if UNITY_IPHONE && !UNITY_EDITOR
//					growthPushClearBadge();
//				#endif
//		}

};
