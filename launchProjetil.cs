using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class launchProjetil : MonoBehaviour {

	public float delay_time;
	public float repeat_time;

	public enum ProjectilType{projetil1,projetil2,fireWorks};

	public ProjectilType projetil_Type;

	void Start () {
		InvokeRepeating ("launch", delay_time, repeat_time);
	}

	void launch () {

		GameObject obj = null;

		switch (projetil_Type) {

			case ProjectilType.projetil1:
				 obj = asset_manager.current.Get_projetil1 ();
				break;

			case ProjectilType.projetil2:
				 obj = asset_manager.current.Get_projetil2 ();
				break;

			case ProjectilType.fireWorks:
				obj = asset_manager.current.Get_fireworks (); 
				break;
		}

		 if(obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}
}
