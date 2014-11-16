using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class asset_manager : MonoBehaviour {

	//static instance to accsess the script
	public static asset_manager current;

	//prefabs
	public GameObject fireWorks_GO;
	public GameObject projetil1_GO;
	public GameObject projetil2_GO;

	//class instances
	public poole_obj projetil1;
	public poole_obj projetil2;
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

		public poole_obj (GameObject g_obj,int start_amount) 
		{
			obj_list = new List<GameObject> ();

			for (int i = 0; i < start_amount; i++) 
			{
				var temp_obj = (GameObject)Instantiate(g_obj);
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
		projetil1 = new poole_obj (projetil1_GO,10);
		projetil2 = new poole_obj (projetil2_GO,10);
		fireworks = new poole_obj (fireWorks_GO,6);
	}


	//methods to accsess the object from outside the script, each method returns a diferent object.
	//to put a new object you have to mount a instance of "poole_obj" class on start, then make the same method pattern below whith the instance
	public GameObject Get_projetil1 ()
	{
		for (int i = 0; i < projetil1.obj_list.Count; i++) 
		{
			if(!projetil1.obj_list[i].activeInHierarchy)
			{
				print("succes projetil 1");
				return projetil1.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(projetil1_GO);
			projetil1.obj_list.Add(extra_obj);
			print("projetil 1 expanded");
			return extra_obj;
		}

		print ("projetil 1 send null");

		return null;
	}
	public GameObject Get_projetil2 ()
	{
		for (int i = 0; i < projetil2.obj_list.Count; i++) 
		{
			if(!projetil2.obj_list[i].activeInHierarchy)
			{
				print("succes projetil 2");
				return projetil2.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(projetil2_GO);
			projetil2.obj_list.Add(extra_obj);
			print("projetil 2 expanded");
			return extra_obj;
		}

		print("projetil 2 send null");
		return null;
	}


	public GameObject Get_fireworks ()
	{
		for (int i = 0; i < fireworks.obj_list.Count; i++) 
		{
			if(!fireworks.obj_list[i].activeInHierarchy)
			{
				return fireworks.obj_list[i];
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
