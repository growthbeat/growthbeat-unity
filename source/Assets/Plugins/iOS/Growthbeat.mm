//
//  Growthbeat.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthbeat.h>

extern "C" void growthbeatInitializeWithApplicationId(const char* applicationId, const char* credentialId) {
    [[Growthbeat sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
    											credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]];
}

extern "C" void growthbeatStart() {
    [[Growthbeat sharedInstance] start];
}

extern "C" void growthbeatStop() {
	[[Growthbeat sharedInstance] stop];
}

extern "C" void growthbeatSetLoggerSilent(bool silent) {
	[[Growthbeat sharedInstance] setLoggerSilent:silent];	
}

extern "C" void growthbeatSetBaseUrl(const char* baseUrl) {
	[[[GrowthbeatCore sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
}
