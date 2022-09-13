using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] int score;
    private void Start()
    {
        instance = this;
    }
    public void Amount(int cantidad)
    {
        score += cantidad;
        CanvasManager.instance.UpdateScore(score);
    } 
    public int GetScore() { return score; }
}
