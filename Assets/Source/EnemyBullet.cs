using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerAudio");
        Vector3 temp = new Vector3(0, -0.09f, 0);
        gameObject.transform.position += temp;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall2":
                Destroy(gameObject);
                break;
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
