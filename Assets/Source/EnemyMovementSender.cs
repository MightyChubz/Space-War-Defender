using UnityEngine;
using System.Collections;

public class EnemyMovementSender : MonoBehaviour
{
    private Vector3 world;
    private Vector3 worldWidth;
    private float halfSize;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        worldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        world = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        halfSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        // Collision
        if (gameObject.transform.position.x < (world.x + halfSize))
        {
            EnemyMovementManager.SpeedCounter = 0.050f;
            EnemyMovementManager.AddJumpCounter = -0.5f;
        }

        if (gameObject.transform.position.x > (worldWidth.x - halfSize))
        {
            EnemyMovementManager.SpeedCounter = -0.050f;
            EnemyMovementManager.AddJumpCounter = -0.5f;
        }
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerAudio");

        switch (collision.gameObject.tag)
        {
            case "Player":
                player.GetComponent<AudioSource>().Play();
                Destroy(collision.gameObject);
                VariableManager.ScoreCounter = 0;
                VariableManager.IsPlayerDead = true;
                VariableManager.PlayerShotCounter++;
                Destroy(gameObject);
                break;
        }
    }
}
