using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScriptControllerPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ControladorDeFinalEnvioDePostComienzoDeVideo controlador;
    [SerializeField] private AplicationHUD hud;
    public void QuitarPlayuerControll()
    {
        player.ShutDown();
        hud.StopAll();
    }

    public void StartVideoCinematicaFinal()
    {
        controlador.GuardarIntento();
    }
}
