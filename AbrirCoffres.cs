using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace miJuego
{
    public class AbrirCoffres : MonoBehaviour
    {
        public Canvas imgCof;

        void Start()
        {
            imgCof = GetComponentInChildren<Canvas>();
            imgCof.gameObject.SetActive(false);
        }
        
        void OnTriggerEnter(Collider cof)
        {
            if(cof.gameObject.tag == "THE05")
            {
                print("ABRIR COFRE");
                imgCof.gameObject.SetActive(true);
            }
            else
            {
                imgCof.gameObject.SetActive(false);
            }
            
        }
       
    }
}
