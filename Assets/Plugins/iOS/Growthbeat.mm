//
//  Growthbeat.mm
//
//
//  Created by Baekwoo Chung on 02/10/15.
//
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthbeat.h>

extern "C" void initializeWithApplicationId(const char* applicationId, const char* credentialId) {
    [[Growthbeat sharedInstance] initializeWithApplicationId:[NSString stringWithCString:applicationId encoding:NSUTF8StringEncoding]
    											credentialId:[NSString stringWithCString:credentialId encoding:NSUTF8StringEncoding]];
}

extern "C" void start() {
    [[Growthbeat sharedInstance] start];
}

extern "C" void stop() {
	[[Growthbeat sharedInstance] stop];
}

extern "C" void setLoggerSilent(bool silent) {
	[[Growthbeat sharedInstance] setLoggerSilent:silent];	
}
