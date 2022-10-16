using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        gameOverCanvas.SetActive(false);
    }

public void HandleDeath()
    {
        firstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverCanvas.SetActive (true);
        FindObjectOfType<WeaponSwitcher>().enabled = false; 
    }
}
