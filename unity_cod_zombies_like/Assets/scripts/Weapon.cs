using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponName;
    public int damages;
    public int magazineCapacity;
    public int ammo;
    public float range;
    public float fireRate;
    public float muzzleFlashDelay;
    public AudioClip fireSound;

    AudioSource soundPlayer;
    Renderer muzzleFlash;
    Light muzzleLight;

    float lastFireTime = 0f;

    public AudioSource WeaponAudio
    {
        get { return soundPlayer; }
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start - Weapon : " + WeaponName);
        muzzleFlashDelay = muzzleFlashDelay > 0 ? muzzleFlashDelay : 0.1f;


        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.clip = fireSound;

        foreach (Transform t in transform)
        {
            if (t.name == "MuzzleFlash")
                muzzleFlash = t.GetComponent<Renderer>();

            if (t.name == "MuzzleLight")
                muzzleLight = t.GetComponent<Light>();
        }

        muzzleFlash.enabled = false;
        muzzleLight.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > (lastFireTime + fireRate))
            {
                ActivateMuzzleFlash();
                soundPlayer.PlayOneShot(fireSound);
                lastFireTime = Time.time;
            }
        } 
        */
    }

    public void ActivateMuzzleFlash()
    {
        muzzleFlash.enabled = true;
        muzzleLight.enabled = true;
        Invoke("DeactivateMuzzleFlash", muzzleFlashDelay);
    }

    public void DeactivateMuzzleFlash()
    {
        muzzleFlash.enabled = false;
        muzzleLight.enabled = false;
    }
}
