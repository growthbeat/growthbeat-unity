package com.growthbeat.intenthandler;

import com.growthbeat.Growthbeat;
import com.growthbeat.model.CustomIntent;
import com.unity3d.player.UnityPlayer;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class IntentHandlerWrapper {

    private List<IntentHandler> intentHandlers = new ArrayList<IntentHandler>();

    private static final IntentHandlerWrapper instance = new IntentHandlerWrapper();

    public IntentHandlerWrapper() {
        super();
        Growthbeat.getInstance().setIntentHandlers(intentHandlers);
    }

    private static IntentHandlerWrapper getInstance() {
        return IntentHandlerWrapper.instance;
    }

    public void clearIntentHandlers() {
        intentHandlers.clear();
    }

    public void addNoopIntentHandler() {
        intentHandlers.add(new NoopIntentHandler());
    }

    public void addUrlIntentHandler() {
        intentHandlers.add(new UrlIntentHandler(Growthbeat.getInstance().getContext()));
    }

    public void addCustomIntentHandler(final String gameObject, final String methodName) {
        intentHandlers.add(new IntentHandler() {
            public boolean handle(com.growthbeat.model.Intent intent) {
                if (intent.getType() != com.growthbeat.model.Intent.Type.custom) {
                    return false;
                }
                Map<String, String> extra = ((CustomIntent) intent).getExtra();
                JSONObject json = new JSONObject();
                for (Map.Entry<String, String> entry : extra.entrySet()) {
                    try {
                        json.put(entry.getKey(), entry.getValue());
                    } catch (JSONException e) {
                    }
                }
                UnityPlayer.UnitySendMessage(gameObject, methodName, json.toString());
                return true;
            }
        });
    }

}
