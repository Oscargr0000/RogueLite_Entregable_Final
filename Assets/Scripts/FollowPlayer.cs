using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 DesactivatedPos = new Vector3(0, -5, 0);

    public bool ShieldActive = false;

    
    void Update()
    {
        if (ShieldActive == true)
        {
            this.transform.position = player.transform.position;
        }
        else
        {
            this.transform.position = DesactivatedPos;
        }
    }
}
