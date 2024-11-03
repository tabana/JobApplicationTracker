namespace JobApplicationTracker.Mappers
{
    public static class EmployerMapping
    {
        public static Infrastructure.Persistence.Employer ToDto(this ViewModel.Employer employer)
        {
            return new Infrastructure.Persistence.Employer
            {
                Id = employer.Id,
                DisplayText = employer?.DisplayText,
            };
        }

        public static ViewModel.Employer ToViewModel(this Infrastructure.Persistence.Employer employer)
        {
            return new ViewModel.Employer
            {
                Id = employer.Id,
                DisplayText = employer?.DisplayText,
            };
        }
    }
}
