//
//  GrowthLinkPlugin.h
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2016/06/01.
//  Copyright (c) 2016年 SIROK, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "AppDelegateListener.h"

@interface GrowthLinkPlugin : NSObject <AppDelegateListener>

+ (GrowthLinkPlugin *)sharedInstance;

@end
