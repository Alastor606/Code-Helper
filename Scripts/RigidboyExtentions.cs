using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using Unity.VisualScripting;

namespace CodeHelper.Unity
{
    internal static class RigidboyExtentions
    {
        #region Rigibody
        /// <summary>
        /// Make simulation of jump with given force
        /// </summary>
        /// <param name="force"> The force of rigidbody with you want to jump</param>
        internal static void Jump<T>(this T self, float force) where T : Rigidbody =>
            self.AddForce(new Vector3(0, 200 + force));

        /// <summary>
        /// Moves Rigidbody to given direction with given speed
        /// </summary>
        /// <param name="direction"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveTo<T>(this T self, Vector3 direction, float speed) where T : Rigidbody =>
            self.velocity = direction * speed;

        /// <summary>
        /// Moves Rigidbody to given position with given speed
        /// </summary>
        /// <param name="pos"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveTo<T>(this T self, Transform pos, float speed) where T : Rigidbody =>
            self.velocity = Vector3.MoveTowards(self.position, pos.position, speed);

        /// <summary>
        /// Moves Rigidbody by x direction
        /// </summary>
        /// <param name="direction"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveX<T>(this T self, float direction, float speed) where T : Rigidbody =>
             self.velocity = new Vector3(direction * speed, self.velocity.y);

        /// <summary>
        /// Moves Rigidbody by z direction
        /// </summary>
        /// <param name="direction"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveZ<T>(this T self, float direction, float speed) where T : Rigidbody =>
            self.velocity = new Vector3(self.velocity.x, self.velocity.y, direction * speed);

        /// <summary>Moves Rigidbody by Y direction (not jump)</summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        internal static void MoveY<T>(this T self, float direction, float speed) where T : Rigidbody =>
            self.velocity = new Vector3(self.velocity.x, direction*speed, self.velocity.z);

        /// <summary> UnFreeze Rotation by x of rigidbody </summary>>
        internal static void UnFreezeRotationX<T>(this T self) where T : Rigidbody =>
            self.constraints &= ~RigidbodyConstraints.FreezeRotationX;


        /// <summary> UnFreeze Rotation by Y of rigidbody </summary>>
        internal static void UnFreezeRotationY<T>(this T self) where T : Rigidbody =>
            self.constraints &= ~RigidbodyConstraints.FreezeRotationY;


        /// <summary> UnFreeze Rotation by Z of rigidbody </summary>>
        internal static void UnFreezeRotationZ<T>(this T self) where T : Rigidbody =>
           self.constraints &= ~RigidbodyConstraints.FreezeRotationZ;


        /// <summary>Freeze Rotation by y of rigidbody </summary>>
        internal static void FreezeRotationY<T>(this T self) where T : Rigidbody =>
           self.constraints = RigidbodyConstraints.FreezeRotationY;


        /// <summary>Freeze Rotation by x of rigidbody </summary>>
        internal static void FreezeRotationX<T>(this T self) where T : Rigidbody =>
           self.constraints = RigidbodyConstraints.FreezeRotationX;


        /// <summary>Freeze Rotation by Z of rigidbody </summary>>
        internal static void FreezeRotationZ<T>(this T self) where T : Rigidbody =>
           self.constraints = RigidbodyConstraints.FreezeRotationZ;


        /// <summary> Call this method in update and give the Input.GetAxis for moving 3D character </summary>
        /// <param name="moveDirection">Set there player input</param>
        /// <param name="moveSpeed">Movement speed</param>
        /// <param name="YMouseAxis">Mouse Axis Y</param>
        /// <param name="XMouseAxis">Mouse Axis X</param>
        /// <param name="sensivity">Rotation speed</param>
        internal static void TransferControl3D<T>(this T self, Vector3 moveDirection, float moveSpeed, float YMouseAxis, float XMouseAxis, float sensivity) where T : Rigidbody
        {
            Vector3 movement = self.transform.TransformDirection(moveDirection) * moveSpeed;
            self.MoveTo(new Vector3(movement.x, self.velocity.y, movement.z), moveSpeed);
            self.MoveRotation(Quaternion.Euler(self.rotation.eulerAngles.x - YMouseAxis * sensivity, self.rotation.eulerAngles.y + XMouseAxis * sensivity, 0));
        }


