using Platformer.Extensions;
using Platformer.Units.PlayerSpace;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Damage;
    [SerializeField]
    private Animator _anim;
    private bool IsHitted = false;
    private void Update()
    {
        if (!IsHitted)
        {
            var CalcX = transform.right * _speed * Time.deltaTime;
            transform.localPosition += CalcX;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(Damage);
        }
        _anim.SetTrigger("Hit");
        IsHitted = true;

    }
    public void EndShoot_U()
    {
        gameObject.SetActive(false);
        IsHitted = false;
    }
}
