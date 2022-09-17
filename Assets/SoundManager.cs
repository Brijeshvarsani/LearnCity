using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] AudioSource music;

    public void ChangeVolume()
    {
        AudioListener.volume = masterSlider.value;
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }
}
