
using Unity.Netcode;
using UnityEngine;

namespace GameManager
{
    public class Game_Manager : MonoBehaviour
    {
        private int x = 0;
        public bool isServer;
        private void Update()
        {


            if (x == 0 && isServer == true) { NetworkManager.Singleton.StartServer(); x++; }
        }

        void OnGUI()
            {
                GUILayout.BeginArea(new Rect(10, 10, 300, 300));
                if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
                {
                    StartButtons();
                }
                else
                {
                    StatusLabels();


                }

                GUILayout.EndArea();
            }

            static void StartButtons()
            {

           
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
                if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
                if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
            }

            static void StatusLabels()
            {
                var mode = NetworkManager.Singleton.IsHost ?
                    "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

                GUILayout.Label("Transport: " +
                    NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
                GUILayout.Label("Mode: " + mode);
            }


        }
    }
