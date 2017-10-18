using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    private GameObject enemy;

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemyAudio");
        Vector3 temp = new Vector3(0, 0.09f, 0);
        gameObject.transform.position += temp;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                enemy.GetComponent<AudioSource>().Play();
                VariableManager.EnemyKilledCounter++;
                VariableManager.ScoreCounter += 50;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }
    }
}
