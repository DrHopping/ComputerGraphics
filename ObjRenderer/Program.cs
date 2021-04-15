using System;
using System.Buffers;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;
using ObjRenderer.Extensions;
using ObjRenderer.Light;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Shapes;

namespace ObjRenderer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            var tr1 = new Triangle(
                new Vector3(-1,-1,-5), 
                new Vector3(1,-1,-5), 
                new Vector3(0,1,-5)
                );
            var tr2 = new Triangle(
                new Vector3(3.13f, 1.71f, 0.81f),
                new Vector3(4.08f, 0.59f, 1.68f),
                new Vector3(1.4f, 1.4f, 2.31f)
            );

            var ray = new Ray(new Vector3(0,0,0), new Vector3(0.1f, -0.1f, -1.0f));

            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                tr1.Intersect(ray);
                tr2.Intersect(ray);
            }

            Console.WriteLine(timer.ElapsedMilliseconds);
            */



            var cow = new ObjParser(File.ReadAllText("cow.obj")).ToGroup().ToMesh();
            cow.Transform(Matrix.RotationX(MathF.PI / 2).Scale(5, 5, 5));
            //cow.Transform = Matrix.Scaling(2, 2, 2) * Matrix.RotationX( -MathF.PI/ 2);

            //var diamond = new ObjParser(File.ReadAllText("diamond.obj")).ToGroup();
            //diamond.Transform = Matrix.Scaling(0.1f, 0.1f, 0.1f) * Matrix.RotationX(-MathF.PI / 2);

            //var swords = new ObjParser(File.ReadAllText("SWORDS.obj")).ToGroup()[0];
            //swords.Transform = Matrix.Scaling(0.1f, 0.1f, 0.1f) * Matrix.RotationX(-MathF.PI / 2);


            var sphere = new Sphere(1f, Vector3.Zero);
            //sphere.Transform = Matrix.Translation(0,0,0);
            // var sphere2 = new Sphere();
            var scene = new Scene();

            //scene.Objects.Add(sphere);
            //scene.Objects.Add(triangle);
            // scene.Objects.Add(sphere2);
            //scene.Objects.Add(sphere);
            scene.Objects.Add(cow);
            /*scene.Camera.Transform = Matrix.View(
                new Point(0, 0, 10),
                new Point(0, 0, 0),
                new Vector(0, 1, 0));*/
            scene.Light = new PointLight(new Vector3(0, 0, 100));
            scene.Camera.Transform = Matrix4x4.CreateLookAt(
                new Vector3(0,0,5.5f),
                new Vector3(0,0,0),
                new Vector3(0,1,0)
                );



            var tracer = new MultiThreadRayTracer(new FlatShading());
            var image = tracer.Render(scene);
            var sr = new StreamWriter("output.ppm");
            await image.ToPpmAsync(sr.BaseStream);
        }
    }
}
