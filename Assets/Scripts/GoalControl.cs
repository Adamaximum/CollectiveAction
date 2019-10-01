using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalControl : MonoBehaviour
{
    Scene current;
    string sceneName;

    public TextMeshProUGUI numberNeedChange;

    public int numberNeed;
    public int numberHave;

    // Start is called before the first frame update
    void Start()
    {
        current = SceneManager.GetActiveScene();
        sceneName = current.name;

        numberNeedChange = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        numberNeedChange.text = (numberNeed - numberHave).ToString();

        if (sceneName == "SampleScene")
        {
            if (numberNeed == numberHave)
            {
                SceneManager.LoadScene("level1");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        else
        {
            if (numberNeed == numberHave)
            {
                SceneManager.LoadScene("SampleScene");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("level1");
            }
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
