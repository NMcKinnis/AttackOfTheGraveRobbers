using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damagedCanvas;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = damagedCanvas.GetComponent<Animator>();
    }

    public void ShowDamageImpact()
    {
        myAnimator.SetTrigger("wasDamaged");
    }
}
