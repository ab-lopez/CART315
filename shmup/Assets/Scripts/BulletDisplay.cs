using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletDisplay : MonoBehaviour
{
    public TMP_Text bulletText;
    public int bulletsLeft;

    ShipController sC;

    void Awake(){
        GameObject obj = GameObject.Find("Ship");
        sC = obj.GetComponent<ShipController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBulletCount();
    }

    public void UpdateBulletCount() { 
        if(sC != null){
            bulletsLeft = sC.bulletCounter;
        }
        string bulletDisplay = ("Bullets Left: " + bulletsLeft);
        bulletText.text = bulletDisplay;
    }
}
