
#import <Growthbeat/GrowthPush.h>

static GPRecieveHandlerPlugin *_instance = [GPRecieveHandlerPlugin sharedInstance];

@interface GPReceiveHanderPlugin() {

  NSMutableDictionary *renderHandlers;

}

@property (nonatomic, strong) renderHandlers;

@end

@implementation GPReceiveHanderPlugin

@synthesize renderHandlers;

+ (GPRecieveHandlerPlugin *)sharedInstance {
	return _instance;
}

+ (void)initialize {
	if (!_instance) {
		_instance = [[GPRecieveHandlerPlugin alloc] init];
	}
}

- (id)init {
	if (_instance != nil) {
		return _instance;
	}

	if ((self = [super init])) {
		_instance = self;
	}
	return self;
}

- (void) setShowMessageHandler:(void(^messageCallback)())showMessageHandler uuid:(NSString *)uuid {
    [[self renderHandlers] setObject:renderMessage forKey:uuid];
}

- (void) renderMessageByUUID:(NSString *)uuid {
    void(^messageCallback)() renderCallback = [[self renderHandlers] objectForKey:uuid];
    if(renderCallback)
      renderCallback();
}

@end
