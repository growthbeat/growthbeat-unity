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

extern "C" {

    void ga_trackWithNamespace(const char* _namespace, const char* name, const char* properties, int option) {
        NSData* data = [GANSStringFromCharString(properties) dataUsingEncoding:NSUTF8StringEncoding];
        NSDictionary* dictionary = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingAllowFragments error:nil];

        [[GrowthAnalytics sharedInstance] track:GANSStringFromCharString(_namespace) name:GANSStringFromCharString(name) properties:dictionary option:(GATrackOption)option completion:nil];
    }

    void ga_track(const char* name, const char* properties, int option) {
        NSData* data = [GANSStringFromCharString(properties) dataUsingEncoding:NSUTF8StringEncoding];
        NSDictionary* dictionary = [NSJSONSerialization JSONObjectWithData:data options:NSJSONReadingAllowFragments error:nil];

        [[GrowthAnalytics sharedInstance] track:GANSStringFromCharString(name) properties:dictionary option:(GATrackOption)option];
    }

    void ga_tagWithNamespace(const char* _namespace, const char* name, const char* value, int option) {
        [[GrowthAnalytics sharedInstance] tag:GANSStringFromCharString(_namespace) name:GANSStringFromCharString(name) value:GANSStringFromCharString(value) completion:nil];
    }

    void ga_tag(const char* name, const char* value) {
        [[GrowthAnalytics sharedInstance] tag:GANSStringFromCharString(name) value:GANSStringFromCharString(value)];
    }

    void ga_open() {
        [[GrowthAnalytics sharedInstance] open];
    }

    void ga_close() {
        [[GrowthAnalytics sharedInstance] close];
    }

    void ga_purchase(int price, const char* category, const char* product) {
        [[GrowthAnalytics sharedInstance] purchase:price setCategory:GANSStringFromCharString(category) setProduct:GANSStringFromCharString(product)];
    }

    void ga_setUserId(const char* userId) {
        [[GrowthAnalytics sharedInstance] setUserId:GANSStringFromCharString(userId)];
    }

    void ga_setName(const char* name) {
        [[GrowthAnalytics sharedInstance] setName:GANSStringFromCharString(name)];
    }

    void ga_setAge(int age) {
        [[GrowthAnalytics sharedInstance] setAge:age];
    }

    void ga_setGender(int gender) {
        [[GrowthAnalytics sharedInstance] setGender:(GAGender)gender];
    }

    void ga_setLevel(int level) {
        [[GrowthAnalytics sharedInstance] setLevel:level];
    }

    void ga_setDevelopment(bool development) {
        [[GrowthAnalytics sharedInstance] setDevelopment:development];
    }

    void ga_setDeviceModel() {
        [[GrowthAnalytics sharedInstance] setDeviceModel];
    }

    void ga_setOS() {
        [[GrowthAnalytics sharedInstance] setOS];
    }

    void ga_setLanguage() {
        [[GrowthAnalytics sharedInstance] setLanguage];
    }

    void ga_setTimeZone() {
        [[GrowthAnalytics sharedInstance] setTimeZone];
    }

    void ga_setTimeZoneOffset() {
        [[GrowthAnalytics sharedInstance] setTimeZoneOffset];
    }

    void ga_setAppVersion() {
        [[GrowthAnalytics sharedInstance] setAppVersion];
    }

    void ga_setRandom() {
        [[GrowthAnalytics sharedInstance] setRandom];
    }

    void ga_setAdvertisingId() {
        [[GrowthAnalytics sharedInstance] setAdvertisingId];
    }

    void ga_setTrackingEnabled() {
        [[GrowthAnalytics sharedInstance] setTrackingEnabled];
    }

    void ga_setBasicTags() {
        [[GrowthAnalytics sharedInstance] setBasicTags];
    }

    void ga_setBaseUrl(const char* baseUrl) {
        [[[GrowthAnalytics sharedInstance] httpClient] setBaseUrl:[NSURL URLWithString:[NSString stringWithCString:baseUrl encoding:NSUTF8StringEncoding]]];
    }


}