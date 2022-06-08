using UnityEngine;
using UnityEngine.VFX;

public class Dissolve : MonoBehaviour
{
    public bool Active;
    [SerializeField] private Renderer[] _renderer;
    [SerializeField] private VisualEffect[] _vfx;

    private float _timer;
    private float _dissolve;

    private void Awake()
    {
        //_renderer = GetComponents<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            _timer += Time.deltaTime * 0.5f;
            _dissolve = _timer;

            foreach (Renderer r in _renderer)
            {
                r.material.SetFloat("_DissolveVal", _dissolve);
            }



            foreach (VisualEffect v in _vfx)
            {
                v.SetFloat("Lifetime", -_dissolve);
            }

            if (_timer > 1)
            {
                Active = false;
                _dissolve = 1;
            }

        }

    }
}
