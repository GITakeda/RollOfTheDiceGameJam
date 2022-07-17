using System.Collections;
using UnityEngine;

enum FaceType
{
    FrontFace,
    UpFace
}

public class Movement : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 5;
    [SerializeField] private Vector2 _startingPosition = new Vector2();

    [SerializeField] private Transform _face;
    [SerializeField] private SpriteRenderer _faceSprite;
    [SerializeField] private Vector3 _faceOffset;

    [SerializeField] private Transform _handLeft;
    [SerializeField] private Transform _handRight;
    [SerializeField] private SpriteRenderer _handLeftSprite;
    [SerializeField] private SpriteRenderer _handRighSprite;
    [SerializeField] private Vector3 _handOffset;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _weaponSprite;
    [SerializeField] private Vector3 _weaponOffset;
    [SerializeField] private DiceFace[] _faces;
    [SerializeField] private FaceType faceType;

    [SerializeField] private FaceIndicator faceIndicator;

    public DiceFace faceUp;
    public DiceFace faceRight;
    public DiceFace faceDown;
    public DiceFace faceLeft;
    public DiceFace faceCur;

    private bool _isMoving;

    private Vector3 lastDir;

    private void Awake()
    {
        CalculateFaceOffset();
        CalculateWeaponOffset();
        CalculateHandOffset();
        CheckFaces();

        this.transform.position = new Vector3(_startingPosition.x, 0, _startingPosition.y);
    }

    private void FixedUpdate()
    {
        if (_isMoving) return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) Assemble(Vector3.left);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) Assemble(Vector3.right);
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) Assemble(Vector3.forward);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) Assemble(Vector3.back);
    }

    void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);
        lastDir = dir;
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            CalculateFaceOffset();
            CalculateWeaponOffset();
            CalculateHandOffset();
            yield return new WaitForSeconds(0.01f);
        }

        var playerPos = Camera.main.WorldToScreenPoint(transform.position);

        if (playerPos.x > Camera.main.pixelWidth || playerPos.x < 0 || playerPos.y > Camera.main.pixelHeight || playerPos.y < 0)
        {
            //this.transform.position = new Vector3(-transform.position.x, transform.position.y, -transform.position.z);
            CheckFaces();
            UpdateProperties();
            Assemble(lastDir * -1);
        }
        else
        {
            CheckFaces();
            UpdateProperties();
            _isMoving = false;
        }
    }

    private void CheckFaces()
    {
        foreach (DiceFace face in _faces)
        {
            if (face.transform.position.y > 0.4f)
            {
                faceCur = face;
            }

            var facePositionRelativeToBody = this.transform.position - face.transform.position;

            if (facePositionRelativeToBody.z > 0.4f)
            {
                faceUp = face;
            }

            if (facePositionRelativeToBody.z < -0.4f)
            {
                faceDown = face;
            }

            if (facePositionRelativeToBody.x > 0.4f)
            {
                faceRight = face;
            }

            if (facePositionRelativeToBody.x < -0.4f)
            {
                faceLeft = face;
            }
        }

        UpdateProperties();
    }

    private void UpdateProperties()
    {
        faceIndicator.UpdateDirections();
        _weapon.SetWeaponProperties(faceCur.weaponProperties);

        Sprite newFaceSprite = null;

        switch (faceType)
        {
            case FaceType.UpFace:
                newFaceSprite = faceCur.weaponProperties.faceSprite;
                break;
            case FaceType.FrontFace:
                newFaceSprite = faceUp.weaponProperties.faceSprite;
                break;
        }

        _faceSprite.sprite = newFaceSprite;
    }

    private void CalculateFaceOffset()
    {
        _face.position = transform.position + _faceOffset;
    }

    private void CalculateWeaponOffset()
    {
        _weapon.transform.position = transform.position + _handOffset;
        _weaponSprite.transform.position = transform.position + _weaponOffset;
    }

    private void CalculateHandOffset()
    {
        _handLeft.transform.position = transform.position +  new Vector3(-1 * _handOffset.x, -1 * _handOffset.y, _handOffset.z);
        _handRight.transform.position = transform.position + _handOffset;
    }
}