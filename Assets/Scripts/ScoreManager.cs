using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int coin;
    public Text scoreText;
    public Text lifeText;
    Scene_Manager sceneManagement;
    bool check;

    void Start()
    {
        score=0;
        coin=0;
    }
    // Update is called once per frame
    void Update()
    {
        lifeText.text = coin.ToString();
        scoreText.text = score.ToString();
    }

    public static void ScoreSet(int value)
    {
        score += value;
    }
}
