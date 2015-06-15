//
//  GrowthPush.mm
//
//
//  Created by Cuong Do on 11/5/13.
//
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>

extern "C" void growthPushInitializeWithApplicationId (const char* applicationId, const char* credentialId, int environment, bool debug) {
	GPEnvironment gpEnvironment = GPEnvironmentUnknown;
    switch (environment) {
        case GPEnvironmentDevelopment:
            gpEnvironment = GPEnvironmentDevelopment;
            break;
            
        case GPEnvironmentProduction:
            gpEnvironment = GPEnvironmentProduction;
            break;
        default:
            break;
    }
    
    [[GrowthPush sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
    											credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]
    											 environment:gpEnvironment];
}

//extern "C" void growthPushTrackEvent(const char* name, const char* value) {
//    [EasyGrowthPush trackEvent:[NSString stringWithCString:name encoding:NSUTF8StringEncoding]
//    					 value:[NSString stringWithCString:value encoding:NSUTF8StringEncoding]];
//}
//
//extern "C" void growthPushSetTag(const char* name, const char* value) {
//    [EasyGrowthPush setTag:[NSString stringWithCString:name encoding:NSUTF8StringEncoding]
//    				 value:[NSString stringWithCString:value encoding:NSUTF8StringEncoding]];
//}
//
//extern "C" void growthPushSetDeviceTags() {
//    [EasyGrowthPush setDeviceTags];
//}
//
//extern "C" void growthPushClearBadge() {
//    [EasyGrowthPush clearBadge];
//}
