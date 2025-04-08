using UnityEngine;
using UnityEngine.UI;  // Make sure to include this to access UI components

public class PowerBar : MonoBehaviour
{
    public Slider powerSlider; // Reference to the Slider in the UI
    private Image fillImage; // Reference to the Image component of the Slider's Fill Area
    public float currentPower = 50f; // Starting power value (can be between Min and Max)
    public float maxPower = 100f; // Maximum power value
    public float minPower = 0f; // Minimum power value

    // Define colors for low, medium, and high power
    public Color lowPowerColor = Color.red;
    public Color mediumPowerColor = Color.yellow;
    public Color highPowerColor = Color.green;

    void Start()
    {
        // Initialize the slider with current power
        powerSlider.maxValue = maxPower;
        powerSlider.minValue = minPower;
        powerSlider.value = currentPower;

        // Ensure fillImage references the Image component of the Slider's Fill Area
        fillImage = powerSlider.fillRect.GetComponent<Image>(); // Get the Image component from Fill Area
    }

    void Update()
    {
        // Simulate power increasing or decreasing (for demonstration)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            IncreasePower(1f); // Increase power by 1 each frame when Up Arrow is pressed
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DecreasePower(1f); // Decrease power by 1 each frame when Down Arrow is pressed
        }

        // Optionally, update the slider value based on the current power value
        powerSlider.value = currentPower;

        // Update the color of the slider based on the power value
        UpdateSliderColor();
    }

    // Increase power function
    void IncreasePower(float amount)
    {
        currentPower += amount;
        if (currentPower > maxPower) currentPower = maxPower; // Clamp to max value
    }

    // Decrease power function
    void DecreasePower(float amount)
    {
        currentPower -= amount;
        if (currentPower < minPower) currentPower = minPower; // Clamp to min value
    }

    // Update the color of the slider fill based on the power level
    void UpdateSliderColor()
    {
        // Normalize power value to a 0-1 range
        float normalizedPower = Mathf.InverseLerp(minPower, maxPower, currentPower);

        // Blend between colors based on the power level
        if (normalizedPower < 0.33f)
        {
            fillImage.color = lowPowerColor; // Red for low power
        }
        else if (normalizedPower < 0.66f)
        {
            fillImage.color = mediumPowerColor; // Yellow for medium power
        }
        else
        {
            fillImage.color = highPowerColor; // Green for high power
        }
    }
}
