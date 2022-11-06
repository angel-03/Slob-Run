using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //for spawning at spawnPoints
    public Transform[] spawnPoints;
    public GameObject[] SawPrefabs; //array cuz many types of SawPrefabs
    public GameObject CoinPrefab;
    public GameObject GemPrefab;

    float spawnIntervalSaw = 5f;
    float spawnIntervalCoin = 7f;
    float spawnIntervalGem = 10.3f;

    private float overTimeSaw = 0.5f;
    private float overTimeCoin = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnSawAtSpawnPoint(spawnIntervalSaw, overTimeSaw));
        StartCoroutine(spawnCoinAtSpawnPoint(spawnIntervalCoin, overTimeCoin));  
        StartCoroutine(spawnGemAtSpawnPoint(spawnIntervalGem)); 
    }

     //spawn Points
    private IEnumerator spawnSawAtSpawnPoint(float spawnIntervalSaw , float overTimeSaw)
    {
        yield return new WaitForSeconds(spawnIntervalSaw);
        int randomSaw = Random.Range(0,SawPrefabs.Length);
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);
        Instantiate(SawPrefabs[randomSaw], spawnPoints[randomSpawnPoint].position, transform.rotation);
        if(spawnIntervalSaw<2)
        {
            spawnIntervalSaw = 2;
            StartCoroutine(spawnSawAtSpawnPoint(spawnIntervalSaw,overTimeSaw));
        }
        else
        {
            StartCoroutine(spawnSawAtSpawnPoint((spawnIntervalSaw - overTimeSaw),overTimeSaw));
        }
    }

    private IEnumerator spawnCoinAtSpawnPoint(float spawnIntervalCoin,float overTimeCoin)
    {
        yield return new WaitForSeconds(spawnIntervalCoin);
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);
        Instantiate(CoinPrefab, spawnPoints[randomSpawnPoint].position, transform.rotation);
        if(spawnIntervalCoin<3)
        {
            spawnIntervalCoin = 3f;
            StartCoroutine(spawnCoinAtSpawnPoint(spawnIntervalCoin,overTimeCoin));
        }
        else
        {
            StartCoroutine(spawnCoinAtSpawnPoint((spawnIntervalCoin - overTimeCoin),overTimeCoin));
        }
    }

    private IEnumerator spawnGemAtSpawnPoint(float spawnIntervalGem)
    {
        yield return new WaitForSeconds(spawnIntervalGem);
        int randomSpawnPoint = Random.Range(0,spawnPoints.Length);
        Instantiate(GemPrefab, spawnPoints[randomSpawnPoint].position, transform.rotation);
        StartCoroutine(spawnGemAtSpawnPoint(spawnIntervalGem));
    }
}