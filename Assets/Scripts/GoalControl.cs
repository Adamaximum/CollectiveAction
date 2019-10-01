using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalControl : MonoBehaviour
{
    public TextMeshProUGUI numberNeedChange;

    public int numberNeed;
    public int numberHave;

    // Start is called before the first frame update
    void Start()
    {
        numberNeedChange = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        numberNeedChange.text = (numberNeed - numberHave).ToString();

        if (numberNeed == numberHave)
        {
            SceneManager.LoadScene("level1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberHave++;
            Destroy(collision.gameObject);
        }
    }
}
