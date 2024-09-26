using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioBackgrond, audioEffect;

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
        InvokeRepeating("CheckBgMusic", 0f, 1.5f);
    }

    void CheckBgMusic()
    {
        bool checkBgMusic = true;
        listCurrentAudioSrc.ForEach(auSrc =>
        {
            Debug.Log(auSrc);
            if (auSrc.isPlaying)
            {
                checkBgMusic = false;
            }
        });
        if (checkBgMusic && !audioBackgrond.isPlaying)
            audioBackgrond.Play();
    }

    public AudioSource PlayEffectFromPath(string pathAudio)
    {
        if (isSound)
        {
            var audioClip = Resources.Load(pathAudio) as AudioClip;
            audioBackgrond.Pause();
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
