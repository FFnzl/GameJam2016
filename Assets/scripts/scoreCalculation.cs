﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCalculation : MonoBehaviour {

    [SerializeField] Text perfectScoreTxt;
    [SerializeField] Text timeScoreTxt;
    [SerializeField] Text roomsTxt;
    [SerializeField] Text endScoreTxt;
    GameObject stats;

    private int perfects;
    private int clearedRooms;
    private int totalRooms;
    private int restTime;
    private int junk;

    // Use this for initialization
    void Start () {
        stats = GameObject.FindGameObjectWithTag("Stats");
        Stats s = stats.GetComponent<Stats>();

        restTime = s.restTime;
        totalRooms = s.totalRooms;
        clearedRooms = s.roomsCleared;
        perfects = s.numberPerfect;
        junk = s.junkCollected;
                
        timeScoreTxt.text = restTime.ToString();
        roomsTxt.text = "\n" + clearedRooms.ToString() + " of " + totalRooms.ToString();
        perfectScoreTxt.text = "\n\n" + perfects.ToString() + " of " + clearedRooms.ToString();

        endScoreTxt.text = calc().ToString();
		Destroy(s.gameObject);
	}

    private int calc()
    {
        int result;

        result =
            restTime * 100 +
            clearedRooms * 1000 +
            perfects * 1000 +
            junk * 5;

        if (totalRooms == clearedRooms) result += 5000;

        return result;
    }

}