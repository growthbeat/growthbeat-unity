package com.growthbeat.intenthandler;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;

import com.growthbeat.link.GrowthLink;
import com.unity3d.player.UnityPlayerProxyActivity;

public class IntentReceiveActivity extends FragmentActivity {

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
        // nothing to do when button pressed.
    }

}