using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRespawn))]
public class PlayerHazardInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerRespawn playerRespawn;
    void Start()
    {
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Hazard"))
    //     {
    //         Debug.Log("Player hit a hazard!");
    //     }
    // }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Player hit a hazard!");
            playerRespawn.SendMessage("PlayerRespawnToCheckpoint");
        }
    }
}
