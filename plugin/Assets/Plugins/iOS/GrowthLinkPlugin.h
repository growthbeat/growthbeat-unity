//
//  GrowthLinkPlugin.h
//

#import <Foundation/Foundation.h>

#import "AppDelegateListener.h"

@interface GrowthLinkPlugin : NSObject <AppDelegateListener>

+ (GrowthLinkPlugin *)sharedInstance;

@end
