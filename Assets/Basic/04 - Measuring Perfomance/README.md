# Measuring Performance

[The source article](https://catlikecoding.com/unity/tutorials/basics/measuring-performance/)

The goal of this is to learn about:

1. The profiler
2. Displaying an FPS counter
3. Point function transition/lerp

### Notes

- Use the `Stats` toggle on the "game" tab for a quick overview of rendering
  - There is always 1 triangle being rendered, this is probably where the frame buffer is being rendered to.
  - Using Universal Rennder Pipeline(URP) reduces the render batches by a third of the Builtin Render Pipeline (BRP).
- The Frame Debugger tool is not available on Linux.
- Use `Mathf.SmoothStep(from, to, t)` create a slight S curve to smoothly interpolate from `from` to `to` using a 0 to 1 clamped `t`.
