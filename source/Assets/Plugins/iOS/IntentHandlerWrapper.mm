

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthbeatCore.h>
#import <Growthbeat/GBCustomIntentHandler.h>
#import <Growthbeat/GBUrlIntentHandler.h>
#import <Growthbeat/GBNoopIntentHandler.h>


extern "C" void _initializeIntentHandlers() {
   [GrowthbeatCore sharedInstance].intentHandlers = [NSMutableArray array];
}

extern "C" void _addNoopIntentHandler() {
    NSMutableArray *mutableArray = [[GrowthbeatCore sharedInstance].intentHandlers mutableCopy];
    [mutableArray addObject:[[GBNoopIntentHandler alloc] init]];
    [GrowthbeatCore sharedInstance].intentHandlers = mutableArray;
}

extern "C" void _addUrlIntentHandler() {
	NSMutableArray *mutableArray = [[GrowthbeatCore sharedInstance].intentHandlers mutableCopy];
    [mutableArray addObject:[[GBUrlIntentHandler alloc] init]];
    [GrowthbeatCore sharedInstance].intentHandlers = mutableArray;
}

extern "C" void _addCustomIntentHandler() {
	typedef void (*HogeCallback)();
	NSMutableArray *mutableArray = [[GrowthbeatCore sharedInstance].intentHandlers mutableCopy];
    [mutableArray addObject:[[GBCustomIntentHandler alloc] initWithBlock:^BOOL (GBCustomIntent *customIntent){
        NSDictionary *dict = customIntent.extra;
        NSError *err;
        NSData *jsonData = [NSJSONSerialization dataWithJSONObject:dict options:0 error:&err];
        NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        UnitySendMessage("IntentHandlerWrapper", "handleCustomIntent", (char *)[jsonString UTF8String]);
    }];
    [GrowthbeatCore sharedInstance].intentHandlers = mutableArray;
}