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
	public GameObject projetil3_GO;

	//class instances
	public poole_obj projetil1;
	public poole_obj projetil2;
	public poole_obj projetil3;
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
		projetil1 = new poole_obj (projetil1_GO,7);
		projetil2 = new poole_obj (projetil2_GO,6);
		projetil3 = new poole_obj (projetil3_GO,6);
		fireworks = new poole_obj (fireWorks_GO,3);
	}

	
	public GameObject Get_projetil (string projetil_name)
	{
		poole_obj proj_obj = null;

		if(projetil_name == "projetil1")
			proj_obj = projetil1;

		else if (projetil_name == "projetil2")
			proj_obj = projetil2;

		else if (projetil_name == "projetil3")
			proj_obj = projetil3;

		else if (projetil_name == "fireworks")
			proj_obj = fireworks;


		if (proj_obj == null) {
			Debug.LogError("wrong or inexistent projetil name"+ projetil_name);		
			return null;
		}

		print (proj_obj.ToString ());


		for (int i = 0; i < proj_obj.obj_list.Count; i++) 
		{
			if(!proj_obj.obj_list[i].activeInHierarchy)
			{
				return proj_obj.obj_list[i];
			}	
		}
		if (Can_Expand) 
		{
			GameObject extra_obj = (GameObject)Instantiate(projetil1_GO);
			proj_obj.obj_list.Add(extra_obj);
			print(projetil_name+" expanded");
			return extra_obj;
		}

		return null;
	}
}
