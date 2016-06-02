//
//  GrowthLink.mm
//  Growthbeat-unity
//
//  Created by Tabata Katsutoshi on 2015/09/26.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthlink.h>

NSString* GLNSStringFromCharString(const char* charString) {
	if(charString == NULL)
		return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" {

	void gl_initializeWithApplicationId(const char* applicationId, const char* credentialId) {
	    [[GrowthLink sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
	    											credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]];
	}

}
