using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject defaultWeaponPrefab;

    public Weapon armePrincipale;
    public Weapon armeSecondaire;

    public Transform weaponHandler;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Switch"))
        {
            SwitchArme();
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

    public void Tirer()
    {

    }

    public void Recharger()
    {

    }
}



