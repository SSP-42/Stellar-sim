using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float thrust = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Thrust();
        }       
    }
    void Thrust()
    {
        rb.AddForce(transform.up*thrust);
    }
}
