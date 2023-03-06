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

public class GameManager2 : MonoBehaviour
{

    public GameObject panelEleccion, textoAtaquePlayer1, textoDefensaPlayer2, textoAtaquePlayer2, textoDefensaPlayer1, textoEscucha, textoAdivina, textoAccionesRestantes, textoPerdiste;

    public int turnoGeneral;
    public static bool ataquePlayer1, defensaPlayer2, ataquePlayer2, defensaPlayer1, hasPerdido;
    public static bool corrutina1Activa, corrutina2Activa, corrutina3Activa, corrutina4Activa;

    public static int accionesRestantes, accionesActuales,sonidosRestantes;

    public TextMeshProUGUI accionesRestantesText;


  
    
    public int[] infiniteList;

    public float tiempoEscucha;
    public float tiempoAdivinar;
    public List<int> listaInts = new List<int>();
    public List<int> listaAdivinar = new List<int>();


    public int numeroLista, valorLista;

    //Necesario para el diccionario de palabras
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;

    void Start()
    {
        /*FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");*/
        
        turnoGeneral = 1;

        ataquePlayer1 = true;
        defensaPlayer2 = false;
        ataquePlayer2 = false;
        defensaPlayer1 = false;

        corrutina1Activa = false;
        corrutina2Activa = false;
        corrutina3Activa = false;
        corrutina4Activa = false;
        hasPerdido = false;
        listaInts.Clear();
        accionesActuales = 1;
        accionesRestantes = 1;
        //infiniteList = new int[]{1, 2, 3, 4};
        wordToAction = new Dictionary<string, Action>();

        wordToAction.Add("Pajaro", DecirPajaro);
        wordToAction.Add("Unpajaro", DecirPajaro);
        wordToAction.Add("Pajaros", DecirPajaro);
        wordToAction.Add("Pajarito", DecirPajaro);
        wordToAction.Add("Pajaritos", DecirPajaro);
        wordToAction.Add("Pajarillo", DecirPajaro);
        wordToAction.Add("Pajarillos", DecirPajaro);
        wordToAction.Add("Coche", DecirCoche);
        wordToAction.Add("Uncoche", DecirCoche);
        wordToAction.Add("Coches", DecirCoche);
        wordToAction.Add("Motor", DecirCoche);
        wordToAction.Add("Unmotor", DecirCoche);   
        wordToAction.Add("Campana", DecirCampana);
        wordToAction.Add("Unacampana", DecirCampana);
        wordToAction.Add("Campanas", DecirCampana);
        wordToAction.Add("Unascampanas", DecirCampana);
        wordToAction.Add("Campanilla", DecirCampana);
        wordToAction.Add("Campanillas", DecirCampana);
        wordToAction.Add("Timbre", DecirCampana);
        wordToAction.Add("Untimbre", DecirCampana);
        wordToAction.Add("Trueno", DecirTrueno);
        wordToAction.Add("Untrueno", DecirTrueno);
        wordToAction.Add("Truenos", DecirTrueno);
        wordToAction.Add("Rayo", DecirTrueno);
        wordToAction.Add("Unrayo", DecirTrueno);
        wordToAction.Add("Rayos", DecirTrueno);
        wordToAction.Add("Tormenta", DecirTrueno);
        wordToAction.Add("Unatormenta", DecirTrueno);
        wordToAction.Add("Lluvia", DecirTrueno);
        wordToAction.Add("Unalluvia", DecirTrueno);
        wordToAction.Add("Gallo", DecirGallo);
        wordToAction.Add("Ungallo", DecirGallo);
        wordToAction.Add("Puerta", Decirpuerta);
        wordToAction.Add("Unapuerta", Decirpuerta);
        wordToAction.Add("Chirrido", Decirpuerta);
        wordToAction.Add("Unchirrido", Decirpuerta);
        wordToAction.Add("Rechino", Decirpuerta);
        wordToAction.Add("Unrechino", Decirpuerta);
        wordToAction.Add("salir", DecirSalir);
        wordToAction.Add("Algo", DecirAlgo);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += wordRecogniced;
        keywordRecognizer.Start();

        valorLista = 0;
        tiempoEscucha = 0f;
        tiempoAdivinar = 1f;
    }

