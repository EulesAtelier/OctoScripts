using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
/*
    This code was written from a tutorial by LoneX
    https://www.youtube.com/watch?v=F82BlnW5z6g
*/
public class SoftbodyScript : MonoBehaviour
{
    #region  Constants
    private const float splineOffset = 0.5f;
    #endregion
    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;
    #endregion
    // Awake is called before the first frame
    void Awake()
    {
        UpdateVertices();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVertices();
    }
    #region privateMethods
    private void UpdateVertices(){
        for(int i = 0; i < points.Length - 1;i++){
            Vector2 _vertex = points[i].localPosition;
            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;
            float _colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch{
                Debug.Log("Spline points are to close to each other, recalculate");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius+splineOffset)));
            }
            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);

            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);

            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetRightTangent(i, _newLt);
            
        }
    }
    #endregion
}
