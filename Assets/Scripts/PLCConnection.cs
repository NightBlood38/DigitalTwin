using UnityEngine;
using Opc.UaFx.Client; 

public class PLCConnection : MonoBehaviour
{
    private string opcUrl = "opc.tcp://PLC-ip-address:4840"; 
    private OpcClient client;

    void Start()
    {
        try
        {

            client = new OpcClient(opcUrl);
            client.Connect();
            Debug.Log("Connection Succesful");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Connection failed: " + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Disconnect();
            client.Dispose();
            Debug.Log("Disconnected");
        }
    }
}