using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSoundBehaviour : MonoBehaviour
{
    [SerializeField] private GameManeger scriptManeger;
    [SerializeField] private AudioSource[] allAudios;
    [SerializeField] private Slider currentSlider;

    //recebe o slider da cena atual
    public void SetCurrentSlider(GameObject slider)
    {
        currentSlider = slider.GetComponent<Slider>();
        currentSlider.value = scriptManeger.GetMasterVolume();
        currentSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    //recebe novo valor de volume
    public void ChangeVolume()
    {
        scriptManeger.SetMasterVolume(currentSlider.value);
        SetAllVolume();
    }

    //ajusta volume de todos os audios
    public void SetAllVolume()
    {
        foreach (AudioSource audio in allAudios)
        {
            audio.volume = scriptManeger.GetMasterVolume();
        }
    }

    // tocar os audios
    public void PlaySound(int sound)
    {
        allAudios[sound].Play();
    }
}
