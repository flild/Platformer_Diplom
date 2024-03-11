using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.Units.PlayerSpace
{
    public class HealthBarController : MonoBehaviour
    {
        private List<GameObject> heartContainers;
        private List<Image> heartFills;        
        [Inject]
        private Player _player;
        [SerializeField]
        private GameObject heartContainerPrefab;
        [SerializeField, Tooltip("Отступ между сердцами в px")]
        private float _heartPadding;


        public static Event onHealthChanged;

        private void Start()
        {
            //по идеи вынести в stats максимально возможный размер хп, но пока так
            heartContainers = new List<GameObject>(20);
            heartFills = new List<Image>(20);
            for(int i = 0; i < 20; i++)
            {
                heartContainers.Add(null);
                heartFills.Add(null);
            }
            InstantiateHeartContainers();
            _player.Stats.MaxHealth.OnChanged += UpdateHeartsHUD;
            _player.Stats.Health.OnChanged += UpdateHeartsHUD;
            UpdateHeartsHUD();
        }
        private void OnDestroy()
        {
            _player.Stats.MaxHealth.OnChanged -= UpdateHeartsHUD;
            _player.Stats.Health.OnChanged -= UpdateHeartsHUD;
        }
        public void UpdateHeartsHUD(float value = 0)
        {
            SetHeartContainers();
            SetFilledHearts();
        }

        void SetHeartContainers()
        {
            for (int i = 0; i < heartContainers.Count; i++)
            {
                if (i < _player.Stats.MaxHealth.Value)
                {
                    heartContainers[i].SetActive(true);
                }
                else
                {
                    heartContainers[i].SetActive(false);
                }
            }
        }

        void SetFilledHearts()
        {
            for (int i = 0; i < heartFills.Count; i++)
            {
                if (i < _player.Stats.Health.Value)
                {
                    heartFills[i].fillAmount = 1;
                }
                else
                {
                    heartFills[i].fillAmount = 0;
                }
            }

            if (_player.Stats.Health.Value % 1 != 0)
            {
                int lastPos = Mathf.FloorToInt(_player.Stats.Health.Value);
                heartFills[lastPos].fillAmount = _player.Stats.Health.Value % 1;
            }
        }

        void InstantiateHeartContainers()
        {
            var offset = heartContainerPrefab.GetComponent<RectTransform>().sizeDelta.x;
            var startX = heartContainerPrefab.GetComponent<RectTransform>().sizeDelta.x/2;
            var startY = heartContainerPrefab.GetComponent<RectTransform>().sizeDelta.y / 2;
            for (int i = 0; i < 20; i++)
            {
                GameObject temp = Instantiate(heartContainerPrefab,new Vector2(startX + offset*i+ _heartPadding*i, startY),Quaternion.identity, transform);
                heartContainers[i] = temp;
                heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
            }
        }

    }
}


