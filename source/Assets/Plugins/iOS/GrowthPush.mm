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

extern "C" void requestDeviceToken (int environment) {
	[[GrowthPush sharedInstance] requestDeviceTokenWithEnvironment:(GPEnvironment)environment];
}

extern "C" void setDeviceToken (const char* deviceToken) {
	[[GrowthPush sharedInstance] setDeviceToken:[NSData dataWithBytes:(const void *)deviceToken length:(sizeof(unsigned char) * strlen(deviceToken))]];
}

extern "C" void clearBadge () {
	[[GrowthPush sharedInstance] clearBadge];
}

extern "C" void setTag (const char* name, const char* value) {
    [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
}

extern "C" void trackEvent (const char* name, const char* value) {
    [[GrowthPush sharedInstance] trackEvent:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
}

extern "C" void setDeviceTags () {
    [[GrowthPush sharedInstance] setDeviceTags];
}

extern "C" void growthPushSetBaseUrl(const char* baseUrl) {
	[[[GrowthPush sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
}
