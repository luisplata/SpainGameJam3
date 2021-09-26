using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject creditos;
    public GameObject menu;
    // Start is called before the first frame update    
    public void onClickJugar(){
        SceneManager.LoadScene("PrincipalScene_wood_fnal");
    }
    public void onClickCreditos(){
        creditos.SetActive(true);
        menu.SetActive(false);
    }

    public void onClickQuit(){
        Application.Quit();
    }
    public void onClickAtras(){
        creditos.SetActive(false);
        menu.SetActive(true);

    }
}
