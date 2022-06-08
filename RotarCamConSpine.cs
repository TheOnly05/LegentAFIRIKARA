using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego
{
    public class RotarCamConSpine : MonoBehaviour
    {
        public Transform conCam;

         
        void FixedUpdate()
        {
            transform.rotation = conCam.rotation;
        }
    }
}
