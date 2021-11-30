using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    //===========================================
    //NOTE: FIRING SCRIPT
    // Assign to an empty object or gun
    //===========================================

    //Camera~~~~~~~~~~~
    public Camera fpscam;

    //Audio~~~~~~~~~~~~
    private AudioSource Audio;
    public AudioClip Fire_Sound;
    public AudioClip Reload_Sound;

    //Text~~~~~~~~~~~~~
    public TextMeshProUGUI AmmoNumber;
    public TextMeshProUGUI Reloading;

    //Global Variables~~~~~~~~~~~~~
    //public float damage = 0f; // damage of bullets
    public float distance = 100f; // distance of the raycast
    public float Impactforce = 200f; //force of impact
    public float fireRate = 0.5f; //rate of fire
    public int maxAmmo = 8;
    private int currentAmmo = 0;
    public int reloadspeed = 1;

    private float nextTimeToFire = 0f; // firing intervals


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Audio = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                currentAmmo--;
                Audio.PlayOneShot(Fire_Sound);
            }
        }
        else if(currentAmmo == 0)
        {
            Reloading.gameObject.SetActive(true);
        }
        //reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reloading.text = "Reloading...";
            StartCoroutine(Reload()); // start the coroutine
        }

        AmmoNumber.text = "Ammo Left: " + currentAmmo + "/" + maxAmmo;

    }
    //===========================================
    //RELOADING
    //===========================================
    IEnumerator Reload()
    {
        Audio.PlayOneShot(Reload_Sound);
        yield return new WaitForSeconds(reloadspeed);

        currentAmmo = maxAmmo;
        Reloading.gameObject.SetActive(false);
        Reloading.text = "Press 'R' to Reload.";

    }

    //===========================================
    //SHOOTING MECHANIC w/ Raycast
    //===========================================
    void Shoot()
    {
        Ray direction = new Ray(fpscam.transform.position, fpscam.transform.forward); // direction from origin to radius
        RaycastHit hit; //this identifies what is hit
        if (Physics.Raycast(direction, out hit, distance)) //checks what it hits and the distance
        {
            //getting component of the other object
            Target target = hit.transform.GetComponent<Target>();

            //hitting the other object
            if (target != null)
            {
                target.TakeDamage();
            }

            //adding force for pushback
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * Impactforce);
            }
        }
    }
}
