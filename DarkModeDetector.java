package com.framepush.darkmodedetect;

import android.view.ContextThemeWrapper;
import android.content.res.Configuration;

public class DarkModeDetector {
    public static int getCurrentMode(ContextThemeWrapper ctw) {
        switch (ctw.getResources().getConfiguration().uiMode & Configuration.UI_MODE_NIGHT_MASK) {
            case Configuration.UI_MODE_NIGHT_YES:
                return 2;
            case Configuration.UI_MODE_NIGHT_NO:
                return 1;
        }
        
        return 0;
    }
}