namespace UnityEngine.UI
{
    public sealed class TextFormater : MonoBehaviour
    {
        [SerializeField]
        private Text label;

        private string format { 
            get 
            {
                if (_format == null)
                    _format = label.text;
                return _format;
            }
        }

        private string _format;

        public void Format(int value) =>
            SetLabelText(string.Format(format, value));

        private void SetLabelText(string value) =>
            label.text = value;
    }
}