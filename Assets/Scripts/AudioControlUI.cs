using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioControlUI : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _sliderAudio;
    [SerializeField] private TMP_Text _textVolume;

    private void Start()
    {
        _sliderAudio.value = GameSettings.MainVolume;
        var volume = _sliderAudio.value;
        _audioSource.volume = volume;
        SetTextVolume(volume);
    }

    public void OnChangeVolume()
    {
        var volume = _sliderAudio.value;
        _audioSource.volume = volume;
        GameSettings.MainVolume = volume;
        SetTextVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    private void SetTextVolume(float volume)
    {
        _textVolume.text = $"Volume: {(int)(volume * 100)}%";
    }
}
