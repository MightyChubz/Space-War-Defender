using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerPosition;

    [HideInInspector]
    public GameObject prefab;

    private Vector3 world;
    private Vector3 worldWidth;
    private float halfSize;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        worldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        world = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        halfSize = playerPosition.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        // Input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 temp = new Vector3(-0.08f, 0, 0);
            playerPosition.position += temp;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 temp = new Vector3(0.08f, 0, 0);
            playerPosition.position += temp;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab,
                new Vector3(playerPosition.position.x, playerPosition.position.y + 1, 0),
                playerPosition.rotation);
        }

        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.Alpha4))
        {
            Application.LoadLevel(3);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VariableManager.BulletSpawnedCounter = 0;
            VariableManager.ShouldSpawnBullet = true;
            VariableManager.EnemyKilledCounter = 0;
            VariableManager.ScoreCounter = 0;
            VariableManager.ShouldReset = true;
            Application.LoadLevel(0);
        }

        // Collision
        if (playerPosition.position.x < (world.x + halfSize))
        {
            Vector3 temp = new Vector3(0.08f, 0, 0);
            playerPosition.position += temp;
        }

        if (playerPosition.position.x > (worldWidth.x - halfSize))
        {
            Vector3 temp = new Vector3(-0.08f, 0, 0);
            playerPosition.position += temp;
        }

        // Variable handling
        if (VariableManager.EnemyKilledCounter > 11)
        {
            VariableManager.EnemyKilledCounter = 0;
            VariableManager.ScoreCounter += 500;
            VariableManager.ShouldReset = true;
        }

        // Debug
        //Debug.Log(VariableManager.GetEnemyKilledVariable());
    }
}