    private void wordRecogniced(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
        FindObjectOfType<audioManager>().play("SiguientePal");
    }
    private void Acierto()
    {
        FindObjectOfType<audioManager>().play("Acierto"); 
    }

    public void listasInf()
    {
        StartCoroutine("tiempoSonido");
    }
      // Update is called once per frame
    void Update()
    {
        if (!hasPerdido)
        {
        if (turnoGeneral == 1 && corrutina1Activa == false)
        {
            corrutina1Activa = true;
            corrutina2Activa = false;
            ataquePlayer1 = true;
            defensaPlayer2 = false;
            ataquePlayer2 = false;
            defensaPlayer1 = false;
            StartCoroutine("turno1");
        }
        if (turnoGeneral == 2 && corrutina2Activa == false)
        {
            corrutina2Activa = true;
            corrutina3Activa = false;
            ataquePlayer1 = false;
            defensaPlayer2 = true;
            ataquePlayer2 = false;
            defensaPlayer1 = false;
            StartCoroutine("turno2");
        }
        if (turnoGeneral == 3 && corrutina3Activa == false)
        {
            corrutina3Activa = true;
            corrutina4Activa = false;
            ataquePlayer1 = false;
            defensaPlayer2 = false;
            ataquePlayer2 = true;
            defensaPlayer1 = false;
            StartCoroutine("turno3");
        }
        if (turnoGeneral == 4 && corrutina4Activa == false)
        {
            corrutina4Activa = true;
            corrutina1Activa = false;
            ataquePlayer1 = false;
            defensaPlayer2 = false;
            ataquePlayer2 = false;
            defensaPlayer1 = true;
            StartCoroutine("turno4");
        }

        if (accionesRestantes == 0)
        {
            if (ataquePlayer1 == false && ataquePlayer2 == false)
            {
                accionesActuales ++;
            }
            accionesRestantes = accionesActuales;
            turnoGeneral ++;
            if (turnoGeneral > 4)
            {
                turnoGeneral = 1;
            }
        }
        }
        if (hasPerdido)
        {
            textoPerdiste.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("MenuPrincipal");
            }
        }


