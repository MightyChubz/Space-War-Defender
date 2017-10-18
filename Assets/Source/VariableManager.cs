using UnityEngine;
using System.Collections;

public class VariableManager : MonoBehaviour
{
    private static int EnemyKilled = 0;
    private static bool Reset = true;

    private static int BulletSpawned = 0;
    private static bool SpawnBullet = true;

    private static int PlayerShot = 0;
    private static bool RespawnPlayer = false;
    private static bool PlayerDead = false;

    private static int Score = 0;
    private static GameObject GuiScore;
    private static string UserNameString;
    private static bool ScoreCap = true;

    private static int Won = 0;
    private static bool StartSpawningSnow = false;

    private static bool windows = true;

    public static int EnemyKilledCounter
    {
        get
        {
            return EnemyKilled;
        }

        set
        {
            EnemyKilled = value;
        }
    }

    public static bool ShouldReset
    {
        get
        {
            return Reset;
        }

        set
        {
            Reset = value;
        }
    }

    public static int BulletSpawnedCounter
    {
        get
        {
            return BulletSpawned;
        }

        set
        {
            BulletSpawned = value;
        }
    }

    public static bool ShouldSpawnBullet
    {
        get
        {
            return SpawnBullet;
        }

        set
        {
            SpawnBullet = value;
        }
    }

    public static int PlayerShotCounter
    {
        get
        {
            return PlayerShot;
        }

        set
        {
            PlayerShot = value;
        }
    }

    public static bool ShouldRespawnPlayer
    {
        get
        {
            return RespawnPlayer;
        }

        set
        {
            RespawnPlayer = value;
        }
    }

    public static bool IsPlayerDead
    {
        get
        {
            return PlayerDead;
        }

        set
        {
            PlayerDead = value;
        }
    }

    public static int ScoreCounter
    {
        get
        {
            return Score;
        }

        set
        {
            Score = value;
        }
    }

    public static GameObject GuiScoreObj
    {
        get
        {
            return GuiScore;
        }

        set
        {
            GuiScore = value;
        }
    }

    public static string UserName
    {
        get
        {
            return UserNameString;
        }

        set
        {
            UserNameString = value;
        }
    }

    public static int WonCounter
    {
        get
        {
            return Won;
        }

        set
        {
            Won = value;
        }
    }

    public static bool ShouldSpawnSnow
    {
        get
        {
            return StartSpawningSnow;
        }

        set
        {
            StartSpawningSnow = value;
        }
    }

    public static bool IsWindows
    {
        get
        {
            return windows;
        }

        set
        {
            windows = value;
        }
    }

    public static bool ScoreCapToggle
    {
        get
        {
            return ScoreCap;
        }

        set
        {
            ScoreCap = value;
        }
    }
}
