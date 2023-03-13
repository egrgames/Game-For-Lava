using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
   public Joystick joystick;
   public CharacterController controller;
   public Animator anim;
   public Image bulletIndicator;
   public Transform targetIndicator;
   public Transform target;
   public ParticleSystem movementEffect;
   public ParticleSystem shootingEffect;
   public AudioSource audioSource;

   private float darknum;
   public float speed;
   public float gravity;
   public float bulletCount;
   public float reloadSpeed;
   private float darknumm;
   
   Vector3 moveDirection;
   float bullets = 1f;

	public bool isItRunning;
   
   List<GameObject> bulletStorage = new List<GameObject>();
   
   [HideInInspector]
   public bool safe;
   
   
   void Start(){
	   darknum = 0f;
	   PlayerPrefs.SetFloat("darknum", darknum);
   }
   void OnCollisionEnter(Collision collision)
    {   
		
        if(collision.gameObject.name == "Rock Type1 02 (1)")
        {
           anim.SetTrigger("hit"); 
        }
	}
   void OnTriggerEnter(Collider other)
    {	
		
    }
   void Update(){
	   darknumm = PlayerPrefs.GetFloat("darknum");
	   
	   Vector2 direction = joystick.direction;
	   
	   if(controller.isGrounded){
            moveDirection = new Vector3(direction.x, 0, direction.y);
			
			Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
			transform.rotation = targetRotation;
	
            moveDirection = moveDirection * speed;
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
		
		bulletIndicator.fillAmount = bullets;
		
		if(anim.GetBool("Run") != (direction != Vector2.zero)){
			anim.SetBool("Run", direction != Vector2.zero);
			
			if(direction != Vector2.zero){
				movementEffect.Play();
				audioSource.Play();
				isItRunning = true;
	   			PlayerPrefs.SetFloat("darknum", darknum);
			}
			else{
				movementEffect.Stop();
				audioSource.Stop();
				isItRunning = false;
			}
		}
		
		if(!safe){
			Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
			Quaternion targetIndicatorRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
			targetIndicator.rotation = Quaternion.Slerp(targetIndicator.rotation, targetIndicatorRotation, Time.deltaTime * 50);
		}	
   }
   
   
	public void SwitchSafeState(bool safe){
	   this.safe = safe;
	   
	   targetIndicator.gameObject.SetActive(!safe);
	}

	public void ChangeTarget(Transform NewTarget)
	{
		target = NewTarget;
	}
}
