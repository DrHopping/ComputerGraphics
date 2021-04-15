using System;
using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer
{
    public class CameraProvider : ICameraProvider
    {
        private readonly IRayProvider _rayProvider;

        public CameraProvider(IRayProvider rayProvider)
        {
            this._rayProvider = rayProvider;
        }

        public Camera GetCamera()
        {
            return new Camera(300, 300, MathF.PI / 3, _rayProvider)
            {
                Direction = Vector3.UnitZ,
                Origin = Vector3.Zero,
                Transform = Matrix4x4.CreateLookAt(
                    new Vector3(0, 0, 5.5f),
                    new Vector3(0, 0, 0),
                    new Vector3(0, 1, 0)
                )
            };
        }
                
        
    }
}