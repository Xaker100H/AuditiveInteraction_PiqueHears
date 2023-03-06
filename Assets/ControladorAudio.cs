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
      
        wordToAction.Add("Bandida", A�aa);
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
        // Si es la �ltima palabra sonido de chicl�n y siquiente turno
        throw new NotImplementedException();
    }

    public void NoUltimaPalabra()
    {
        // si no es la �ltima palabra el programa tiene que seguir escuchando y comprobando las palabras dichas.
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

    private void A�aa()
    {   GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        FindObjectOfType<audioManager>().play("acierto");
      
     
    }
  
    public void Juego()
    {
          carta = NuevaCarta.Carta;
        switch (carta)
        {
           
            case 1:
                wordToAction.Add("MiniPeka", A�aa);
                break;
            case 2:
                wordToAction.Add("Bowler", A�aa);
                break;
            case 3:
                wordToAction.Add("MagoElectrico", A�aa);
                break;
            case 4:
                wordToAction.Add("Padilla", A�aa);
                wordToAction.Add("PadillaDeDuendes", A�aa);
                break;
            case 5:
                wordToAction.Add("MontaPuerco", A�aa);  
                wordToAction.Add("MontaPuercos", A�aa);
                wordToAction.Add("Puerco", A�aa);
                break;
            case 6:
                wordToAction.Add("Valkiria", A�aa);
                break;
        }
        
    }
    public void Turnos()
    {
        // primer turno, suena un audio de una carta si se pierde de va al jugador X a ganado si se acierta turno 2
        //turno 2, se guarda la palabra anterior y se suma otro sonido aleatoriamente.

    }
}
