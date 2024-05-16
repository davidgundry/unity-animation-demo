using UnityEditor.Animations;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource tremorSound;
    [SerializeField] private AudioSource breakSound;
    [SerializeField, Range(1, 20)] private float resetTime;
    [SerializeField, Range(0.01f, 2)] private float movementSpeed;
    private Animator _animator;
    private float _fallTime;

    public bool IsUp { get { 
        if (_animator != null)
        {
            AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
            return state.IsName("Idle");
        }
        return true;
    } }

    void Start() {
        _animator = GetComponent<Animator>();
        _fallTime = -resetTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            this.Fall();
    }

    void Update() {
        if (_fallTime > 0)
        {
            if (_fallTime + resetTime < Time.time)
                Reset();
        }
        if (IsUp)
            _animator.SetFloat("speed", movementSpeed);
    }

    public void Fall() {
        _animator.SetBool("fall", true);
        _fallTime = Time.time;
    }

    public void Reset() {
        _animator.SetBool("fall", false);
        _fallTime = -resetTime;
    }

    public void OnAnimTremor(string sound) {
        if (tremorSound != null)
            tremorSound.Play();
    }

    public void OnAnimBreak() {
        if (breakSound != null)
            breakSound.Play();
        _animator.SetFloat("speed", 0);
    }
}
