using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;

public class IntentHandlerWrapper 
{
	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void _initializeIntentHandlers();
	[DllImport("__Internal")] static extern void _addNoopIntentHandler();
	[DllImport("__Internal")] static extern void _addUrlIntentHandler();
	[DllImport("__Internal")] static extern void _addCustomIntentHandler();
	#endif

	public static void InitializeIntentHandlers()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			IntentHandlerWrapper.javaObject.CallStatic("initializeIntentHandlers");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_initializeIntentHandlers();
		#endif

	}

	public static void AddNoopIntentHandler()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			IntentHandlerWrapper.javaObject.CallStatic("addNoopIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addNoopIntentHandler();
		#endif
	}

	public static void AddUrlIntentHandler()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			IntentHandlerWrapper.javaObject.CallStatic("addUrlIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addUrlIntentHandler();
		#endif
	}

	public static void AddCustomIntentHandler()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			IntentHandlerWrapper.javaObject.CallStatic("addCustomIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addCustomIntentHandler();
		#endif
	}
	

	#if UNITY_ANDROID
	private static AndroidJavaObject javaObject;

	private Growthbeat() {
		IntentHandlerWrapper.javaObject = new AndroidJavaClass("com.growthbeat.unity.IntentHandlerWrapper");
	}

	private static void RunBlockOnThread(Action runBlock) {
		
		using(AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
			var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call("runOnUiThread", new AndroidJavaRunnable(runBlock));	
		}
		
	}

	#endif
}