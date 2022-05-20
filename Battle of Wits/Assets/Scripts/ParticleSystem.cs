using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  GetComponent<Renderer>().sortingLayerName = "Foreground";
        Destroy(gameObject,1.5f);

    }
}
