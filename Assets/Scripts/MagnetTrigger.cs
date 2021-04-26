using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MagnetTrigger : MonoBehaviour
{
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.isMagnet == true)
        {
            if(Vector3.Distance(transform.position, Player.position) < 7)
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.position, 0.1f);
            }
        }
    }
}
