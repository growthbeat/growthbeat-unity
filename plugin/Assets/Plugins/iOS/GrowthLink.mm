//
//  GrowthLink.mm
//  Growthbeat-unity
//
//  Created by Tabata Katsutoshi on 2015/09/26.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthLink.h>
#import "GrowthLinkPlugin.h"

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
