//Created by: Ben Jenkins
//Date created: 3/2/2022
//Last edited: NA
//Last edited by: NA
//Description: controls CubeSlot behavior
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSlot : MonoBehaviour
{
    [HideInInspector]
    public GameObject HoverSpot;
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;

    private void Awake()
    {
        HoverSpot = GameObject.Find("HoverSpot");
        HoverSpot.SetActive(false);
        trigger1 = GameObject.Find("Spot1");
        trigger2 = GameObject.Find("Spot2");
        trigger3 = GameObject.Find("Spot3");
        trigger4 = GameObject.Find("Spot4");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string getFirst()
    {
        return trigger1.CubeCollider.getCurrent();
    }
    public string getSecond()
    {
        return trigger2.CubeCollider.getCurrent();
    }
    public string getThird()
    {
        return trigger3.CubeCollider.getCurrent();
    }
    public string getFourth()
    {
        return trigger4.CubeCollider.getCurrent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        HoverSpot.SetActive(true);
    }

    private void OnMouseExit()
    {
        HoverSpot.SetActive(false) ;
    }
}
