
#import <Foundation/Foundation.h>

@interface GPReceiveHanderPlugin : NSObject

+ (GPReceiveHanderPlugin *)sharedInstance;
- (void) setShowMessageHandler:(void(^messageCallback)())showMessageHandler uuid:(NSString *)uuid;
- (void) renderMessageByUUID:(NSString *)uuid;

@end
