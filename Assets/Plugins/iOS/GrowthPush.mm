//
//  GrowthPush.mm
//
//
//  Created by Cuong Do on 11/5/13.
//
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthPush.h>

extern "C" void growthPushInitializeWithApplicationId (const char* applicationId, const char* credentialId, int environment) {
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

extern "C" void growthPushRequestDeviceToken () {
	[[GrowthPush sharedInstance] requestDeviceToken];
}

extern "C" void growthPushSetDeviceToken (const char* deviceToken) {
	[[GrowthPush sharedInstance] setDeviceToken:[NSData dataWithBytes:(const void *)deviceToken length:(sizeof(unsigned char) * strlen(deviceToken))]];
}

extern "C" void growthPushClearBadge () {
	[[GrowthPush sharedInstance] clearBadge];
}
