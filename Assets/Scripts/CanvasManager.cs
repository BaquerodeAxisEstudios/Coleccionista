using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public GameObject imagePress;

    public Text scoreTxt;
    private void Start()
    {
        instance = this;
        imagePress.SetActive(false);
    }
    public void ShowPress()
    {
        imagePress.SetActive(true);
    }
    public void DontShowPress() { imagePress.SetActive(false); }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

}
