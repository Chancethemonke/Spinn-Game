using Unity.Netcode;
using UnityEngine;

public class NetworkVariableTest : NetworkBehaviour
{
    private NetworkVariable<float> ServerNetworkVariable = new NetworkVariable<float>();
    

    
    void Update()
    {
        Debug.Log(ServerNetworkVariable.Value);
        if (IsOwner)
        {
            ServerNetworkVariable.Value = ServerNetworkVariable.Value + 0.1f;
           
              
                Debug.Log("Server set its var to: " + ServerNetworkVariable.Value);
            
        }
    }
}