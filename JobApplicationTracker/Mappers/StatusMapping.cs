namespace JobApplicationTracker.Mappers
{
    public static class StatusMapping
    {
        public static Infrastructure.Persistence.Status ToDto(this ViewModel.Status status)
        {
            return new Infrastructure.Persistence.Status
            {
                Id = status.Id,
                DisplayText = status.DisplayText,
            };
        }

        public static ViewModel.Status ToViewModel(this Infrastructure.Persistence.Status status)
        {
            return new ViewModel.Status
            {
                Id = status.Id,
                DisplayText = status.DisplayText,
            };
        }
    }
}
