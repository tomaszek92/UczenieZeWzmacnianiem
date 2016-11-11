namespace UczenieZeWzmacnianiem.WinForms
{
    public class ComboBoxItem
    {
        public int Value { get; private set; }
        public string Text { get; private set; }

        public ComboBoxItem(int value)
        {
            Value = value;
            Text = value.ToString();
        }
    }
}