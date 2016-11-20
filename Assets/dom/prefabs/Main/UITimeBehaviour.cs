﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class UITimeBehaviour : MonoBehaviour {

    private Text txt;
    [SerializeField] private float timeLimit;

    private Color startColor;
    private int startSize;
    private bool changing;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        startColor = txt.color;
        startSize = txt.fontSize;
	}
	
	// Update is called once per frame
	void Update () {
        timeLimit -= Time.deltaTime;
        txt.text = ((int)timeLimit).ToString();
        if(timeLimit <= 20)
        {
            if (timeLimit <= 10) showWarning(0.25f);
            else showWarning(0.5f);
        } else
        {
            txt.color = startColor;
            txt.fontSize = startSize;
        }
	}

    public void addPunish(int n)
    {
        timeLimit -= n;
    }

    private void showWarning(float d)
    {
        if (!changing)
        {
            changing = true;
            DOTween.To(() => txt.color, x => txt.color = x, Color.red, d).OnComplete(() =>
                 DOTween.To(() => txt.color, x => txt.color = x, Color.black, d));
            DOTween.To(() => txt.fontSize, x => txt.fontSize = x, startSize * 2, d).OnComplete(() =>
                 DOTween.To(() => txt.fontSize, x => txt.fontSize = x, startSize, d).OnComplete(() => changing = false));
        }
    }
}