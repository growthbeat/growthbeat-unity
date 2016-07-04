//
//  GrowthPush.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>
#import "GPReceiveHanderPlugin.h"

NSString* GPNSStringFromCharString(const char* charString) {
    if(charString == NULL)
        return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" {

    void gp_initialize (const char* applicationId, const char* credentialId, int environment) {
        [[GrowthPush sharedInstance] initializeWithApplicationId:GPNSStringFromCharString(applicationId) credentialId:GPNSStringFromCharString(credentialId) environment:(GPEnvironment) environment];
    }

    void gp_requestDeviceToken () {
        [[GrowthPush sharedInstance] requestDeviceToken];
    }

    void gp_setDeviceToken (const char* deviceToken) {
        [[GrowthPush sharedInstance] setDeviceToken:GPNSStringFromCharString(deviceToken)];;
    }

    void gp_clearBadge () {
        [[GrowthPush sharedInstance] clearBadge];
    }

    void gp_setTag (const char* name, const char* value) {
        [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
    }

    void gp_trackEvent (const char* name, const char* value) {
        [[GrowthPush sharedInstance] trackEvent:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
    }

    void gp_trackEvent_with_handler (const char* name, const char* value, const char* gameObject, const char* methodName) {
        NSString *eventName = [NSString stringWithCString:name encoding:NSUTF8StringEncoding];
        NSString *eventValue = [NSString stringWithCString:value encoding:NSUTF8StringEncoding];
        [[GrowthPush sharedInstance] trackEvent:eventName value:eventValue showMessage:^(void(^renderMessage)())
        {
          NSString *uuid = [[NSUUID UUID] UUIDString];
          [[GPReceiveHanderPlugin sharedInstance] setShowMessageHandler:renderMessage uuid:uuid];
          UnitySendMessage(gameObj, method, (char *)[uuid UTF8String]);
        } failure:(NSString *error) {
          NSLog(@"showMessage failure: %@", error);
        }];
    }

    void gp_render_message (const char* uuid) {
        [[GPReceiveHanderPlugin sharedInstance] renderMessage:[NSString stringWithCString:uuid encoding:NSUTF8StringEncoding]];
    }

    void gp_setDeviceTags () {
        [[GrowthPush sharedInstance] setDeviceTags];
    }

    void gp_setBaseUrl(const char* baseUrl) {
        [[[GrowthPush sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
    }

}
