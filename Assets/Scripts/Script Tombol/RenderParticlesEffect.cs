using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class RenderParticlesEffect : MonoBehaviour
{
    // Here reference the camera component of the particles camera
    [SerializeField] private Camera particlesCamera;

    // Adjust the resolution in pixels
    [SerializeField] private Vector2Int imageResolution = new Vector2Int(256, 256);

    // Reference the RawImage in your UI
    [SerializeField] private RawImage targetImage1, targetImage2, targetImage3, targetImage4;

    private RenderTexture renderTexture;

    private void Awake()
    {
        if (!particlesCamera) particlesCamera = GetComponent<Camera>();

        renderTexture = new RenderTexture(imageResolution.x, imageResolution.y, 32);
        particlesCamera.targetTexture = renderTexture;

        targetImage1.texture = renderTexture;
        if (SceneManager.GetActiveScene().name == "LevelSelection")
        {
            targetImage2.texture = renderTexture;
            targetImage3.texture = renderTexture;
            targetImage4.texture = renderTexture;
        }
        // targetImagePeng.texture = renderTexture;
    }
}
