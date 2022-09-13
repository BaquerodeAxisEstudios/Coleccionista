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

    public AudioClip audioClipFail;
    public void KillPlayer()
    {
        //Control de audio
        Guardian[] guardianes = FindObjectsOfType<Guardian>();
        foreach (Guardian item in guardianes)
        {
            item.Callar();
        }
        AudioSource.PlayClipAtPoint(audioClipFail, Vector3.zero, .8f);
        
        Time.timeScale = 0;
        for (int i = 0; i < paneles.Count; i++)
        {
            paneles[i].SetActive(false);
        }
        panelKill.SetActive(true);
        recordScoreTxt.gameObject.SetActive(false);

        int score = ScoreManager.instance.GetScore();
        endScoreTxt.text = "Puntaje: " + score.ToString();
        
        if (PlayerPrefs.GetInt("MaxScore",0) <= score)
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }

        if (PlayerPrefs.GetInt("MaxScore", 0) == 0) 
            return;
        recordScoreTxt.text = "Mejor puntaje: " + PlayerPrefs.GetInt("MaxScore", 0).ToString();
        recordScoreTxt.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void GoHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
