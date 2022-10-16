using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float startingHealth = 100;
    public float health;
    DeathHandler deathHandler;
    AudioSource audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        deathHandler = GetComponent<DeathHandler>();
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        audioSource.Play();
        health -= damage;
        if (health <= 0)
        {
            deathHandler.HandleDeath();
        }
        
    }
}
