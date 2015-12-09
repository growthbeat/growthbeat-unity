//
//  GrowthLinkPlugin.h
//

#import <Foundation/Foundation.h>

@interface UIApplication(SupressWarnings)

- (BOOL)application:(UIApplication *)application linkOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;

@end