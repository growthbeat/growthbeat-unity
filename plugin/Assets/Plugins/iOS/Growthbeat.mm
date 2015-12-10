//
//  Growthbeat.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthbeat.h>

extern "C" {
	
	void gb_initializeWithApplicationId(const char* applicationId, const char* credentialId) {
    	[[Growthbeat sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
    											credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]];
	}

	void gb_start() {
    	[[Growthbeat sharedInstance] start];
	}

	void gb_stop() {
		[[Growthbeat sharedInstance] stop];
	}

	void gb_setLoggerSilent(bool silent) {
		[[Growthbeat sharedInstance] setLoggerSilent:silent];
	}

	void gb_setBaseUrl(const char* baseUrl) {
		[[[GrowthbeatCore sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
	}

} 
