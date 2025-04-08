
using UnityEngine;
using TMPro;

public class PlayerRotationUI : MonoBehaviour
{
    public TextMeshProUGUI rotationText; 

    void Update()
    {
        if (rotationText != null)
        {
            float yRotation = transform.eulerAngles.y; 
            rotationText.text = "Rotation: " + yRotation.ToString("F1") + "°";
        }
    }
}

