//
//  GrowthLinkPlugin.mm
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2016/06/01.
//  Copyright (c) 2016年 SIROK, Inc. All rights reserved.
//

#include "GrowthLinkPlugin.h"
#import <Growthbeat/GrowthLink.h>

static GrowthLinkPlugin *_instance = [GrowthLinkPlugin sharedInstance];

@implementation GrowthLinkPlugin

#pragma mark Object Initialization

+ (GrowthLinkPlugin *)sharedInstance
{
	return _instance;
}

+ (void)initialize
{
	if (!_instance) {
		_instance = [[GrowthLinkPlugin alloc] init];
	}
}

- (id)init
{
	if (_instance != nil) {
		return _instance;
	}

	if ((self = [super init])) {
		_instance = self;
		UnityRegisterAppDelegateListener(self);
	}
	return self;
}

#pragma mark - App (Delegate) Lifecycle

- (void)onOpenURL:(NSNotification *)notification
{
	NSURL *url = notification.userInfo[@"url"];

	if ([GrowthLink instancesRespondToSelector:@selector(handleOpenUrl:)]) {
		[[GrowthLink sharedInstance] handleOpenUrl: url];
	}
}

@end