        /// <summary> Call this method in update and give the Input.GetAxis for moving 3D character </summary>
        /// <param name="moveDirection">Set there player input</param>
        /// <param name="moveSpeed">Movement speed</param>
        /// <param name="rotation">Use mouse input to rotate the rigidbody</param>
        internal static void TransferControl3D<T>(this T self, Vector3 moveDirection, float moveSpeed, Quaternion rotation) where T : Rigidbody
        {
            Vector3 movement = self.transform.TransformDirection(moveDirection) * moveSpeed;
            self.MoveTo(new Vector3(movement.x, self.velocity.y, movement.z), moveSpeed);
            self.MoveRotation(rotation);
        }

        /// <summary>
        /// Uses the old input system!
        /// Controls the 3d movement of your character
        /// </summary>
        /// <param name="speed">Speed of movement</param>
        /// <param name="sensivity">Rotation speed</param>
        internal static void TransferControl3D<T>(this T self, float speed, float sensivity) where T : Rigidbody
        {
            Vector3 movementInput = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 movement = self.transform.TransformDirection(movementInput) * speed;
            self.MoveTo(new Vector3(movement.x, self.velocity.y, movement.z), speed);
            self.MoveRotation(Quaternion.Euler(self.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") * sensivity, self.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensivity, 0));
        }

        #endregion

        #region Rigidbody2D
        /// <summary>
        /// Make simulation of jump with given force
        /// </summary>
        /// <param name="force">Movement speed</param>
        internal static void Jump(this Rigidbody2D self, float force) =>
            self.AddForce(new Vector3(0, 200 + force));

        /// <summary>
        /// Moves Rigidbody to given direction with given speed
        /// </summary>
        /// <param name="direction"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveTo(this Rigidbody2D self, Vector3 direction, float speed) =>
            self.velocity = direction * speed;

        /// <summary>
        /// Moves Rigidbody to given position with given speed
        /// </summary>
        /// <param name="pos"> Position of moving to</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveTo(this Rigidbody2D self, Transform pos, float speed) =>
            self.velocity = Vector3.MoveTowards(self.position, pos.position, speed);

        /// <summary>
        /// Moves Rigidbody by x direction with given speed
        /// </summary>
        /// <param name="direction"> Direction of moving, use Input.GetAxis or similar metods</param>
        /// <param name="speed">Movement speed</param>
        internal static void MoveX(this Rigidbody2D self, float direction, float speed) =>
            self.velocity = new Vector3(direction * speed, self.velocity.y);

        ///<summary>
        ///Not a jump.
        ///Moves Rb up/down with a given speed
        ///</summary>
        internal static void MoveY(this Rigidbody2D self, float direction, float speed) =>
             self.velocity = new Vector3(self.velocity.x, direction * speed);

        /// <summary>
        /// Change parametr 'Freeze rotation z' of Rigidbody2D on oposite
        /// </summary>
        internal static void FreezeRotationChangeState(this Rigidbody2D self) =>
            self.freezeRotation = !self.freezeRotation;

        /// <summary>Freeze or unfreeze rigidbody`s rotation </summary>
        /// <param name="value">If true freezeing rotation</param>
        internal static void FreezeRotation(this Rigidbody2D self, bool value) =>
            self.freezeRotation = value;

        /// <summary>Moves rigidbody with inputs, uses old input system </summary>
        /// <param name="speed">Movement speed</param>
        /// <param name="force">Jump force</param>
        /// <param name="jumpKey">key that triggers a jump when pressed.</param>
        internal static void TransferControl2D(this Rigidbody2D self, float speed, float force, KeyCode jumpKey = KeyCode.None)
        {
            StackTrace stackTrace = new();
            StackFrame[] stackFrames = stackTrace.GetFrames();
            if (stackFrames.Length >= 2)
            {
                StackFrame callingFrame = stackFrames[1];
                MethodBase callingMethod = callingFrame.GetMethod();
                if (callingMethod.Name == nameof(FixedUpdate)) throw new TargetException("Method must called only from Update!");
            }
            var horizontal = Input.GetAxis("Horizontal") * speed * 100;
            self.velocity = new Vector2(horizontal * Time.deltaTime, self.velocity.y);
            if (jumpKey == KeyCode.None && Input.GetKeyDown(KeyCode.W)) self.Jump(force);
            else if (Input.GetKeyDown(jumpKey)) self.Jump(force);
        }

        #endregion
    }
}

