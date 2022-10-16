using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;

    [Range(0, 1)] public float batteryCharge = 1f;
    [SerializeField] float batteryDecay = .1f;
    Light myLight;
    float startingAngle;
    bool lightIsOn = true;
    bool batteryIsCharged = true;

    private void Start()
    {
        myLight = GetComponent<Light>();
        startingAngle = myLight.spotAngle;
    }


    private void Update()
    {
        EvaluateBatteryLevel();
        ToggleLight();
        if (lightIsOn)
        {
            ProcessLightUsage();
        }
        else
        {
            RechargeBattery();
        }
    }

    private void EvaluateBatteryLevel()
    {
        if (batteryCharge >= .2f)
        {
            batteryIsCharged = true;
        }
        else if (batteryCharge <= .2f)
        {
            batteryIsCharged = false;
            lightIsOn = false;
            myLight.intensity = 0;
        }
    }

    private void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && lightIsOn)
        {
            lightIsOn = false;
            myLight.intensity = 0;

        }
         else if (Input.GetKeyDown(KeyCode.F) & !lightIsOn && batteryIsCharged)
        {
            lightIsOn = true;
            myLight.intensity =4;
        }
    }

    private void RechargeBattery()
    {

        if (lightIsOn) { return; }
        else if (!lightIsOn)
        {
            batteryCharge += Mathf.Clamp(batteryDecay, 0, 1f) * Time.deltaTime;

        }
    }

    private void DecreaseLightAngle()
    {
        myLight.spotAngle = batteryCharge *100;

    }

    private void ProcessLightUsage()
    {

        batteryCharge -= Mathf.Clamp(batteryDecay, 0, 1f) * Time.deltaTime;
        myLight.intensity -= lightDecay * Time.deltaTime;
        DecreaseLightAngle();
    }
}
