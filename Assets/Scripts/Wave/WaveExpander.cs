using Assets.Scripts.Utility;
using UnityEngine;

[ExecuteInEditMode]
public class WaveExpander : MonoBehaviour
{
    public enum Plane { XY, XZ, YZ }

    /// <summary>
    /// The time it takes for the wave to reach its maximum expansion (in seconds)
    /// </summary>
    public float TotalExpansionTime = 3;

    /// <summary>
    /// The percentage the wave expands per second on the selected Plane
    /// </summary>
    [Range(0, 1)]
    public float ExpansionPerSecond = 0.1f;

    /// <summary>
    /// The local Plane the wave should expand on
    /// </summary>
    public Plane ExpansionPlane = Plane.XZ;

    [SerializeField, ReadOnly]
    private float _totalExpansion = -1;

    private float _lifeTime;
    private Transform _myTransform;

    // Use this for initialization
    void Start()
    {
        if (!Application.isPlaying)
            return;

        _myTransform = GetComponent<Transform>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = "Wave";
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            _totalExpansion = TotalExpansionTime * ExpansionPerSecond;
            return;
        }

        _lifeTime += Time.deltaTime;
        if (_lifeTime < TotalExpansionTime && _myTransform != null)
        {
            switch (ExpansionPlane)
            {
                case Plane.XY:
                    _myTransform.localScale += new Vector3(ExpansionPerSecond, ExpansionPerSecond, 0);
                    break;
                case Plane.XZ:
                    _myTransform.localScale += new Vector3(ExpansionPerSecond, 0, ExpansionPerSecond);
                    break;
                case Plane.YZ:
                    _myTransform.localScale += new Vector3(0, ExpansionPerSecond, ExpansionPerSecond);
                    break;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
