using UnityEngine;

namespace Platformer.UI.Popup
{
    public class PopupStorage : MonoBehaviour
    {
        private static PopupStorage _instance;
        public static PopupStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (Instantiate(Resources.Load("PopupStorage")) as GameObject).GetComponent<PopupStorage>();
                }
                return _instance;
            }
        }
        public DeathPopup DeathPopup;

    }
}

