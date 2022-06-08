using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego
{
    public class GunDefinitivoScripts : MonoBehaviour
    {
        public Transform croosHair;

        public Transform bulletPrefbs;
        public Transform ShootPoint;
        public float fireRate = 0.5f;
        public float nextTire = 0;

        public float rango = 10f;

        
        bool IsShowcrooshair = false;

        //public static GunDefinitivoScripts armaGun;

        //private void Awake()
        //{
        //    armaGun = this;
        //}

        private void Start()
        {
             croosHair = GetComponentInChildren<Canvas>().transform;
           //croosHair.gameObject.SetActive(false);
            //AL AJUSTAR EL JUEGO AL APUNTAR HA DE ACTIVARSE EL CROOSHAIR
            
        }
        //AÑADIR UN LOOK AT para que sirva de orientacion a la hora de apuntar 
        public void DispararBullet()
        {
            if (Time.deltaTime > nextTire)
            {
                nextTire = Time.deltaTime * fireRate;

                Instantiate(bulletPrefbs, ShootPoint.position, ShootPoint.rotation);
            }
        }
        public void ShowCroosHair()
        {
            IsShowcrooshair = !IsShowcrooshair;
            croosHair.gameObject.SetActive(true);
        }

        //public void OffCroosHair()
        //{
        //    IsShowcrooshair = !IsShowcrooshair;
        //    croosHair.gameObject.SetActive(false);
        //}
        //AÑADIDO DEL CODIGO ORIGINAL PARA ACTIVAR Y DESACTIVAR EL PUNTO DE MIRA

        private void FixedUpdate()
        {
            ShowCroosHair();
        }

        public void DrawCroosHair(Transform camara)
        {
            if (IsShowcrooshair)
            {
                ShowCroosHair();
            }
            Vector3 end = ShootPoint.position + ShootPoint.forward * rango;
            croosHair.position = Vector3.Lerp(end, camara.position, 0.9f);
            croosHair.rotation = camara.rotation;
        }
    }
}
