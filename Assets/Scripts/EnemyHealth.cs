using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip DeathSFX;
    Animator myAnimator;
    EnemyAI enemyAI;
    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        myAnimator = GetComponentInChildren<Animator>();
    }
    public void BroadcastChaseMessage()
    {
        BroadcastMessage("OnDamageTaken"); //todo rename method 

    }
    public void TakeDamage(float damage)
    {
        if (enemyAI.isAlive)
        {
            enemyAI.StopChasing();
            BroadcastMessage("OnDamageTaken");
            myAnimator.SetTrigger("isHit");
            AudioSource.PlayClipAtPoint(hitSFX,transform.position);
            hitpoints -= damage;
        }
        if (hitpoints <= 0 && enemyAI.isAlive)
        {
            AudioSource.PlayClipAtPoint(DeathSFX,transform.position);
            myAnimator.ResetTrigger("isHit");
            myAnimator.SetBool("isAlive", false);
            enemyAI.isAlive = false;
            if(gameObject.tag == "Boss")
            {
                FindObjectOfType<SceneLoader>().LoadNextScene();
            }
        }

    }
}
