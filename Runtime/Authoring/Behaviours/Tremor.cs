using System;
using System.Collections;
using UnityEngine;

namespace AlephVault.Unity.CamJam
{
    namespace Authoring
    {
        namespace Behaviours
        {
            public class Tremor : CameraJammingEffect
            {
                // The max. tremor intensity for random.
                [SerializeField]
                private float intensity = 0.0625f;

                // The time interval (in seconds) between vibrations
                [SerializeField]
                private float interval = 0.1f;

                private float timeSinceLastVibration = 0;

                private void Shake(float newIntensity, float newInterval)
                {
                    intensity = newIntensity;
                    interval = newInterval;
                }

                protected override void Tick(Camera camera)
                {
                    intensity = Mathf.Abs(intensity);
                    interval = Mathf.Abs(interval);
                    if (intensity != 0 || interval != 0)
                    {
                        timeSinceLastVibration += Time.deltaTime;
                        if (timeSinceLastVibration >= interval)
                        {
                            timeSinceLastVibration -= interval;
                            float randomAngle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
                            float randomIntensity = UnityEngine.Random.Range(0, intensity);
                            camera.transform.position = new Vector3(
                                camera.transform.position.x + Mathf.Cos(randomAngle) * randomIntensity,
                                camera.transform.position.y + Mathf.Sin(randomAngle) * randomIntensity,
                                camera.transform.position.z
                            );
                        }
                    }
                    else
                    {
                        timeSinceLastVibration = 0;
                    }
                }
            }
        }
    }
}
