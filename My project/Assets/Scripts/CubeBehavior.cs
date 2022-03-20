using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag=="Transparent" || collidedWith.tag == "Opaque")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
