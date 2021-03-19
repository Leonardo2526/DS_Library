using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;

using System.Diagnostics;

namespace DS_NW_CurrentView_Info
{
    [Plugin("TestPlugin_Rotation", "DS", ToolTip = "", DisplayName = "TestPlugin_Rotation")]

    public class DS_CurrentView_Info : AddInPlugin
    //Get information about current view in debug mode
    {
        public override int Execute(params string[] parameters)
        {
            Program();

            return 0;
        }

        public void Program()
        {


            Document oDoc =

                Autodesk.Navisworks.Api.Application.ActiveDocument;

            // get current viewpoint

            Viewpoint oCurVP = oDoc.CurrentViewpoint;



            // common properties

            Debug.Print("Far Plane Distance: " +

                    oCurVP.FarPlaneDistance);

            Debug.Print("Near Plane Distance: " +

                    oCurVP.NearPlaneDistance);

            Debug.Print("Projection: " +

                    oCurVP.Projection);

            Debug.Print("Aspect Ratio: " +

                    oCurVP.AspectRatio);





            if (oCurVP.HasLinearSpeed)

                Debug.Print("Linear Speed: " +

                    oCurVP.LinearSpeed);

            else

                Debug.Print("Linear Speed: <None>");

            if (oCurVP.HasAngularSpeed)

                Debug.Print("Angular Speed: " +

                    oCurVP.AngularSpeed);

            else

                Debug.Print("Angular Speed: <None>");

            if (oCurVP.HasLighting)

                Debug.Print("Lighting: " +

                    oCurVP.Lighting);

            else

                Debug.Print("Lighting: <None>");



            if (oCurVP.HasRenderStyle)

                Debug.Print("RenderStyle: " +

                    oCurVP.RenderStyle);

            else

                Debug.Print("RenderStyle:<None> " +

                    oCurVP.RenderStyle);



            if (oCurVP.HasTool)

                Debug.Print("Tool: " +

                    oCurVP.Tool);

            else

                Debug.Print("Tool:<None> " +

                    oCurVP.Tool);





            // camera properties

            double oFocal =

                oCurVP.FocalDistance;

            Debug.Print("Focal Distance: " +

                oFocal);

            // Rotation

            Rotation3D oRot = oCurVP.Rotation;

            //Debug.Print("Quaternion: <A (x),B(y),C(z),D(w)> = <{0},{1},{2},{3}> ",  
            Debug.Print("Quaternion: " + oRot.A + "," + oRot.B + "," + oRot.C + "," + oRot.D);



            // calculate view direction

            Rotation3D oNegtiveZ =

                new Rotation3D(0, 0, -1, 0);

            Rotation3D otempRot =

                MultiplyRotation3D(oNegtiveZ, oRot.Invert());

            Rotation3D oViewDirRot =

                MultiplyRotation3D(oRot, otempRot);

            // get view direction

            Vector3D oViewDir =

                new Vector3D(oViewDirRot.A,

                            oViewDirRot.B,

                            oViewDirRot.C);

            oViewDir.Normalize();

            Debug.Print("View Direction:<{0},{1},{2}> ",

                        oViewDir.X,

                        oViewDir.Y,

                        oViewDir.Z);

            // position

            Point3D oPos = oCurVP.Position;

            Debug.Print("Position:<{0},{1},{2}> ",

                        oPos.X,

                        oPos.Y,

                        oPos.Z);

            // target

            Point3D oTarget =

                new Point3D(oPos.X + oViewDir.X * oFocal,

                            oPos.Y + oViewDir.Y * oFocal,

                            oPos.Z + oViewDir.Z * oFocal);

            Debug.Print("Target:<{0},{1},{2}> ",

                            oTarget.X,

                            oTarget.Y,

                            oTarget.Z);



            // rotation information

            AxisAndAngleResult oAR =

                oRot.ToAxisAndAngle();

            Debug.Print("Rotation Axis:<{0},{1},{2}> ",

                        oAR.Axis.X,

                        oAR.Axis.Y,

                        oAR.Axis.Z);



            Debug.Print("Rotation Angle: " +

                oAR.Angle);



        }

        private Rotation3D MultiplyRotation3D(Rotation3D r2, Rotation3D r1)

        {

            Rotation3D oRot =

                new Rotation3D(r2.D * r1.A + r2.A * r1.D +

                                   r2.B * r1.C - r2.C * r1.B,

                               r2.D * r1.B + r2.B * r1.D +

                                   r2.C * r1.A - r2.A * r1.C,

                               r2.D * r1.C + r2.C * r1.D +

                                  r2.A * r1.B - r2.B * r1.A,

                               r2.D * r1.D - r2.A * r1.A -

                                  r2.B * r1.B - r2.C * r1.C);





            oRot.Normalize();

            return oRot;

        }
    }


}
