package com.growthbeat.unity;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.json.JSONException;
import org.json.JSONObject;

import com.growthbeat.GrowthbeatCore;
import com.growthbeat.intenthandler.IntentHandler;
import com.growthbeat.intenthandler.NoopIntentHandler;
import com.growthbeat.intenthandler.UrlIntentHandler;
import com.growthbeat.model.CustomIntent;
import com.unity3d.player.UnityPlayer;

import android.util.Log;

public class IntentHandlerWrapper {
    private static List<IntentHandler> intentHandlers;

    public static void initializeIntentHandlers() {
        intentHandlers = new ArrayList<IntentHandler>();
        GrowthbeatCore.getInstance().setIntentHandlers(intentHandlers);
    }

    public static void addNoopIntentHandler() {
        if (intentHandlers == null)
            throw new IllegalStateException("not initialized.");
        intentHandlers.add(new NoopIntentHandler());
    }

    public static void addUrlIntentHandler() {
        if (intentHandlers == null || GrowthbeatCore.getInstance().getContext() == null)
            throw new IllegalStateException("not initialized.");
        intentHandlers.add(new UrlIntentHandler(GrowthbeatCore.getInstance().getContext()));
    }

    public static void addCustomIntentHandler(final String gameObject) {
        if (intentHandlers == null)
            throw new IllegalStateException("not initialized.");
        intentHandlers.add(new IntentHandler() {
            public boolean handle(com.growthbeat.model.Intent intent) {
                Log.d("growthlink", "handle called");
                if (intent.getType() != com.growthbeat.model.Intent.Type.custom)
                    return false;;
                Map<String, String> extra = ((CustomIntent) intent).getExtra();
                JSONObject json = new JSONObject();
                for (Map.Entry<String, String> entry : extra.entrySet()) {
                    try {
                        json.put(entry.getKey(), entry.getValue());
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }
                UnityPlayer.UnitySendMessage(gameObject, "handleCustomIntent", json.toString());
                return true;
            }
        });
    }

}
