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
    public GameObject HoverSpot;

    private void Awake()
    {
        HoverSpot = GameObject.Find("HoverSpot");
        HoverSpot.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onMouseEnter()
    {
        HoverSpot.SetActive(true);
    }

    private void onMouseExit()
    {
        HoverSpot.SetActive(false) ;
    }
}
