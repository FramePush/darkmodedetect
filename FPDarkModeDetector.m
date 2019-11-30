#import "FPDarkModeDetector.h"

@implementation FPDarkModeDetector

+ (UIUserInterfaceStyle) getCurrentMode
{
    return UITraitCollection.currentTraitCollection.userInterfaceStyle;
}

@end

#if __cplusplus
extern "C" {
#endif
    
    int _FP_DarkModeDetector_getCurrentMode()
    {
		if (@available(iOS 13, *)) {
			switch (FPDarkModeDetector.getCurrentMode)
			{
				case UIUserInterfaceStyleDark:
					return 2;
				case UIUserInterfaceStyleLight:
					return 1;
				case UIUserInterfaceStyleUnspecified:
					return 0;
			}
		}
        
        return 0;
    }
    
#if __cplusplus
}
#endif
