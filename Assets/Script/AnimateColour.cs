using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class AnimateTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Renderer objectRenderer;
    private Vector2 savedOffset;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        savedOffset = objectRenderer.material.mainTextureOffset;
    }

    void Update()
    {
        // Animate the texture offset over time for a moving effect
        float offsetX = Time.time * scrollSpeed;
        float offsetY = Time.time * scrollSpeed * 0.5f; // Different speed for Y-axis
        Vector2 newOffset = new Vector2(offsetX, offsetY);

        objectRenderer.material.mainTextureOffset = newOffset;
    }

    void OnDisable()
    {
        // Reset the texture offset when the script is disabled
        objectRenderer.material.mainTextureOffset = savedOffset;
    }
}
