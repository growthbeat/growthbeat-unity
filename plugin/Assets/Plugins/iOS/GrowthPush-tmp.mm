#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>

extern "C" typedef void (*ShowMessageHandler)();
extern "C" typedef void (*FailureHandler)(char *parameter);

NSString* GPNSStringFromCharString(const char* charString) {
    if(charString == NULL)
        return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" {

  void gp_requestDeviceToken () {
      [[GrowthPush sharedInstance] requestDeviceToken];
  }

  void gp_setDeviceToken(const char* deviceToken) {
      [[GrowthPush sharedInstance] setDeviceToken:GPNSStringFromCharString(deviceToken)];
  }

  bool gp_enableNotification() {
      [[GrowthPush sharedInstance] enableNotification];
  }

  void gp_clearBadge() {
      [[GrowthPush sharedInstance] clearBadge];
  }

  void gp_setTag(const char* name) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name)];
  }

  void gp_setTag(const char* name, const char* value) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
  }

  void gp_setTag(const GPTagType type, const char* name, const char* value) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(type) name:GPNSStringFromCharString(name), value:GPNSStringFromCharString(value)];
  }

  void gp_trackEvent(const char* name) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name)];
  }

  void gp_trackEvent(const char* name, const char* value) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
  }

  void gp_trackEvent(const char* name, const char* value, ShowMessageHandler showMessageHandler, FailureHandler failureHandler) {
      [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name)
                                   value:GPNSStringFromCharString(value)
                                   showMessage: ^{
                                     renderMessage();
                                   }
                                   failure: ^ (NSString *detail) {}]
  }

  void gp_setDeviceTags() {
      [[GrowthPush sharedInstance] setDeviceTags];
  }

  void gp_selectButton() {
      [[GrowthPush sharedInstance] selectButton: ];
  }

  void gp_notifyClose() {
      [[GrowthPush sharedInstance] notifyClose];
  }

}
