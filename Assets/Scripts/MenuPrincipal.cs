using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    public HighScores scores;

    public GameObject puntuaciones;
    public GameObject final;
    public GameObject inputField;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if(GuardarTiempo.tiempo >= 0)
        {
            final.SetActive(true);
        }
    }

    public void IniciarJuego() 
    {
        SceneManager.LoadScene(1);
    } 

    public void AbrirPunto()
    {
        puntuaciones.SetActive(true);
    }

    public void CerrarPunto()
    {
        puntuaciones.SetActive(false);
    }

    public void CerrarTodo()
    {
        Application.Quit();
        Debug.Log("Cerras");
    }

    public void GuardarTotal()
    {
        scores.AddNewScore(inputField.GetComponent<TMP_InputField>().text, GuardarTiempo.tiempo);
        XMLManager.instance.SaveScores(scores.scores); 
        final.SetActive(false);
        GuardarTiempo.tiempo = -1;
    }
}
