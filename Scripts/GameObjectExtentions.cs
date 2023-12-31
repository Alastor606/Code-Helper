using UnityEngine;

namespace CodeHelper.Unity
{
    public static class GameObjectExtentions
    {
        /// <returns>Transform forvard</returns>
        public static Vector3 Forvard(this GameObject self) => self.transform.forward;

        /// <returns>Transform up</returns>
        public static Vector3 Up(this GameObject self) => self.transform.up;

        /// <returns>Transform rotation</returns>
        public static Quaternion Rotation(this GameObject self) => self.transform.rotation;

        /// <summary>Get the rigidbody in given game object if hasn`t returns the added component of rigidbody</summary>
        /// <returns>rigidbody component</returns>
        public static Rigidbody Rigidbody(this GameObject self)
        {
            if (self.TryGetComponent(out Rigidbody comp)) return comp;
            else return self.AddComponent<Rigidbody>();
        }

        /// <summary>Get the rigidbody2D in given game object if hasn`t returns the added component of rigidbody</summary>
        /// <returns>rigidbody component</returns>
        public static Rigidbody2D Rigidbody2D(this GameObject self)
        {
            if (self.TryGetComponent(out Rigidbody2D component)) return component;
            else return self.AddComponent<Rigidbody2D>();
        }

        /// <summary>Change sprite rendere color </summary>
        /// <param name="color">Given color to change</param>
        public static void ChangeColor2D(this GameObject self, Color color) => self.GetComponent<SpriteRenderer>().color = color;

        /// <summary>Change sprite rendere color </summary>
        /// <param name="color">Given color to change</param>
        public static void ChangeColor2D(this GameObject self, float r, float g, float b, float a = 1) => self.GetComponent<SpriteRenderer>().color = new Color(r, g, b, a);

        /// <summary>Change color of material in current object </summary>
        /// <param name="color"></param>
        public static void ChangeColor3D(this GameObject self, Color color) => self.GetComponent<Renderer>().material.color = color;

        /// <summary>Changing Color of material in current object </summary>
        /// <param name="a">Muse be value between 0, 1</param>
        public static void ChangeColor3D(this GameObject self, float r, float g, float b, float a = 1) => self.GetComponent<Renderer>().material.color = new Color(r, g, b, a);

        /// <returns>Parent GameObject</returns>
        public static GameObject GetParent(this GameObject self) => self.transform.parent.gameObject;

        /// <summary> Reverse the active self</summary>
        public static void ReverseActive(this GameObject self) => self.SetActive(!self.activeSelf);
    }

}
