using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Audio;



public class GameController : MonoBehaviour
{
    public static Animator anim;
    public AudioMixer sonidosPrincipales;
    public GameObject menu;

    public GameObject musica;
    public GameObject creditos;
    bool escape = true;
    public GameObject canvas;
    public Slider barraSonido;


    // Start is called before the first frame update 

    public void OnMenu()
    {
        if (escape)
        {
            Time.timeScale = 0f;
            escape = !escape;
            canvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            escape = !escape;
            canvas.SetActive(false);
        }

    }
    public void setAudio()
    {
        sonidosPrincipales.SetFloat("MyExposedParam", Mathf.Log10(barraSonido.value) * 20);
    }
    void Start()
    {
        anim = GetComponent<Animator>();


    }
    void Update()
    {

    }
    public void Jugar()
    {
        anim.SetFloat("play", 2f);
    }
    public void jugarPausa()
    {
        Time.timeScale = 1f;
        escape = !escape;
        canvas.SetActive(false);
    }
    public void salirPausa()
    {
        Application.Quit();
    }

    public void onClickJugar()
    {
        SceneManager.LoadScene("intro_1");
    }

    public void Omitir()
    {
        SceneManager.LoadScene(2);
    }
    public void onClickSalir()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void onClickCreditos()
    {

        anim.SetFloat("opciones", 2f);
        // creditos.SetActive(true);
        //menu.SetActive(false);
    }

    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickSonido()
    {
        menu.SetActive(false);
        musica.SetActive(true);
    }

    public void onClickBotonAtras()
    {
        menu.SetActive(true);
        musica.SetActive(false);
    }


    public void onClickAtras()
    {
        anim.SetFloat("opciones", 0f);
    }

}
