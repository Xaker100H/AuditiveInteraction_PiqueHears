using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Audio;
using Random = System.Random;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject botonPlay, botonExit, botonDuelo, botonIndividual, botonModoNormal, botonModoClash;

    public int menu;

    public static bool puedoHablar;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;

    // Start is called before the first frame update
    void Start()
    {
        menu = 1;

        wordToAction = new Dictionary<string, Action>();

        wordToAction.Add("Jugar", DecirJugar);
        wordToAction.Add("Play", DecirJugar);
        wordToAction.Add("Individual", DecirIndividual);
        wordToAction.Add("Modoindividual", DecirIndividual);   
        wordToAction.Add("Duelo", DecirDuelo);
        wordToAction.Add("Mododuelo", DecirDuelo);
        wordToAction.Add("Normal", DecirNormal);
        wordToAction.Add("Modonormal", DecirNormal);
        wordToAction.Add("Clash", DecirClash);
        wordToAction.Add("Modoclash", DecirClash);
        wordToAction.Add("Atras", DecirAtras);
        wordToAction.Add("Salir", DecirSalir);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += wordRecogniced;
        keywordRecognizer.Start();

        puedoHablar = true;
    }

    private void wordRecogniced(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (menu == 1)
        {
            botonPlay.SetActive(true);
            botonExit.SetActive(true);
            botonDuelo.SetActive(false);
            botonIndividual.SetActive(false);
            botonModoNormal.SetActive(false);
            botonModoClash.SetActive(false);

            FindObjectOfType<audioManager>().stop("ModosPrincipales");
            FindObjectOfType<audioManager>().stop("ModosSecundarios");

            if (puedoHablar)
            {
                puedoHablar = false;
                FindObjectOfType<audioManager>().play("InicioJuego");
            }
        }

        if (menu == 2)
        {
            botonPlay.SetActive(false);
            botonExit.SetActive(false);
            botonDuelo.SetActive(true);
            botonIndividual.SetActive(true);
            botonModoNormal.SetActive(false);
            botonModoClash.SetActive(false);

            FindObjectOfType<audioManager>().stop("InicioJuego");
            FindObjectOfType<audioManager>().stop("ModosSecundarios");
            
            if (puedoHablar)
            {
                puedoHablar = false;
                FindObjectOfType<audioManager>().play("ModosPrincipales");
            }
        }

        if (menu == 3)
        {
            botonPlay.SetActive(false);
            botonExit.SetActive(false);
            botonDuelo.SetActive(false);
            botonIndividual.SetActive(false);
            botonModoNormal.SetActive(true);
            botonModoClash.SetActive(true);

            FindObjectOfType<audioManager>().stop("InicioJuego");
            FindObjectOfType<audioManager>().stop("ModosPrincipales");

            if (puedoHablar)
            {
                puedoHablar = false;
                FindObjectOfType<audioManager>().play("ModosSecundarios");
            }
        }

        if (menu == 1 && Input.GetMouseButtonDown(2))
        {
            Exit();
        }
        if (menu == 2 && Input.GetMouseButtonDown(1))
        {
            jugarDuelo();
        }
        if (menu == 3 && Input.GetMouseButtonDown(1))
        {
            jugarModoNormal();
        }
        if (menu == 3 && Input.GetMouseButtonDown(2))
        {
            jugarModoClash();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu --;
        }
        if (menu == 1 && Input.GetMouseButtonDown(1))
        {
            Play();
        }
        if (menu == 2 && Input.GetMouseButtonDown(2))
        {
            jugarIndividual();
        }
    }

    public void Play()
    {
        menu = 2;
    }

    public void Exit()
    {
        Application.Quit();
       
    }

    public void jugarIndividual()
    {
        menu = 3;
        puedoHablar = true;
    }

    public void jugarDuelo()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoTurnos");
    }

    public void jugarModoNormal()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoSerie");
    }

    public void jugarModoClash()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoSerieClash");
    }

    public void DecirJugar()
    {
        menu = 2;
        puedoHablar = true;
    }

    public void DecirIndividual()
    {
        menu = 3;
        puedoHablar = true;
    }

    public void DecirDuelo()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoTurnos");
    }

    public void DecirNormal()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoSerie");
    }

    public void DecirClash()
    {
        FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");
        SceneManager.LoadScene("JuegoSerieClash");
    }

    public void DecirSalir()
    {
        Application.Quit();
    }

    public void DecirAtras()
    {
        menu--;
        puedoHablar = true;
    }
}
