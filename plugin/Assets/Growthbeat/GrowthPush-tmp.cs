using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthPush {

  private delegate void ShowMessageHandler ();
  private delegate void FailureHandler ();

  #if UNITY_IPHONE && !UNITY_EDITOR
  [DllImport("__Internal")] private static extern void gp_requestDeviceToken();
  [DllImport("__Internal")] private static extern void gp_setDeviceToken();
  [DllImport("__Internal")] private static extern bool gp_enableNotification();
  [DllImport("__Internal")] private static extern void gp_clearBadge();
  [DllImport("__Internal")] private static extern void gp_setTag(string name);
  [DllImport("__Internal")] private static extern void gp_setTag(string name, string value);
  [DllImport("__Internal")] private static extern void gp_setTag(GrowthPush.TagType type, string value, string value);
  [DllImport("__Internal")] private static extern void gp_trackEvent(string name);
  [DllImport("__Internal")] private static extern void gp_trackEvent(string name, string value);
  [DllImport("__Internal")] private static extern void gp_trackEvent(string name, string value, ShowMessageHandler showMessageHandler, FailureHandler failureHandler);
  [DllImport("__Internal")] private static extern void gp_setDeviceTags();
  [DllImport("__Internal")] private static extern void gp_setBaseUrl(string baseUrl);
  #endif
}
