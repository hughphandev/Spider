using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D startZone;
    [SerializeField] private BoxCollider2D endZone;
    [SerializeField] private Spider[] spiderPrefabs;
    [SerializeField] private float maxDelay = 0.1f;

    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
        Debug.unityLogger.logEnabled = false;
        Application.targetFrameRate = 60;
#endif
    }

    public void StartSpawn(int count)
    {
        StartCoroutine(SpawnCoroutine(count));
    }

    IEnumerator SpawnCoroutine(int count)
    {
        Vector2 minStartPos = startZone.bounds.min;
        Vector2 maxStartPos = startZone.bounds.max;
        Vector2 minEndPos = endZone.bounds.min;
        Vector2 maxEndPos = endZone.bounds.max;

        for (int i = 0; i < count; ++i)
        {
            Vector2 startPos = new Vector2(Random.Range(minStartPos.x, maxStartPos.x), Random.Range(minStartPos.y, maxStartPos.y));
            Vector2 endPos = new Vector2(Random.Range(minEndPos.x, maxEndPos.x), Random.Range(minEndPos.y, maxEndPos.y));
            Spider spider = LeanPool.Spawn(spiderPrefabs[Random.Range(0, spiderPrefabs.Length)], startPos, Quaternion.identity);
            spider.MoveTo(endPos);
            yield return new WaitForSeconds(Random.Range(0.0f, maxDelay));
        }
    }
}
