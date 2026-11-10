using UnityEngine;

public class Scanner : MonoBehaviour
{
    public enum SensorTechnology 
    { 
        Inductive, 
        Capacitive, 
        Photoelectric, 
        NearInfrared
    }

    [Header("Sensor Settings")]
    public SensorTechnology sensorType;

    public bool isSignalActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged")) return;

        if (CanDetectMaterial(other.tag))
        {
            isSignalActive = true;
            Debug.Log($"[{sensorType} SENSOR] SIGNAL ACTIVE (TRUE)! Detected object.");
            isSignalActive = true;
        }
        else
        {
            Debug.Log($"[{sensorType} SENSOR] Signal: FALSE.");
            isSignalActive = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (CanDetectMaterial(other.tag))
        {
            isSignalActive = false; 
            Debug.Log($"[{sensorType} SENSOR] Object left the zone. Signal: FALSE.");
        }
    }

    private bool CanDetectMaterial(string materialTag)
    {
        switch (sensorType)
        {
            case SensorTechnology.Inductive:
                return materialTag == "Metal"; 

            case SensorTechnology.Capacitive:
                return materialTag == "Metal" || materialTag == "Plastic" || 
                       materialTag == "Glass" || materialTag == "Rubber" || 
                       materialTag == "Cardboard";

            case SensorTechnology.Photoelectric:
                return materialTag == "Metal" || materialTag == "Plastic" || 
                       materialTag == "Rubber" || materialTag == "Cardboard"; 

            case SensorTechnology.NearInfrared:
                return materialTag == "Plastic" || materialTag == "Cardboard";

            default:
                return false;
        }
    }
}