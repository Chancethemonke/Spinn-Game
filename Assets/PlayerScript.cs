using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { if (GetComponent<NetworkObject>().IsOwner == true) { gameObject.name = "Client"; gameObject.GetComponent<NetworkTransform>().SyncRotAngleY = false; }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
