using UnityEngine;
using System.Collections;

public class EnemyMovementManager : MonoBehaviour
{
    private static float speed = -0.050f;
    private static float addJump = 0;

    private float jump = 0;

    public static float SpeedCounter
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public static float AddJumpCounter
    {
        get
        {
            return addJump;
        }

        set
        {
            addJump = value;
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update()
    {
        if (!VariableManager.ShouldReset)
        {
            for (int i = 0; i < EnemySpawnManager.spawnedObjects.Length; i++)
            {
                if (EnemySpawnManager.spawnedObjects[i] != null)
                {
                    Vector3 temp = new Vector3(speed, jump + addJump, 0);
                    EnemySpawnManager.spawnedObjects[i].transform.position += temp;
                }
            }
        }
        addJump = 0;
    }
}
