using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miJuego
{
    public class IKhandlerUIButttons : MonoBehaviour
    {
        public Transform leftHandPOS; public Transform rightHandPOS; public Transform leftElbowPOS; public Transform rightElbowPOS;
        public float leftHand; public float rigtHand; public float leftElbow; public float rightElbow;

        public bool isApuntar;

        Animator anima;

        // Start is called before the first frame update
        void Start()
        {
            anima = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnAnimatorIK()
        {
            if (isApuntar)
            {
                //MANO IZQ
                anima.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHand);
                anima.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPOS.position);

                //MANO DER
                anima.SetIKPositionWeight(AvatarIKGoal.RightHand, rigtHand);
                anima.SetIKPosition(AvatarIKGoal.RightHand, rightHandPOS.position);
                
                Debug.Log("AQUI ESTOY APUNTANDO");

            }
            
        }
    }
}
