namespace JobApplicationTracker.Mappers
{
    public static class JobApplicationMapping
    {
        public static Infrastructure.Persistence.JobApplication ToDto(this ViewModel.JobApplication jobApplication)
        {
            return new Infrastructure.Persistence.JobApplication
            {
                Id = jobApplication.Id,
                ApplicantId = jobApplication.ApplicantId,
                EmployerId = jobApplication.EmployerId,
                SourceId = jobApplication.SourceId,
                RecruiterId = jobApplication.RecruiterId,
                StatusId = jobApplication.StatusId,
                JobIdentifier = jobApplication.JobIdentifier,
                ResumePath = jobApplication.ResumePath,
                Notes = jobApplication.Notes,
                Employer = jobApplication.Employer.ToDto(),
                Source = jobApplication.Source.ToDto(),
                Recruiter = jobApplication.Recruiter.ToDto(),
                Status = jobApplication.Status.ToDto(),
            };
        }

        public static ViewModel.JobApplication ToViewModel(this Infrastructure.Persistence.JobApplication jobApplication)
        {
            return new ViewModel.JobApplication
            {
                Id = jobApplication.Id,
                ApplicantId = jobApplication.ApplicantId,
                EmployerId = jobApplication.EmployerId,
                SourceId = jobApplication.SourceId,
                RecruiterId = jobApplication.RecruiterId,
                StatusId = jobApplication.StatusId,
                JobIdentifier = jobApplication.JobIdentifier,
                ResumePath = jobApplication.ResumePath,
                Notes = jobApplication.Notes,
                Employer = jobApplication.Employer.ToViewModel(),
                Source = jobApplication.Source.ToViewModel(),
                Recruiter = jobApplication.Recruiter.ToViewModel(),
                Status = jobApplication.Status.ToViewModel(),
            };
        }
    }
}
