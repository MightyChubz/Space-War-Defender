using UnityEngine;
using System.Collections;
using System;

public class PlayerDead : MonoBehaviour
{
    public GameObject player;
    public GameObject diedText;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        diedText.SetActive(false);
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (VariableManager.PlayerShotCounter > 0)
        {
            VariableManager.ShouldRespawnPlayer = true;
            VariableManager.PlayerShotCounter = 0;
        }

        if (VariableManager.IsPlayerDead)
        {
            diedText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                VariableManager.EnemyKilledCounter = 0;
                VariableManager.ShouldReset = true;

                VariableManager.IsPlayerDead = false;
                StartCoroutine(respawnPlayer(1));
                diedText.SetActive(false);
                VariableManager.ShouldRespawnPlayer = false;
            }

            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemy.Length; i++)
            {
                Destroy(enemy[i]);
            }
        }
    }

    private IEnumerator respawnPlayer(int wait)
    {
        yield return new WaitForSeconds(wait);

        Instantiate(player, new Vector3(-0.2003954f, -4.365619f, 0), Quaternion.identity);
    }
}
