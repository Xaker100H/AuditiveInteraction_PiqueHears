using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Audio;
using Random = System.Random;

public class ControladorAudio : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;
    public bool ultimaPalabra;
    // Start is called before the first frame update
    private int carta;
    void Start()
    {
        ultimaPalabra = false;
        wordToAction = new Dictionary<string, Action>();
      
        wordToAction.Add("Bandida", Añaa);
        wordToAction.Add("MontaPuercos", JojRaider);
        wordToAction.Add("Reina", folouDeCuin);
        wordToAction.Add("MagoElectrico", Electricityyy);
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += wordRecogniced;
        keywordRecognizer.Start();
    }

    private void wordRecogniced(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    public void Siguiente()
    {
        //if palabra no es la ultima, siguiente palabra,sonid0o de acierto
        if (ultimaPalabra == false )
        {
            NoUltimaPalabra();
        }
        else
        {
            SiUltimaPalabra();
        }
        //else PAlabra acertada, sonid0o de aciertoM, siquiente turno.
        throw new NotImplementedException();
    }

    private void SiUltimaPalabra()
    {
        // Si es la última palabra sonido de chiclín y siquiente turno
        throw new NotImplementedException();
    }

    public void NoUltimaPalabra()
    {
        // si no es la última palabra el programa tiene que seguir escuchando y comprobando las palabras dichas.
        throw new NotImplementedException();
    }
    private void Electricityyy()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
       
    }

    private void folouDeCuin()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void JojRaider()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    private void Piruriru()
    {
      transform.Translate(0,1,0);
    }

    private void Añaa()
    {   GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        FindObjectOfType<audioManager>().play("acierto");
      
     
    }
  
    public void Juego()
    {
          carta = NuevaCarta.Carta;
        switch (carta)
        {
           
            case 1:
                wordToAction.Add("MiniPeka", Añaa);
                break;
            case 2:
                wordToAction.Add("Bowler", Añaa);
                break;
            case 3:
                wordToAction.Add("MagoElectrico", Añaa);
                break;
            case 4:
                wordToAction.Add("Padilla", Añaa);
                wordToAction.Add("PadillaDeDuendes", Añaa);
                break;
            case 5:
                wordToAction.Add("MontaPuerco", Añaa);  
                wordToAction.Add("MontaPuercos", Añaa);
                wordToAction.Add("Puerco", Añaa);
                break;
            case 6:
                wordToAction.Add("Valkiria", Añaa);
                break;
        }
        
    }
    public void Turnos()
    {
        // primer turno, suena un audio de una carta si se pierde de va al jugador X a ganado si se acierta turno 2
        //turno 2, se guarda la palabra anterior y se suma otro sonido aleatoriamente.

    }
}
