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

public class GameManager4 : MonoBehaviour
{

    public GameObject textoEscucha, textoRepite, textoPerdiste;

    public int turnoGeneral;
    public static bool corrutina1Activa, corrutina2Activa, corrutina3Activa, corrutina4Activa, hasPerdido;

    public static int accionesRestantes, accionesActuales,sonidosRestantes;

    public TextMeshProUGUI scoreText;


    
    public int[] infiniteList;

    public float tiempoEscucha, tiempoAdivinar;
    public List<int> listaInts = new List<int>();

    public List<int> listaAdivinar = new List<int>();

    public int numeroLista, valorLista;
    public static int score;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;

    // Start is called before the first frame update
    void Start()
    {
        /*FindObjectOfType<audioManager>().stop("InicioJuego");
        FindObjectOfType<audioManager>().stop("ModosPrincipales");
        FindObjectOfType<audioManager>().stop("ModosSecundarios");*/
        
        turnoGeneral = 1;

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

        wordToAction.Add("Lanzarrocas", DecirLanzarrocas);
        wordToAction.Add("Elanzarrocas", DecirLanzarrocas);
        wordToAction.Add("Bouler", DecirLanzarrocas);
        wordToAction.Add("Elbouler", DecirLanzarrocas);
        wordToAction.Add("Bolero", DecirLanzarrocas);
        wordToAction.Add("Elbolero", DecirLanzarrocas);
        wordToAction.Add("Brujamadre", DecirBrujaMadre);
        wordToAction.Add("Labrujamadre", DecirBrujaMadre);   
        wordToAction.Add("Gigantenoble", DecirGiganteNoble);
        wordToAction.Add("Elgigantenoble", DecirGiganteNoble);
        wordToAction.Add("Ibai", DecirGiganteNoble);
        wordToAction.Add("Elibai", DecirGiganteNoble);
        wordToAction.Add("Golemelixir", DecirGolemElixir);
        wordToAction.Add("Golemdelixir", DecirGolemElixir);
        wordToAction.Add("Elgolemdelixir", DecirGolemElixir);
        wordToAction.Add("Montapuercos", DecirMontapuercos);
        wordToAction.Add("Elmontapuercos", DecirMontapuercos);
        wordToAction.Add("Jograider", DecirMontapuercos);
        wordToAction.Add("Eljograider", DecirMontapuercos);
        wordToAction.Add("Valquiria", DecirValquiria);
        wordToAction.Add("Lavalquiria", DecirValquiria);
        wordToAction.Add("Carlosma", DecirLanzarrocas);
        wordToAction.Add("Carlos", DecirLanzarrocas);
        wordToAction.Add("Carlosgonzalez", DecirLanzarrocas);
        wordToAction.Add("Isabel", DecirBrujaMadre);
        wordToAction.Add("Isabelfernandez", DecirBrujaMadre);   
        wordToAction.Add("Javigra", DecirGiganteNoble);
        wordToAction.Add("Javi", DecirGiganteNoble);
        wordToAction.Add("Juanpe", DecirGolemElixir);
        wordToAction.Add("Juanperalta", DecirGolemElixir);
        wordToAction.Add("Peralta", DecirGolemElixir);
        wordToAction.Add("Joseluis", DecirMontapuercos);
        wordToAction.Add("Rocio", DecirValquiria);
        wordToAction.Add("Rociogra", DecirValquiria);
        wordToAction.Add("Salir", DecirSalir);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += wordRecogniced;
        keywordRecognizer.Start();

        valorLista = 0;
        tiempoEscucha = 0f;
        tiempoAdivinar = 0f;
        score = -1;
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
        //int numero = Random.Range(1,7);
        //Debug.Log("numero = " + numero);

        if (!hasPerdido)
        {
        if (turnoGeneral == 1 && corrutina1Activa == false)
        {
            corrutina1Activa = true;
            corrutina2Activa = false;
            StartCoroutine("turno1");
        }
        if (turnoGeneral == 2 && corrutina2Activa == false)
        {
            corrutina2Activa = true;
            corrutina1Activa = false;
            StartCoroutine("turno2");
        }

        if (accionesRestantes == 0)
        {
            accionesActuales ++;
            accionesRestantes = accionesActuales;
            turnoGeneral ++;
            if (turnoGeneral > 2)
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


        scoreText.text = ("¡HAS PERDIDO! Score: " + score.ToString());
    }

    IEnumerator turno1()
    {
        score++;
        sonidosRestantes = accionesActuales;
        FindObjectOfType<audioManager>().play("Escucha");
        textoEscucha.SetActive(true);
        yield return new WaitForSeconds(2f);
        textoEscucha.SetActive(false);
        masSonidos();
        listasInf();
        tiempoEscucha += 3f;
        yield return new WaitForSeconds(tiempoEscucha);
        accionesRestantes = 0;

    }

    IEnumerator turno2()
    {
       
        accionesActuales --;
        listaAdivinar.Clear();
        FindObjectOfType<audioManager>().play("Adivina");
        textoRepite.SetActive(true);
        yield return new WaitForSeconds(1f);
        textoRepite.SetActive(false);
        TurnoDecirCosas();
        tiempoAdivinar += 3.5f;
        float check = 1f;
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
                    FindObjectOfType<audioManager>().play("Lanzarrocas");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 2:
            Debug.Log("funciona2");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("BrujaMadre");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 3:
            Debug.Log("funciona3");
                    //Debug.Log("i =" + i);
                    //Invoke("audioCampana", 2.3f);
                    FindObjectOfType<audioManager>().play("GiganteNoble");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 4:
            Debug.Log("funciona4");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("GolemElixir");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

                case 5:
                    Debug.Log("funciona5");
                    //Debug.Log("i ="+i);
                    FindObjectOfType<audioManager>().play("Montapuercos");
                    yield return new WaitForSeconds(3f);
                    //StartCoroutine("tiempoSonido");
                    //listaInts.RemoveAt(valorLista);
                    break;

            case 6:
            Debug.Log("funciona6");
                    //Debug.Log("i =" + i);
                    FindObjectOfType<audioManager>().play("Valquiria");
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
                //listaInts.Clear();
                break;
            }

        }
    }


    public void masSonidos()
    {
        for (int i = 0; i < accionesActuales; i++)
        {
        numeroLista = UnityEngine.Random.Range(1,7);
        listaInts.Add(numeroLista);
        //Debug.Log("i=" + i);
        }
    }

    public void DecirLanzarrocas()
    {
        numeroLista = 1;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirBrujaMadre()
    {
        numeroLista = 2;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirGiganteNoble()
    {
        numeroLista = 3;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirGolemElixir()
    {
        numeroLista = 4;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirMontapuercos()
    {
        numeroLista = 5;
        listaAdivinar.Add(numeroLista);
    }

    public void DecirValquiria()
    {
        numeroLista = 6;
        listaAdivinar.Add(numeroLista);
    }

        public void DecirSalir()
    {
        SceneManager.LoadScene("MenuPrincipal");
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
