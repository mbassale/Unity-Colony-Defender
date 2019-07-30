using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    [Tooltip("In m/s")][SerializeField] float xSpeed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 15f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 15f;
    [Tooltip("In m")] [SerializeField] float yRange = 8f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 4.2f;
    [SerializeField] float controlYawFactor = 5f;
    [SerializeField] float controlRollFactor = -30f;

    private float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis(HORIZONTAL);
        yThrow = CrossPlatformInputManager.GetAxis(VERTICAL);
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos, transform.localPosition.z);
    }
}
