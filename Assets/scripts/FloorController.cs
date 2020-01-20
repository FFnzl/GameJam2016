using UnityEngine;
using System.Collections;
using System.Text;

public class FloorController : MonoBehaviour
{

	void Start()
	{

		FloorComponents controller = GameObject.FindGameObjectWithTag("FloorManager").GetComponent<FloorComponents>();
		Room room = GetComponent<Room>();

		string randPattern = controller.RandomPattern;

		string[] pattern = randPattern.Split(',');

		for (int i = 0; i < pattern.Length; i++)
		{
			GameObject o = Instantiate(controller.FloorPrefab) as GameObject;
			o.transform.parent = transform;
			o.transform.localPosition = new Vector3((((i % 10) - 5) * 0.1f) + 0.05f, (((i / 10) - 5) * -0.1f) - 0.05f);
			o.transform.localScale = new Vector3(1, 1);
			o.GetComponent<SpriteRenderer>().sprite = controller.Floors[int.Parse(pattern[i])];

			room.tiles.Add(o);
		}
	}
}
