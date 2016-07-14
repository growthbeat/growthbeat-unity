//
//  Growthbeat.mm
//  Growthbeat-unity
//
//  Created by Shigeru Ogawa on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthbeat.h>

#pragma mark - Growthbeat UnityPlugin

extern "C" {

		void gb_setLoggerSilent(bool silent) {
			[[Growthbeat sharedInstance] setLoggerSilent:silent];
		}

		void gb_setBaseUrl(const char* baseUrl) {
			[[[Growthbeat sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
		}

    void gb_initializeIntentHandlers() {
        [Growthbeat sharedInstance].intentHandlers = [NSMutableArray array];
    }

    void gb_clearIntentHandlers() {
        [Growthbeat sharedInstance].intentHandlers = [NSMutableArray array];
    }

    void gb_addNoopIntentHandler() {
        NSMutableArray *mutableArray = [[Growthbeat sharedInstance].intentHandlers mutableCopy];
        [mutableArray addObject:[[GBNoopIntentHandler alloc] init]];
        [Growthbeat sharedInstance].intentHandlers = mutableArray;
    }

    void gb_addUrlIntentHandler() {
        NSMutableArray *mutableArray = [[Growthbeat sharedInstance].intentHandlers mutableCopy];
        [mutableArray addObject:[[GBUrlIntentHandler alloc] init]];
        [Growthbeat sharedInstance].intentHandlers = mutableArray;
    }

    void gb_addCustomIntentHandler(const char* gameObject, const char* methodName) {

        if(gameObject == NULL || methodName == NULL)
            return;

        NSString *gameObj = [NSString stringWithCString:gameObject encoding:NSUTF8StringEncoding];
        NSString *method = [NSString stringWithCString:methodName encoding:NSUTF8StringEncoding];

        NSMutableArray *mutableArray = [[Growthbeat sharedInstance].intentHandlers mutableCopy];
        [mutableArray addObject:[[GBCustomIntentHandler alloc] initWithBlock:^BOOL (GBCustomIntent *customIntent){
            NSDictionary *dict = customIntent.extra;
            NSError *err;
            NSData *jsonData = [NSJSONSerialization dataWithJSONObject:dict options:0 error:&err];
            NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];

            UnitySendMessage((char *)[gameObj UTF8String], (char *)[method UTF8String], (char *)[jsonString UTF8String]);

            return YES;
        }]];
        [Growthbeat sharedInstance].intentHandlers = mutableArray;

    }

}
