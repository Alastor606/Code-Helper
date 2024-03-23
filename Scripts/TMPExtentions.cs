namespace CodeHelper.Unity
{
    using TMPro;
    public static class TMPExtentions
    {
        public static bool IsEmpty<T>(this T self) where T : TextMeshProUGUI => self.text == null;
        public static bool IsEmpty(this TMP_InputField self) => self.text == null;
    }
}


