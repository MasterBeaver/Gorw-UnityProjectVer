using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public float horizontal;
    private Transform cam;


    private void Start() {
        cam = gameObject.transform;
    }

    void Update()
    {
        transform.Translate(new Vector3(horizontal, 0, 0) * speed * Time.deltaTime);

        if(cam.position.x >= 610.5f)
        {
            cam.position = new Vector3(0f,0f,37.5f);
            Debug.Log("SS");
        }
    }

    
}
    