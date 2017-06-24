using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class WeaponLoot : MonoBehaviour {

    public GameObject weaponPrefab;
    public string WeaponName;

    Text itemInfoText;
    void Start()
    {
        itemInfoText = GameObject.FindGameObjectWithTag("ItemInfo").GetComponent<Text>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            itemInfoText.text = "PRESS E TO PICK : " + WeaponName;
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
            itemInfoText.text = "";
    }

    void OnTriggerStay(Collider col)
    {
        if (Input.GetButtonDown("Pick"))
        {
            if (col.tag == "Player")
            {
                col.GetComponent<WeaponManager>().RamasserArme(weaponPrefab);
            }
        }
        
    }

}
