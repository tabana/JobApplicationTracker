using SQLite;

namespace JobApplicationTracker.Infrastructure.Persistence
{
    public class LocalDbService
    {
        private readonly SQLiteAsyncConnection connection;

        public LocalDbService()
        {
            connection = new SQLiteAsyncConnection(Constants.DatabasePath);
            connection.CreateTableAsync<State>();
            connection.CreateTableAsync<JobApplication>();
            connection.CreateTableAsync<Applicant>();
        }

        public async Task<State> GetState()
        {
            var states = await connection.Table<State>().ToListAsync();
            var state = states.OrderByDescending(s => s.CreatedDateTime).FirstOrDefault();
            return state ?? default;
        }

        public async Task SetState(State state)
        {
            await connection.InsertAsync(state);
        }

        public async Task<List<Applicant>> GetApplicants()
        {
            var applicants = await connection.Table<Applicant>().ToListAsync();
            foreach (var applicant in applicants)
            {
                await GetJobApplicationsByApplicant(applicant);
            }

            return applicants;
        }

        public async Task<Applicant> GetApplicant(Guid? id)
        {
            var applicant = await connection.Table<Applicant>().Where(ja => ja.Id == id).FirstOrDefaultAsync();
            applicant.JobApplications = await GetJobApplicationsByApplicant(applicant);
            return applicant;
        }

        public async Task Create(Applicant applicant)
        {
            await connection.InsertAsync(applicant);
        }

        public async Task Update(Applicant applicant)
        {
            await connection.UpdateAsync(applicant);
        }

        public async Task Delete(Applicant applicant)
        {
            await connection.DeleteAsync(applicant);
        }

        public async Task<List<JobApplication>> GetJobApplicationsByApplicant(Applicant applicant)
        {
            var jobApplications = await connection.Table<JobApplication>().Where(ja => ja.ApplicantId == applicant.Id).ToListAsync();
            foreach (var jobApplication in jobApplications)
            {
                jobApplication.Applicant = applicant;
                jobApplication.Employer = await connection.Table<Employer>().FirstOrDefaultAsync(e => e.Id == jobApplication.EmployerId);
                jobApplication.Source = await connection.Table<Source>().FirstOrDefaultAsync(so => so.Id == jobApplication.SourceId);
                jobApplication.Recruiter = await connection.Table<Recruiter>().FirstOrDefaultAsync(e => e.Id == jobApplication.RecruiterId);
                jobApplication.Status = await connection.Table<Status>().FirstOrDefaultAsync(st => st.Id == jobApplication.StatusId);
            };
            return jobApplications;
        }

        public async Task Create(JobApplication jobApplication)
        {
            await connection.InsertAsync(jobApplication);
        }

        public async Task Update(JobApplication jobApplication)
        {
            await connection.UpdateAsync(jobApplication);
        }

        public async Task Delete(JobApplication jobApplication)
        {
            await connection.DeleteAsync(jobApplication);
        }
    }
}
