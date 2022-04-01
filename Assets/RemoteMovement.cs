using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class RemoteMovement : MonoBehaviour
{

    public float speed = 2.5f;
    private GameObject NetworkManager;
    
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager = GameObject.Find("Network Manager");
       if (!NetworkManager.GetComponent<NetworkManager>().IsServer) { gameObject.GetComponent<RemoteMovement>().enabled = false; }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<MousePosition3d>().LMBisHeld == true)
        {
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, gameObject.GetComponent<MousePosition3d>().direction + transform.position, speed * Time.deltaTime);
            transform.LookAt(gameObject.GetComponent<MousePosition3d>().direction);
        }
        else { gameObject.GetComponent<Animator>().SetBool("isMoving", false); }
    }

}
