using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atrous : MonoBehaviour
{
    public ComputeShader shader;

    public RenderTexture texture;
    public RenderTexture output;

    public Texture2D image;

    private readonly int _StepWidthId = Shader.PropertyToID("StepWidth");
    private readonly int _IterationId = Shader.PropertyToID("Iteration");

    void Start()
    {
        texture = new RenderTexture(1920, 1080, 24);
        texture.enableRandomWrite = true;
        texture.Create();

        output = new RenderTexture(1920, 1080, 24);
        output.enableRandomWrite = true;
        output.Create();

        Graphics.Blit(image, texture);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (texture == null)
        {
            texture = new RenderTexture(1920, 1080, 24);
            texture.enableRandomWrite = true;
            texture.Create();

            output = new RenderTexture(1920, 1080, 24);
            output.enableRandomWrite = true;
            output.Create();
        }

        Graphics.Blit(image, texture);

        Atrous24();
        Atrous12();
        Atrous8();

        Graphics.Blit(texture, destination);
    }

    public void Atrous24()
    {
        int iterations = 6;
        for (int i = 0; i < iterations; i++)
        {
            shader.SetTexture(0, "ShadowInput", texture);
            shader.SetTexture(0, "FilteredOutput", output);
            shader.SetFloat(_StepWidthId, Mathf.Max(i, 1));
            shader.SetInt(_IterationId, i);
            shader.Dispatch(0, 1920 / 24, 1080 / 24, 1);
            Graphics.Blit(output, texture);
        }
    }

    public void Atrous12()
    {
        int iterations = 6;
        for (int i = 0; i < iterations; i++)
        {
            shader.SetTexture(1, "ShadowInput", texture);
            shader.SetTexture(1, "FilteredOutput", output);
            shader.SetFloat(_StepWidthId, Mathf.Max(i, 1));
            shader.SetInt(_IterationId, i);
            shader.Dispatch(1, 1920 / 12, 1080 / 12, 1);
            Graphics.Blit(output, texture);
        }
    }

    public void Atrous8()
    {
        int iterations = 6;
        for (int i = 0; i < iterations; i++)
        {
            shader.SetTexture(2, "ShadowInput", texture);
            shader.SetTexture(2, "FilteredOutput", output);
            shader.SetFloat(_StepWidthId, Mathf.Max(i, 1));
            shader.SetInt(_IterationId, i);
            shader.Dispatch(2, 1920 / 8, 1080 / 8, 1);
            Graphics.Blit(output, texture);
        }
    }
}
