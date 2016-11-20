using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    public enum RoomType { TYPE_O, TYPE_I, TYPE_L, TYPE_T, TYPE_X }
    public RoomType type;

    public List<GameObject> doors;
    public List<GameObject> dust;
    public List<GameObject> tiles;

    public List<GameObject> mapIcons;

    public GameObject doneMapIcon;

    private bool done = false;
    private bool perfect = true;

    void Awake()
    {
        doors = new List<GameObject>();
        tiles = new List<GameObject>();
        dust = new List<GameObject>();
    }


    void Start()
    {
        FurnitureBehaviour[] f = GetComponentsInChildren<FurnitureBehaviour>();
        foreach(FurnitureBehaviour fe in f)
        {
            fe.ParentRoom = this;
        }
    }


    void Update()
    {
        if(!done)
        {
            float dustInPercent = 0f;

            foreach (GameObject d in dust)
            {
                if (d != null) dustInPercent += 1;
            }

            if (dust.Count == 0)
            {
                dustInPercent = 1;
            }
            else dustInPercent /= dust.Count;
            tiles.ForEach((x) => {
                SpriteRenderer sr = x.GetComponent<SpriteRenderer>();
                sr.color = Color.HSVToRGB(0, 0, ((1f - dustInPercent) * 0.5f) + 0.5f);
            });
            mapIcons.ForEach((x) =>
            {
                SpriteRenderer sr = x.GetComponent<SpriteRenderer>();
                Color c = sr.color;
                sr.color = new Color(dustInPercent, (1f - dustInPercent), 0f);
            });

            if (dustInPercent == 0)
            {
                done = true;
                GameObject o = Instantiate(doneMapIcon, transform.position, Quaternion.identity) as GameObject;
                if (perfect) doneMapIcon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);

                Stats s = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
                s.roomsCleared++;
                s.numberPerfect += perfect ? 1 : 0;
            }
        }
        
    }

    public void StuffSmashed()
    {
        perfect = false;
    }

}
