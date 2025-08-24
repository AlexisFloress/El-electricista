using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAssetMap;

    [Header("Action Map Names")]
    [SerializeField] private string _actionMapName;
    [SerializeField] private string _inputActionMoveName;
    [SerializeField] private string _inputActionLookName;

    private InputAction _moveAction;
    private InputAction _lookAction;

    public Vector2 MoveInput;
    public Vector2 LookInput;

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        _moveAction = _actionAssetMap.FindActionMap(_actionMapName).FindAction(_inputActionMoveName);
        _lookAction = _actionAssetMap.FindActionMap(_actionMapName).FindAction(_inputActionLookName);

        RegisterInputs();
    }

     private void OnEnable()
    {
        _moveAction.Enable();
        _lookAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
    }

    private void RegisterInputs()
    {
        _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveAction.canceled += context => MoveInput = Vector2.zero;

        _lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        _lookAction.canceled += context => LookInput = Vector2.zero;
    }
}
