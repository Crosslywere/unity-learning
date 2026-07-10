using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float Function(float x, float t);

    private static readonly Function[] functions = { Wave, MultiWave, Ripple };

    public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Torus };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name % functions.Length];
    } 

    private static float Wave(float x, float t)
    {
        return Sin(PI * (x + t));
    }

    private static float MultiWave(float x, float t)
    {
        float y = Sin(PI * (x + 0.5f * t));
        y += 0.5f * Sin(2f * PI * (x + t));
        return y * (2f / 3f);
    }

    private static float Ripple(float x, float t)
    {
        float d = Abs(x); // Using Abs because it is the same as to Sqrt(x * x)
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }

    // 3 dimensional graphing
    public delegate Vector3 Function3D(float x, float z, float t);

    private static readonly Function3D[] functions3D = { Wave, MultiWave, Ripple, Sphere, Torus };

    public static Function3D GetFunction3D(FunctionName name)
    {
        return functions3D[(int)name];
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
        return y * (2f / 5f);
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
        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }

    private static Vector3 Sphere(float u, float v, float t)
    {
        float r = 0.9f + 0.1f * Sin(PI * (4f * u + 4f * v + t));
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    private static Vector3 Torus(float u, float v, float t)
    {
        float radius = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
        float thickness = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 0.5f * t));
        float s = radius + thickness * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = thickness * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }
}