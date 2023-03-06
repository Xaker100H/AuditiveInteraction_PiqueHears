using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevaCarta : MonoBehaviour
{
    public static int Carta;
    // Start is called before the first frame update
    void Start()
    {
       Carta= Random.Range(1, 6);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
