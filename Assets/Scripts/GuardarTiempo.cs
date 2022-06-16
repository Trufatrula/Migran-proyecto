using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarTiempo : MonoBehaviour
{
    public static int tiempo = -1;
    public Timer timer;
    public string menuP;

    public void Guardar()
    {
        if(timer.timeRemaining == -1){
            SceneManager.LoadScene(menuP);
        } else {
            tiempo = 300 - (int) timer.timeRemaining;
            SceneManager.LoadScene(menuP);
        }
    }
}
