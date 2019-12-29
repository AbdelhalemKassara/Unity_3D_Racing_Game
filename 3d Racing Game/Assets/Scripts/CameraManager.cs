using UnityEngine;
[RequireComponent(typeof(InputManager))]

public class CameraManager : MonoBehaviour
{
    public GameObject focus;//
    public float distance = 5f;//
    public float height = 2f;//
    public float dampening = 1f;//
    private int camMode = 0;
    private protected int NumOfCam = 5;
    public float h2 = 0.7f;
    public float d2 = -0.07f;
    public float l2 = -0.32f;

    public float h = 0.7f;
    public float d = -0.07f;
    public float l = -0.32f;

    public float h1 = 0.7f;
    public float d1 = -0.07f;
    public float l1 = -0.32f;

    public InputManager In; // 
    void Start()
    {

        In = GetComponent<InputManager>();

    }
    // Update is called once per frame
    void Update()
    {
        if (In.CamView)
        {
            camMode = (camMode + 1) % NumOfCam;
        }
        switch (camMode)
        {
            case 1:
                transform.position = Vector3.Lerp(transform.position, focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)), dampening * Time.deltaTime);// slowely follows the car
                transform.LookAt(focus.transform);
                Camera.main.fieldOfView = 60f;
                break;
            case 2:
                transform.position = focus.transform.position + focus.transform.TransformDirection(new Vector3(l2, h2, d2)); // stays behind the car
                transform.rotation = focus.transform.rotation;
                Camera.main.fieldOfView = 90f;
                break;
            case 3:
                transform.position = focus.transform.position + focus.transform.TransformDirection(new Vector3(l, h, d)); // stays behind the car
                transform.rotation = focus.transform.rotation;
                Camera.main.fieldOfView = 90f;
                break;
            case 4:
                transform.position = focus.transform.position + focus.transform.TransformDirection(new Vector3(l1, h1, d1)); // stays behind the car
                transform.rotation = focus.transform.rotation;
                Camera.main.fieldOfView = 90f;
                break;

            default:
                transform.position = focus.transform.position + focus.transform.TransformDirection(new Vector3(0f, height, -distance)); // stays behind the car
                transform.LookAt(focus.transform);
                Camera.main.fieldOfView = 60f;
                break;

        }
    }
}
