using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour
{
    public GameObject defaultWeaponPrefab;

    public Weapon armePrincipale;
    public Weapon armeSecondaire;


    public Transform weaponHandler;
    public LayerMask mask;

    public float switchWeaponDelay;
    float lastTimeSwitch = 0f;
    float lastFireTime = 0f;
    

    Camera cam;
    

    // Use this for initialization
    void Start()
    {
        if (weaponHandler == null)
        {
            Debug.LogError("Please assign weaponHandler reference in WeaponManager");
        }
        if (armePrincipale == null)
        {
            GameObject defaultWeapon = Instantiate(defaultWeaponPrefab, weaponHandler, false);
            armePrincipale = defaultWeapon.GetComponent<Weapon>();
            // Init ath
        }
        switchWeaponDelay = switchWeaponDelay > 0 ? switchWeaponDelay : .3f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Switch") != 0f)
        {
            if(Time.time > (lastTimeSwitch + switchWeaponDelay))
            {
                SwitchArme();
                lastTimeSwitch = Time.time;
            }
            
        }
    }

    void LateUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > (lastFireTime + armePrincipale.fireRate))
            {
                PlayWeaponFX();
                Shoot();
                lastFireTime = Time.time;
            }
        }
    }

    /// <summary>
    /// Plays player's primary weapon's muzzle flash + sounds
    /// </summary>
    void PlayWeaponFX()
    {
        armePrincipale.ActivateMuzzleFlash();
        armePrincipale.WeaponAudio.PlayOneShot(armePrincipale.WeaponAudio.clip);
        
    }

    void Shoot()
    {
        if(cam == null)
        {
            cam = GetComponent<PlayerController>().playerCamera;
        }

        if(cam != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, armePrincipale.range, mask))
            {
                Debug.Log("Object hit : " + hit.collider.name);

                if (hit.collider.tag == "Zombie")
                {
                    hit.transform.GetComponent<ZombieHealth>().GetHitted(armePrincipale.damages);
                }
                else if (hit.collider.tag == "DestructibleCrate")
                {
                    hit.transform.GetComponent<Hit>().DestroyIt();
                }
            }
        }
        
    }

    public void RamasserArme(GameObject newArme)
    {
        if (armeSecondaire != null)
        {
            Destroy(armePrincipale.gameObject);
            GameObject na = Instantiate(newArme, weaponHandler, false);
            armePrincipale = na.GetComponent<Weapon>();

        }
        else
        {
            GameObject na = Instantiate(newArme, weaponHandler, false);
            armeSecondaire = na.GetComponent<Weapon>();
            na.SetActive(false);
            SwitchArme();
        }

    }

    public void SwitchArme()
    {
        if(armeSecondaire != null)
        {
            GameObject secCopy = armeSecondaire.gameObject;
            armeSecondaire = armePrincipale;
            armeSecondaire.gameObject.SetActive(false);
            armePrincipale = secCopy.GetComponent<Weapon>();
            armePrincipale.gameObject.SetActive(true);
        }
        
    }

    public void Recharger()
    {

    }
}



