using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class AnimasiRenderer : MonoBehaviour
{
    // Here reference the camera component of the particles camera
    [SerializeField] private Camera animasiCamera;

    // Adjust the resolution in pixels
    [SerializeField] private Vector2Int imageResolution = new Vector2Int(256, 256);

    // Reference the RawImage in your UI
    [SerializeField] private RawImage targetImagePeng;

    private RenderTexture renderTexture;

    private void Awake()
    {
        if (!animasiCamera) animasiCamera = GetComponent<Camera>();

        renderTexture = new RenderTexture(imageResolution.x, imageResolution.y, 32);
        animasiCamera.targetTexture = renderTexture;


        targetImagePeng.texture = renderTexture;
    }
}
