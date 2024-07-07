using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float speed = 5f;
}
public class PlayerController : MonoBehaviour
{
    public bool isPaused = false;
    public PlayerStats stats;
    private float currentSpeed;
    private Rigidbody rb;
    private Camera mainCamera;
    [SerializeField] private float sensititvity;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        currentSpeed = stats.speed;
    }
    private void Update()
    {
        if (isPaused) return;
        float moveX = Input.GetAxis("Horizontal") * currentSpeed;
        float moveZ = Input.GetAxis("Vertical") * currentSpeed;
        rb.velocity = transform.forward * moveZ + transform.right * moveX - transform.up;
        float rotationX = Input.GetAxis("Mouse X") * Time.deltaTime * sensititvity;
        transform.Rotate(0, rotationX, 0);
        float rotationY = mainCamera.transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * Time.deltaTime * sensititvity;
        if (rotationY > 180) rotationY -= 360;
        rotationY = Mathf.Clamp(rotationY, -80, 80);
        if (rotationY < 0) rotationY += 360;
        mainCamera.transform.localEulerAngles = new Vector3(rotationY, mainCamera.transform.localEulerAngles.y, 0);
        currentSpeed = stats.speed;
    }
}
