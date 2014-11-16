using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class asset_manager : MonoBehaviour {

	//static instance to accsess the script
	public static asset_manager current;

	//prefabs
	public GameObject fireWorks_GO;
	public GameObject move_light1_GO;
	public GameObject move_light2_GO;

	//class instances
	public poole_obj moveLight_1;
	public poole_obj moveLight_2;
	public poole_obj fireworks;

	//can the list grow the amount of prefabs if needed? (you can also do code to limit how much can grow)
	public bool Can_Expand;

	void Awake ()
	{
		current = this;
	}


	public class poole_obj
	{
		public List<GameObject> obj_list;

		public poole_obj (GameObject GO,int start_amount) 
		{
			obj_list = new List<GameObject> ();

			for (int i = 0; i < start_amount; i++) 
			{
				GameObject temp_obj = (GameObject)Instantiate(GO);
				temp_obj.SetActive(false);
				obj_list.Add(temp_obj);
			}
		}
	}

	//inicialize your objects in start (or awake).
	//as first argument put the prefab you want to instantiate.
	//as second argument put how many objects you will instantiate at first to be always ready to use(it can grow if needed if you enable "Can_Expand")
	void Start () 
	{
		moveLight_1 = new poole_obj (move_light1_GO, 5);
		moveLight_2 = new poole_obj (move_light2_GO, 5);
		fireworks = new poole_obj (fireWorks_GO,5);
	}


	//methods to accsess the object from outside the script, each method returns a diferent object.
	//to put a new object you have to mount a instance of "poole_obj" class on start, then make the same method pattern below whith the instance
	public GameObject Get_moveLight1 ()
	{
		for (int i = 0; i < moveLight_1.obj_list.Count; i++) 
		{
			if(!moveLight_1.obj_list[i].activeInHierarchy)
			{
				return moveLight_1.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(move_light1_GO);
			moveLight_1.obj_list.Add(extra_obj);
			return extra_obj;
		}

		return null;
	}
	public GameObject Get_moveLight2 ()
	{
		for (int i = 0; i < moveLight_2.obj_list.Count; i++) 
		{
			if(!moveLight_2.obj_list[i].activeInHierarchy)
			{
				return moveLight_2.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(move_light2_GO);
			moveLight_2.obj_list.Add(extra_obj);
			return extra_obj;
		}
		
		return null;
	}


	public GameObject Get_fireworks ()
	{
		for (int i = 0; i < fireworks.obj_list.Count; i++) 
		{
			if(!fireworks.obj_list[i].activeInHierarchy)
			{
				return moveLight_1.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(fireWorks_GO);
			fireworks.obj_list.Add(extra_obj);
			return extra_obj;
		}
		
		return null;
	}
}
