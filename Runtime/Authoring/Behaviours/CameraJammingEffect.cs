using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamJam
{
    namespace Behaviours
    {
        [RequireComponent(typeof(JammedCamera))]
        public abstract class CameraJammingEffect : MonoBehaviour
        {
            [SerializeField]
            private uint priority;

            private JammedCamera jammedCamera;

            private void Start()
            {
                GetComponent<JammedCamera>().Register(priority, Tick);
            }

            protected abstract void Tick(Camera camera);
        }
    }
}