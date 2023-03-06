using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public List<int> listaInts = new List<int>();
    public int contador;
    public int ValorLista;
    void Start()
    {
        listaInts.Add(1);
        listaInts.Add(2);
        listaInts.Add(3);
        listaInts.Add(4);
        listaInts.Add(5);
        listaInts.Add(6);

        ValorLista = -1;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ValorLista++;
            contador++;
            Debug.Log("contador=" + contador);
            Debug.Log("valorLista=" + ValorLista);
            Lista();
        } 
    }
    public void Lista()
    {
        
        for (int i = 0; i < contador; i++)
        {         
                   Debug.Log("hago el for =" + i);
                  //listaInts.Add(Random.Range(1, 6));
                    //listaInts.Add(numeroLista);
                    switch (listaInts[ValorLista])
                    {
                        case 1:
                            Debug.Log("funciona1");
                            Debug.Log("i =" + i);
                          //  FindObjectOfType<audioManager>().play(audio);
                            //listaInts.RemoveAt(i);
                            break;

                        case 2:
                            Debug.Log("funciona2");
                            Debug.Log("i =" + i);
                          //  FindObjectOfType<audioManager>().play("Coche");
                            //listaInts.RemoveAt(i);
                            break;

                        case 3:
                            Debug.Log("funciona3");
                            Debug.Log("i =" + i);
//FindObjectOfType<audioManager>().play("Campana");
                            //listaInts.RemoveAt(i);
                            break;

                        case 4:
                            Debug.Log("funciona4");
                            Debug.Log("i =" + i);
                           // FindObjectOfType<audioManager>().play("Trueno");
                            //listaInts.RemoveAt(i);
                            break;

                        case 5:
                            Debug.Log("funciona5");
                            Debug.Log("i =" + i);
                          //  FindObjectOfType<audioManager>().play("Gallo");
                            //listaInts.RemoveAt(i);
                            break;

                        case 6:
                            Debug.Log("funciona6");
                            Debug.Log("i =" + i);
                          //  FindObjectOfType<audioManager>().play("Puerta");
                            //listaInts.RemoveAt(i);
                            break;
                        
                        default:
                        Debug.Log("default");
                        break;
                      
                           
            }
        }
    }
}
