using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{

    [SerializeField]
    private Transform pointTransform;

    [SerializeField, Range(10u, 100u)]
    private uint resolution = 10;

    private Transform[] points;

    void Awake()
    {
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        for (int i = 0; i < points.Length; i++)
        {    
            Transform point = points[i] = Instantiate(pointTransform);
            position.x = (i + 0.5f) * step - 1;
            position.y = Mathf.Sin(Mathf.PI * position.x);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 position = points[i].localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            points[i].localPosition = position;
        }
    }

}
