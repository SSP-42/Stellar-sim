using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravWell : MonoBehaviour
{
    [SerializeField]
    bool IsElipticalOrbit = false;
    [SerializeField]
    private float gravitaionalConstant = 10f;
    private GameObject[] celestials;
    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        initVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gravity();
    }
    void Gravity()
    {
        foreach(GameObject a in celestials)
        {
            foreach(GameObject b in celestials)
            {
                if(a != b)
                {
                    float mass1 = a.GetComponent<Rigidbody>().mass;
                    float mass2 = b.GetComponent<Rigidbody>().mass;
                    float radius = Vector3.Distance(a.transform.position,b.transform.position);
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (gravitaionalConstant * ((mass1*mass2)/(radius*radius))));
                }
            }
        }
    }
    void initVelocity()
    {
        foreach(GameObject a in celestials)
        {
            if(!a.GetComponent<properties>().IsStableOrbital){break;}
            foreach(GameObject b in celestials)
            {
                if(!b.GetComponent<properties>().IsStableOrbital){break;}
                if(a != b)
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);

                    if (IsElipticalOrbit)
                    {
                        // Eliptic orbit = G * M  ( 2 / r + 1 / a) where G is the gravitational constant, M is the mass of the central object, r is the distance between the two bodies
                        // and a is the length of the semi major axis (!!! NOT GAMEOBJECT a !!!)
                        a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((gravitaionalConstant * m2) * ((2 / r) - (1 / (r * 1.5f))));
                    }
                    else
                    {
                        //Circular Orbit = ((G * M) / r)^0.5, where G = gravitational constant, M is the mass of the central object and r is the distance between the two objects
                        //We ignore the mass of the orbiting object when the orbiting object's mass is negligible, like the mass of the earth vs. mass of the sun
                        a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((gravitaionalConstant * m2) / r);
                    }

                }
            }
        }
    }
}
                
