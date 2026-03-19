using UnityEngine;

public class SettingsPanelActivator : MonoBehaviour
{
    private void OnEnable()
    {
        SoundManager.Instance.AssignSliderInScene();
    }
}

