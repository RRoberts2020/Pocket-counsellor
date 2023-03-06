using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{

	public GameObject platform;
	private float platformCount = 300f;
	public GameObject renderGameScreen;


	// Start is called before the first frame update
	void Start()
	{
		Vector3 spawnPos = new Vector3();

		for (int i = 0; i < platformCount; i++)
		{
			spawnPos.y += Random.Range(.5f, 2f);
			spawnPos.x = Random.Range(-4.5f, 4.5f);
			Instantiate(platform, spawnPos, Quaternion.identity);
			platform.transform.SetParent(renderGameScreen.transform);
			platform.transform.Rotate(0, 0, 0);
		}
	}

}
