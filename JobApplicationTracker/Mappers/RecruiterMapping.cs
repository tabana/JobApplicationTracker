namespace JobApplicationTracker.Mappers
{
    public static class RecruiterMapping
    {
        public static Infrastructure.Persistence.Recruiter ToDto(this ViewModel.Recruiter recruiter)
        {
            return new Infrastructure.Persistence.Recruiter
            {
                Id = recruiter.Id,
                Name = recruiter.Name,
                Agency = recruiter.Agency,
                EmailAddress = recruiter.EmailAddress,
                LinkedInUri = recruiter.LinkedInUri,
                PhoneNumber = recruiter.PhoneNumber,
            };
        }

        public static ViewModel.Recruiter ToViewModel(this Infrastructure.Persistence.Recruiter recruiter)
        {
            return new ViewModel.Recruiter
            {
                Id = recruiter.Id,
                Name = recruiter.Name,
                Agency = recruiter.Agency,
                EmailAddress = recruiter.EmailAddress,
                LinkedInUri = recruiter.LinkedInUri,
                PhoneNumber = recruiter.PhoneNumber,
            };
        }
    }
}
