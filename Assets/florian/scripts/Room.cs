using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    public enum RoomType { TYPE_O, TYPE_I, TYPE_L, TYPE_T, TYPE_X }
    public RoomType type;

    public List<GameObject> doors;
    public List<GameObject> dust;
    public List<GameObject> tiles;

    void Awake()
    {
        doors = new List<GameObject>();
        tiles = new List<GameObject>();
        dust = new List<GameObject>();
    }

    void Update()
    {
        float dustInPercent = 0f;

        foreach(GameObject d in dust)
        {
            if (d != null) dustInPercent += 1;
        }

        if (dust.Count == 0)
        {
            dustInPercent = 1;
        } else dustInPercent /= dust.Count;
        tiles.ForEach((x) => {
            SpriteRenderer sr = x.GetComponent<SpriteRenderer>();
            sr.color = Color.HSVToRGB(0, 0, ((1f - dustInPercent) * 0.5f) + 0.5f);
        });
    }
    
}
