using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace miJuego
{
    public class ButtonMovementScripts : MonoBehaviour
    {
        Transform th05;
        Animator anims;
        CharacterController cp;

        Vector3 altura;
        public float gravedad = -9.8f;
        public LayerMask suelMask;

        public GameObject botonUP; public GameObject botonCROUCH;

        bool movForward; bool movBackward; bool movLeft; bool movRight;bool isGrounded;public bool isJump; bool isCrouch; bool crouch;
        public float velDelande = 0.09f; public float velLados = 0.02f; public float fuerSalto = 2f; public float crouchHeighPos = -2f; public float crouchCenterPos =- 2f;

        void Start()
        {
            th05 = this.transform;
            anims = GetComponentInChildren<Animator>();
            cp = GetComponent<CharacterController>();

            botonUP.gameObject.SetActive(false);
 
        }

        public void OnPointerDownForward()
        {
            movForward = true;
            anims.SetBool("isForward", movForward);
            
        }
        public void OnPointerUpForward()
        {
            movForward = false;
            anims.SetBool("isForward", false);
        }
        public void OnPointerDownBackward()
        {
            movBackward = true;
            anims.SetBool("isBackward", movBackward);
        }
        public void OnPointerUpBackward()
        {
            movBackward = false;
            anims.SetBool("isBackward", false);
        }
        public void OnPointerDownLeft()
        {
            movLeft = true;
            anims.SetBool("isLeft", movLeft);
        }
        public void OnPointerUpLeft()
        {
            movLeft = false;
            anims.SetBool("isLeft", false);
        }
        public void OnPointerDownRight()
        {
            movRight = true;
            anims.SetBool("isRight", movRight);
        }
        public void OnPointerUpRight()
        {
            movRight = false;
            anims.SetBool("isRight", false);
        }
        public void OnPointerDownCrouch()
        {
            isCrouch = true;
            anims.SetBool("isCrouching", isCrouch);
            botonCROUCH.gameObject.SetActive(false);
            botonUP.gameObject.SetActive(true);
        }
        public void OnPointerUpCrouch()
        {
            isCrouch = false;
            anims.SetBool("isCrouching", false);

            botonCROUCH.gameObject.SetActive(true);
            botonUP.gameObject.SetActive(false);
        }
        public void OnPointerDownSaltar()
        {
            isJump = true;
            anims.SetBool("isGround", isJump);
        }
        public void OnPointerUpSaltar()
        {
            isJump = false;
            anims.SetBool("isGround", false);
        }
        private void Update()
        {
            RaycastHit sHIT;
            isGrounded = Physics.Raycast(this.th05.position, -this.th05.up, out sHIT, suelMask);

            if (isGrounded)
            {
                print(sHIT.collider.gameObject.tag);
            }
        }
        void FixedUpdate()
        { 
            altura.y += gravedad * Time.deltaTime;

            cp.Move(altura * Time.deltaTime);

            if (isGrounded && altura.y < 0 ) { altura.y = 0f; }

            if (isGrounded)
            {
                if (isCrouch ){ Agachar(); }

            } 
           

            if (movForward)
            {
                MoverDelante();
            }
            if (movBackward)
            {
                MoverDetras();
            }
            if (movLeft)
            {
                MoverIzquierda();
            }
            if (movRight)
            {
                MoverDerecha();
            }

            if (isJump)
            {
                Saltar();
            }
        }

        void MoverDelante()
        {
            this.th05.Translate(0, 0, velDelande);
        }
        void MoverDetras()
        {
            this.th05.Translate(0, 0, -velDelande);
        }
        void MoverIzquierda()
        {
            this.th05.Translate(-velLados, 0, 0);
        }
        void MoverDerecha()
        {
            this.th05.Translate(velLados, 0, 0);
        }

        public void Saltar()
        {
            altura.y = Mathf.Sqrt(fuerSalto * -2f *  gravedad);
        }
        public void Agachar()
        {
            cp.center = cp.center + new Vector3 (0, crouchCenterPos / 2, 0);
            cp.height += crouchHeighPos/2;
              //isCrouch = false;
            anims.SetBool("isCrouching", isCrouch);
             
        }
        public void DePie()
        { 
            cp.center = cp.center;
            cp.height += crouchHeighPos;
            isCrouch = false;
            anims.SetBool("isCrouching", false);  
        }
    }
}
