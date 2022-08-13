using System.Collections;
using UnityEngine;

public class HumanoidLandController : MonoBehaviour
{
    public Transform CameraFollow;

    Rigidbody _rigidbody;
    [SerializeField] CapsuleCollider _capsuleCollider;

    [SerializeField] HumanoidLandInput _input;
    [SerializeField] CameraController CameraController;

    Vector3 _playerMoveInput;
    Vector3 _playerLookInput = Vector3.zero;
    Vector3 _previousPlayerLookInput = Vector3.zero;
    float _cameraPitch = 0f;
    [SerializeField] float _playerLookLerpTime = 0.35f;

    [Header("Movement")]
    [SerializeField] float _movementMultiplier = 30f;
    [SerializeField] float _notGroundedMovementMultiplier = 1.25f;
    [SerializeField] float _notGroundedFallingMovementMultiplier = 0.01f;
    [SerializeField] float _hasNotBeenGroundedFor;
    [SerializeField] float _rotationSpeedMultiplier = 180f;
    [SerializeField] float _pitchSpeedMultiplier = 180f;
    [SerializeField] float _runSpeedMultiplier = 2.5f;

    [Header("GroundCheck")]
    [SerializeField] bool _playerIsGrounded = true;
    [SerializeField] [Range(0.0f, 1.8f)] float _groundCheckRadiusMultiplier = 0.9f;
    [SerializeField] [Range(-0.95f, 1.05f)] float _groundCheckDistance = 0.05f;
    RaycastHit _groundChaeckHit = new RaycastHit();

    [Header("Gravity")]
    [SerializeField] float _gravityFallCurrent = -100f;
    [SerializeField] float _gravityFallMin = -100f;
    [SerializeField] float _gravityFallMax = -500f;
    [SerializeField] [Range(-0.5f, -1000.0f)] float _gravityFallIncrementAmount = -20f;
    [SerializeField] float _gravityFallIncrementTime = 0.05f;
    [SerializeField] float _PlayerFallTimer = 0f;
    [SerializeField] float _gravity = 0f;

    [Header("Jumping")]
    [SerializeField] float _initialJumpForce = 750f;
    [SerializeField] float _countinueJumpForceMultiplier = 0.1f;
    [SerializeField] float _jumpTime = 0.175f;
    [SerializeField] float _jumpTimeCounter;
    [SerializeField] float _coyoteTime = 0.15f;
    [SerializeField] float _coyoteTimeCounter;
    [SerializeField] float _jumpBufferTime = 0.2f;
    [SerializeField] float _jumpBufferTimeCounter;
    [SerializeField] bool _playerIsJumping = false;
    [SerializeField] bool _jumpWasPressedLastFrame = false;

    [SerializeField] GameObject TestBlock;

    int counter;
    [SerializeField] float PlaceBlockCooldown;
    [SerializeField] float RemoveBlockCooldown;
    bool IsPlaceBlockCooldownActive;
    bool IsRemoveBlockCooldownActive;
    bool PlaceCooldownActive;
    bool RemoveCooldownActive;

    Ray rayCamera;
    Ray rayBlock;
    RaycastHit hitPlace;
    RaycastHit hitRemove;
    public float rayMaxDistance;

    public LayerMask blockLayer;
    public LayerMask playerLayer;

    //Blockplacering
    private Vector3 Uppe = new Vector3(0f, 1f, 0f);
    private Vector3 Framme = new Vector3(0f, 0f, 1f);
    private Vector3 Höger = new Vector3(-1f, 0f, 0f);
    private Vector3 Vänster = new Vector3(1f, 0f, 0f);
    private Vector3 Bak = new Vector3(0f, 0f, -1f);
    private Vector3 Under = new Vector3(0f, -1f, 0f);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerLookInput = GetLookInput();
        PlayerLook();
        PitchCamera();

        _playerMoveInput = GetMoveInput();
        _playerIsGrounded = PlayerGroundCheck();

        _playerMoveInput = PlayerMove();
        _playerMoveInput = PlayerRun();

        _playerMoveInput.y = PlayerGravity();
        _playerMoveInput.y = PlayerJump();

        _rigidbody.AddRelativeForce(_playerMoveInput, ForceMode.Force);

