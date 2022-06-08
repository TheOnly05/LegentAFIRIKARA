using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego
{
    public class CogerArmaSueloApuntarYDisparar : MonoBehaviour
    {
        public Transform arma;
        bool tieneARMA;

        public GameObject pMira;
       

        // Start is called before the first frame update
        void Start()
        {
            //pMira.gameObject.SetActive(true);

        }
        void Update()
        {

        }
        private void FixedUpdate()
        {
            
        }
        public void RecogerARMA()
        {
            arma.gameObject.SetActive(true); 
            tieneARMA = true;
            //pMira.gameObject.SetActive(false);
           
        }
        private void OnTriggerEnter(Collider cola)
        {
            if (cola.gameObject.CompareTag("ARMA"))
            {
                RecogerARMA();
                Destroy(cola.gameObject);
               
            }
        }
    }
}
