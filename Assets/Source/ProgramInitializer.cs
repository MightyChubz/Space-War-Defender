using UnityEngine;
using System.Collections;

public class ProgramInitializer : MonoBehaviour
{
    public int targetFrameRate;
    public int vSyncCount;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = vSyncCount;
    }
}
