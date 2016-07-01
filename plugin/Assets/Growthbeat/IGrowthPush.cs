internal interface IGrowthPush {

  void RequestDeviceToken();

  void SetDeviceToken();

  bool enableNotification();

  void clearBadge();

  void Tag (string name);

  void Tag (string name, string value);

  void Tag (GrowthPush.TagType type, string name, string value);

  void SetDeviceTag ();

  void Track (string name);

  void Track (string name, string value);

  // TODO Block Scope の使伊方調べる
  void Track (string name, string value, delegate showMessage, delegate failureHandler);

  void SelectButton (GrowthPush button, GrowthPush message);

  void NotifyClose();

}
