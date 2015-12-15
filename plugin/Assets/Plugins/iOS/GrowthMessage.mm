//
//  GrowthMessage.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthMessage.h>

extern "C" {

	void gm_setBaseUrl(const char* baseUrl) {
	    [[[GrowthMessage sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
	}

}
