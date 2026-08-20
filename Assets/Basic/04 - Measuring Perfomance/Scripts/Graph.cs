using UnityEngine;

namespace MeasuringPerfomance
{
    public class Graph : MonoBehaviour
    {
        [SerializeField, Header("Initialization")]
        private Transform pointTransform;

        [SerializeField, Range(1, 10)]
        private uint resolution = 5;

        [SerializeField, Header("Function Select")]
        private FunctionLibrary.FunctionName function;

        [SerializeField]
        private TransitionMode transitionMode;

        public enum TransitionMode { Cycle, Random }

        [SerializeField, Min(0f)]
        private float functionDuration = 1f, transitionDuration = 1f;

        private Transform[] points;

        private float duration;

        private bool transitioning;

        private FunctionLibrary.FunctionName transitionFunction;

        void Awake()
        {
            uint res = resolution * 10;
            points = new Transform[res * res];
            float step = 2f / res;
            Vector3 scale = Vector3.one * step;
            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i] = Instantiate(pointTransform, transform, false);
                point.localScale = scale;
            }
        }

        void Update()
        {
            duration += Time.deltaTime;
            if (transitioning) 
            {
                if (duration >= transitionDuration)
                {
                    duration -= transitionDuration;
                    transitioning = false;
                }
                else
                    UpdateFunctionTransition();
            }
            else if (duration >= functionDuration)
            {
                duration -= functionDuration;
                transitioning = true;
                transitionFunction = function;
                PickNextFunction();
            }
            else
                UpdateFunction();
        }

        void PickNextFunction()
        {
            function = transitionMode == TransitionMode.Cycle ?
                FunctionLibrary.GetNextFunctionName(function) :
                FunctionLibrary.GetRandomFunctionNameOtherThan(function);
        }

        void UpdateFunction()
        {
            uint res = resolution * 10;
            FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
            float time = Time.time;
            float step = 2f / res;
            for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
            {
                if (x == res)
                {
                    x = 0;
                    z++;
                }
                float u = (x + 0.5f) * step - 1f;
                float v = (z + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, time);
            }
        }


        void UpdateFunctionTransition()
        {
            uint res = resolution * 10;
            FunctionLibrary.Function
                from = FunctionLibrary.GetFunction(transitionFunction),
                to = FunctionLibrary.GetFunction(function);
            float progress = duration / transitionDuration;
            float time = Time.time;
            float step = 2f / res;
            for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
            {
                if (x == res)
                {
                    x = 0;
                    z++;
                }
                float u = (x + 0.5f) * step - 1f;
                float v = (z + 0.5f) * step - 1f;
                points[i].localPosition = FunctionLibrary.Morph(u, v, time, from, to, progress);
            }
        }
    }
}
