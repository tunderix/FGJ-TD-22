using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator
{
    public class ChangeRenderSettings : MonoBehaviour
    {
        [SerializeField] Color _day;
        [SerializeField] Color _night;
        [SerializeField] Camera _camera;



        [SerializeField] float _fogNightDensity;
        [SerializeField] float _fogDayDensity;


        [SerializeField] Color _lightDay;
        [SerializeField] Color _lightNight;
        [SerializeField] Light _dirLight;


        [SerializeField] float _transitionDuration;

        public void ChangeFogColor(Color from, Color to, float time, float acceleration)
        {
            float changeofrate = time * acceleration;
            RenderSettings.fogColor = Color.Lerp(from, to, Time.deltaTime + changeofrate);
        }

        private void Start() {
            _camera.backgroundColor = _day;
            RenderSettings.fogColor = _day;
            _dirLight.color = _lightDay;    
        }

        public void Day()
        {
            StartCoroutine(ColorLerpFunction(_day,_lightDay,_transitionDuration));
            StartCoroutine(FloatLerpFunction(_fogDayDensity,_transitionDuration));
        }
        public void Night()
        {
            StartCoroutine(ColorLerpFunction(_night,_lightNight, _transitionDuration));
            StartCoroutine(FloatLerpFunction(_fogNightDensity,_transitionDuration));
        }

        private IEnumerator ColorLerpFunction(Color endValue, Color targetLightColor, float duration)
        {
            float time = 0;
            Color startColor = RenderSettings.fogColor;
            Color startLightColor = _dirLight.color;

            while (time < duration)
            {
                _camera.backgroundColor = Color.Lerp(startColor, endValue, time / duration);
                RenderSettings.fogColor = Color.Lerp(startColor, endValue, time / duration);
                _dirLight.color = Color.Lerp(startLightColor, targetLightColor, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            RenderSettings.fogColor = endValue;
            _camera.backgroundColor = endValue;
        }

        
        private IEnumerator FloatLerpFunction(float endValue, float duration)
        {
            float time = 0;
            float startValue = RenderSettings.fogDensity;

            while (time < duration)
            {
                RenderSettings.fogDensity = Mathf.Lerp(startValue, endValue, time / duration);

                time += Time.deltaTime;
                yield return null;
            }
            RenderSettings.fogDensity = endValue;
        }
    }
}
