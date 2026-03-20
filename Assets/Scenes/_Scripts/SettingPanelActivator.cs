using UnityEngine;

public class SettingsPanelActivator : MonoBehaviour // done by Microsoft Copilot
{
    private void OnEnable()
    {
        SoundManager.Instance.AssignSliderInScene(); // assign slider to sound manager
    }
}

