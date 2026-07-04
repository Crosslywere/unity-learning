# Building a Graph

[The source article](https://catlikecoding.com/unity/tutorials/basics/building-a-graph/)

The goal is to learn about

1. Creating prefabs
2. Instantiating multiple cubes
3. Show a mathematical function
4. Create a surface shader and shader graph
5. Animate the graph

### Notes

- Reference [Unity docs](https://docs.unity3d.com/2022.3/Documentation/Manual/SL-SurfaceShaders.html) for writing Surface shaders.
- Changing the Render Pipeline:
  - The version of the `Universal RP` is `14.0.12` which may be different from the one used in the tutorial
  - Creating the `URP` required from the [tutorial](https://catlikecoding.com/unity/tutorials/basics/building-a-graph/#3.3) was to create a `URP Asset (with Universal Render)`
  - When changing the render pipeline goto `Project Settings > Graphics` and there set the **`Scriptable Render Pipeline Settings`** to the created `URP Asset(with Universal Renderer)`
