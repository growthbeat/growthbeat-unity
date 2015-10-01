using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;

public class IntentHandlerWrapper 
{
	private delegate bool HogeCallback(string argstring);
	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void _initializeIntentHandlers();
	[DllImport("__Internal")] static extern void _addNoopIntentHandler();
	[DllImport("__Internal")] static extern void _addUrlIntentHandler();
	[DllImport("__Internal")] static extern void _addCustomIntentHandler();

	
	[DllImport("__Internal")]
	private static extern int hogeNative(HogeCallback callback);
	

	#endif

	public void Hoge() {
		hogeNative(HogeCallback);
	}
	
	[AOT.MonoPInvokeCallbackAttribute(typeof(HogeCallback))]
	static bool HogeCallback(string argstring) {
	}

	public static void initializeIntentHandlers()  {
		#if UNITY_ANDROID
		_runBlockOnThread(() => {
			_getAndroidJavaClass().CallStatic("initializeIntentHandlers");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_initializeIntentHandlers();
		#endif

	}

	public static void addNoopIntentHandler()  {
		#if UNITY_ANDROID
		_runBlockOnThread(() => {
			_getAndroidJavaClass().CallStatic("addNoopIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addNoopIntentHandler();
		#endif
	}

	public static void addUrlIntentHandler()  {
		#if UNITY_ANDROID
		_runBlockOnThread(() => {
			_getAndroidJavaClass().CallStatic("addUrlIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addUrlIntentHandler();
		#endif
	}

	public static void addCustomIntentHandler()  {
		#if UNITY_ANDROID
		_runBlockOnThread(() => {
			_getAndroidJavaClass().CallStatic("addCustomIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		_addCustomIntentHandler();
		#endif
	}
	

	#if UNITY_ANDROID
	public static AndroidJavaClass _getAndroidJavaClass() {
		if (_androidJavaClass == null) {
			_androidJavaClass = new AndroidJavaClass("com.growthbeat.unity.IntentHandlerWrapper");
		}
		return _androidJavaClass;
	}

	private static void _runBlockOnThread(Action runBlock) {
		var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		activity.Call("runOnUiThread", new AndroidJavaRunnable(runBlock));
	}

	private static AndroidJavaClass _androidJavaClass;
	#endif
}