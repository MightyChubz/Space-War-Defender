using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreCounter : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject winText;
    public GameObject player;
    public GameObject snow;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        winText.SetActive(false);
        VariableManager.GuiScoreObj = GameObject.FindGameObjectWithTag("Score");

        if (VariableManager.ScoreCapToggle)
        {
            InvokeRepeating("spawnSnow", 1, 3.0f);
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (VariableManager.ScoreCapToggle)
        {
            if (VariableManager.ScoreCounter < 10000)
            {
                winText.SetActive(false);
                VariableManager.GuiScoreObj.GetComponent<Text>().text = Convert.ToString(VariableManager.ScoreCounter);
            }
            else if (VariableManager.ScoreCounter >= 10000)
            {
                GameObject[] gameobj = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < gameobj.Length; i++)
                {
                    Destroy(gameobj[i]);
                }

                winText.GetComponent<Text>().text = "You won!\nMerry Christmas, " + VariableManager.UserName + "." +
                    "\n Press R to restart or press M to return to menu!";
                winText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    VariableManager.EnemyKilledCounter = 0;
                    VariableManager.ShouldReset = true;

                    player.transform.position = new Vector3(-0.2003954f, -4.365619f, 0);

                    VariableManager.ScoreCounter = 0;
                }
                else if (Input.GetKeyDown(KeyCode.M))
                {
                    Application.LoadLevel(0);
                }
            }
        }
        else
        {
            winText.SetActive(false);
            VariableManager.GuiScoreObj.GetComponent<Text>().text = Convert.ToString(VariableManager.ScoreCounter);

            if (Input.GetKeyDown(KeyCode.M))
            {
                Application.LoadLevel(0);
            }
        }
    }

    private void spawnSnow()
    {
        if (VariableManager.ScoreCounter >= 10000)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(snow,
                    new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y, 0),
                    Quaternion.identity);
            }
        }
    }
}
