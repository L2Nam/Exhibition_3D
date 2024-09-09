using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioMusic, audioEffect;

    public static SoundManager instance;

    [SerializeField]
    AudioClip click;
    [SerializeField]
    AudioClip lobby;

    private List<AudioSource> listAudioSrc = new List<AudioSource>();
    private List<AudioSource> listCurrentAudioSrc = new List<AudioSource>();
    bool isSound = true;

    private void Awake()
    {
        SoundManager.instance = this;
    }

    public AudioSource playEffectFromPath(string pathAudio)
    {
        if (isSound)
        {
            audioMusic.Stop();
            var audioClip = Resources.Load(pathAudio) as AudioClip;
            AudioSource audioSrc;
            if (listAudioSrc.Count > 0 && listAudioSrc[0].isPlaying == false)
            {
                audioSrc = listAudioSrc[0];
                listAudioSrc.RemoveAt(0);
            }
            else
            {
                audioSrc = Instantiate(audioEffect);
                audioSrc.transform.SetParent(transform);
            }
            audioSrc.Stop();
            audioSrc.clip = audioClip;
            audioSrc.Play();
            listCurrentAudioSrc.Add(audioSrc);
            DOTween.Sequence()
              .AppendInterval(audioSrc.clip.length).AppendCallback(() =>
              {
                  audioMusic.Play();
                  listAudioSrc.Add(audioSrc);
                  listCurrentAudioSrc.Remove(audioSrc);
              });
            return audioSrc;
        }
        return null;
    }

    public void stopAllCurrentEffect()
    {
        Debug.Log("stopAllCurrentEffect");
        listCurrentAudioSrc.ForEach(auSrc =>
        {

            if (auSrc.isPlaying)
            {
                auSrc.Stop();
                listAudioSrc.Add(auSrc);
            }
        });
        listAudioSrc.ForEach(auSrc =>
        {

            if (auSrc.isPlaying)
            {
                auSrc.Stop();
            }
        });
        listCurrentAudioSrc.Clear();
        audioEffect.Stop();
    }

    public void SoundClick()
    {
        PlaySound(click);
    }

    void PlaySound(AudioClip audioClip)
    {
        if (!isSound) return;

        audioEffect.clip = audioClip;
        audioEffect.Play();
    }
}
