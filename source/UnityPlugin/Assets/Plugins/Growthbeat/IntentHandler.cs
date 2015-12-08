using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;

public class IntentHandler
{

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void initializeIntentHandlers();
	[DllImport("__Internal")] static extern void addNoopIntentHandler();
	[DllImport("__Internal")] static extern void addUrlIntentHandler();
	[DllImport("__Internal")] static extern void addCustomIntentHandler(string gameObjectName, string methodName);
	#endif

	#if UNITY_ANDROID && !UNITY_EDITOR
	private AndroidJavaObject intentHandler;

	private AndroidJavaObject javaObject;

	private void RunBlockOnThread(Action runBlock) {
		
		using(AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
			var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call("runOnUiThread", new AndroidJavaRunnable(runBlock));	
		}

	}
	#endif

	private IntentHandler()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		using(AndroidJavaClass intentHandlerclass = new AndroidJavaClass( "com.growthbeat.intenthandler.IntentHandlerWrapper" ))
		{
			intentHandler = intentHandlerclass.CallStatic<AndroidJavaObject>("getInstance");
		}
		#endif
	}

	private static IntentHandlerWrapper instance = new IntentHandlerWrapper();

	public static IntentHandlerWrapper GetInstance ()
	{
		return IntentHandlerWrapper.instance;
	}

	public void ClearIntentHandlers()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			intentHandler.Call("clearIntentHandlers");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		initializeIntentHandlers();
		#endif

	}

	public void AddNoopIntentHandler()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			intentHandler.Call("addNoopIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		addNoopIntentHandler();
		#endif
	}

	public void AddUrlIntentHandler()  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			intentHandler.Call("addUrlIntentHandler");
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		addUrlIntentHandler();
		#endif
	}

	public void AddCustomIntentHandler(string gameObjectName, string methodName)  {
		#if UNITY_ANDROID
		RunBlockOnThread(() => {
			intentHandler.Call("addCustomIntentHandler", gameObjectName, methodName);
		});
		#elif UNITY_IPHONE && !UNITY_EDITOR
		addCustomIntentHandler(gameObjectName, methodName);
		#endif
	}
	
}