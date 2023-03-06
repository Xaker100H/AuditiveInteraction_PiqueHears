using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreText : MonoBehaviour
{

    public Text scoreFinalText;
    public TextMesh hola;

    private int scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        scoreFinalText.text = "Score = " + scoreNumber;
    }
}
