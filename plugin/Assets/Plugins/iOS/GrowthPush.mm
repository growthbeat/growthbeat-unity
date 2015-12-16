//
//  GrowthPush.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>

NSString* GPNSStringFromCharString(const char* charString) {
    if(charString == NULL)
        return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" {

    void gp_requestDeviceToken (int environment) {
        [[GrowthPush sharedInstance] requestDeviceTokenWithEnvironment:(GPEnvironment)environment];
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

    void gp_setDeviceTags () {
        [[GrowthPush sharedInstance] setDeviceTags];
    }

    void gp_setBaseUrl(const char* baseUrl) {
        [[[GrowthPush sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
    }

}