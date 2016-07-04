//
//  GrowthPushPlugin.h
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2016/07/04.
//  Copyright (c) 2016年 SIROK, Inc. All rights reserved.
//
#import <Foundation/Foundation.h>

@interface GrowthPushPlugin : NSObject

+ (GrowthPushPlugin *)sharedInstance;
- (void) setShowMessageHandler:(void(^)())messageCallback uuid:(NSString *)uuid;
- (void) renderMessage:(NSString *)uuid;

@end
