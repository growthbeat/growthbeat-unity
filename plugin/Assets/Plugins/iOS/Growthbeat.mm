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
	
	void gb_setLoggerSilent(bool silent) {
		[[Growthbeat sharedInstance] setLoggerSilent:silent];
	}

	void gb_setBaseUrl(const char* baseUrl) {
		[[[GrowthbeatCore sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
	}

}
