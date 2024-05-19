﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;


    //[SerializeField] InputActionReference leftHapticAction;
    //[SerializeField] InputActionReference rightHapticAction;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    [Header("XR Settings")]
    [SerializeField] XRBaseController RightController;
    [SerializeField] XRBaseController LeftController;

    //public AudioSource source;
    //public AudioClip fireSound;

    public AudioClip fireSound;




    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        if (RightController == null)
        {
            RightController = FindObjectOfType<XRBaseController>();
            //controller = FindObjectOfType<XRController>();
            if (RightController != null)
            {
                Debug.Log("Controller found and assigned.");
            }
            else
            {
                Debug.LogError("Controller not found.");
            }
        }
    }

    public void PullTheTrigger()
    {
        gunAnimator.SetTrigger("Fire");

  

        SendHaptics();
        
    }

    public void SendHaptics()
    {
        if (RightController != null)
        {
            
            RightController.SendHapticImpulse(1f, 0.15f);
        }

       

        
    }

   


    //This function creates the bullet behavior
    void Shoot()
    {
        //source.PlayOneShot(fireSound);
        if (fireSound != null)
        {
            Debug.Log("Playing fire sound");
            AudioSource.PlayClipAtPoint(fireSound, barrelLocation.position);
        }
        else
        {
            Debug.LogError("Fire sound is not assigned");
        }
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
