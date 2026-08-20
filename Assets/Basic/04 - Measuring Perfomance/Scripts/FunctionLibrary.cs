using UnityEngine;
using static UnityEngine.Mathf;

namespace MeasuringPerfomance
{
    public class FunctionLibrary
    {
        public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Torus };

        public delegate Vector3 Function(float x, float y, float t = 0f);

        private static readonly Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus };

        public static Function GetFunction(FunctionName name)
        {
            return functions[(int)name];
        }

        private static Vector3 Wave(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            p.y = WaveY(u, v, t);
            p.z = v;
            return p;
        }

        private static float WaveY(float x, float z, float t)
        {
            return Sin(PI * (x + z + t));
        }

        private static Vector3 MultiWave(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            p.y = MultiWaveY(u, v, t);
            p.z = v;
            return p;
        }

        private static float MultiWaveY(float x, float z, float t)
        {
            float y = Sin(PI * (x + 0.5f * t));
            y += 0.5f * Sin(2f * PI * (z + t));
            y += Sin(PI * (x + z + 0.25f * t));
            return y * 0.4f;
        }

        private static Vector3 Ripple(float u, float v, float t)
        {
            Vector3 p;
            p.x = u;
            p.y = RippleY(u, v, t);
            p.z = v;
            return p;
        }

        private static float RippleY(float x, float z, float t)
        {
            float d = new Vector2(x, z).magnitude;
            float y = Sin(PI * (4f * d - t));
            return y / (1 + 10f * d);
        }

        private static Vector3 Sphere(float u, float v, float t)
        {
            float radius = 0.9f + 0.1f * Sin(PI * (4f * (u + v) + t));
            // For a smooth unsegmented sphere use simple values that don't change over time
            float s = radius * Cos(0.5f * PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = radius * Sin(0.5f * PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }

        public static Vector3 Torus(float u, float v, float t)
        {
            float radius = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
            float thickness = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 0.5f * t));
            // For a smooth unsegmented torus use simple values for radius and thickness
            float s = radius + thickness * Cos(PI * v);
            Vector3 p;
            p.x = s * Sin(PI * u);
            p.y = thickness * Sin(PI * v);
            p.z = s * Cos(PI * u);
            return p;
        }

        public static FunctionName GetNextFunctionName(FunctionName name) => (int)name < functions.Length - 1 ? name + 1 : 0;

        public static FunctionName GetRandomFunctionNameOtherThan(FunctionName name)
        {
            var choice = (FunctionName)Random.Range(1, functions.Length);
            return choice == name ? 0 : choice;
        }

        public static Vector3 Morph(float u, float v, float t, Function from, Function to, float progress) =>
            Vector3.LerpUnclamped(from(u, v, t), to(u, v, t), SmoothStep(0f, 1f, progress));
    }
}