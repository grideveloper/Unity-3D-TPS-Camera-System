//--------------------------------------
//created by grigamedevelopment.com.tr
//BURAK KARADAG / karadagburak1881@gmail.com
//-----------------------------------------
//ADD INSIDE YOUR SCRIPT

if (verticalMovement == 0 && horizontalMovement == 0)
{
    _playerRotationTimeValue += 4f * Time.deltaTime;
    Quaternion referenceRotation = _defaultCameraParent.localRotation;
    if (!_canRotate)
    {
        _playerCameraParent.localRotation = Quaternion.Lerp(_playerCameraParent.localRotation, Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, referenceRotation.y, _playerCameraParent.localRotation.z), _playerRotationTimeValue);
    }
    if ((Mathf.Approximately(_playerCameraParent.localRotation.normalized.y, referenceRotation.normalized.y) && !_canRotate))
    {
        _cameraHorizontalRotation.y = 0;
        _canRotate = true;
    }
    if (_canRotate)
    {
        _cameraHorizontalRotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
        _playerCameraParent.localRotation = Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, _cameraHorizontalRotation.y, 0f);
    }
    _isGunRotateTimer = false;
}
else if (verticalMovement != 0 || horizontalMovement != 0)
{
    if (verticalMovement != 0)
    {
        if (verticalMovement > 0)
        {
            _playerHorizontalAndCameraVerticalRotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _playerCameraParent.localRotation = Quaternion.Lerp(_playerCameraParent.localRotation, Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, 0, 0), (verticalMovementAbs * 25) * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _playerHorizontalAndCameraVerticalRotation.y, 0f), (verticalMovementAbs * 25) * Time.deltaTime);
        }
        else if (verticalMovement < 0)
        {
            _playerHorizontalAndCameraVerticalRotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _playerCameraParent.localRotation = Quaternion.Lerp(_playerCameraParent.localRotation, Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, 180, 0), (verticalMovementAbs * 25) * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _playerHorizontalAndCameraVerticalRotation.y, 0f), (verticalMovementAbs * 25) * Time.deltaTime);
        }
    }
    if (horizontalMovement != 0)
    {
        if (horizontalMovement > 0)
        {
            _playerHorizontalAndCameraVerticalRotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _playerCameraParent.localRotation = Quaternion.Lerp(_playerCameraParent.localRotation, Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, 90, 0), (horizontalMovementAbs * 25) * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _playerHorizontalAndCameraVerticalRotation.y, 0f), (horizontalMovementAbs * 25) * Time.deltaTime);
        }
        else if (horizontalMovement < 0)
        {
            _playerHorizontalAndCameraVerticalRotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _playerCameraParent.localRotation = Quaternion.Lerp(_playerCameraParent.localRotation, Quaternion.Euler(_playerHorizontalAndCameraVerticalRotation.x, -90, 0), (horizontalMovementAbs * 25) * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _playerHorizontalAndCameraVerticalRotation.y, 0f), (horizontalMovementAbs * 25) * Time.deltaTime);
        }
    }
    _isGunRotateTimer = false;
    _canRotate = false;
    _playerRotationTimeValue = 0;
}