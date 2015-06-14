//
//  Growthbeat.mm
//
//
//  Created by Baekwoo Chung on 02/10/15.
//
//

#import <UIKit/UIKit.h>
#import <Growthbeat/Growthbeat.h>

NSString* NSStringFromCharString(const char* charString) {
	if(charString == NULL)
		return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" void initializeWithApplicationId(const char* applicationId, const char* credentialId) {
    [[Growthbeat sharedInstance] initializeWithApplicationId:NSStringFromCharString(applicationId) credentialId:NSStringFromCharString(credentialId)];
}

extern "C" void start() {
    [[Growthbeat sharedInstance] start];
}
