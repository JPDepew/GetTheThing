using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int numberOfObjects;

    public static Data Instance
    {
        get;
        set;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Player.onObjectCaptured += OnObjectCaptured;
    }

    private void OnDestroy()
    {
        Player.onObjectCaptured -= OnObjectCaptured;
    }

    void OnObjectCaptured()
    {
        numberOfObjects++;
    }
}
