using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Canvas ammoCanvas;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] AmmoType ammoType;
    AudioSource audioSource;
    TextMeshProUGUI ammoText;

    bool canshoot = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammoText = ammoCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1" ) && canshoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();

    }

    private void OnDisable()
    {
        canshoot = true;
    }

    private IEnumerator Shoot()
    {
        canshoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0 )
        {
            PlayMuzzleFlash();
            PlaySFX();
            ProcessRaycast();
            ammoSlot.DecreaseAmmo(ammoType);
   
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canshoot = true;
    }

    private void PlaySFX()
    {
        audioSource.Play();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null && target.GetComponent<EnemyHealth>())
            {
                target.TakeDamage(damage);
            }

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
