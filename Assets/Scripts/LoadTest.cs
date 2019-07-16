﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTest : MonoBehaviour {

    public GameObject loadPanel;
    public Slider loadBar;
    public Text charge;

    private AsyncOperation asyn;

    private void Start()
    {
        loadBar.value = 0f;
    }

    public void ClickCarga()
    {
        loadPanel.SetActive(true);
        StartCoroutine(LoadSlider("Camara"));
    }

    IEnumerator LoadSlider(string scene)
    {
        asyn = Application.LoadLevelAsync("Camara");

        while(!asyn.isDone)
        {
            loadBar.value = asyn.progress * 100;
            charge.text = loadBar.value.ToString() + "%";
            yield return null;
        }
    }
}
