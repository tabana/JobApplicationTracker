namespace JobApplicationTracker.Mappers
{
    public static class StateMapping
    {
        public static Infrastructure.Persistence.State ToDto(this ViewModel.State state)
        {
            return new Infrastructure.Persistence.State
            {
                ApplicantId = state.ApplicantId,
                CreatedDateTime = state.CreatedDateTime.ToString(),
            };
        }

        public static ViewModel.State ToViewModel(this Infrastructure.Persistence.State state)
        {
            return new ViewModel.State
            {
                ApplicantId = state.ApplicantId,
                CreatedDateTime = DateTime.Parse(state.CreatedDateTime ?? DateTime.Now.ToString()),
            };
        }
    }
}
