using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using ObjRenderer.Extensions;
using ObjRenderer.Light;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Shapes;
using ObjRenderer.Tuples;

namespace ObjRenderer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tr1 = new Triangle(
                new Point(-1,-1,-5), 
                new Point(1,-1,-5), 
                new Point(0,1,-5)
                );
            var tr2 = new Triangle(
                new Point(3.13f, 1.71f, 0.81f),
                new Point(4.08f, 0.59f, 1.68f),
                new Point(1.4f, 1.4f, 2.31f)
            );

            var ray = new Ray(new Point(0,0,0), new Vector(0.1f, -0.1f, -1.0f));

            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 100000; i++)
            {
                tr1.Intersect(ray);
                tr2.Intersect(ray);
            }

            Console.WriteLine(timer.ElapsedMilliseconds);



            var cow = new ObjParser(File.ReadAllText("simplecow2.obj")).ToGroup();
            cow.Transform = Matrix.Scaling(2, 2, 2) * Matrix.RotationX( -MathF.PI/ 2);

            var diamond = new ObjParser(File.ReadAllText("diamond.obj")).ToGroup();
            diamond.Transform = Matrix.Scaling(0.1f, 0.1f, 0.1f) * Matrix.RotationX(-MathF.PI / 2);

            var swords = new ObjParser(File.ReadAllText("SWORDS.obj")).ToGroup()[0];
            //swords.Transform = Matrix.Scaling(0.1f, 0.1f, 0.1f) * Matrix.RotationX(-MathF.PI / 2);


            var sphere = new Sphere();
            sphere.Transform = Matrix.Translation(0,0,0);
            // var sphere2 = new Sphere();
            var scene = new Scene();
            
            //scene.Objects.Add(sphere);
            //scene.Objects.Add(triangle);
            // scene.Objects.Add(sphere2);
            scene.Objects.Add(cow);
            scene.Camera.Transform = Matrix.View(
                new Point(0, 0, 10),
                new Point(0, 0, 0),
                new Vector(0, 1, 0));
            scene.Light = new PointLight(new Point(0,0,100));




            var tracer = new MultiThreadRayTracer(new FlatShading());
            var image = tracer.Render(scene);
            var sr = new StreamWriter("output.ppm");
            await image.ToPpmAsync(sr.BaseStream);
        }
    }
}
