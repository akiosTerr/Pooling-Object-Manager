using UnityEngine;
using System.Collections;

public class move_projetil : MonoBehaviour {
	
	private Rigidbody RbLIGHT;
	public float velocity;
	public ForceMode force_mode;
	public float gravityValue;
	public float time_to_destroy;
	
	private Light light_comp;
	private ParticleSystem particle_comp;
	public GameObject explosion;
	
	private int choice;
	private Color main_color;
	
	
	void Awake() 
	{
		RbLIGHT = GetComponent<Rigidbody> ();
		light_comp = GetComponent<Light> ();
		particle_comp = GetComponent<ParticleSystem> ();
	}
	
	void OnEnable() 
	{
		Invoke ("destroy",time_to_destroy);
		
		choice = Random.Range (1, 7);
		
		if(choice == 1)
			main_color = Color.white;
		else if(choice == 2)
			main_color = Color.red;
		else if(choice == 3)
			main_color = Color.green;
		else if(choice == 4)
			main_color = Color.yellow;
		else if(choice == 5)
			main_color = Color.blue;
		else if(choice == 6)
			main_color = Color.magenta;
		
		light_comp.color = main_color;
		particle_comp.startColor = main_color;
	}
	
	void destroy () 
	{
		gameObject.SetActive (false);
	}
	
	void OnDisable()
	{
		RbLIGHT.velocity = Vector3.zero;
		CancelInvoke ();
	}
	
	void FixedUpdate () 
	{
		RbLIGHT.AddRelativeForce (Vector3.forward * velocity, force_mode);
		RbLIGHT.AddForce (Physics.gravity*gravityValue);
	}
	
}
