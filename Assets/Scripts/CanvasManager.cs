using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public GameObject imagePress;
    public Text scoreTxt;

    //todo: mejorar sistema de paneles, este es muy basico pero funcional
    public List<GameObject> paneles;
    
    private void Start()
    {
        instance = this;
        imagePress.SetActive(false);
        panelKill.SetActive(false);
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

    public GameObject panelKill;
    public Text endScoreTxt, recordScoreTxt;
    public void KillPlayer()
    {
        for (int i = 0; i < paneles.Count; i++)
        {
            paneles[i].SetActive(false);
        }
        panelKill.SetActive(true);
        recordScoreTxt.gameObject.SetActive(false);

        int score = ScoreManager.instance.GetScore();
        endScoreTxt.text = "Puntaje: " + score.ToString();
        
        if (PlayerPrefs.GetInt("Score",0) < score)
        {
            recordScoreTxt.gameObject.SetActive(true);
            recordScoreTxt.text = "Mejor puntaje: " + PlayerPrefs.GetInt("Score", 0).ToString();
            PlayerPrefs.SetInt("Score", score);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
