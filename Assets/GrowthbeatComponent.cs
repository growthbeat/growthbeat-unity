using UnityEngine;
using System.Collections;

public class GrowthbeatComponent : MonoBehaviour {
	
	void Awake () {
		Growthbeat.GetInstance().Initialize("OrUq6yu3KsZ1MjJ7", "saWAVZs5f531VXk3ZVgJZwK1vQUzPg23");
		Growthbeat.GetInstance().Start();
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}
}
