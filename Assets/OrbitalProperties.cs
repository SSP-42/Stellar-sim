using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalProperties : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float zenith;
    [SerializeField]
    private float GM;
    [SerializeField]
    private float gravitaionalConstant;
    [SerializeField]
    private GravWell gravWell;

    void Awake()
    {
        gravitaionalConstant =  gravWell.gravitaionalConstant;       
    }

    void Update()
    {
        
    }
}