        accionesRestantesText.text = ("Acciones Restantes: " + accionesRestantes.ToString());
    }

    IEnumerator turno1()
    {
        sonidosRestantes = accionesActuales;
        panelEleccion.SetActive(true);
        textoAtaquePlayer1.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoAtaquePlayer1.SetActive(false);

    }

    IEnumerator turno2()
    {
       
        panelEleccion.SetActive(false);
        textoDefensaPlayer2.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoDefensaPlayer2.SetActive(false);
        FindObjectOfType<audioManager>().play("Escucha");
        textoEscucha.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoEscucha.SetActive(false);
        listasInf();
        tiempoEscucha += 3f;
        tiempoAdivinar += 3.5f;
        float check = 1f;
        yield return new WaitForSeconds(tiempoEscucha);
        listaAdivinar.Clear();
        FindObjectOfType<audioManager>().play("Adivina");
        textoAdivina.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoAdivina.SetActive(false);
        TurnoDecirCosas();
        yield return new WaitForSeconds(tiempoAdivinar);
        chek();
        yield return new WaitForSeconds(check);
        accionesRestantes = 0;
        listaInts.Clear();
        listaAdivinar.Clear();

    }

    IEnumerator turno3()
    {
        sonidosRestantes = accionesActuales;
        panelEleccion.SetActive(true);
        textoAtaquePlayer2.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoAtaquePlayer2.SetActive(false);
    }

    IEnumerator turno4()
    {
      
        panelEleccion.SetActive(false);
        textoDefensaPlayer1.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoDefensaPlayer1.SetActive(false);
        FindObjectOfType<audioManager>().play("Escucha");
        textoEscucha.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoEscucha.SetActive(false);
        listasInf();
        tiempoEscucha += 3f;
        tiempoAdivinar += 3.5f;
        float check = 1f;
        yield return new WaitForSeconds(tiempoEscucha);
        listaAdivinar.Clear();
        FindObjectOfType<audioManager>().play("Adivina");
        textoAdivina.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoAdivina.SetActive(false);
        TurnoDecirCosas();
        yield return new WaitForSeconds(tiempoAdivinar);
        chek();
        yield return new WaitForSeconds(check);
        accionesRestantes = 0;
        listaInts.Clear();
        listaAdivinar.Clear();
    }

    IEnumerator tiempoSonido()
    {
       //bool hacerbreak = false;
        for (int i = 0; i < accionesActuales; i++ )
        {  Debug.Log("Sonidos=" + sonidosRestantes);
            sonidosRestantes--;
            //listaInts.TrimExcess();

            Debug.Log("i =" + i);
            //listaInts.Add(Random.Range(1, 6));
            //listaInts.Add(numeroLista);
            switch (listaInts[i])
             {
            case 1:
            Debug.Log("funciona1");
                    //Debug.Log("i =" + i);
                    //Invoke("audioPajaro", 2.3f);
                    FindObjectOfType<audioManager>().play("Pajaro");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 2:
            Debug.Log("funciona2");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("Coche");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 3:
            Debug.Log("funciona3");
                    //Debug.Log("i =" + i);
                    //Invoke("audioCampana", 2.3f);
                    FindObjectOfType<audioManager>().play("Campana");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 4:
            Debug.Log("funciona4");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("Trueno");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

                case 5:
                    Debug.Log("funciona5");
                    //Debug.Log("i ="+i);
                    FindObjectOfType<audioManager>().play("Gallo");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 6:
            Debug.Log("funciona6");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("Puerta");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;
                default:
                    Debug.Log("default");
                    listaInts.Clear();
                    //hacerbreak = true;
                    break;
            }

            if (sonidosRestantes == 0)
            {
              //  listaInts.Clear();
                break;
            }

        }
    }

    public void elegirSonido()
    {
        accionesRestantes -= 1;
    }
    public void Pajaro()
    {
        numeroLista = 1;
       listaInts.Add(numeroLista);
       
    }  
    public void DecirPajaro()
    {
        numeroLista = 1;
        listaAdivinar.Add(numeroLista);
    }

    public void Coche()
    {
        numeroLista = 2;
        listaInts.Add(numeroLista);
      
    }   
    public void DecirCoche()
    {
        numeroLista = 2;
        listaAdivinar.Add(numeroLista);
    }

    public void Campana()
    {
        numeroLista = 3;
        listaInts.Add(numeroLista);
    }   
    public void DecirCampana()
    {
        numeroLista = 3;
        listaAdivinar.Add(numeroLista);
    }

    public void Trueno()
    {
        numeroLista = 4;
       listaInts.Add(numeroLista);

    }  
    public void DecirTrueno()
    {
        numeroLista = 4;

        listaAdivinar.Add(numeroLista);
    }

    public void Gallo()
    {
        numeroLista = 5;
        listaInts.Add(numeroLista);
    }  
    public void DecirGallo()
    {
        numeroLista = 5;
        listaAdivinar.Add(numeroLista);
    }

    public void puerta()
    {
        numeroLista = 6;
       listaInts.Add(numeroLista);
    }    
    public void Decirpuerta()
    {
        numeroLista = 6;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirSalir()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void DecirAlgo()
    {
        FindObjectOfType<audioManager>().play("Algo");
    }
    public void TurnoDecirCosas()
    {
        
        keywordRecognizer.Start();
      
    }

    public void chek()
    {
        int ultimaPalabraAdiv = listaAdivinar.Count -1;
        int ultimaPalabraEsc = listaInts.Count -1;
        for (int i = 0; i < accionesActuales; i++)
        {
            //Debug.Log("count adiv=" + listaAdivinar.Count);
            //Debug.Log("count int=" + listaInts.Count);
            //Debug.Log("listaInts=" + listaInts[i]);
            //Debug.Log("listaAdivinar=" + listaAdivinar[i]);
            if (listaAdivinar.Count == accionesActuales)
            {
            if (listaAdivinar[i] != listaInts[i])
            {
                Debug.Log("perdiste");
                hasPerdido = true;
                break;
            }
            if (listaAdivinar[i] == listaInts[i])
            {
                Debug.Log("ganaste");
                if (listaAdivinar[ultimaPalabraAdiv] == listaInts[ultimaPalabraEsc])
                {
                FindObjectOfType<audioManager>().play("AciertoDef");
                }
            }
            }
            else
            {
                Debug.Log("perdiste");
                FindObjectOfType<audioManager>().play("Perdiste");
                hasPerdido = true;
                break;
            }
        }
    }
}
