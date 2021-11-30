using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
namespace PortalsVR
{
    [RequireComponent(typeof(Camera))]
    public class Eye : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Camera.StereoscopicEye eye;
        #endregion

        #region Properties
        public Camera Camera { get; private set; }
        public List<Portal> Portals { get; set; } = new List<Portal>();
        #endregion

        #region Methods
        private void Awake()
        {
            Camera = GetComponent<Camera>();
            RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        }

        void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            // Put the code that you want to execute before the camera renders here
            // If you are using URP or HDRP, Unity calls this method automatically
            // If you are writing a custom SRP, you must call RenderPipeline.BeginCameraRendering
            for (int i = 0; i < Portals.Count; i++)
            {
                Portals[i].Render(eye);
            }
        }

        void OnDestroy()
        {
            RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        }
        #endregion
    }
}