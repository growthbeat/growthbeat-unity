//
//  GrowthPush.mm
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2016/07/04.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>
#import "GrowthPushPlugin.h"

static GrowthPushPlugin *_instance = [GrowthPushPlugin sharedInstance];

@interface GrowthPushPlugin() {

    NSMutableDictionary *renderHandlers;

}

@property (nonatomic, strong) NSMutableDictionary *renderHandlers;

@end

@implementation GrowthPushPlugin

@synthesize renderHandlers;

#pragma mark - Initialize Object

+ (GrowthPushPlugin *)sharedInstance {
    return _instance;
}

+ (void)initialize {
    if (!_instance) {
        _instance = [[GrowthPushPlugin alloc] init];
    }
}

- (id)init {
    if (_instance != nil) {
        return _instance;
    }

    if ((self = [super init])) {
        _instance = self;
        self.renderHandlers = [NSMutableDictionary dictionary];
    }
    return self;
}

#pragma mark - store blocks callback

- (void) setShowMessageHandler:(void(^)())messageCallback uuid:(NSString *)uuid {
    [[self renderHandlers] setObject:messageCallback forKey:uuid];
}

#pragma mark - show message after call messageRenderHandler

- (void) renderMessage:(NSString *)uuid {
    void(^messageRenderHandler)();
    messageRenderHandler = [[self renderHandlers] objectForKey:uuid];
    if(messageRenderHandler) {
        messageRenderHandler();
        [[self renderHandlers] removeObjectForKey:uuid];
    }
}

@end

#pragma mark - Growth Push UnityPlugin

NSString* GPNSStringFromCharString(const char* charString) {
    if(charString == NULL)
        return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" {

    void gp_initialize (const char* applicationId, const char* credentialId, int environment, bool adInfoEnable) {
        [[GrowthPush sharedInstance] initializeWithApplicationId:GPNSStringFromCharString(applicationId) credentialId:GPNSStringFromCharString(credentialId) environment:(GPEnvironment) environment adInfoEnable:adInfoEnable];
    }

    void gp_requestDeviceToken () {
        [[GrowthPush sharedInstance] requestDeviceToken];
    }

    void gp_setDeviceToken (const char* deviceToken) {
        [[GrowthPush sharedInstance] setDeviceToken:GPNSStringFromCharString(deviceToken)];;
    }

    void gp_clearBadge () {
        [[GrowthPush sharedInstance] clearBadge];
    }

    void gp_setTag (const char* name, const char* value) {
        [[GrowthPush sharedInstance] setTag:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
    }

    void gp_trackEvent (const char* name, const char* value) {
        [[GrowthPush sharedInstance] trackEvent:GPNSStringFromCharString(name) value:GPNSStringFromCharString(value)];
    }

    void gp_trackEvent_with_handler (const char* name, const char* value, const char* gameObject, const char* methodName) {
        NSString *eventName = [NSString stringWithCString:name encoding:NSUTF8StringEncoding];
        NSString *eventValue = [NSString stringWithCString:value encoding:NSUTF8StringEncoding];
        const NSString *gameObjectStr = GPNSStringFromCharString(gameObject);
        const NSString *methodNameStr = GPNSStringFromCharString(methodName);

        [[GrowthPush sharedInstance] trackEvent:eventName value:eventValue showMessage:^(void(^renderMessage)())
         {
             NSString *uuid = [[NSUUID UUID] UUIDString];
             [[GrowthPushPlugin sharedInstance] setShowMessageHandler:[renderMessage copy] uuid:uuid];
             UnitySendMessage((char *)[gameObjectStr UTF8String], (char *)[methodNameStr UTF8String], (char *)[uuid UTF8String]);
         } failure:^(NSString *error) {
             NSLog(@"showMessage failure: %@", error);
         }];
    }

    void gp_render_message (const char* uuidChar) {
        [[GrowthPushPlugin sharedInstance] renderMessage:GPNSStringFromCharString(uuidChar)];
    }

    void gp_setDeviceTags () {
        [[GrowthPush sharedInstance] setDeviceTags];
    }

    void gp_setBaseUrl(const char* baseUrl) {
        [[[GrowthPush sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
    }

}
