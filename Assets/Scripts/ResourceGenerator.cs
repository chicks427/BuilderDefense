using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;
    [SerializeField] private ResourceTypeSO resourceType;
    [SerializeField] private float rate;

    private void Awake()
    {
        timerMax = 1 / rate;
        timer = timerMax;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            ResourceManager.Instance.AddResource(resourceType, 1);
        }
    }
}
