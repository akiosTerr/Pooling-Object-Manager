using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class launchProjetil : MonoBehaviour {

	public Transform spawnPoint;

	public float delay_time;
	public float repeat_time;

	public enum ProjectilType{projetil1,projetil2,projetil3,fireWorks};

	public ProjectilType projetil_Type;

	void Start () {
		InvokeRepeating ("launch", delay_time, repeat_time);
	}

	void launch () {

		GameObject obj = null;

		switch (projetil_Type) {

			case ProjectilType.projetil1:
			obj = asset_manager.current.Get_projetil ("projetil1");
				break;

			case ProjectilType.projetil2:
				 obj = asset_manager.current.Get_projetil ("projetil2");
				break;

			case ProjectilType.fireWorks:
				obj = asset_manager.current.Get_projetil ("fireworks"); 
				break;

			case ProjectilType.projetil3:
				obj = asset_manager.current.Get_projetil ("projetil3");
				break;
		}

		 if(obj == null)
			return;

		obj.transform.position = spawnPoint.position;
		obj.transform.rotation = spawnPoint.rotation;
		obj.SetActive (true);
	}
}
