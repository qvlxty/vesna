using Unity.Netcode;
using UnityEngine;

public class NetworkConnectionDebugger : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        Debug.Log($"Object spawned! IsServer: {IsServer}, IsClient: {IsClient}, IsOwner: {IsOwner}");
        
        if (IsServer)
        {
            Debug.Log("Это сервер - должен спавнить игроков");
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
        
        if (IsClient)
        {
            Debug.Log("Клиент подключился к серверу!");
        }
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Клиент подключился! ID: {clientId}");
    }

    void Update()
    {
        // Показываем статус каждые 3 секунды
        if (Time.frameCount % 180 == 0 && NetworkManager.Singleton)
        {
            var transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport;
            // Debug.Log($"Transport State: {transport.GetConnectionState()}");
            // Debug.Log($"IsListening: {transport.IsListening}");
            Debug.Log($"Connected Clients: {NetworkManager.Singleton.ConnectedClients.Count}");
        }
    }
}