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
    public GameObject thisCubeSlot;
    [HideInInspector]
    public GameObject HoverSpot;
    [HideInInspector]
    public GameObject ActiveSpot;
    [HideInInspector]
    public GameObject trigger1;
    [HideInInspector]
    public GameObject trigger2;
    [HideInInspector]
    public GameObject trigger3;
    [HideInInspector]
    public GameObject trigger4;
    [HideInInspector]
    public int numberOfBlocks = 0;
    public GameObject TransparentCube;
    public GameObject OpaqueCube;
    [HideInInspector]
    public GameObject newCube;
    [HideInInspector]
    public bool hover=false;
    [HideInInspector]
    public static string currentCube="opaque";

    private void Awake()
    {
        thisCubeSlot = this.gameObject;
        HoverSpot = thisCubeSlot.transform.Find("HoverSpot").gameObject;
        ActiveSpot = thisCubeSlot.transform.Find("ActiveSpot").gameObject;
        HoverSpot.SetActive(false);
        trigger1 = thisCubeSlot.transform.Find("Spot1").gameObject;
        trigger2 = thisCubeSlot.transform.Find("Spot2").gameObject;
        trigger3 = thisCubeSlot.transform.Find("Spot3").gameObject;
        trigger4 = thisCubeSlot.transform.Find("Spot4").gameObject;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string getFirst()
    {
        if (trigger1.GetComponent<CubeCollider>().getCurrent() == "Transparent" || trigger1.GetComponent<CubeCollider>().getCurrent() == null)
            return "empty";
        return trigger1.GetComponent<CubeCollider>().getCurrent();
    }
    public string getSecond()
    {
        if (trigger2.GetComponent<CubeCollider>().getCurrent() == "Transparent" || trigger2.GetComponent<CubeCollider>().getCurrent() == null)
            return "empty";
        return trigger2.GetComponent<CubeCollider>().getCurrent();
    }
    public string getThird()
    {
        if (trigger3.GetComponent<CubeCollider>().getCurrent() == "Transparent" || trigger3.GetComponent<CubeCollider>().getCurrent() == null)
            return "empty";
        return trigger3.GetComponent<CubeCollider>().getCurrent();
    }
    public string getFourth()
    {
        if (trigger4.GetComponent<CubeCollider>().getCurrent() == "Transparent" || trigger4.GetComponent<CubeCollider>().getCurrent() == null)
            return "empty";
        return trigger4.GetComponent<CubeCollider>().getCurrent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.HoverSpot.SetActive(true);
        this.ActiveSpot.SetActive(false);
        hover = true;
    }

    private void OnMouseExit()
    {
        this.HoverSpot.SetActive(false);
        this.ActiveSpot.SetActive(true);
        hover = false;
    }

    private void OnMouseDown()
    {
        if (hover)
            PlaceCube();
    }

    private void PlaceCube()
    {
        if (numberOfBlocks >= 4)
        {
            //put code to say the cube slot is full
            return;
        }
        else
        {
            if (currentCube=="transparent" )
            {
                newCube = Instantiate(TransparentCube) as GameObject;
            }
            if (currentCube=="opaque")
            {
                newCube = Instantiate(OpaqueCube) as GameObject;
            }
            Vector3 slotPOS = this.transform.position;

            newCube.transform.localPosition = new Vector3(slotPOS.x, slotPOS.y+5, slotPOS.z);
            //newCube.GetComponent<Rigidbody>().isKinematic = true;
            numberOfBlocks++;
        }
    }
}
