using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class BlockerBehaviour : MonoBehaviour
{

    public float size;

    public GameObject pusher;
    public GameObject arm;

    BoxCollider box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        pusher.transform.localPosition = new Vector3(size, 0, 0);
        pusher.transform.localPosition = new Vector3(size, 0, 0);
        box.size = new Vector3(size + 0.5f, 1, 1);
        box.center = new Vector3(size/2  -0.125f, 0, 0);
        arm.transform.localScale = new Vector3(size + 0.25f, 0.25f, 0.25f);
        arm.transform.localPosition = new Vector3((size + 0.25f)/2  -0.375f, 0, 0);
    }

    public void PlaySound()
    {
        Debug.Log("PlaySound called at: " + Time.time);
    }
}
