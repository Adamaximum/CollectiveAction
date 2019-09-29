using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public SpriteRenderer beamSR;
    public Transform vertTR;
    public Transform horizTR;

    public bool reversePolarity;

    public bool vertAttract;
    public bool horizAttract;

    [Header("Polarity Switch Colors")]
    public Color normal;
    public Color reverse;

    // Start is called before the first frame update
    void Start()
    {
        beamSR = GetComponent<SpriteRenderer>();
        vertTR = GameObject.Find("Magnet Right").GetComponent<Transform>();
        horizTR = GameObject.Find("Magnet Up").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (reversePolarity == false)
            {
                reversePolarity = true;
                Debug.Log("Polarity Reversed");
            }
            else
            {
                reversePolarity = false;
                Debug.Log("Polarity Normal");
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            if(gameObject.name == "VertBeam" && transform.localScale.y > 0.1)
            {
                transform.localScale -= new Vector3(0f, 0.01f, 0f);
            }
            if (gameObject.name == "HorizBeam" && transform.localScale.x > 0.1)
            {
                transform.localScale -= new Vector3(0.01f, 0f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.V))
        {
            if (gameObject.name == "VertBeam" && transform.localScale.y < 0.8)
            {
                transform.localScale += new Vector3(0f, 0.01f, 0f);
            }
            if (gameObject.name == "HorizBeam" && transform.localScale.x < 0.8)
            {
                transform.localScale += new Vector3(0.01f, 0f, 0f);
            }
        }

        if (reversePolarity == false)
        {
            beamSR.color = normal;
        }
        else
        {
            beamSR.color = reverse;
        }
        
        if (gameObject.name == "VertBeam")
        {
            transform.position = new Vector3(0f, vertTR.position.y, 0f);

            if (Input.GetKey(KeyCode.Z))
            {
                vertAttract = true;
                normal.a = 1f;
                reverse.a = 1f;
            }
            else
            {
                vertAttract = false;
                normal.a = 0.2f;
                reverse.a = 0.2f;
            }
        }
        if (gameObject.name == "HorizBeam")
        {
            transform.position = new Vector3(horizTR.position.x, 0f, 0f);

            if (Input.GetKey(KeyCode.X))
            {
                horizAttract = true;
                normal.a = 1f;
                reverse.a = 1f;
            }
            else
            {
                horizAttract = false;
                normal.a = 0.2f;
                reverse.a = 0.2f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (gameObject.name == "VertBeam")
            {
                if (vertAttract == true && reversePolarity == false)
                {
                    collision.gameObject.transform.position += new Vector3(0.05f, 0f, 0f);
                }
                else if (vertAttract == true && reversePolarity == true)
                {
                    collision.gameObject.transform.position -= new Vector3(0.05f, 0f, 0f);
                }
            }
            if (gameObject.name == "HorizBeam")
            {
                if (horizAttract == true && reversePolarity == false)
                {
                    collision.gameObject.transform.position += new Vector3(0f, 0.05f, 0f);
                }
                else if (horizAttract == true && reversePolarity == true)
                {
                    collision.gameObject.transform.position -= new Vector3(0, 0.05f, 0f);
                }
            }
        }
    }
}
