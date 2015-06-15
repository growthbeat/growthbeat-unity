//
//  GrowthPush.mm
//
//
//  Created by Cuong Do on 11/5/13.
//
//

#import <UIKit/UIKit.h>
#import <Growthbeat/GrowthAnalytics.h>

//NSString* NSStringFromCharString(const char* charString) {
//	if(charString == NULL)
//		return nil;
//    return [NSString stringWithCString:charString encoding:NSUTF8StringEncoding];
//}
//
//extern "C" void AnalyticsInitializeWithApplicationId(const char* applicationId, const char* credentialId) {
//    [[GrowthAnalytics sharedInstance] initializeWithApplicationId:NSStringFromCharString(applicationId) credentialId:NSStringFromCharString(credentialId)];
//}
//
//extern "C" void AnalyticsTrack(const char* eventId) {
//    [[GrowthAnalytics sharedInstance] track:NSStringFromCharString(eventId)];
//}
//
///*
//- (void)track:(NSString *)eventId properties:(NSDictionary *)properties;
//extern "C" void track(const char* eventId, ) {
//    [[GrowthAnalytics sharedInstance] track];
//}*/
//
///*
//- (void)track:(NSString *)eventId option:(GATrackOption)option;
//extern "C" void track() {
//    [[GrowthAnalytics sharedInstance] track];
//}
//
//- (void)track:(NSString *)eventId properties:(NSDictionary *)properties option:(GATrackOption)option;
//extern "C" void track() {
//    [[GrowthAnalytics sharedInstance] track];
//}*/
//
//extern "C" void AnalyticsTag(const char* tagId, const char* value) {
//    [[GrowthAnalytics sharedInstance] tag:NSStringFromCharString(tagId) value:NSStringFromCharString(value)];
//}
//
//extern "C" void AnalyticsOpen() {
//    [[GrowthAnalytics sharedInstance] open];
//}
//
//extern "C" void AnalyticsClose() {
//    [[GrowthAnalytics sharedInstance] close];
//}
//
//extern "C" void AnalyticsPurchase(int price, const char* category, const char* product) {
//    [[GrowthAnalytics sharedInstance] purchase:price setCategory:NSStringFromCharString(category) setProduct:NSStringFromCharString(product)];
//}
//
//extern "C" void AnalyticsSetUserId(const char* userId) {
//    [[GrowthAnalytics sharedInstance] setUserId:NSStringFromCharString(userId)];
//}
//
//extern "C" void AnalyticsSetName(const char* name) {
//    [[GrowthAnalytics sharedInstance] setName:NSStringFromCharString(name)];
//}
//
//extern "C" void AnalyticsSetAge(int age) {
//    [[GrowthAnalytics sharedInstance] setAge:age];
//}
//
///*
//- (void)setGender:(GAGender)gender;
//extern "C" void setGender() {
//    [[GrowthAnalytics sharedInstance] ];
//}*/
//
//extern "C" void AnalyticsSetLevel(int level) {
//    [[GrowthAnalytics sharedInstance] setLevel:level];
//}
//
///*
//- (void)setDevelopment:(BOOL)development;
//extern "C" void setDevelopment() {
//    [[GrowthAnalytics sharedInstance] ];
//}*/
//
//extern "C" void AnalyticsSetDeviceModel() {
//    [[GrowthAnalytics sharedInstance] setDeviceModel];
//}
//
//extern "C" void AnalyticsSetOS() {
//    [[GrowthAnalytics sharedInstance] setOS];
//}
//
//extern "C" void AnalyticsSetLanguage() {
//    [[GrowthAnalytics sharedInstance] setLanguage];
//}
//
//extern "C" void AnalyticsSetTimeZone() {
//    [[GrowthAnalytics sharedInstance] setTimeZone];
//}
//
//extern "C" void AnalyticsSetTimeZoneOffset() {
//    [[GrowthAnalytics sharedInstance] setTimeZoneOffset];
//}
//
//extern "C" void AnalyticsSetAppVersion() {
//    [[GrowthAnalytics sharedInstance] setAppVersion];
//}
//
//extern "C" void AnalyticsSetRandom() {
//    [[GrowthAnalytics sharedInstance] setRandom];
//}
//
//extern "C" void AnalyticsSetAdvertisingId(const char* idfa) {
//    //[[GrowthAnalytics sharedInstance] setAdvertisingId:NSStringFromCharString(idfa)];
//}
//
//extern "C" void AnalyticsSetBasicTags() {
//    [[GrowthAnalytics sharedInstance] setBasicTags];
//}
//
///*typedef NS_ENUM (NSInteger, GATrackOption) {
//    GATrackOptionDefault = 0,
//    GATrackOptionOnce,
//    GATrackOptionCounter
//};
//
//typedef NS_ENUM (NSInteger, GAGender) {
//    GAGenderNone = 0,
//    GAGenderMale,
//    GAGenderFemale
//};*/