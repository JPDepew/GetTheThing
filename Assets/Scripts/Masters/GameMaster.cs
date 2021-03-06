﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text timer;
    public GameObject[] pickups;

    AudioSource[] audioSources;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 30;
        timer.text = time.ToString("F0");
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(Timer());
        StartCoroutine(TurnTextRedTimer());
        StartCoroutine(InstantiateObjects());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    time -= Time.deltaTime;
    //    timer.text = time.ToString("F2");
    //}

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
            timer.text = time.ToString("F0");
        }
    }

    IEnumerator TurnTextRedTimer()
    {
        yield return new WaitForSeconds(27.25f);
        timer.color = Color.red;
        audioSources[0].Play();
        yield return new WaitForSeconds(1);
        audioSources[0].Play();
        yield return new WaitForSeconds(1);
        audioSources[0].Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }

    IEnumerator InstantiateObjects()
    {
        while (true)
        {
            int index = Random.Range(0, pickups.Length - 1);
            float xPos = Random.Range(-6.5f, 6.5f);
            float zPos = Random.Range(-4.3f, 3.5f);
            Vector3 position = new Vector3(xPos, 2, zPos);
            float xRotation = Random.Range(0, 360);
            float yRotation = Random.Range(0, 360);
            float zRotation = Random.Range(0, 360);
            Quaternion.Euler(xRotation,yRotation,zRotation);
            Instantiate(pickups[index], position, Quaternion.Euler(xRotation, yRotation, zRotation));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
