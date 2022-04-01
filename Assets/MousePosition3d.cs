using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class MousePosition3d : NetworkBehaviour
{
  
    [SerializeField] Camera mainCamera;
  
    private float xPosition;
    private float zPosition;
   public Vector3 direction;
    public MousePosition3d script;
    public bool LMBisHeld;
    public bool LMBisheldnomore;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float sSpeed;
    private Transform toBeRotation;



    // Start is called before the first frame update
    void Start()
    { 
       if (gameObject.GetComponent<NetworkObject>().IsOwner == false) { script.enabled = false; }
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButton(0)) { LMBisHeld = true; }
        else { LMBisHeld = false; }
          transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction ), sSpeed * Time.deltaTime);

     transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        if (mainCamera == null) { mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); }
        xPosition = Input.mousePosition.x - ((Screen.width / 2));
         zPosition = Input.mousePosition.y - ((Screen.height / 2) - Screen.height / 10);
    //  Ray ray  = mainCamera.ScreenPointToRay(Input.mousePosition);
      //  if (Physics.Raycast(ray,out RaycastHit raycastHit)) { direction = raycastHit.point; }

        direction = new Vector3(xPosition, 0f, zPosition);
        if (Time.time > nextActionTime && LMBisHeld)
        {
            LMBisheldnomore = true;
            nextActionTime += period;
            DirectionServerRpc(direction, LMBisHeld);
        }
        if (LMBisHeld == false && LMBisheldnomore == true) { DirectionServerRpc(direction, LMBisHeld); LMBisheldnomore = false; }





    }
    [ServerRpc]
    void DirectionServerRpc(Vector3 directionsend,bool lmb) { direction = directionsend;  LMBisHeld=lmb; }

}
