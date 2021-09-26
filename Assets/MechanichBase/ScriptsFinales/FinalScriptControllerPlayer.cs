using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScriptControllerPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ControladorDeFinalEnvioDePostComienzoDeVideo controlador;
    public void QuitarPlayuerControll()
    {
        player.ShutDown();
    }

    public void StartVideoCinematicaFinal()
    {
        controlador.GuardarIntento();
    }
}
