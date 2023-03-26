using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
	public GameObject Mob;
	GameObject Obj;
	GameObject Player;

	void Start()
	{
		Player = GameObject.Find("Player");
	}
	public void Dead()
	{
		Obj = (GameObject)Instantiate(Mob, this.transform.position, Quaternion.identity);
		Obj.transform.parent = Player.transform;
	}
}
