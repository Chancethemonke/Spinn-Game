using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
   private Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public CameraFollow script;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameObject.Find("Client") == null) { script.enabled = false; }
        target = GameObject.Find("Client").GetComponent<Transform>();
        transform.parent = null;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
          

      

        }
    }
