using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlephVault.Unity.CamJam
{
    namespace Authoring
    {
        namespace Behaviours
        {
            [RequireComponent(typeof(Camera))]
            public class JammedCamera : MonoBehaviour
            {
                /**
                 * Receives effects (essentially: just methods) that alter how the camera behaves.
                 * 
                 * On each update, the camera is altered according to the registered effects.
                 */
                private Camera camera;
                private SortedDictionary<uint, Action<Camera>> pipeline = new SortedDictionary<uint, Action<Camera>>();

                private void Start()
                {
                    camera = GetComponent<Camera>();
                }

                // Update is called once per frame
                void Update()
                {
                    foreach (Action<Camera> action in pipeline.Values)
                    {
                        action(camera);
                    }
                }

                public void Register(uint priority, Action<Camera> action)
                {
                    // This method should be only called from a CameraJammingEffect.
                    pipeline.Add(priority, action);
                }
            }
        }
    }
}