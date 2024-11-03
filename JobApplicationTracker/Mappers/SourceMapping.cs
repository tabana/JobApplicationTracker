namespace JobApplicationTracker.Mappers
{
    public static class SourceMapping
    {
        public static Infrastructure.Persistence.Source ToDto(this ViewModel.Source source)
        {
            return new Infrastructure.Persistence.Source
            {
                Id = source.Id,
                DisplayText = source.DisplayText,
                Uri = source.Uri,
            };
        }

        public static ViewModel.Source ToViewModel(this Infrastructure.Persistence.Source source)
        {
            return new ViewModel.Source
            {
                Id = source.Id,
                DisplayText = source.DisplayText,
                Uri = source.Uri,
            };
        }
    }
}
