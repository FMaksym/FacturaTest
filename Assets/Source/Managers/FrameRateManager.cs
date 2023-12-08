using System.Collections;
using System.Threading;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    [SerializeField] private int MaxRate = 9999;
    [SerializeField] private float TargetFrameRate = 60.0f;
    [SerializeField] private float currentFrameTime;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxRate;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine(nameof(WaitForNextFrame));
    }

    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / TargetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
}
