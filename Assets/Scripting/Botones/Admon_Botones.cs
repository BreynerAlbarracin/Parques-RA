using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admon_Botones : MonoBehaviour
{
    /*------------------------------------------------------*/
    /* BOTONES DEL MENU PRINCIPAL */

    //Abre la escena Jugar
    public void BotonJugar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    //Abre la escena Opciones
    public void BotonOpciones()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    //Abre la escena Instrucciones
    public void BotonInstrucciones()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    /* FIN*/
    /*------------------------------------------------------*/

    /*------------------------------------------------------*/
    /*REGRESAR AL MENU*/

    //Boton de "INTRODUCCIÓN" regresar al menú pincipal
    public void BotonR_Intrucciones()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void BotonR_Jugar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    /* FIN*/
    /*------------------------------------------------------*/





    //Cierra  la aplicación
    public void BotonSalir()
    {
        UnityEngine.Application.Quit();
    }
}
