using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Control_Jugador : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking, bwalking;
	public Transform playerTrans;

	public UnityEvent activarBate;

	public bool isLlave = false;
	
	
	void FixedUpdate(){
		
    
       if (walking || bwalking)
        {
            // Si walking es verdadero, mueve hacia adelante; si bwalking es verdadero, mueve hacia atrás
            float speed = walking ? -w_speed : wb_speed;
            playerRigid.velocity = transform.forward * speed * Time.deltaTime;
        }
        else
        {
            playerRigid.velocity = Vector3.zero; // Restablecer la velocidad a cero si no está caminando
        }
    
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
			playerAnim.SetTrigger("Andar");
			playerAnim.ResetTrigger("Idle");
			walking = true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.ResetTrigger("Andar");
			playerAnim.SetTrigger("Idle");
			walking = false;
			//steps1.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			playerAnim.SetTrigger("Atras");
			playerAnim.ResetTrigger("Idle");
            bwalking=true;
			//steps1.SetActive(true);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			playerAnim.ResetTrigger("Atras");
			playerAnim.SetTrigger("Idle");
            bwalking = false;
			//steps1.SetActive(false);
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKeyDown(KeyCode.E)){
			playerAnim.SetTrigger("Atacar");
			SoundManager.PlaySound(SoundType.BATE);
		}
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				//steps1.SetActive(false);
				//steps2.SetActive(true);
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("Correr");
				playerAnim.ResetTrigger("Andar");
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				//steps1.SetActive(true);
				//steps2.SetActive(false);
				w_speed = olw_speed;
				playerAnim.ResetTrigger("Correr");
				playerAnim.SetTrigger("Andar");
			}
		}
	}
}
