using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public sealed class EventsTest : MonoBehaviour
    {
        public delegate void CameraShake();
        public delegate void CameraZoom();

        public static event CameraShake ActivCamShake;
        public static event CameraZoom ActivCamZoom;

        protected internal static void OnActivCamShake() => ActivCamShake?.Invoke();
        
        
        protected internal static void OnActivCamZoom() => ActivCamZoom?.Invoke();
        
    }
}