namespace View
{
    class PageMetadata
    {
        public string Name { get; private set; }

        public object Icon { get; private set; }

        public PageMetadata(string name, object icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
