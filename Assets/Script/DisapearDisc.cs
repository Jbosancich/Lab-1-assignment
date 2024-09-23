using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDisappearance : MonoBehaviour
{
    // Optional: time delay before the portal starts to disappear
    public float disappearDelay = 0f;

    // Fade-out speed (higher = faster fade)
    public float fadeSpeed = 1f;

    // Reference to the Renderer component for controlling portal visibility
    private Renderer portalRenderer;

    // Track whether the portal is fading
    private bool isFading = false;

    // Store a copy of the material to prevent shared material issues
    private Material portalMaterial;

    // Check if the portal is currently active or not
    private bool isActive = true;

    // Reference to the AudioSource for playing the closing sound
    private AudioSource portalAudio;

    void Start()
    {
        // Get the Renderer component of the portal object
        portalRenderer = GetComponent<Renderer>();
        
        // Instantiate a copy of the material to prevent shared material changes
        portalMaterial = portalRenderer.material;

        // Get the AudioSource component for the closing sound
        portalAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Only start fading if we aren't already fading
        if (!isFading)
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
    }

    void Update()
    {
        // Handle portal fading
        HandleFading();
    }

    void HandleFading()
    {
        // If the portal is fading, gradually reduce its transparency
        if (isFading)
        {
            Color portalColor = portalMaterial.color;
            portalColor.a -= fadeSpeed * Time.deltaTime;
            portalMaterial.color = portalColor;

            // Once the portal is fully transparent, deactivate it
            if (portalColor.a <= 0f)
            {
                gameObject.SetActive(false);
                isActive = false;  // Mark the portal as inactive
            }
        }
    }

    void StartDisappearing()
    {
        // Trigger the fading process
        isFading = true;

        // Play the portal closing sound if assigned
        if (portalAudio != null)
        {
            portalAudio.Play();
        }
    }
}



