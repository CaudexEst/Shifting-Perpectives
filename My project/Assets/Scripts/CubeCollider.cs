using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{

    [HideInInspector]
    public string current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        current = other.gameObject.tag;
    }

    public string getCurrent()
    {
        return current;
    }
}
