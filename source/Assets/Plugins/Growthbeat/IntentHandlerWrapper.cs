using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;

public class IntentHandlerWrapper 
{
	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void initializeIntentHandlers();
	[DllImport("__Internal")] static extern void addNoopIntentHandler();
	[DllImport("__Internal")] static extern void addUrlIntentHandler();
	[DllImport("__Internal")] static extern void addCustomIntentHandler(string gameObjectName);
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

	public static void AddCustomIntentHandler(string gameObjectName)  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			IntentHandlerWrapper.javaObject.CallStatic("addCustomIntentHandler", gameObjectName);
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addCustomIntentHandler(gameObjectName);
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