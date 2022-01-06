#import <Foundation/Foundation.h>
extern "C" {
    UIViewController*  UnityGetGLViewController();
    void doShare (NSString*  desc ,UIImage* icon ,NSURL* nsUrl){
        NSMutableArray *activityItems =  [NSMutableArray arrayWithObjects:desc,nsUrl,nil];
        if(icon != nil){
            [activityItems addObject:icon];
        }
        UIActivityViewController * activityViewController = [[UIActivityViewController alloc] initWithActivityItems:activityItems applicationActivities:nil];
        UIActivityViewControllerCompletionWithItemsHandler handler = ^(UIActivityType activityType, BOOL completed, NSArray *returnedItems, NSError *activityError) {
            [activityViewController dismissViewControllerAnimated:YES completion:nil];
        };
        activityViewController.completionWithItemsHandler = handler;
        UIViewController* controller = UnityGetGLViewController();
        [controller presentViewController: activityViewController animated: YES completion: nil];
    }

    void SysShareText(const char* content, const char* title){
        NSDictionary *infoPlist = [[NSBundle mainBundle] infoDictionary];
        NSString *icon = [[infoPlist valueForKeyPath:@"CFBundleIcons.CFBundlePrimaryIcon.CFBundleIconFiles"] lastObject];
        UIImage* image = [UIImage imageNamed:icon];
        NSURL   *nsUrl = [NSURL URLWithString:[NSString stringWithUTF8String:title]];
        NSString *description = [NSString stringWithUTF8String:content];
        doShare(description,image,nsUrl);
    }

    void SysShareImage(const char* imagePath, const char* title, const char* desc){
        NSString* sPath = [NSString stringWithUTF8String:imagePath];
        UIImage *shareImage = nil;
        if([sPath hasPrefix:@"http://"] || [sPath hasPrefix:@"https://"]){
            shareImage = [UIImage imageWithData:[NSData dataWithContentsOfURL:[NSURL URLWithString:sPath]]];
        }else{
            shareImage = [[UIImage alloc] initWithContentsOfFile:sPath];
        }
        NSURL   *nsUrl = [NSURL URLWithString:@""];
        NSString* description = [NSString stringWithUTF8String: desc];
        doShare(description,shareImage,nsUrl);
    }

}
