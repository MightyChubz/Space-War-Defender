using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemysInRows;
    public GameObject[] spawnPoints;
    public GameObject enemyBulletPrefab;
    public float[] rangeInSeconds;

    [HideInInspector]
    public static GameObject[] spawnedObjects;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        spawnedObjects = new GameObject[spawnPoints.Length];
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (VariableManager.ShouldReset)
        {
            StartCoroutine(delayEnemySpawn(1));
            VariableManager.ShouldReset = false;
        }
    }

    private IEnumerator delayEnemySpawn(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int row = (i > 5) ? 1 : 0;
            spawnedObjects[i] = Instantiate(enemysInRows[row],
                spawnPoints[i].transform.position,
                Quaternion.identity) as GameObject;
        }
    }
}
