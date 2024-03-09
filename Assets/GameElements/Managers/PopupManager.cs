
using System.Collections;
using UnityEngine;

namespace Platformer.UI.Popup
{
    public class PopupManager : MonoBehaviour
    {
        private PopupContentBase curPopup;
        [SerializeField]
        private Transform _popupParent;
        [SerializeField]
        private Animator _anim;
        [SerializeField]
        private GameObject Popup;
        private int _IDAppear;
        private int _IDHide;

        private void Awake()
        {
            _IDAppear = Animator.StringToHash("Appear");
            _IDHide = Animator.StringToHash("Hide");
        }
        public void ActivatePopup(PopupContentBase popup)
        {
            Popup.SetActive(true);
            curPopup = Instantiate<PopupContentBase>(popup, _popupParent);
            _anim.SetTrigger(_IDAppear);
            curPopup.gameObject.SetActive(true);
            curPopup.HidePopup += OnHidePopup;
        }
        private void OnHidePopup()
        {
            curPopup.HidePopup -= OnHidePopup;
            _anim.SetTrigger(_IDHide);
            StartCoroutine(DelayToDestroy());
        }
        private IEnumerator DelayToDestroy()
        {
            yield return new WaitForSeconds(1);
            Destroy(curPopup.gameObject);
        }

        
    }
}


