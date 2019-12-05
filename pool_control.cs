using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool_control : MonoBehaviour {

	public static pool_control instance;

	public int pool_size;


	public GameObject[] prefabs; 
	public static Transform parent;
	public static List<prefab_pool> pool_instance;


	public class prefab_pool {
		public List<GameObject> pool;
		public string id = "---";
		public int size;

		public prefab_pool (GameObject obj, int pool_size){
			pool = new List<GameObject>();
			for(int i = 0; i < pool_size; i++)
			{
				GameObject prefab = Instantiate(obj,parent);
				prefab.SetActive(false);
				pool.Add(prefab);
			}
		}

		public GameObject get_free_obj(){
			foreach(GameObject obj in pool){
				if(!obj.activeInHierarchy)
				{
					return obj;
				}
			}
			Debug.LogError("no free object found");
			return null;
		}
	}

	void Awake () {
		instance = this;
		pool_instance = new List<prefab_pool>();
		parent = GameObject.FindGameObjectWithTag("pool_parent").transform;

		foreach(GameObject go in prefabs){
			prefab_pool pool = new prefab_pool(go,pool_size);
			pool.id = go.name;
			pool_instance.Add(pool);
		}
		foreach(prefab_pool pol in pool_instance){
			print(pol.id);
		}
	}

	public GameObject get_prefab(string id){
		foreach(prefab_pool pool in pool_instance){
			if(pool.id == id){
				return pool.get_free_obj();
			}
		}
		Debug.LogError("id not found");
		return null;
	}
}
