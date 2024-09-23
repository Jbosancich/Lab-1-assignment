using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class PortalDisappearance : MonoBehaviour
{
    // Optional: time delay before the portal starts to disappear
    public float disappearDelay = 0f;

    // Fade-out speed (higher = faster fade)
    public float fadeSpeed = 1f;

    // Renderer to control portal visibility
    private Renderer portalRenderer;
    
    // Track whether the portal is fading
    private bool isFading = false;

    void Start()
    {
        // Get the Renderer component of the portal
        portalRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Start the disappearance process (fade-out) when any object enters
        if (disappearDelay > 0f)
        {
            Invoke("StartDisappearing", disappearDelay);
        }
        else
        {
            StartDisappearing();
        }
    }

    void Update()
    {
        // If the portal is fading, gradually reduce its transparency
        if (isFading)
        {
            Color portalColor = portalRenderer.material.color;
            portalColor.a -= fadeSpeed * Time.deltaTime;
            portalRenderer.material.color = portalColor;

            // Once the portal is fully transparent, deactivate it
            if (portalColor.a <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void StartDisappearing()
    {
        // Trigger the fading process
        isFading = true;
    }
}

