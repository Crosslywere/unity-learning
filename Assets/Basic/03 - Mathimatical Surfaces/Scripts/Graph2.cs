using System;
using UnityEngine;

public class Graph2 : MonoBehaviour
{

    [SerializeField]
    private Transform pointTransform;

    [SerializeField, Range(10u, 100u)]
    private uint resolution = 10;

    [SerializeField]
    private FunctionLibrary.FunctionName function;

    private Transform[] points;

    void Awake()
    {
        points = new Transform[resolution * resolution];
        float step = 2f / resolution;
        // Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        for (int i = 0; i < points.Length; i++)
        {
            // if (x == resolution)
            // {
            //     x = 0;
            //     z++;
            // }
            Transform point = points[i] = Instantiate(pointTransform);
            // position.x = (x + 0.5f) * step - 1f;
			// position.z = (z + 0.5f) * step - 1f;
            // point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    void Update()
    {
        FunctionLibrary.Function3D func = FunctionLibrary.GetFunction3D(function);
        float time = Time.time;
        float step = 2f / resolution;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z++;
            }
            float u = (x + 0.5f) * step - 1;
            float v = (z + 0.5f) * step - 1;
            points[i].localPosition = func(u, v, time);
        }
    }

}
