using UnityEngine;

public class SphericalCartesianConverter : MonoBehaviour
{
    public GameObject brain;
    public float rotationSpeed = 20.0f;
    private Vector3 brainPosition;
    private Vector2 motion;

    struct BoundsData
    {
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        public float minZ;
        public float maxZ;
    }

    BoundsData GetBoundsFromMesh(Mesh mesh)
    {
        var result = new BoundsData();
        
        for (int i = 0; i < mesh.vertices.Length; i++) {
            //mesh.vertices[i];
        }
        return result;
    }
    
    float GetCenterPoint(float min, float max)
    {
        return min + (max - min) / 2;
    }
    
    void Start () 
    {
        //var brainMesh = brain.GetComponentInChildren<MeshFilter>().mesh;
        //var centerPoint = GetBoundsFromMesh(brainMesh);
        brainPosition = new Vector3(0f, 1f, 1f);
        //    GetCenterPoint(centerPoint.minX, centerPoint.maxX), 
        //    GetCenterPoint(centerPoint.minY, centerPoint.maxY), 
        //    GetCenterPoint(centerPoint.minZ, centerPoint.maxZ));
        transform.LookAt(brainPosition);
    }
    void Update(){
        motion = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        transform.RotateAround(brainPosition, motion, rotationSpeed * Time.deltaTime);
    }
}
