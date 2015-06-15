//
//  GrowthAnalytics.mm
//  Growthbeat-unity
//
//  Created by Baekwoo Chung on 2015/06/15.
//  Copyright (c) 2015年 SIROK, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthAnalytics.h>

NSString* NSStringFromCharString(const char* charString) {
	if(charString == NULL)
		return nil;
    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
}

extern "C" void growthAnalyticsInitializeWithApplicationId(const char* applicationId, const char* credentialId) {
    [[GrowthAnalytics sharedInstance] initializeWithApplicationId:NSStringFromCharString(applicationId) credentialId:NSStringFromCharString(credentialId)];
}

extern "C" void growthAnalyticsTrack(const char* eventId) {
    [[GrowthAnalytics sharedInstance] track:NSStringFromCharString(eventId)];
}

/*
- (void)track:(NSString *)eventId properties:(NSDictionary *)properties;
extern "C" void track(const char* eventId, ) {
    [[GrowthAnalytics sharedInstance] track];
}*/

/*
- (void)track:(NSString *)eventId option:(GATrackOption)option;
extern "C" void track() {
    [[GrowthAnalytics sharedInstance] track];
}

- (void)track:(NSString *)eventId properties:(NSDictionary *)properties option:(GATrackOption)option;
extern "C" void track() {
    [[GrowthAnalytics sharedInstance] track];
}*/

extern "C" void growthAnalyticsTag(const char* tagId, const char* value) {
    [[GrowthAnalytics sharedInstance] tag:NSStringFromCharString(tagId) value:NSStringFromCharString(value)];
}

extern "C" void growthAnalyticsOpen() {
    [[GrowthAnalytics sharedInstance] open];
}

extern "C" void growthAnalyticsClose() {
    [[GrowthAnalytics sharedInstance] close];
}

extern "C" void growthAnalyticsPurchase(int price, const char* category, const char* product) {
    [[GrowthAnalytics sharedInstance] purchase:price setCategory:NSStringFromCharString(category) setProduct:NSStringFromCharString(product)];
}

extern "C" void growthAnalyticsSetUserId(const char* userId) {
    [[GrowthAnalytics sharedInstance] setUserId:NSStringFromCharString(userId)];
}

extern "C" void growthAnalyticsSetName(const char* name) {
    [[GrowthAnalytics sharedInstance] setName:NSStringFromCharString(name)];
}

extern "C" void growthAnalyticsSetAge(int age) {
    [[GrowthAnalytics sharedInstance] setAge:age];
}

/*
- (void)setGender:(GAGender)gender;
extern "C" void setGender() {
    [[GrowthAnalytics sharedInstance] ];
}*/

extern "C" void growthAnalyticsSetLevel(int level) {
    [[GrowthAnalytics sharedInstance] setLevel:level];
}

/*
- (void)setDevelopment:(BOOL)development;
extern "C" void setDevelopment() {
    [[GrowthAnalytics sharedInstance] ];
}*/

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

extern "C" void growthAnalyticsSetAdvertisingId(const char* idfa) {
    //[[GrowthAnalytics sharedInstance] setAdvertisingId:NSStringFromCharString(idfa)];
}

extern "C" void growthAnalyticsSetBasicTags() {
    [[GrowthAnalytics sharedInstance] setBasicTags];
}

/*typedef NS_ENUM (NSInteger, GATrackOption) {
    GATrackOptionDefault = 0,
    GATrackOptionOnce,
    GATrackOptionCounter
};

typedef NS_ENUM (NSInteger, GAGender) {
    GAGenderNone = 0,
    GAGenderMale,
    GAGenderFemale
};*/