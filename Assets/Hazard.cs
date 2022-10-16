using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float damageDecayRate = 1f;
    PlayerHealth player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerHealth>();
        if (player)
        {
            Debug.Log("player detected");
            player.TakeDamage(damage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (player)
        {
            player.TakeDamage(damage);
        }
    }
}
