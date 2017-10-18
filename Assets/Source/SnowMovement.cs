using UnityEngine;
using System.Collections;

public class SnowMovement : MonoBehaviour
{
    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        Vector3 temp = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, -0.09f), 0);
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
        }
    }
}
