using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static Animator anim;

    public GameObject creditos;
    public GameObject menu;
    // Start is called before the first frame update    

    void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void Jugar()
    {
        anim.SetFloat("play", 2f);
    }
    public void onClickJugar(){
       
        SceneManager.LoadScene("intro_1");
       
    }


    public void Omitir()
    {

      
        SceneManager.LoadScene("PrincipalScene_wood_fnal");
    }


    public void onClickCreditos(){

        anim.SetFloat("opciones", 2f);
       // creditos.SetActive(true);
        //menu.SetActive(false);
    }

    public void onClickQuit(){
        Application.Quit();
    }


    public void onClickAtras(){

        anim.SetFloat("opciones", 0f);
      
        //creditos.SetActive(false);
        // menu.SetActive(true);

    }


   

}
