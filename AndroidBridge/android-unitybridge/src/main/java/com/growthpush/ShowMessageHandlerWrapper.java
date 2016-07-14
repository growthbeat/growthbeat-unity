package com.growthpush;

import com.growthbeat.message.handler.ShowMessageHandler;
import com.unity3d.player.UnityPlayer;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public class ShowMessageHandlerWrapper {

    private static Map<String, ShowMessageHandler.MessageRenderHandler> messageRenderHandlers = new HashMap<>();

    public static void trackEvent(final String name, final String value, final String gameObject, final String methodName) {

        GrowthPush.getInstance().trackEvent(name, value, new ShowMessageHandler() {
            @Override
            public void complete(MessageRenderHandler run) {
                String uuid = UUID.randomUUID().toString();
                messageRenderHandlers.put(uuid, run);
                UnityPlayer.UnitySendMessage(gameObject, methodName, uuid);
            }

            @Override
            public void error(String error) {
            }
        });

    }

    public static void renderMessage(String uuid) {
        ShowMessageHandler.MessageRenderHandler messageRenderHandler = messageRenderHandlers.get(uuid);
        if (messageRenderHandler != null) {
            messageRenderHandler.render();
            messageRenderHandlers.remove(uuid);
        }
    }

}