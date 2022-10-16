using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float standardview = 60f;
    [SerializeField] float zoomedView = 40f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonController = GetComponentInParent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            mainCamera.fieldOfView = zoomedView;
            firstPersonController.m_MouseLook.XSensitivity = zoomInSensitivity;   
            firstPersonController.m_MouseLook.YSensitivity = zoomInSensitivity;   
        }
        else
        {
            mainCamera.fieldOfView = standardview;
            firstPersonController.m_MouseLook.XSensitivity = zoomOutSensitivity;
            firstPersonController.m_MouseLook.YSensitivity = zoomOutSensitivity;
        }
    }
}
