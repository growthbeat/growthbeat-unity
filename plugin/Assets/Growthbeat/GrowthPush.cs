//
//  GrowthPush.cs
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2016/07/04.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthPush {

 #if UNITY_IPHONE && !UNITY_EDITOR
 [DllImport("__Internal")] private static extern void gp_initialize(string applicationId, string credentialId, int environment, bool adInfoEnable);
 [DllImport("__Internal")] private static extern void gp_requestDeviceToken();
 [DllImport("__Internal")] private static extern void gp_setDeviceToken(string deviceToken);
 [DllImport("__Internal")] private static extern void gp_clearBadge();
 [DllImport("__Internal")] private static extern void gp_setTag(string name, string value);
 [DllImport("__Internal")] private static extern void gp_trackEvent(string name, string value);
 [DllImport("__Internal")] private static extern void gp_trackEvent_with_handler(string name, string value, string gameObject, string methodName);
 [DllImport("__Internal")] private static extern void gp_render_message(string uuid);
 [DllImport("__Internal")] private static extern void gp_setDeviceTags();
 [DllImport("__Internal")] private static extern void gp_setBaseUrl(string baseUrl);
 #endif

 #if UNITY_ANDROID && !UNITY_EDITOR
 private AndroidJavaObject growthPush;
 #endif

 private GrowthPush()
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 using(AndroidJavaClass gpclass = new AndroidJavaClass( "com.growthpush.GrowthPush" ))
	 {
		 growthPush = gpclass.CallStatic<AndroidJavaObject>("getInstance");
	 }
	 #endif
 }

 private static GrowthPush instance = new GrowthPush ();
 public static GrowthPush GetInstance ()
 {
	 return GrowthPush.instance;
 }

 public enum Environment {
	 Unknown = 0,
	 Development = 1,
	 Production = 2
 }

 public void Initialize(string applicationId, string credentialId, Environment environment) {
    Initialize(applicationId, credentialId, environment, true);
 }

 public void Initialize(string applicationId, string credentialId, Environment environment, bool adInfoEnable)
 {
   #if UNITY_ANDROID && !UNITY_EDITOR
    using(AndroidJavaClass environmentClass = new AndroidJavaClass( "com.growthpush.model.Environment" ))
    {
       AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
       AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaObject environmentObject = environmentClass.GetStatic<AndroidJavaObject>(environment == GrowthPush.Environment.Production ? "production" : "development");
      growthPush.Call("initialize", activity, applicationId, credentialId, environmentObject, adInfoEnable);
    }
  #elif UNITY_IPHONE && !UNITY_EDITOR
    gp_initialize(applicationId, credentialId, (int)environment, adInfoEnable);
  #endif
 }

 public void RequestDeviceToken (string senderId)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 growthPush.Call("requestRegistrationId", senderId);
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_requestDeviceToken();
	 #endif
 }

 public void RequestDeviceToken ()
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 RequestDeviceToken(null);
	 #endif
 }

 /**
 * Support Only Android.
 * iOS uses UnityEngine.iOS.NotificationServices.
 * This method must be call after GrowthPush#RequestDeviceToken
 */
 public string GetDeviceToken ()
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	 AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	 return growthPush.Call<string>("registerGCM", activity);
	 #endif

	 return null;
 }

 public void SetDeviceToken (string deviceToken)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_setDeviceToken(deviceToken);
	 #endif
 }

 public void ClearBadge ()
 {
	 #if UNITY_IPHONE && !UNITY_EDITOR
	 gp_clearBadge();
	 #endif
 }

 public void SetTag (string name)
 {
	 SetTag (name, "");
 }

 public void SetTag (string name, string value)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 growthPush.Call("setTag", name, value);
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_setTag(name, value);
	 #endif
 }

 public void TrackEvent(string name)
 {
	 TrackEvent (name, "");
 }

 public void TrackEvent (string name, string value)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 growthPush.Call("trackEvent", name, value);
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_trackEvent(name, value);
	 #endif
 }

 public void TrackEvent (string name, string value, string gameObject, string methodName)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 using(AndroidJavaClass gpclass = new AndroidJavaClass( "com.growthpush.ShowMessageHandlerWrapper" )) {
		 gpclass.CallStatic("trackEvent", name, value, gameObject, methodName);
	 }
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_trackEvent_with_handler(name, value, gameObject, methodName);
	 #endif
 }

 public void RenderMessage (string uuid) {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 using(AndroidJavaClass gpclass = new AndroidJavaClass( "com.growthpush.ShowMessageHandlerWrapper" )) {
		 gpclass.CallStatic("renderMessage", uuid);
	 }
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_render_message(uuid);
	 #endif
 }

 public void SetDeviceTags ()
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 growthPush.Call("setDeviceTags");
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_setDeviceTags();
	 #endif
 }

 public void SetBaseUrl(string baseUrl)
 {
	 #if UNITY_ANDROID && !UNITY_EDITOR
	 AndroidJavaObject httpClient = growthPush.Call<AndroidJavaObject>("getHttpClient");
	 httpClient.Call("setBaseUrl", baseUrl);
	 #elif UNITY_IPHONE && !UNITY_EDITOR
	 gp_setBaseUrl(baseUrl);
	 #endif
 }

}
