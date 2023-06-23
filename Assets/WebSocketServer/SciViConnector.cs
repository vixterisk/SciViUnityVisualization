using System;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketServer;

public class SciViConnector : WebSocketServer.WebSocketServer
{
    public Visualizer visualizer;

    override public void OnMessage(WebSocketMessage message)
    {
        try
        {
            if (message.data.ToLower().Contains("clientdisconnect"))
                hasConnectedClient = false;
            var json = JsonConvert.DeserializeObject<VisualizationPackage>(message.data);
            if (json.settings != null)
                visualizer.settings = json.settings;
            if (json.data != null)
                visualizer.Draw(json.data);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}