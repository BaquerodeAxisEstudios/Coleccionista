using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    public Button jugar, salir;

    private void Start()
    {
        jugar.onClick.RemoveAllListeners();
        jugar.onClick.AddListener(Jugar);
        salir.onClick.RemoveAllListeners();
        salir.onClick.AddListener(Salir);
    }

    public void Salir() { Application.Quit(); }
    public void Jugar() { SceneManager.LoadScene(1); }
}
