using UnityEngine;

public class BaseCharacterRotation : MonoBehaviour
{
    [SerializeField]
    protected float smoothForCharacter = 10;
    [SerializeField]
    protected float smoothForCamera = 5;
    [SerializeField]
    protected float rotationSpeed = 0.5f;
    [SerializeField]
    protected Transform character;
    protected float yRotation;
    protected float xRotation;
    protected float yMRotation;
    protected float xMRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected void Update()
    {
        yRotation += Input.GetAxis("Horizontal") * rotationSpeed;
        xRotation = Input.GetAxis("Vertical") * rotationSpeed;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    }

    protected void RotateCharacter()
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * smoothForCharacter);
        character.rotation = Quaternion.Lerp(character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * smoothForCamera);
        
    }
}
