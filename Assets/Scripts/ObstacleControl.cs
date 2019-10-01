using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleControl : MonoBehaviour
{
    public Rigidbody2D obsRB;

    public TextMeshProUGUI numberNeedChange;

    public int numberNeed;
    public int numberHave;

    // Start is called before the first frame update
    void Start()
    {
        obsRB = GetComponent<Rigidbody2D>();

        numberNeedChange = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        numberNeedChange.text = (numberNeed - numberHave).ToString();

        if (numberHave == numberNeed)
        {
            obsRB.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            obsRB.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberHave++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberHave--;
        }
    }
}
