using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour {
	
	public GameObject carveNavmesh;
	public Animator anim;
	public float leaveDistance;
	
	private float swnum;
	public float pubswnum;
	public Animator tutorial;
	
	public Text scoreText;
	int score;
	
	Transform player;
	
	void Start(){
	}

	void Update(){
		if(anim.GetBool("Open") && Vector3.Distance(transform.position, player.position) > leaveDistance){
			anim.SetBool("Open", false);
			
			StartCoroutine(LeftCircle());
		}
		swnum = PlayerPrefs.GetFloat("swnum");
	}
	
	public void OnTriggerEnter(Collider other){
    
        PlayerPrefs.SetFloat("swnum", pubswnum);
        Invoke("swi", 0.5f);
		if(!other.gameObject.CompareTag("Player"))
			return;
		
		carveNavmesh.SetActive(true);
		anim.SetBool("Open", true);
		
		player = other.gameObject.transform;
		player.GetComponent<PlayerController>().SwitchSafeState(true);
		
		AddPoints();
	}
	public void swi()
	{
		if(swnum == 0)
        {
           SceneManager.LoadScene("Game scene 1"); 
        }
        if(swnum == 1)
        {
           SceneManager.LoadScene("Game scene 2"); 
        }
        if(swnum == 2)
        {
           SceneManager.LoadScene("Game scene"); 
        }
        if(swnum == 3)
        {
           SceneManager.LoadScene("Game scene 3"); 
        }
        if(swnum == 4)
        {
           SceneManager.LoadScene("Game scene 4"); 
        }
        if(swnum == 5)
        {
           SceneManager.LoadScene("Game scene 5"); 
        }
        if(swnum == 6)
        {
           SceneManager.LoadScene("Game scene 8"); 
        }
        if(swnum == 7)
        {
           SceneManager.LoadScene("Game scene 9"); 
        }
        if(swnum == 8)
        {
           SceneManager.LoadScene("Game scene 10"); 
        }
        if(swnum == 9)
        {
           SceneManager.LoadScene("Game scene 11"); 
        }
        if(swnum == 10)
        {
           SceneManager.LoadScene("Game scene 12"); 
        }
        if(swnum == 11)
        {
           SceneManager.LoadScene("Game scene 6"); 
        }
        if(swnum == 12)
        {
           SceneManager.LoadScene("Game scene 7"); 
        }
        if(swnum == 13)
        {
           SceneManager.LoadScene("Game scene 13"); 
        }
        if(swnum == 14)
        {
           SceneManager.LoadScene("Game scene 14"); 
        }
        if(swnum == 15)
        {
           SceneManager.LoadScene("Game scene 15"); 
        }
        if(swnum == 16)
        {
           SceneManager.LoadScene("Game scene 16"); 
        }
        if(swnum == 17)
        {
           SceneManager.LoadScene("Game scene 17"); 
        }
	}
	void AddPoints(){
		if(!scoreText.gameObject.activeSelf)
			scoreText.gameObject.SetActive(true);
		
		score++;
		scoreText.text = "" + score;
	}
	
	public int GetScore(){
		return score;
	}
	
	IEnumerator LeftCircle(){		
		if(!tutorial.GetBool("Invisible"))
			tutorial.SetBool("Invisible", true);
	
		yield return new WaitForSeconds(0.5f);
		
		carveNavmesh.SetActive(false);
		player.GetComponent<PlayerController>().SwitchSafeState(false);
	}
}
