using UnityEngine;
using System.Collections;
using System;

public class EnemyShootRandom : MonoBehaviour
{
    public GameObject bullet;
    public int[] randomRangeSelector;

    private float randomRange;

    private static int randomEnemy;
    private static GameObject[] gameObj;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        randomEnemy = UnityEngine.Random.Range(0, 12);
        randomRange = UnityEngine.Random.Range(randomRangeSelector[0], randomRangeSelector[1]);
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (VariableManager.ShouldReset == false)
        {
            gameObj = GameObject.FindGameObjectsWithTag("Enemy");
            randomEnemy = UnityEngine.Random.Range(0, gameObj.Length);

            if (gameObj.Length != 0)
            {
                if (VariableManager.ShouldSpawnBullet)
                {
                    StartCoroutine(delayShoot(randomRange));
                    VariableManager.ShouldSpawnBullet = false;
                }

                if (VariableManager.BulletSpawnedCounter > 0)
                {
                    VariableManager.BulletSpawnedCounter = 0;
                    VariableManager.ShouldSpawnBullet = true;
                }
            }
        }
    }

    private IEnumerator delayShoot(float randomRange)
    {
        yield return new WaitForSeconds(randomRange);

        randomRange = UnityEngine.Random.Range(randomRangeSelector[0], randomRangeSelector[1]);

        for (int i = 0; i < gameObj.Length; i++)
        {
            if (gameObj[i] != null)
            {
                Instantiate(bullet,
                    new Vector3(gameObj[randomEnemy = UnityEngine.Random.Range(0, gameObj.Length)].transform.position.x,
                    gameObj[randomEnemy].transform.position.y - 0.1f, 0),
                    Quaternion.identity);
                break;
            }
        }

        VariableManager.BulletSpawnedCounter++;
    }
}
