using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float thrust = 10f;
    private Quaternion target;
    //! This is for testing and should be removed later
    public float XRotation;
    public float YRotation;
    public float ZRotation;
    private float smooth = 5.0f;
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
        else if(Input.GetKeyUp("space")){
            CancelThrust();
        }
        if(Input.GetKeyDown("w"))
        {
            target = MakeTarget(XRotation,YRotation,ZRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation,target,Time.deltaTime * smooth);
        }      
    }
    void Thrust()
    {
        rb.AddForce(transform.up*thrust, ForceMode.Impulse);
    }
    void CancelThrust()
    {
        rb.AddForce(transform.up*-thrust);
    }
    public Quaternion MakeTarget(float x, float y,float z)
    {
        Quaternion target = Quaternion.Euler(x, y, z);
        return target;
    }
}
