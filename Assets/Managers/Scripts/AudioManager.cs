using System;
using DG.Tweening;
using UnityEngine;

namespace Managers.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusicSource;
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private float fadeDuration = 2f;

        void Start()
        {
            FadeInMusic();
        }

        private void FadeInMusic()
        {
            backgroundMusicSource.volume = 0f;
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.spatialBlend = 0f; 
            backgroundMusicSource.Play();
            backgroundMusicSource.DOFade(1f, fadeDuration);
        }
    }
}