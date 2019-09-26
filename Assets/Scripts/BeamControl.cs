using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public SpriteRenderer beamSR;
    public Transform vertTR;
    public Transform horizTR;

    // Start is called before the first frame update
    void Start()
    {
        beamSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