        if (PlaceCooldownActive)
        {
            Cooldown(PlaceBlockCooldown);
        }
        else if (RemoveCooldownActive)
        {
            Cooldown(RemoveBlockCooldown);
        }
    }
    private void Update()
    {
        PlaceBlock();
        RemoveBlock();
    }
    public void Cooldown(float Cooldown)
    {
        counter += 1;
        if (counter >= 50 * Cooldown) //Vad som händer när 1 sekund har gått
        {
            IsPlaceBlockCooldownActive = false;
            IsRemoveBlockCooldownActive = false;

            counter = 0;
            PlaceCooldownActive = false;
            RemoveCooldownActive = false;
        }
    }

    private Vector3 GetLookInput()
    {
        _previousPlayerLookInput = _playerLookInput;
        _playerLookInput = new Vector3(_input.LookInput.x, _input.InvertMouseY ? -_input.LookInput.y : _input.LookInput.y, 0.0f);
        return Vector3.Lerp(_previousPlayerLookInput, _playerLookInput * Time.deltaTime, _playerLookLerpTime);
    }

    private void PlayerLook()
    {
        _rigidbody.rotation = Quaternion.Euler(0.0f, _rigidbody.rotation.eulerAngles.y + (_playerLookInput.x * _rotationSpeedMultiplier), 0.0f);
    }
    private void PitchCamera()
    {
        _cameraPitch += _playerLookInput.y * _pitchSpeedMultiplier;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -89.9f, 89.8f);

        CameraFollow.rotation = Quaternion.Euler(_cameraPitch, CameraFollow.rotation.eulerAngles.y, CameraFollow.rotation.eulerAngles.z);
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(_input.MoveInput.x, 0f, _input.MoveInput.y);
    }
    private Vector3 PlayerMove()
    {
        Vector3 calculatedPlayerMovement;
        if (_playerIsGrounded)
        {
            calculatedPlayerMovement = (new Vector3(_playerMoveInput.x * _movementMultiplier * _rigidbody.mass,
                                                            _playerMoveInput.y * _rigidbody.mass,
                                                            _playerMoveInput.z * _movementMultiplier * _rigidbody.mass));

        }
        else if (_hasNotBeenGroundedFor < 0.1f)
        {
            calculatedPlayerMovement = (new Vector3(_playerMoveInput.x * (_movementMultiplier * _notGroundedMovementMultiplier) * _rigidbody.mass,
                                                            _playerMoveInput.y * _rigidbody.mass,
                                                            _playerMoveInput.z * (_movementMultiplier * _notGroundedMovementMultiplier) * _rigidbody.mass));
        }
        else
        {
            calculatedPlayerMovement = (new Vector3(_playerMoveInput.x * (_movementMultiplier * _notGroundedFallingMovementMultiplier) * _rigidbody.mass,
                                                            _playerMoveInput.y * _rigidbody.mass,
                                                            _playerMoveInput.z * (_movementMultiplier * _notGroundedFallingMovementMultiplier) * _rigidbody.mass));
        }
        return calculatedPlayerMovement;
    }
    private bool PlayerGroundCheck()
    {
        float sphereCastRadius = _capsuleCollider.radius * _groundCheckRadiusMultiplier;
        float sphereCastTravelDistance = _capsuleCollider.bounds.extents.y - sphereCastRadius + _groundCheckDistance;
        return Physics.SphereCast(_rigidbody.position, sphereCastRadius, Vector3.down, out _groundChaeckHit, sphereCastTravelDistance);
    }
    private float PlayerGravity()
    {
        if (_playerIsGrounded)
        {
            _gravity = 0.0f;
            _gravityFallCurrent = _gravityFallMin;
        }
        else
        {
            _PlayerFallTimer -= Time.fixedDeltaTime;
            if (_PlayerFallTimer < 0.0f)
            {
                if (_gravityFallCurrent > _gravityFallMax)
                {
                    _gravityFallCurrent += _gravityFallIncrementAmount;
                }
                _PlayerFallTimer = _gravityFallIncrementTime;
            }
            _gravity = _gravityFallCurrent;
        }
        return _gravity;
    }
    private Vector3 PlayerRun()
    {
        Vector3 calculatedRunSpeed = _playerMoveInput;
        if (_input.RunIsPressed)
        {
            calculatedRunSpeed.x *= _runSpeedMultiplier;
            calculatedRunSpeed.z *= _runSpeedMultiplier;
        }
        return calculatedRunSpeed;
    }
    private float PlayerJump()
    {
        float calculatedJumpInput = _playerMoveInput.y;

        SetJumpTimeCounter();
        SetCoyoteTimeCounter();
        SetJumpBufferCounter();

        if (_jumpBufferTimeCounter > 0.0f && !_playerIsJumping && _coyoteTimeCounter > 0.0f)
        {
            calculatedJumpInput = _initialJumpForce;
            _playerIsJumping = true;
            _jumpBufferTimeCounter = 0.0f;
            _coyoteTimeCounter = 0.0f;
        }
        else if (_input.JumpIsPressed && _playerIsJumping && !_playerIsGrounded && _jumpTimeCounter > 0.0f)
        {
            calculatedJumpInput = _initialJumpForce * _countinueJumpForceMultiplier;
        }
        else if (_playerIsJumping && _playerIsGrounded)
        {
            _playerIsJumping = false;
        }
        return calculatedJumpInput;
    }
    private void SetJumpTimeCounter()
    {
        if (_playerIsJumping && !_playerIsGrounded)
        {
            _jumpTimeCounter -= Time.fixedDeltaTime;
        }
        else
        {
            _jumpTimeCounter = _jumpTime;
        }
    }
    private void SetCoyoteTimeCounter()
    {
        if (_playerIsGrounded)
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.fixedDeltaTime;
        }
    }
    private void SetJumpBufferCounter()
    {
        if (!_jumpWasPressedLastFrame && _input.JumpIsPressed)
        {
            _jumpBufferTimeCounter = _jumpBufferTime;
        }
        else if (_jumpBufferTimeCounter > 0.0f)
        {
            _jumpBufferTimeCounter -= Time.fixedDeltaTime;
        }
        _jumpWasPressedLastFrame = _input.JumpIsPressed;
    }
    private void PlaceBlock()
    {
        if (_input.PlaceBlockInput == 1f && !IsPlaceBlockCooldownActive) //Om input för PlaceBlockInput och om de tinte är cooldown
        {
            BlockHitAngle();

            PlaceCooldownActive = true;
            IsPlaceBlockCooldownActive = true;
        }
    }
    private void BlockHitAngle()
    {
        Debug.DrawRay(CameraController.cam.transform.position, CameraController.cam.transform.forward * rayMaxDistance, Color.yellow, 2f);
        rayCamera = new Ray(CameraController.cam.transform.position, CameraController.cam.transform.forward);
        if (Physics.Raycast(rayCamera, out hitPlace, rayMaxDistance, blockLayer)) //Om ett block blir träffat
        {

            if (hitPlace.normal == Uppe)             //Uppe
            {
                rayBlock = new Ray(hitPlace.transform.position, Uppe);
                if (!Physics.CheckBox(hitPlace.transform.position + Uppe, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Uppe, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Uppe, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else if (hitPlace.normal == Framme)      //Framme
            {
                rayBlock = new Ray(hitPlace.transform.position, Framme);
                if (!Physics.CheckBox(hitPlace.transform.position + Framme, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Framme, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Framme, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else if (hitPlace.normal == Höger)       //Höger
            {
                rayBlock = new Ray(hitPlace.transform.position, Höger);
                if (!Physics.CheckBox(hitPlace.transform.position + Höger, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Höger, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Höger, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else if (hitPlace.normal == Vänster)     //Vänster
            {
                rayBlock = new Ray(hitPlace.transform.position, Vänster);
                if (!Physics.CheckBox(hitPlace.transform.position + Vänster, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Vänster, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Vänster, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else if (hitPlace.normal == Bak)         //Bak
            {
                rayBlock = new Ray(hitPlace.transform.position, Bak);
                if (!Physics.CheckBox(hitPlace.transform.position + Bak, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Bak, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Bak, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else if (hitPlace.normal == Under)       //Under
            {
                rayBlock = new Ray(hitPlace.transform.position, Under);
                if (!Physics.CheckBox(hitPlace.transform.position + Under, new Vector3(0.45f, 0.45f, 0.45f), Quaternion.identity, playerLayer))
                {
                    Debug.DrawRay(hitPlace.transform.position, Under, Color.blue, 3f);
                    Instantiate(TestBlock, hitPlace.transform.position + Under, Quaternion.identity);
                }
                else { Debug.Log("Det fanns redan ett block / person där"); }
            }
            else
        { Debug.Log("Nu hände något knas"); }

        }
    }
    private void RemoveBlock()
    {
        if (_input.RemoveBlockInput == 1f && !IsRemoveBlockCooldownActive) //Om input för PlaceBlockInput och om de tinte är cooldown
        {
            rayCamera = new Ray(CameraController.cam.transform.position, CameraController.cam.transform.forward);
            if (Physics.Raycast(rayCamera, out hitRemove, rayMaxDistance, blockLayer)) //Om ett block blir träffat
            {
                Destroy(hitRemove.transform.gameObject);
            }

            RemoveCooldownActive = true;
            IsRemoveBlockCooldownActive = true;
        }
    }
}
