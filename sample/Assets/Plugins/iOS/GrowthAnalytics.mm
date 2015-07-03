//
//  GrowthAnalytics.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthAnalytics.h>

NSString* GANSStringFromCharString(const char* charString) {
	if(charString == NULL)
		return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" void growthAnalyticsTrackWithNamespace(const char* _namespace, const char* name, const char* properties, int option) {
    NSData* data = [GANSStringFromCharString(properties) dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary* dictionary = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingAllowFragments error:nil];
    
    [[GrowthAnalytics sharedInstance] track:GANSStringFromCharString(_namespace) name:GANSStringFromCharString(name) properties:dictionary option:(GATrackOption)option completion:nil];
}

extern "C" void growthAnalyticsTrack(const char* name, const char* properties, int option) {
    NSData* data = [GANSStringFromCharString(properties) dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary* dictionary = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingAllowFragments error:nil];
    
    [[GrowthAnalytics sharedInstance] track:GANSStringFromCharString(name) properties:dictionary option:(GATrackOption)option];
}

extern "C" void growthAnalyticsTagWithNamespace(const char* _namespace, const char* name, const char* value, int option) {
    [[GrowthAnalytics sharedInstance] tag:GANSStringFromCharString(_namespace) name:GANSStringFromCharString(name) value:GANSStringFromCharString(value) completion:nil];
}

extern "C" void growthAnalyticsTag(const char* name, const char* value) {
    [[GrowthAnalytics sharedInstance] tag:GANSStringFromCharString(name) value:GANSStringFromCharString(value)];
}

extern "C" void growthAnalyticsOpen() {
    [[GrowthAnalytics sharedInstance] open];
}

extern "C" void growthAnalyticsClose() {
    [[GrowthAnalytics sharedInstance] close];
}

extern "C" void growthAnalyticsPurchase(int price, const char* category, const char* product) {
    [[GrowthAnalytics sharedInstance] purchase:price setCategory:GANSStringFromCharString(category) setProduct:GANSStringFromCharString(product)];
}

extern "C" void growthAnalyticsSetUserId(const char* userId) {
    [[GrowthAnalytics sharedInstance] setUserId:GANSStringFromCharString(userId)];
}

extern "C" void growthAnalyticsSetName(const char* name) {
    [[GrowthAnalytics sharedInstance] setName:GANSStringFromCharString(name)];
}

extern "C" void growthAnalyticsSetAge(int age) {
    [[GrowthAnalytics sharedInstance] setAge:age];
}

extern "C" void growthAnalyticsSetGender(int gender) {
    [[GrowthAnalytics sharedInstance] setGender:(GAGender)gender];
}

extern "C" void growthAnalyticsSetLevel(int level) {
    [[GrowthAnalytics sharedInstance] setLevel:level];
}

extern "C" void growthAnalyticsSetDevelopment(bool development) {
    [[GrowthAnalytics sharedInstance] setDevelopment:development];
}

extern "C" void growthAnalyticsSetDeviceModel() {
    [[GrowthAnalytics sharedInstance] setDeviceModel];
}

extern "C" void growthAnalyticsSetOS() {
    [[GrowthAnalytics sharedInstance] setOS];
}

extern "C" void growthAnalyticsSetLanguage() {
    [[GrowthAnalytics sharedInstance] setLanguage];
}

extern "C" void growthAnalyticsSetTimeZone() {
    [[GrowthAnalytics sharedInstance] setTimeZone];
}

extern "C" void growthAnalyticsSetTimeZoneOffset() {
    [[GrowthAnalytics sharedInstance] setTimeZoneOffset];
}

extern "C" void growthAnalyticsSetAppVersion() {
    [[GrowthAnalytics sharedInstance] setAppVersion];
}

extern "C" void growthAnalyticsSetRandom() {
    [[GrowthAnalytics sharedInstance] setRandom];
}

extern "C" void growthAnalyticsSetAdvertisingId() {
    [[GrowthAnalytics sharedInstance] setAdvertisingId];
}

extern "C" void growthAnalyticsSetBasicTags() {
    [[GrowthAnalytics sharedInstance] setBasicTags];
}
