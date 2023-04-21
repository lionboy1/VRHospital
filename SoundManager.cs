﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script added to patient

namespace VRH
{    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource _pain;
        [SerializeField] AudioSource _cough;
        [SerializeField] AudioSource _hostile;
        [SerializeField] AudioSource _anxious;
        [SerializeField] AudioSource _neutral;
        [SerializeField] AudioSource _happy;

        float coughInterval;
        float coughReset;
        void Start()
        {
            GiveInjection.pain += Pain;
            coughInterval = Random.Range(10.0f, 30.0f);
            coughReset = Time.deltaTime;
        }
        void Pain()
        {
            _pain.Play();
        }
        void Cough()
        {
            if(coughReset > coughInterval)
            {
                _cough.Play();
                coughReset = 0f;
            }
        }
        void CoughCounter()
        {
            coughReset += Time.deltaTime;
        }
        // Update is called once per frame
        void Update()
        {
            Cough();
            CoughCounter();
        }
        void OnDisable()
        {
            GiveInjection.pain -= Pain;
        }
        public void PlayHostileSound()
        {
            _hostile.PlayOneShot(_hostile.clip);
        }
        public void PlayAnxiousSound()
        {
            _anxious.PlayOneShot(_anxious.clip);
        }
        public void PlayNeutralSound()
        {
            _neutral.PlayOneShot(_neutral.clip);
        }
        public void PlayExhuberantSound()
        {
            _happy.PlayOneShot( _happy.clip);
        }
    }
}
