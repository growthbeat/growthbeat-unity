using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class IntentHandler
{

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void gb_initializeIntentHandlers();
	[DllImport("__Internal")] static extern void gb_clearIntentHandlers();
	[DllImport("__Internal")] static extern void gb_addNoopIntentHandler();
	[DllImport("__Internal")] static extern void gb_addUrlIntentHandler();
	[DllImport("__Internal")] static extern void gb_addCustomIntentHandler(string gameObjectName, string methodName);
	#endif

	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaObject intentHandler;

	private void RunBlockOnThread(Action runBlock) {
		
		using(AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
			var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call("runOnUiThread", new AndroidJavaRunnable(runBlock));	
		}

	}
	#endif

	public IntentHandler()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass intentHandlerclass = new AndroidJavaClass( "com.growthbeat.intenthandler.IntentHandlerWrapper" ))
		{
			intentHandler = intentHandlerclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_initializeIntentHandlers();
		#endif
	}

	private static IntentHandler instance = new IntentHandler();

	public static IntentHandler GetInstance ()
	{
		return IntentHandler.instance;
	}

	public void ClearIntentHandlers()  {
		#if UNITY_ANDROID && !UNITY_EDITOR
		RunBlockOnThread(() => {
			intentHandler.Call("clearIntentHandlers");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_clearIntentHandlers();
		#endif

	}

	public void AddNoopIntentHandler()  {
		#if UNITY_ANDROID && !UNITY_EDITOR
		RunBlockOnThread(() => {
			intentHandler.Call("addNoopIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_addNoopIntentHandler();
		#endif
	}

	public void AddUrlIntentHandler()  {
		#if UNITY_ANDROID && !UNITY_EDITOR
		RunBlockOnThread(() => {
			intentHandler.Call("addUrlIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_addUrlIntentHandler();
		#endif
	}

	public void AddCustomIntentHandler(string gameObjectName, string methodName)  {
		#if UNITY_ANDROID && !UNITY_EDITOR
		RunBlockOnThread(() => {
			intentHandler.Call("addCustomIntentHandler", gameObjectName, methodName);
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		gb_addCustomIntentHandler(gameObjectName, methodName);
		#endif
	}
	
}