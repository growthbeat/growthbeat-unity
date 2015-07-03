//
//  GrowthMessage.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthMessage.h>

extern "C" void growthMessageInitializeWithApplicationId (const char* applicationId, const char* credentialId) {
    [[GrowthMessage sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
    											   credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]];
}
