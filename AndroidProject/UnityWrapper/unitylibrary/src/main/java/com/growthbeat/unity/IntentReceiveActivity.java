package com.growthbeat.unity;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;

import com.growthbeat.link.GrowthLink;
import com.unity3d.player.UnityPlayerProxyActivity;

public class IntentReceiveActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        final Uri uri = getIntent().getData();
        GrowthLink.getInstance().handleOpenUrl(uri);
        Intent intent = new Intent(this, UnityPlayerProxyActivity.class);
        startActivity(intent);
        finish();
    }

    @Override
    public void onBackPressed() {
        // バックキーで何もしない
        // super.onBackPressed();
    }

}