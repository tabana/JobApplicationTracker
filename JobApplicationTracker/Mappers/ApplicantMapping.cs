namespace JobApplicationTracker.Mappers
{
    public static class ApplicantMapping
    {
        public static Infrastructure.Persistence.Applicant ToDto(this ViewModel.Applicant applicant)
        {
            return new Infrastructure.Persistence.Applicant
            {
                Id = applicant.Id,
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                LastName = applicant.LastName,
                EmailAddress = applicant.EmailAddress,
                LinkedInUri = applicant.LinkedInUri,
                JobApplications = (List<Infrastructure.Persistence.JobApplication>)applicant.JobApplications.Select(ja => ja.ToDto()),
            };
        }

        public static ViewModel.Applicant ToViewModel(this Infrastructure.Persistence.Applicant applicant)
        {
            var applicantViewModel = new ViewModel.Applicant
            {
                Id = applicant.Id,
                FirstName = applicant.FirstName,
                MiddleName = applicant.MiddleName,
                LastName = applicant.LastName,
                EmailAddress = applicant.EmailAddress,
                LinkedInUri = applicant.LinkedInUri,
            };

            applicantViewModel.JobApplications = applicant.JobApplications.Select(ja => ja.ToViewModel()).ToList();

            return applicantViewModel;
        }
    }
}
