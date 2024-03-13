
using Platformer.UI.Popup;
using Platformer.Units.PlayerSpace;
using UnityEngine;

namespace Platformer
{
    public class EndGame : MonoBehaviour
    {
        private PopupManager _popups;

        
        private void Awake()
        {
            _popups ??= FindObjectOfType<PopupManager>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Player>(out Player player))
            {
                _popups.ActivatePopup(PopupStorage.Instance.EndGamePopup);
            }
        }
    }
}

