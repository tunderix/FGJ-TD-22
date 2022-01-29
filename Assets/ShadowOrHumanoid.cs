using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creator
{
    public class ShadowOrHumanoid : MonoBehaviour
    {
        [SerializeField]GameObject _shadow;
        [SerializeField]GameObject _humanoid;

        [SerializeField] float _transitionDuration;


        private void Start() 
        {
            _shadow.SetActive(false);
            _humanoid.SetActive(true);
        }

        public void Day()
        {
            StartCoroutine(WaitAndSetActive(false, true,_transitionDuration));
        }
        public void Night()
        {
            StartCoroutine(WaitAndSetActive(true, false,_transitionDuration));
        }

        IEnumerator WaitAndSetActive(bool shadow, bool humanoid, float duration)
        {
            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                yield return null;
            }
            _shadow.SetActive(shadow);
            _humanoid.SetActive(humanoid);
        }
    }
}

