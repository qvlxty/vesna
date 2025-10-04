using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkStarter : MonoBehaviour
{
    [SerializeField] private string serverIP = "192.168.0.165"; // Замени на IP хоста
    [SerializeField] private ushort port = 3000;

    void Start()
    {
        // Настройка транспорта перед стартом
        var transport = GetComponent<UnityTransport>();
        if (transport != null)
        {
            transport.SetConnectionData(serverIP, port);
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        
        if (GUILayout.Button("Start Host"))
        {
            this.StartHost();
        }
        
        if (GUILayout.Button("Start Client")) 
        {
            this.StartClient();
        }

        // Показываем статус подключения
        if (NetworkManager.Singleton)
        {
            //GUILayout.Label($"Status: {NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetConnectionState()}");
            GUILayout.Label($"Clients: {NetworkManager.Singleton.ConnectedClients.Count}");
        }
        
        GUILayout.EndArea();
    }

    private void StartHost()
    {
        Debug.Log("Starting Host...");
        NetworkManager.Singleton.StartHost();
    }

    private void StartClient()
    {
        Debug.Log("Starting Client...");
        NetworkManager.Singleton.StartClient();
    }
}