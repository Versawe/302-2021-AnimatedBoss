using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public Button redo;

    HealthSystem HamHealth;
    HealthSystem pHealth;

    // Start is called before the first frame update
    void Start()
    {
        HamHealth = GameObject.Find("Root_Hamster_Idle").GetComponent<HealthSystem>();
        pHealth = GameObject.Find("rigged-dude").GetComponent<HealthSystem>();

        redo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pHealth.health <= 0 || HamHealth.health <= 0)
        {
            redo.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RedoGame()
    {
        SceneManager.LoadScene("HomeworkScene");
    }
}
